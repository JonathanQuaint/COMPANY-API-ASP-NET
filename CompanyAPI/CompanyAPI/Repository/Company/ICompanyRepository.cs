﻿using CompanyAPI.ViewModel;

namespace CompanyAPI.Repository.Company
{
    public interface ICompanyRepository
    {
        Task AddCompanyAsync(CompanyModel company);
        Task UpdateCompanyAsync(CompanyModel company);
        Task DeleteCompanyAsync(CompanyModel company);
        Task<List<CompanyModel>> GetAllCompaniesAsync(); 
        Task<CompanyModel?> GetCompanyByIdAsync(int companyId);
        Task<CompanyModel?> GetCompanyByNameAsync(string companyName); 
        Task<List<CompanyModel>> GetCompaniesWithBranchesAsync(); 
        Task<bool> CheckCompanyExistByNameAsync(string name); 
        Task<bool> CheckCompanyExistByIdAsync(int companyId);
        Task<CompanyModel?> GetAllDetailsAboutCompanyAsync(int companyId);
        Task<List<IGrouping<BranchModel, AreaModel>>> GetAllInCompanyAsync(int companyId);
        Task<double> CalculateAllExpensesInCompanyAsync(int companyId);
    }
}
