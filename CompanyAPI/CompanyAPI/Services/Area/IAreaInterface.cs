using CompanyAPI.Dto.AreaDTOS;
using CompanyAPI.ViewModel;

namespace CompanyAPI.Services.Area
{
    public interface IAreaInterface
    {

        public Task<ResponseModel<List<AreaModel>>> CreateArea(CreateAreaDto areaDto);
        public Task<ResponseModel<List<AreaModel>>> UpdateArea(EditAreaDto areaDto);
        public Task<ResponseModel<AreaModel>> InformationsAboutArea(int areaId);

    }
}
