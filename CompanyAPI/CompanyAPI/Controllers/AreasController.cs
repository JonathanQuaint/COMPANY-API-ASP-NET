using CompanyAPI.Dto.AreaDTOS;
using CompanyAPI.Services.Area;
using CompanyAPI.Services.Company;
using CompanyAPI.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CompanyAPI.Controllers
{
    [Authorize]
    [Route("Areas")]
    [ApiController]
   
    public class AreasController : ControllerBase
    {
        private readonly IAreaInterface _areaService;

        public AreasController(IAreaInterface areaService)
        {
            _areaService = areaService;
        }

        // POST api/Area/CreateArea
        [HttpPost("CreateArea")]
        public async Task<ActionResult<ResponseModel<List<AreaModel>>>> CreateArea(CreateAreaDto areaDto)
        {
            var area = await _areaService.CreateArea(areaDto);
            return Ok(area);
        }

        // PUT api/Area/EditArea/5
        [HttpPut("EditArea/{id}")]
        public async Task<ActionResult<ResponseModel<List<AreaModel>>>> EditArea(int id, EditAreaDto areaDto)
        {
            areaDto.Id = id; // Ensure the ID is set in the DTO
            var area = await _areaService.UpdateArea(areaDto);
            return Ok(area);
        }



        // GET: api/Area
        [HttpGet("AllAreas")]
        public async Task<ActionResult<ResponseModel<List<AreaModel>>>> AllAreas()
        {
            var areas = await _areaService.ListAllAreas();
            return Ok(areas);
        }

        // GET api/Area/5
        [HttpGet("AreaDetails")]
        public async Task<ActionResult<ResponseModel<AreaModel>>> AreaDetails(int id)
        {
            var area = await _areaService.InformationsAboutArea(id);
            return Ok(area);
        }

        // GET: List All Areas
        [HttpGet("AllAreasInCompany")]
        public async Task<ActionResult<ResponseModel<List<AreaModel>>>> AllAreasInCompany(int company)
        {
            var areas = await _areaService.ListAllAreasInCompany(company);
            return Ok(areas);
        }

        // GET: List All Areas
        [HttpGet("AllAreasInBranch")]
        public async Task<ActionResult<ResponseModel<List<AreaModel>>>> AllAreasInBranch(int branch)
        {
            var areas = await _areaService.GetAreasInBranch(branch);
            return Ok(areas);
        }

        // GET: All Branches in Company
        [HttpGet("AllExpenseInArea")]
        public async Task<ActionResult<ResponseModel<List<BranchModel>>>> AllExpenseinArea(int areaId)
        {
            var branches = await _areaService.GetExpenseInArea(areaId);
            return Ok(branches);
        }


        // DELETE api/Area/DeleteArea/5
        [HttpDelete("DeleteArea/{id}")]
        public async Task<ActionResult<ResponseModel<List<AreaModel>>>> DeleteArea(int id)
        {
            var area = await _areaService.DeleteArea(id);
            return Ok(area);
        }
    }
}
