using CompanyAPI.Repository.Employee;
using CompanyAPI.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace CompanyAPI.Services.Employee
{
    public class EmployeeService 
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }



        public async Task<ResponseModel<List<EmployeeModel>>> ListAllEmployeesInCompany(int companyId)
        {
            ResponseModel<List<EmployeeModel>> reply = new();
            try
            {
                reply.Dados = await _employeeRepository.GetAllEmployeesInCompany(companyId);
                reply.Mensagem = "Employees successfully retrieved";
                return reply;
            }
            catch (DbUpdateException ex)
            {
                throw new DbUpdateException($"Error retrieving employees: {ex.Message}");
            }
        }
    }
}
