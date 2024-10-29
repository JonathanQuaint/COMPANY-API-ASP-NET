using CompanyAPI.Data;
using CompanyAPI.Dto.CompanyDTOS;
using CompanyAPI.Services.Exceptions;
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

        public async Task<ResponseModel<List<CompanyModel>>> CreateCompany(CreateCompanyDTO companyInfos)
        {
            ResponseModel<List<CompanyModel>> reply = new();

            try
            {
                bool CompanyExist = await _context.Company.AnyAsync(x => x.Name == companyInfos.Name);
                if (CompanyExist)
                {

                    throw new ConflictException("The company name already exists");

                }
                var company = new CompanyModel()
                {

                    Name = companyInfos.Name,
                    MonthyBilling = companyInfos.MonthyBilling

                };


                _context.Add(company);
                await _context.SaveChangesAsync();

                reply.Dados = await _context.Company.ToListAsync();
                reply.Mensagem = "Company successfully registered";

                return reply;
            }

            catch (DbUpdateException ex) 
            { 
            
               throw new DbUpdateException(ex.Message); 
            
            }
        }

        public async Task<ResponseModel<List<CompanyModel>>> UpdateCompany(EditCompanyDTOS companyInfos)
        {
            ResponseModel<List<CompanyModel>> reply = new();

            bool hasAny = await _context.Company.AnyAsync(x => x.Id == companyInfos.Id);
            if (!hasAny)
            {
                throw new NotFoundException("Name of the company not found");

            }

            try
            {
                var company = await _context.Company.FirstOrDefaultAsync(x => x.Id == companyInfos.Id);
                
                company.Name = companyInfos.Name;

                company.MonthyBilling = companyInfos.MonthyBilling; 

                _context.Update(company);

                await _context.SaveChangesAsync();

                reply.Dados = await _context.Company.ToListAsync();
                reply.Mensagem = "Company updated successfully";

                return reply;

            }

            catch (DbUpdateConcurrencyException e) 
            {
                throw new DbUpdateException(e.Message);


            }
        }


        public async Task<ResponseModel<CompanyModel>> InformationsAboutTheCompany(int companyId)
        {
            ResponseModel<CompanyModel> reply = new();
            try
            {
                var company = await _context.Company
                    .Include(x => x.Expense)
                    .Include(x => x.Branch)
                    .FirstOrDefaultAsync(x => x.Id == companyId);

                if (company == null)
                {
                    throw new NotFoundException("Company not found");
                }

                reply.Dados = company;
                reply.Mensagem = "Company information successfully retrieved";
                return reply;
            }
            catch (DbUpdateException ex)
            {
                throw new DbUpdateException($"Error retrieving Company information: {ex.Message}");
            }
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
