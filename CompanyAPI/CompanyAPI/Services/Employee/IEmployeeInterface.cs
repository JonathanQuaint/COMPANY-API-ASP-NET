using CompanyAPI.Dto.EmployeeDTOS;
using CompanyAPI.ViewModel;

namespace CompanyAPI.Services.Employee
{
    public interface IEmployeeInterface
    {
        Task<ResponseModel<List<EmployeeModel>>> ListAllEmployeesInCompany(int companyId);
        Task<ResponseModel<List<EmployeeModel>>> CreateEmployee(CreateEmployeeDto employeeDto);
        Task<ResponseModel<EmployeeModel>> InformationsAboutEmployee(int employeeId);
        Task<ResponseModel<EmployeeModel>> UpdateEmployee(EditEmployee employeeDto);
        Task<ResponseModel<EmployeeModel>> GetEmployee(int employeeId);
        Task<ResponseModel<bool>> DeleteEmployee(int id);
        Task<ResponseModel<List<EmployeeModel>>> ListAllEmployeesInBranch(int areaId);
        Task<ResponseModel<List<EmployeeModel>>> ListAllEmployeesInArea(int areaId);
        Task<ResponseModel<List<EmployeeModel>>> ListAllEmployees();
        Task<ResponseModel<double>> ListAllEmployeesExpenseinArea(int areaId);
        Task<ResponseModel<double>> ListAllEmployeesExpenseinBranch(int branchId);

    }
}
