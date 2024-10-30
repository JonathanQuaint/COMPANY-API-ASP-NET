using CompanyAPI.Data;
using CompanyAPI.Dto.AreaDTOS;
using CompanyAPI.ViewModel;

namespace CompanyAPI.Services.Area
{
    public class AreaService : IAreaInterface
    {
        private readonly AppDbContext _context;

        public Task<ResponseModel<List<AreaModel>>> CreateArea(CreateAreaDto areaDto)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<AreaModel>> InformationsAboutArea(int areaId)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<List<AreaModel>>> UpdateArea(EditAreaDto areaDto)
        {
            throw new NotImplementedException();
        }

        
    }
}
