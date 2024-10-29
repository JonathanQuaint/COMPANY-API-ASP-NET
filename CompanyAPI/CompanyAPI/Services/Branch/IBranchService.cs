using CompanyAPI.Dto.BranchDTOS;
using CompanyAPI.ViewModel;

namespace CompanyAPI.Services.Branch
{
    public interface IBranchService
    {
        Task<ResponseModel<List<BranchModel>>> CreateFilial(CreateBranchDto branchDto);
        Task<ResponseModel<List<BranchModel>>> UpdateFilial(EditBranchDto branchDto);
        Task<ResponseModel<BranchModel>> InformationsAboutBranch(int branchId);


    }
}
