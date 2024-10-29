using CompanyAPI.Data;
using CompanyAPI.ViewModel;

namespace CompanyAPI.Repository
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly AppDbContext _context;

        public CompanyRepository(AppDbContext context)
        {
            _context = context;
        }

        public Task AddCompanyAsync(CompanyModel company)
        {
            throw new NotImplementedException();
        }

        public Task DeleteCompanyAsync(CompanyModel company)
        {
            throw new NotImplementedException();
        }

        public Task<List<CompanyModel>> GetAllCompaniesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<CompanyModel>> GetbranchsInCompanyAsync(int companyId)
        {
            throw new NotImplementedException();
        }

        public Task<CompanyModel> GetCompanyByIdAsync(int companyId)
        {
            throw new NotImplementedException();
        }

        public Task<CompanyModel> GetCompanyByNameAsync(string companyName)
        {
            throw new NotImplementedException();
        }

        public Task UpdateCompanyAsync(CompanyModel company)
        {
            throw new NotImplementedException();
        }
    }
}
