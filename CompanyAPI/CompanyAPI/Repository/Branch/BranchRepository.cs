using CompanyAPI.Data;
using CompanyAPI.Services.Exceptions;
using CompanyAPI.ViewModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace CompanyAPI.Repository.Branch
{
    public class BranchRepository : IBranchRepository
    {
        private readonly AppDbContext _context;

        public BranchRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddBranchAsync(BranchModel branch)
        {
            if (!await CheckCompanyExistByIdAsync(branch.CompanyID))
            {
                throw new NotFoundException("Id of the company not found");
            }
            var companyLinked = await _context.Company.FindAsync(branch.CompanyID);

            if (companyLinked != null)
            {
                branch.CompanyLinked = companyLinked;
                companyLinked.Branch.Add(branch);
            }


            await _context.Branchs.AddAsync(branch);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateBranchAsync(BranchModel branch)
        {
            
            if (!await CheckCompanyExistByIdAsync(branch.CompanyID))
            {
                throw new NotFoundException("Id of the company not found");
            }

            
            if (branch.CompanyLinked == null)
            {
                throw new InvalidOperationException("CompanyLinked property cannot be null");
            }

          
            bool companyIsSimilar = branch.CompanyID == branch.CompanyLinked.Id;

            if (!companyIsSimilar)
            {
             
                var currentCompany = await _context.Company.FindAsync(branch.CompanyLinked.Id);
                if (currentCompany == null)
                {
                    throw new NotFoundException("Current linked company not found");
                }

                
                currentCompany.Branch.Remove(branch);

                
                branch.CompanyLinked = await _context.Company.FindAsync(branch.CompanyID);
                if (branch.CompanyLinked == null)
                {
                    throw new NotFoundException("New linked company not found");
                }
            }

           
            _context.Branchs.Update(branch);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteBranchAsync(BranchModel branch)
        {
            _context.Branchs.Remove(branch);
            await _context.SaveChangesAsync();
        }

        public async Task<List<BranchModel>> GetAllBranchesAsync()
        {
            return await _context.Branchs.ToListAsync();
        }

        public async Task<BranchModel> GetBranchByIdAsync(int branchId)
        {
            return await _context.Branchs.FindAsync(branchId);
        }

        public async Task<BranchModel> GetBranchByHeadOfficeAsync(string branchName)
        {
            return await _context.Branchs.FirstOrDefaultAsync(b => b.HeadOffice == branchName);
        }

        public async Task<List<BranchModel>> GetBranchesInCompanyAsync(int companyId)
        {
            return await _context.Branchs.Where(b => b.CompanyID == companyId).ToListAsync();
        }

        public async Task<bool> CheckBranchExistByHeadOfficeAsync(string name)
        {
            return await _context.Branchs.AnyAsync(b => b.HeadOffice == name);
        }

        public async Task<bool> CheckBranchExistByIdAsync(int branchId)
        {
            return await _context.Branchs.AnyAsync(b => b.Id == branchId);
        }

        public async Task<BranchModel> GetAllDetailsAboutBranchAsync(int branchId)
        {
            return await _context.Branchs
                .Include(b => b.CompanyLinked)
                .Include(b => b.Areas)
                .Include(b => b.Employees)
                .Include(b => b.Equipments)
                .FirstOrDefaultAsync(b => b.Id == branchId);
        }

        public async Task<bool> CheckCompanyExistByIdAsync(int companyId)
        {
            return await _context.Company.AnyAsync(c => c.Id == companyId);
        }

        public async Task<List<BranchModel>> GetAllEmployeesInBranch(int branchId)
        {
            return await _context.Branchs
                .Include(b => b.Employees)
                .Where(b => b.Id == branchId)
                .ToListAsync();
        }

        public async Task<List<BranchModel>> GetAllAreasInBranch(int branchId)
        {
            return await _context.Branchs
                .Include(b => b.Areas)
                .Where(b => b.Id == branchId)
                .ToListAsync();
        }

        public async Task<List<BranchModel>> GetAllEquipmentsInBranch(int branchId)
        {
            return await _context.Branchs
                .Include(b => b.Equipments)
                .Where(b => b.Id == branchId)
                .ToListAsync();
        }
    }
}
