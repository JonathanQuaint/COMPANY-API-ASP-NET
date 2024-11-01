using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CompanyAPI.Data;
using CompanyAPI.Services.Exceptions;
using CompanyAPI.ViewModel;

namespace CompanyAPI.Repository.Equipment
{
    public class EquipmentRepository : IEquipmentRepository
    {
        private readonly AppDbContext _context;

        public EquipmentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddEquipmentAsync(EquipmentModel equipment)
        {
            if (!await CheckAreaExistByIdAsync(equipment.AreaId))
            {
                throw new NotFoundException("Id of the area not found");
            }
            var areaLinked = await _context.Areas.FindAsync(equipment.AreaId);

            if (areaLinked != null)
            {
                equipment.AreaLinked = areaLinked;
                areaLinked.Equipments.Add(equipment);
                areaLinked.LinkedBranch.Equipments.Add(equipment);
                areaLinked.Expense += equipment.Price;
            }

            await _context.Equipments.AddAsync(equipment);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateEquipmentAsync(EquipmentModel equipment)
        {
            var equipmentExist = await _context.Equipments.FindAsync(equipment.Id);

            if (equipmentExist == null)
            {
                throw new NotFoundException("Equipment not found");
            }

            if (equipmentExist.AreaId != equipment.AreaId)
            {
                var newArea = await _context.Areas.Include(x => x.LinkedBranch).FirstOrDefaultAsync(a => a.Id == equipment.AreaLinked.Id);

                if (newArea == null)
                {
                    throw new NotFoundException("Current linked area not found");
                }

                equipmentExist.AreaLinked.Equipments.Remove(equipmentExist);
                equipmentExist.AreaLinked.LinkedBranch.Equipments.Remove(equipmentExist);

                newArea.Equipments.Add(equipmentExist);
                newArea.LinkedBranch.Equipments.Add(equipmentExist);

                equipmentExist.AreaLinked = newArea;
                equipmentExist.AreaId = newArea.Id;
            }

            _context.Equipments.Update(equipmentExist);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteEquipmentAsync(EquipmentModel equipment)
        {
            var equipmentExist = await _context.Equipments.Include(e => e.AreaLinked).ThenInclude(e => e.LinkedBranch).FirstOrDefaultAsync(e => e.Id == equipment.Id);

            if (equipmentExist == null)
            {
                throw new NotFoundException("Equipment not found");
            }

            equipmentExist.AreaLinked.Expense -= equipmentExist.Price;
            equipmentExist.AreaLinked.LinkedBranch.Expense -= equipmentExist.Price;

            _context.Equipments.Remove(equipmentExist);
            await _context.SaveChangesAsync();
        }

        public async Task<List<EquipmentModel>> GetAllEquipmentsAsync()
        {
            return await _context.Equipments.ToListAsync();
        }

        public async Task<EquipmentModel?> GetEquipmentByIdAsync(int equipmentId)
        {
            return await _context.Equipments.FindAsync(equipmentId);
        }

        public async Task<List<EquipmentModel>> GetEquipmentsInAreaAsync(int areaId)
        {
            return await _context.Equipments.Where(e => e.AreaId == areaId).ToListAsync();
        }

        public async Task<List<EquipmentModel>> GetAllEquipmentsInBranch(int branchId)
        {
            return await _context.Areas
                .Where(x => x.BranchId == branchId)
                .SelectMany(a => a.Equipments)
                .ToListAsync();
        }

        public async Task<List<EquipmentModel>> GetAllEquipmentsInCompany(int Company)
        {
            return await _context.Branchs
                .Where(x => x.CompanyID == Company)
                .SelectMany(a => a.Equipments)
                .ToListAsync();
        }

        public async Task<EquipmentModel?> GetAllDetailsAboutEquipmentAsync(int equipmentId)
        {
            return await _context.Equipments
                .Include(e => e.Id)
                .Include(e => e.Name)
                .Include(e => e.AreaId)
                .Include(e => e.AreaLinked)
                .Include(e => e.Price)
                .FirstOrDefaultAsync(e => e.Id == equipmentId);
        }

        public async Task<bool> CheckEquipmentExistByIdAsync(int equipmentId)
        {
            return await _context.Equipments.AnyAsync(e => e.Id == equipmentId);
        }

        public async Task<bool> CheckAreaExistByIdAsync(int areaId)
        {
            return await _context.Areas.AnyAsync(a => a.Id == areaId);
        }
    }
}
