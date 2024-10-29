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
        private readonly AppDbContext _context;

        public BranchsController(IBranchService branchService)
        {
            _branchService = branchService;
        }



        // POST: Create the Branch 
        [HttpPost("CreateFilial")]
        public async Task<ActionResult<ResponseModel<List<BranchModel>>>> CreateFilial(CreateBranchDto branchInfos)
        {
            var company = await _branchService.CreateFilial(branchInfos);

            return Ok(company);

        }

        // POST: Edit Branch Details 
        [HttpPost("EditFilial")]
        public async Task<ActionResult<ResponseModel<List<BranchModel>>>> EditCompany(EditBranchDto branchInfos)
        {
            var company = await _branchService.UpdateFilial(branchInfos);

            return Ok(company);

        }


       
    }
}
