using CompanyAPI.Dto.CompanyDTOS;
using CompanyAPI.ViewModel;

namespace CompanyAPI.Services.Company
{
    public interface ICompanyInterface
    {
        Task<ResponseModel<List<CompanyModel>>> CreateCompany(CreateCompanyDTO companyDto);

        Task<ResponseModel<List<CompanyModel>>> UpdateCompany(EditCompanyDTOS companyInfos);

        Task<ResponseModel<CompanyModel>> InformationsAboutTheCompany(int companyId);

        Task<ResponseModel<double>> ExpenseInCompany(int companyId);

        Task<ResponseModel<List<IGrouping<BranchModel, AreaModel>>>> ListAllInCompany(int companyId);

        Task<ResponseModel<bool>> DeleteCompany(int companyId);

    }
}
