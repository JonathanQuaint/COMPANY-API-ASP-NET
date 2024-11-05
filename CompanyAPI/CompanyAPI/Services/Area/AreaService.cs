using CompanyAPI.Data;
using CompanyAPI.Dto.AreaDTOS;
using CompanyAPI.Repository.Area;
using CompanyAPI.Services.Exceptions;
using CompanyAPI.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace CompanyAPI.Services.Area
{
    public class AreaService : IAreaInterface
    {
        private readonly IAreaRepository _areaRepository;

        public AreaService(IAreaRepository areaRepository)
        {
            _areaRepository = areaRepository;
        }

        public async Task<ResponseModel<List<AreaModel>>> CreateArea(CreateAreaDto areaDto)
        {
            ResponseModel<List<AreaModel>> reply = new();

            try
            {

                var area = new AreaModel
                {
                    NameArea = areaDto.NameArea,
                    BranchId = areaDto.BranchLinkedId,
                    Description = areaDto.Description,
                    CreationDate = areaDto.CreationDate

                };

                await _areaRepository.AddAreaAsync(area);

                reply.Dados = await _areaRepository.GetAllAreasAsync();
                reply.Mensagem = "Area successfully created";

                return reply;
            }
            catch (DbUpdateException ex)
            {
                throw new DbUpdateException($"Error creating area: {ex.Message}");
            }
        }

        public async Task<ResponseModel<AreaModel>> InformationsAboutArea(int areaId)
        {
            ResponseModel<AreaModel> reply = new();
            try
            {

                reply.Dados = await _areaRepository.GetAllDetailsAboutAreaAsync(areaId);
                reply.Mensagem = "Area information successfully retrieved";

                return reply;
            }
            catch (DbUpdateException ex)
            {
                throw new DbUpdateException($"Error retrieving area information: {ex.Message}");
            }
        }

        public async Task<ResponseModel<List<AreaModel>>> UpdateArea(EditAreaDto areaDto)
        {
            ResponseModel<List<AreaModel>> reply = new();



            try
            {
                var area = await _areaRepository.GetAreaByIdAsync(areaDto.Id);

                area.NameArea = areaDto.NameArea;
                area.BranchId = areaDto.BranchLinkedId;
                area.CreationDate = areaDto.CreationDate;
                area.Description = areaDto.Description;

                await _areaRepository.UpdateAreaAsync(area);

                reply.Dados = await _areaRepository.GetAllAreasAsync();
                reply.Mensagem = "Area successfully updated";

                return reply;
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbUpdateException($"Error updating area: {e.Message}");
            }
        }

        public async Task<ResponseModel<List<AreaModel>>> DeleteArea(int areaId)
        {
            ResponseModel<List<AreaModel>> reply = new();

            try
            {
                var area = await _areaRepository.GetAreaByIdAsync(areaId);

                await _areaRepository.DeleteAreaAsync(area);

                reply.Dados = await _areaRepository.GetAllAreasAsync();
                reply.Mensagem = "Area successfully deleted";

                return reply;
            }
            catch (DbUpdateException ex)
            {
                throw new DbUpdateException($"Error deleting area: {ex.Message}");
            }
        }

        public async Task<ResponseModel<List<AreaModel>>> ListAllAreas()
        {
            ResponseModel<List<AreaModel>> reply = new();
            try
            {
                reply.Dados = await _areaRepository.GetAllAreasAsync();
                reply.Mensagem = "All areas successfully retrieved";

                return reply;
            }
            catch (DbUpdateException ex)
            {
                throw new DbUpdateException($"Error retrieving all areas: {ex.Message}");
            }
        }

        public async Task<ResponseModel<List<AreaModel>>> ListAllAreasInCompany(int company)
        {
            ResponseModel<List<AreaModel>> reply = new();
            try
            {
                reply.Dados = await _areaRepository.GetAreasInCompanyAsync(company);
                reply.Mensagem = "Areas successfully retrieved";
                return reply;
            }
            catch (DbUpdateException ex)
            {
                throw new DbUpdateException($"Error retrieving areas: {ex.Message}");
            }
        }

        public async Task<ResponseModel<List<AreaModel>>> GetAreasInBranch(int branchId)
        {
            ResponseModel<List<AreaModel>> reply = new();
            try
            {


                reply.Dados = await _areaRepository.GetAreasInBranchAsync(branchId);
                reply.Mensagem = "Areas in branch successfully retrieved";

                return reply;
            }
            catch (DbUpdateException ex)
            {
                throw new DbUpdateException($"Error retrieving areas in branch: {ex.Message}");
            }
        }

        public async Task<ResponseModel<double>> GetExpenseInArea(int areaId)
        {
            ResponseModel<double> reply = new();
            try
            {

                reply.Dados = await _areaRepository.GetExpenseInAreaAsync(areaId);
                reply.Mensagem = "Expense in area successfully retrieved";

                return reply;
            }
            catch (DbUpdateException ex)
            {
                throw new DbUpdateException($"Error retrieving expense in area: {ex.Message}");
            }
        }
    }
}
