using CompanyAPI.Data;
using CompanyAPI.Dto.CompanyDTOS;
using CompanyAPI.Services.Company;
using CompanyAPI.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
namespace CompanyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyInterface _companyInterface;
        private readonly AppDbContext _context;

        public CompanyController(ICompanyInterface companyInterface)
        {
           _companyInterface = companyInterface;
        }

        //POST: Creating Company 
        [HttpPost("CreateCompany")]
        public async Task<ActionResult<ResponseModel<List<CompanyModel>>>> CreateCompany(CreateCompanyDTO companyCreate)
        {
            var company = await _companyInterface.CreateCompany(companyCreate);
           
            return Ok(company);

        }

        //POST:  Edit Company Details 
        [HttpPost("EditCompany")]
        public async Task<ActionResult<ResponseModel<List<CompanyModel>>>> EditCompany(EditCompanyDTOS companyInfos)
        {
            var company = await _companyInterface.UpdateCompany(companyInfos);

            return Ok(company);

        }


    }
}
