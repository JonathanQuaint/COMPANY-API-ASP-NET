using CompanyAPI.Data;
using CompanyAPI.Dto.CompanyDTOS;
using CompanyAPI.ViewModel;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CompanyAPI.Services.Company
{
    public class CompanyService : ICompanyInterface
    {
        private readonly AppDbContext _context;

        public CompanyService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<CompanyModel> CreateCompany(CreateCompanyDTO companyDto)
        {
            ResponseModel<CompanyModel> reply = new();

                var company = new CompanyModel()
                {

                    Name = companyDto.Name,
                    MonthyBilling = companyDto.MonthyBilling

                };

                

                _context.Add(company);
                await _context.SaveChangesAsync();

                     return company;

        }

        public Task<ResponseModel<List<CompanyModel>>> ListAllAreas()
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<List<CompanyModel>>> ListAllBranchs()
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<List<CompanyModel>>> ListAllEmployees()
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<List<CompanyModel>>> ListAllEquipments()
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<List<CompanyModel>>> ListAllInCompany()
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<List<CompanyModel>>> ListExpenseInCompany()
        {
            throw new NotImplementedException();
        }

      
    }
}
