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
        [HttpPost("EditCompany")]
        public async Task<ActionResult<ResponseModel<List<CompanyModel>>>> EditCompany(EditCompanyDTOS companyInfos)
        {
            var company = await _companyInterface.UpdateCompany(companyInfos);
            return Ok(company);
        }

        // GET: Company Details 
        [HttpGet("CompanyDetails")]
        public async Task<ActionResult<ResponseModel<CompanyModel>>> DetailsCompany(int companyID)
        {
            var company = await _companyInterface.InformationsAboutTheCompany(companyID);
            return Ok(company);
        }

        // GET: All Branches in Company
        [HttpGet("AllCompanies")]
        public async Task<ActionResult<ResponseModel<List<BranchModel>>>> AllBranchsInCompany(int companyID)
        {
            var branches = await _companyInterface.ListAllBranchsInCompany(companyID);
            return Ok(branches);
        }

        // GET: List Expense in Company
        [HttpGet("ListExpenseInCompany")]
        public async Task<ActionResult<ResponseModel<List<CompanyModel>>>> ListExpenseInCompany()
        {
            var expenses = await _companyInterface.ListExpenseInCompany();
            return Ok(expenses);
        }

        // GET: List All Areas
        [HttpGet("ListAllAreas")]
        public async Task<ActionResult<ResponseModel<List<CompanyModel>>>> ListAllAreas()
        {
            var areas = await _companyInterface.ListAllAreas();
            return Ok(areas);
        }

        // GET: List All Employees
        [HttpGet("ListAllEmployees")]
        public async Task<ActionResult<ResponseModel<List<CompanyModel>>>> ListAllEmployees()
        {
            var employees = await _companyInterface.ListAllEmployees();
            return Ok(employees);
        }

        // GET: List All Equipments
        [HttpGet("ListAllEquipments")]
        public async Task<ActionResult<ResponseModel<List<CompanyModel>>>> ListAllEquipments()
        {
            var equipments = await _companyInterface.ListAllEquipments();
            return Ok(equipments);
        }

        // GET: List All in Company
        [HttpGet("ListAllInCompany")]
        public async Task<ActionResult<ResponseModel<List<CompanyModel>>>> ListAllInCompany()
        {
            var allInCompany = await _companyInterface.ListAllInCompany();
            return Ok(allInCompany);
        }
    }
}
