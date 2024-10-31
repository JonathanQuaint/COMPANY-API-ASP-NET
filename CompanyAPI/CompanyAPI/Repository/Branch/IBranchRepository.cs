using CompanyAPI.ViewModel;

namespace CompanyAPI.Repository.Branch
{
    public interface IBranchRepository
    {
        Task AddBranchAsync(BranchModel branch);
        Task UpdateBranchAsync(BranchModel branch);
        Task DeleteBranchAsync(BranchModel branch);
        Task<List<BranchModel>> GetAllBranchesAsync();
        Task<BranchModel> GetBranchByIdAsync(int branchId);
        Task<BranchModel> GetBranchByHeadOfficeAsync(string brancHeadOffice);
        Task<List<BranchModel>> GetBranchesInCompanyAsync(int companyId);
        Task<bool> CheckBranchExistByHeadOfficeAsync(string branchHeadOffice);
        Task<bool> CheckBranchExistByIdAsync(int branchId);
        Task<BranchModel> GetAllDetailsAboutBranchAsync(int branchId);
        Task<double> CalculateAllExpenseInBranch(int branchId);

    }
}
