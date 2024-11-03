using CompanyAPI.Dto.CompanyDTOS;
using CompanyAPI.Repository.Company;
using CompanyAPI.Services.Exceptions;
using CompanyAPI.ViewModel;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;

namespace CompanyAPI.Services.Company
{
    public class CompanyService : ICompanyInterface
    {
        private readonly ICompanyRepository _companyRepository;

        public CompanyService(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public async Task<ResponseModel<List<CompanyModel>>> CreateCompany(CreateCompanyDTO companyInfos)
        {
            ResponseModel<List<CompanyModel>> reply = new();

            try
            {
                bool companyExist = await _companyRepository.CheckCompanyExistByNameAsync(companyInfos.Name);
                if (companyExist)
                {
                    throw new ConflictException("The company name already exists");
                }

                var company = new CompanyModel
                {
                    Name = companyInfos.Name,
                    MonthlyBilling = companyInfos.MonthyBilling
                };

                await _companyRepository.AddCompanyAsync(company);

                reply.Dados = await _companyRepository.GetAllCompaniesAsync();
                reply.Mensagem = "Company successfully registered";

                return reply;
            }
            catch (DbUpdateException ex)
                
            {
                throw new DbUpdateException($"Error: {ex.InnerException?.Message}");
            }
        }
        

        public async Task<ResponseModel<List<CompanyModel>>> UpdateCompany(EditCompanyDTOS companyInfos)
        {
            ResponseModel<List<CompanyModel>> reply = new();

            bool hasAnyID = await _companyRepository.CheckCompanyExistByIdAsync(companyInfos.IdOfCompany);

            if (!hasAnyID)
            {
                throw new NotFoundException("Id of the company not found");
            }

            try
            {
                var company = await _companyRepository.GetCompanyByIdAsync(companyInfos.IdOfCompany);

                company.Name = companyInfos.Name;
                company.MonthlyBilling = companyInfos.MonthyBilling;

                await _companyRepository.UpdateCompanyAsync(company);

                reply.Dados = await _companyRepository.GetAllCompaniesAsync();
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
                bool companyExist = await _companyRepository.CheckCompanyExistByIdAsync(companyId);

                if (!companyExist)
                {
                    throw new NotFoundException("Company not found");
                }

                reply.Dados = await _companyRepository.GetAllDetailsAboutCompanyAsync(companyId);
                reply.Mensagem = "Company informations sucessfully retrived";

                return reply;
            }
            catch (DbUpdateException ex)
            {
                throw new DbUpdateException($"Error retrieving Company information: {ex.Message}");
            }
        }

        public async Task<ResponseModel<List<AreaModel>>> ListAllAreasInCompany(int company)
        {
            ResponseModel<List<AreaModel>> reply = new();
            try
            {
                reply.Dados = await _companyRepository.GetAllAreasInCompanyAsync(company);
                reply.Mensagem = "Areas successfully retrieved";
                return reply;
            }
            catch (DbUpdateException ex)
            {
                throw new DbUpdateException($"Error retrieving areas: {ex.Message}");
            }
        }

        public async Task<ResponseModel<List<BranchModel>>> ListAllBranchsInCompany(int companyId)
        {
            ResponseModel<List<BranchModel>> reply = new();
            try
            {
                bool companyExist = await _companyRepository.CheckCompanyExistByIdAsync(companyId);

                if (!companyExist)
                {
                    throw new NotFoundException("Company not found");
                }

                reply.Dados = await _companyRepository.GetbranchsInCompanyAsync(companyId);
                reply.Mensagem = "Branches successfully retrieved";
                return reply;
            }
            catch (DbUpdateException ex)
            {
                throw new DbUpdateException($"Error retrieving branches: {ex.Message}");
            }
        }

       

     

        public async Task<ResponseModel<List<IGrouping<BranchModel, AreaModel>>>> ListAllInCompany(int companyId)
        {
            ResponseModel<List<IGrouping<BranchModel, AreaModel>>> reply = new();
            try
            {
                

                reply.Dados = await _companyRepository.GetAllInCompanyAsync(companyId);
                reply.Mensagem = "All data successfully retrieved";
                return reply;
            }
            catch (DbUpdateException ex)
            {
                throw new DbUpdateException($"Error retrieving all data: {ex.Message}");
            }
        }

        public async Task<ResponseModel<double>> ExpenseInCompany(int companyId)
        {
            ResponseModel<double> reply = new();
            try
            {
                reply.Dados = await _companyRepository.CalculateAllExpensesInCompanyAsync(companyId);
                reply.Mensagem = "Expenses successfully retrieved";
                return reply;
            }
            catch (DbUpdateException ex)
            {
                throw new DbUpdateException($"Error retrieving expenses: {ex.Message}");
            }
        }

        Task<ResponseModel<List<CompanyModel>>> ICompanyInterface.ListAllBranchsInCompany(int companyId)
        {
            throw new NotImplementedException();
        }

        Task<ResponseModel<List<CompanyModel>>> ICompanyInterface.ListExpenseInCompany()
        {
            throw new NotImplementedException();
        }

        Task<ResponseModel<List<CompanyModel>>> ICompanyInterface.ListAllAreas()
        {
            throw new NotImplementedException();
        }

        Task<ResponseModel<List<CompanyModel>>> ICompanyInterface.ListAllEmployees()
        {
            throw new NotImplementedException();
        }

        Task<ResponseModel<List<CompanyModel>>> ICompanyInterface.ListAllEquipments()
        {
            throw new NotImplementedException();
        }

        Task<ResponseModel<List<CompanyModel>>> ICompanyInterface.ListAllInCompany()
        {
            throw new NotImplementedException();
        }
    }
}
