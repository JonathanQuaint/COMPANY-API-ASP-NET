using CompanyAPI.Dto.AreaDTOS;
using CompanyAPI.ViewModel;

namespace CompanyAPI.Services.Area
{
    public interface IAreaInterface
    {
        Task<ResponseModel<List<AreaModel>>> CreateArea(CreateAreaDto areaDto);
        Task<ResponseModel<List<AreaModel>>> UpdateArea(EditAreaDto areaDto);
        Task<ResponseModel<AreaModel>> InformationsAboutArea(int areaId);
        Task<ResponseModel<List<AreaModel>>> ListAllAreas();
        Task<ResponseModel<List<AreaModel>>> DeleteArea(int areaId);
        Task<ResponseModel<List<AreaModel>>> GetAreasInBranch(int branchId);
        Task<ResponseModel<double>> GetExpenseInArea(int areaId);
    }
}
