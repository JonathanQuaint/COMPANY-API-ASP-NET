using CompanyAPI.Data;
using CompanyAPI.Dto.CompanyDTOS;
using CompanyAPI.Services.Company;
using CompanyAPI.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
namespace CompanyAPI.Controllers
{
    [Route("Company")]
    [Authorize]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyInterface _companyInterface;
      

        public CompanyController(ICompanyInterface companyInterface)
        {
            _companyInterface = companyInterface;
        }

        
        // POST: Creating Company 
        [HttpPost("CreateCompany")]
   
        public async Task<ActionResult<ResponseModel<List<CompanyModel>>>> CreateCompany(CreateCompanyDTO companyCreate)
        {
            var company = await _companyInterface.CreateCompany(companyCreate);
            return Ok(company);
        }

        // POST: Edit Company Details 
        [HttpPut("EditCompany/{companyId}")]
        public async Task<ActionResult<ResponseModel<List<CompanyModel>>>> EditCompany(EditCompanyDTOS companyInfos)
        {
            var company = await _companyInterface.UpdateCompany(companyInfos);
            return Ok(company);
        }

        // GET: Company Details 
        [HttpGet("CompanyDetails/{companyId}")]
        public async Task<ActionResult<ResponseModel<CompanyModel>>> DetailsCompany(int companyID)
        {
            var company = await _companyInterface.InformationsAboutTheCompany(companyID);
            return Ok(company);
        }

       

        // GET: List Expense in Company
        [HttpGet("ListExpenseInCompany/{companyId}")]
        public async Task<ActionResult<ResponseModel<List<CompanyModel>>>> ListExpenseInCompany(int companyId)
        {
            var expenses = await _companyInterface.ExpenseInCompany(companyId);
            return Ok(expenses);
        }

       
        // GET: List All in Company
        [HttpGet("ListAllInCompany/{companyId}")]
        public async Task<ActionResult<ResponseModel<List<CompanyModel>>>> ListAllInCompany(int companyId)
        {
            var allInCompany = await _companyInterface.ListAllInCompany(companyId);
            return Ok(allInCompany);
        }

        // GET: Delete in Company
        [HttpDelete("DeleteCompany/{companyId}")]
        public async Task<ActionResult<ResponseModel<List<CompanyModel>>>> DeleteCompany(int companyId)
        {
            var result = await _companyInterface.DeleteCompany(companyId);
            return Ok(result);
        }

    }
}
