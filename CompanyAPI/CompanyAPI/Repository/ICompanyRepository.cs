using CompanyAPI.ViewModel;

namespace CompanyAPI.Repository
{
    public interface ICompanyRepository
    {
      
        Task AddCompanyAsync(CompanyModel company);
        Task UpdateCompanyAsync(CompanyModel company);
        Task DeleteCompanyAsync(CompanyModel company);
        Task<List<CompanyModel>> GetbranchsInCompanyAsync(int companyId);
        Task<List<CompanyModel>> GetAllCompaniesAsync();
        Task<CompanyModel> GetCompanyByIdAsync(int companyId);
        Task<CompanyModel> GetCompanyByNameAsync(string companyName);



    }
}
