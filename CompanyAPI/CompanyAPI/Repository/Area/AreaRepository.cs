using CompanyAPI.Data;
using CompanyAPI.Services.Exceptions;
using CompanyAPI.ViewModel;
using Microsoft.CodeAnalysis.Elfie.Serialization;
using Microsoft.CodeAnalysis.Operations;
using Microsoft.EntityFrameworkCore;

namespace CompanyAPI.Repository.Area
{
    public class AreaRepository : IAreaRepository
    {
        private readonly AppDbContext _context;

        public AreaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAreaAsync(AreaModel area)
        {
            var branchLinked = await _context.Branchs.FindAsync(area.BranchId);
            if (branchLinked == null)
            {
                throw new NotFoundException("Id of the branch not found");
            }

            area.LinkedBranch = branchLinked;
            branchLinked.Areas.Add(area);

            await _context.Areas.AddAsync(area);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAreaAsync(AreaModel area)
        {
            bool branchExist = await _context.Branchs.AnyAsync(c => c.Id == area.BranchId);

            if (!branchExist)
            {
                throw new NotFoundException("branch not found by Id");
            }

            if (area.LinkedBranch == null)
            {
                throw new InvalidOperationException("LinkedBranch property cannot be null");
            }

            bool branchIsSimilar = area.BranchId == area.LinkedBranch.Id;

            if (!branchIsSimilar)
            {
                var currentBranch = await _context.Branchs.FindAsync(area.LinkedBranch.Id);
                if (currentBranch == null)
                {
                    throw new NotFoundException("Current linked branch not found");
                }

                currentBranch.Areas.Remove(area);

                area.LinkedBranch = await _context.Branchs.FindAsync(area.BranchId);
                if (area.LinkedBranch == null)
                {
                    throw new NotFoundException("New linked branch not found");
                }
            }

            _context.Areas.Update(area);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAreaAsync(AreaModel area)
        {
            _context.Areas.Remove(area);
            await _context.SaveChangesAsync();
        }

        public async Task<List<AreaModel>> GetAllAreasAsync()
        {
            return await _context.Areas.ToListAsync();
        }

        public async Task<double> GetExpenseInAreaAsync(int areaId)
        {

            var area = await _context.Areas.FindAsync(areaId);

            if (area == null)
            {
                throw new NotFoundException("Area not found");
            }


            var TotalCosts = area.EquipmentsExpense + area.EmployeesExpense;


            area.Expense = TotalCosts;

            return TotalCosts;


        }

        public async Task<AreaModel> GetAreaByIdAsync(int areaId)
        {
            return await _context.Areas.FirstOrDefaultAsync(e => e.Id == areaId);
        }


        public async Task<List<AreaModel>> GetAreasInBranchAsync(int branchId)
        {

            bool branchExist = await _context.Branchs.AnyAsync(c => c.Id == branchId);

            if (!branchExist)
            {
                throw new NotFoundException("branch not found by Id");
            }

            return await _context.Areas.Where(a => a.BranchId == branchId).ToListAsync();
        }


        public async Task<List<AreaModel>> GetAreasInCompanyAsync(int companyId)
        {
            bool companyExist = await _context.Company.AnyAsync(x => x.Id == companyId);

            if (!companyExist)
            {
                throw new NotFoundException("Company not found by Id");
            }

            return await _context.Branchs
                .Where(b => b.CompanyID == companyId)
                .SelectMany(b => b.Areas)
                .ToListAsync();
        }


        public async Task<AreaModel> GetAllDetailsAboutAreaAsync(int areaId)
        {
            bool areaExist = await _context.Areas.AnyAsync(a => a.Id == areaId);

            if (!areaExist)
            {
                throw new NotFoundException("Area not found");
            }

            return await _context.Areas
                .Include(a => a.Employees)
                .Include(a => a.Equipments)
                .FirstOrDefaultAsync(a => a.Id == areaId);
        }

     


    }
}
