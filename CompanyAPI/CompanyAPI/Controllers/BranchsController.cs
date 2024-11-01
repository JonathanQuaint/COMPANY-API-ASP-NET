using CompanyAPI.Data;
using CompanyAPI.Dto.BranchDTOS;
using CompanyAPI.Dto.CompanyDTOS;
using CompanyAPI.Services.Branch;
using CompanyAPI.Services.Company;
using CompanyAPI.ViewModel;
using Microsoft.AspNetCore.Mvc;


namespace CompanyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchsController : ControllerBase
    {
        private readonly IBranchService _branchService;

        public BranchsController(IBranchService branchService)
        {
            _branchService = branchService;
        }

        // POST: Create the Branch 
        [HttpPost("CreateFilial")]
        public async Task<ActionResult<ResponseModel<List<BranchModel>>>> CreateFilial([FromBody] CreateBranchDto branchInfos)
        {
            var branch = await _branchService.CreateFilial(branchInfos);
            return Ok(branch);
        }

        // PUT: Edit Branch Details 
        [HttpPut("EditFilial")]
        public async Task<ActionResult<ResponseModel<List<BranchModel>>>> EditCompany([FromBody] EditBranchDto branchInfos)
        {
            var branch = await _branchService.UpdateFilial(branchInfos);
            return Ok(branch);
        }

        // GET: Filial Details 
        [HttpGet("FilialDetails")]
        public async Task<ActionResult<ResponseModel<BranchModel>>> DetailsFilial([FromQuery] int branchID)
        {
            var branch = await _branchService.InformationsAboutBranch(branchID);
            return Ok(branch);
        }

        // DELETE: Delete Branch
        [HttpDelete("DeleteFilial/{branchID}")]
        public async Task<ActionResult<ResponseModel<bool>>> DeleteFilial([FromRoute] int branchID)
        {
            var result = await _branchService.DeleteFilial(branchID);
            return Ok(result);
        }
    }
}
