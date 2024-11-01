using CompanyAPI.ViewModel;

namespace CompanyAPI.Repository.Employee
{
    public interface IEmployeeRepository
    {
        Task AddEmployeeAsync(EmployeeModel employee);
        Task UpdateEmployeeAsync(EmployeeModel employee);
        Task DeleteEmployeeAsync(EmployeeModel employee);
        Task<List<EmployeeModel>> GetAllEmployeesAsync();
        Task<EmployeeModel?> GetEmployeeByIdAsync(int employeeId);
        Task<List<EmployeeModel>> GetEmployeesInAreaAsync(int areaId);
        Task<bool> CheckEmployeeExistByIdAsync(int employeeId);
        Task<EmployeeModel?> GetAllDetailsAboutEmployeeAsync(int employeeId);
        Task<List<EmployeeModel>> GetAllEmployeesInCompany(int companyId);
        Task<List<EmployeeModel>> GetAllEmployeesInBranch(int branchId);
        Task<bool> CheckAreaExistByIdAsync(int areaId); 
    }
}
