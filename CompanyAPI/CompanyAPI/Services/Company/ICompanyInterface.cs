﻿using CompanyAPI.Dto.CompanyDTOS;
using CompanyAPI.ViewModel;

namespace CompanyAPI.Services.Company
{
    public interface ICompanyInterface
    {
        Task<CompanyModel> CreateCompany(CreateCompanyDTO companyDto);

        Task<ResponseModel<List<CompanyModel>>> ListExpenseInCompany();

        Task<ResponseModel<List<CompanyModel>>> ListAllBranchs();

        Task<ResponseModel<List<CompanyModel>>> ListAllAreas();

        Task<ResponseModel<List<CompanyModel>>> ListAllEmployees();

        Task<ResponseModel<List<CompanyModel>>> ListAllEquipments();

        Task<ResponseModel<List<CompanyModel>>> ListAllInCompany();
        
    }
}
