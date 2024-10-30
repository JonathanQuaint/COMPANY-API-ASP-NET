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
            }

            await _context.Equipments.AddAsync(equipment);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateEquipmentAsync(EquipmentModel equipment)
        {
            if (!await CheckAreaExistByIdAsync(equipment.AreaId))
            {
                throw new NotFoundException("Id of the area not found");
            }

            if (equipment.AreaLinked == null)
            {
                throw new InvalidOperationException("AreaLinked property cannot be null");
            }

            bool areaIsSimilar = equipment.AreaId == equipment.AreaLinked.Id;

            if (!areaIsSimilar)
            {
                var currentArea = await _context.Areas.FindAsync(equipment.AreaLinked.Id);
                if (currentArea == null)
                {
                    throw new NotFoundException("Current linked area not found");
                }

                currentArea.Equipments.Remove(equipment);

                equipment.AreaLinked = await _context.Areas.FindAsync(equipment.AreaId);
                if (equipment.AreaLinked == null)
                {
                    throw new NotFoundException("New linked area not found");
                }
            }

            _context.Equipments.Update(equipment);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteEquipmentAsync(EquipmentModel equipment)
        {
            _context.Equipments.Remove(equipment);
            await _context.SaveChangesAsync();
        }

        public async Task<List<EquipmentModel>> GetAllEquipmentsAsync()
        {
            return await _context.Equipments.ToListAsync();
        }

        public async Task<EquipmentModel> GetEquipmentByIdAsync(int equipmentId)
        {
            return await _context.Equipments.FindAsync(equipmentId);
        }

        public async Task<List<EquipmentModel>> GetEquipmentsInAreaAsync(int areaId)
        {
            return await _context.Equipments.Where(e => e.AreaId == areaId).ToListAsync();
        }

        public async Task<bool> CheckEquipmentExistByIdAsync(int equipmentId)
        {
            return await _context.Equipments.AnyAsync(e => e.Id == equipmentId);
        }

        public async Task<EquipmentModel> GetAllDetailsAboutEquipmentAsync(int equipmentId)
        {
            return await _context.Equipments
                .Include(e => e.AreaLinked)
                .FirstOrDefaultAsync(e => e.Id == equipmentId);
        }

        public async Task<bool> CheckAreaExistByIdAsync(int areaId)
        {
            return await _context.Areas.AnyAsync(a => a.Id == areaId);
        }
    }
}
