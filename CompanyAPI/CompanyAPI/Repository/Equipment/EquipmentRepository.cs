using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CompanyAPI.Data;
using CompanyAPI.Services.Exceptions;
using CompanyAPI.ViewModel;
using Microsoft.CodeAnalysis.Operations;
using Microsoft.CodeAnalysis.Elfie.Serialization;

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
            if (equipment == null)
            {
                throw new ArgumentNullException(nameof(equipment), "Equipment cannot be null");
            }


            bool areaExist = await _context.Areas.AnyAsync(c => c.Id == equipment.AreaId);

            if (!areaExist)
            {
                throw new NotFoundException("Area not found by Id");
            }

            var areaLinked = await _context.Areas
                .Include(a => a.LinkedBranch)
                .ThenInclude(b => b.Equipments)
                .FirstOrDefaultAsync(a => a.Id == equipment.AreaId);


            if (areaLinked == null)
            {
                throw new NotFoundException("Area not found");
            }

            if (areaLinked.LinkedBranch == null)
            {
                throw new NotFoundException("Linked branch not found");
            }


            var branchLinked = areaLinked.LinkedBranch;


            if (areaLinked.Equipments == null)
            {
                areaLinked.Equipments = new List<EquipmentModel>();
            }

            if (branchLinked.Equipments == null)
            {
                areaLinked.LinkedBranch.Equipments = new List<EquipmentModel>();
            }


            areaLinked.EquipmentsExpense += equipment.Price;
            areaLinked.Expense += equipment.Price;
            branchLinked.EquipmentsExpense += equipment.Price;
            branchLinked.Expense += equipment.Price;
            equipment.AreaLinked = areaLinked;
            areaLinked.Equipments.Add(equipment);
            branchLinked.Equipments.Add(equipment);

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


                //Calculate the price diference between the old and the new price 
                double priceDiference = equipmentExist.Price - equipment.Price;

                equipmentExist.Name = equipment.Name;
                equipmentExist.Price = equipment.Price;
                equipmentExist.AreaId = equipment.AreaId;

                var area = equipment.AreaLinked;
                var branch = equipment.AreaLinked.LinkedBranch;

                area.EquipmentsExpense += priceDiference;
                branch.EquipmentsExpense += priceDiference;
                area.Expense += priceDiference;
                branch.Expense += priceDiference;

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
            if (equipment == null)
            {
                throw new ArgumentNullException(nameof(equipment), "Equipment cannot be null");
            }

            var equipmentExist = await _context.Equipments
                .Include(e => e.AreaLinked)
                .ThenInclude(a => a.LinkedBranch)
                .FirstOrDefaultAsync(e => e.Id == equipment.Id);

            if (equipmentExist == null)
            {
                throw new NotFoundException("Equipment not found");
            }

            // Update expenses
            var area = equipmentExist.AreaLinked;
            var branch = area.LinkedBranch;

            area.Expense -= equipmentExist.Price;
            area.EquipmentsExpense -= equipmentExist.Price;
            branch.Expense -= equipmentExist.Price;
            branch.EquipmentsExpense -= equipmentExist.Price;

            // Remove equipment
            _context.Equipments.Remove(equipmentExist);

            // Save changes
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
            bool areaExist = await _context.Areas.AnyAsync(c => c.Id == areaId);

            if (!areaExist)
            {
                throw new NotFoundException("Area not found by Id");
            }

            return await _context.Equipments.Where(e => e.AreaId == areaId).ToListAsync();
        }

        public async Task<List<EquipmentModel>> GetAllEquipmentsInBranchAsync(int branchId)
        {
            bool branchExist = await _context.Branchs.AnyAsync(c => c.Id == branchId);

            if (!branchExist)
            {
                throw new NotFoundException("Branch not found by Id");
            }

            return await _context.Areas
                .Where(x => x.BranchId == branchId)
                .SelectMany(a => a.Equipments)
                .ToListAsync();
        }

        public async Task<List<EquipmentModel>> GetAllEquipmentsInCompanyAsync(int companyId)
        {
            bool companyExist = await _context.Company.AnyAsync(c => c.Id == companyId);

            if (!companyExist)
            {
                throw new NotFoundException("Company not found by Id");
            }

            return await _context.Branchs
                .Where(x => x.CompanyID == companyId)
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

    }
}
