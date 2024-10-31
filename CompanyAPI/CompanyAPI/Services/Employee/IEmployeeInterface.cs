using CompanyAPI.ViewModel;

namespace CompanyAPI.Services.Employee
{
    public interface IEmployeeInterface
    {
        Task<ResponseModel<List<EmployeeModel>>> ListAllEmployeesInCompany(int companyId);
    }
}
