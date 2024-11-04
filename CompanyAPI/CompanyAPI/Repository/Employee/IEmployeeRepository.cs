using CompanyAPI.ViewModel;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

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
        Task<List<EmployeeModel>> GetAllEmployeesInCompanyAsync(int companyId);
        Task<List<EmployeeModel>> GetAllEmployeesInBranchAsync(int branchId);
  


    }
}
