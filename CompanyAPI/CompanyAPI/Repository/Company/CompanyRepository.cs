using CompanyAPI.Data;
using CompanyAPI.Services.Exceptions;
using CompanyAPI.ViewModel;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.Design;

namespace CompanyAPI.Repository.Company
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly AppDbContext _context;


        public CompanyRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddCompanyAsync(CompanyModel company)
        {
            _context.Company.Add(company);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCompanyAsync(CompanyModel company)
        {
            _context.Company.Remove(company);
            await _context.SaveChangesAsync();
        }

        public async Task<List<CompanyModel>> GetAllCompaniesAsync()
        {
            return await _context.Company.ToListAsync();
        }

        public async Task<List<CompanyModel>> GetbranchsInCompanyAsync(int companyId)
        {
            bool branchsExist = await _context.Branchs.AnyAsync(x => x.CompanyID == companyId);

            if (!branchsExist)
            {
                throw new NotFoundException("This company has no affiliates");
            }


            return await _context.Company
                .Include(c => c.Branch)
                .Where(c => c.Id == companyId)
                .ToListAsync();
        }

        public async Task<CompanyModel> GetCompanyByIdAsync(int companyId)
        {
            return await _context.Company
                .Include(c => c.Branch)
                .FirstOrDefaultAsync(c => c.Id == companyId);
        }

        public async Task<CompanyModel> GetCompanyByNameAsync(string companyName)
        {
            return await _context.Company
                .Include(c => c.Branch)
                .FirstOrDefaultAsync(c => c.Name == companyName);
        }

        public async Task UpdateCompanyAsync(CompanyModel company)
        {
            _context.Company.Update(company);
            await _context.SaveChangesAsync();
        }

        public async Task<List<CompanyModel>> GetCompaniesWithBranchesAsync()
        {
            return await _context.Company
                .Include(c => c.Branch)
                .ToListAsync();
        }

        public async Task<bool> CheckCompanyExistByNameAsync(string name)
        {
            bool companyExist = await _context.Company.AnyAsync(x => x.Name == name);

            if (!companyExist)
            {
                throw new NotFoundException("Company not found");
            }

            return companyExist;

        }

        public async Task<bool> CheckCompanyExistByIdAsync(int companyId)
        {
            bool companyExist = await _context.Company.AnyAsync(x => x.Id == companyId);

            if (!companyExist)
            {
                throw new NotFoundException("Company not found");
            }

            return companyExist;
        }

        public async Task<CompanyModel> GetAllDetailsAboutCompanyAsync(int companyId)
        {
            return await _context.Company
                .Include(x => x.Expense)
                .Include(x => x.Branch)
                .FirstOrDefaultAsync(x => x.Id == companyId);
        }

        public async Task<List<AreaModel>> GetAllAreasInCompanyAsync(int companyId)
        {
            return await _context.Branchs
                .Where(b => b.CompanyID == companyId)
                .SelectMany(b => b.Areas)
                .ToListAsync();




        }

        public async Task<List<EquipmentModel>> GetAllEquipmentsInCompanyAsync(int companyId)
        {


            return await _context.Branchs
                .Where(c => c.Id == companyId)
                .SelectMany(c => c.Equipments)
                .ToListAsync();
        }

        public async Task<List<EmployeeModel>> GetAllEmployeesInCompanyAsync(int companyId)
        {


            return await _context.Branchs
                .Where(c => c.Id == companyId)
                .SelectMany(c => c.Employees)
                .ToListAsync();
        }

        public async Task<List<IGrouping<BranchModel, AreaModel>>> GetAllInCompanyAsync(int companyId)
        {
            return await _context.Branchs
                .Where(b => b.CompanyID == companyId)
                .Include(b => b.Areas)
                .Include(b => b.Employees)
                .Include(b => b.Equipments)
                .SelectMany(b => b.Areas.Select(a => new { Branch = b, Area = a }))
                .GroupBy(x => x.Branch, x => x.Area)
                .ToListAsync();
        }
        public async Task<double> CalculateAllExpensesInCompanyAsync(int companyId)
        {
            var totalExpenseInAllBranch = await _context.Branchs
                .Where(a => a.CompanyID == companyId)
                .SelectMany(a => a.Areas)
                .SumAsync(a => a.Expense);



            var company = await _context.Company.FindAsync(companyId);

            if (company != null)
            {
                // Update the Expense property
                company.Expense = totalExpenseInAllBranch;

                // Save the changes to the database
                _context.Company.Update(company);
                await _context.SaveChangesAsync();
            }

            return totalExpenseInAllBranch;
        }
    }

}


