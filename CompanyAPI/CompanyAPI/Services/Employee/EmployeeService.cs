using CompanyAPI.Dto.AreaDTOS;
using CompanyAPI.Dto.EmployeeDTOS;
using CompanyAPI.Repository.Employee;
using CompanyAPI.Repository.Equipment;
using CompanyAPI.Services.Exceptions;
using CompanyAPI.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace CompanyAPI.Services.Employee
{
    public class EmployeeService : IEmployeeInterface
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<ResponseModel<List<EmployeeModel>>> CreateEmployee(CreateEmployeeDto employeeDto)
        {
            ResponseModel<List<EmployeeModel>> reply = new();

            try
            {
              
                var employee = new EmployeeModel()
                {
                    Name = employeeDto.NameEmployee,
                    AreaId = employeeDto.AreaId,
                    Salary = employeeDto.Salary,
                    IdentificationNumber = employeeDto.IdentificationNumber,
                    Position = employeeDto.Position,
                    Department = employeeDto.Department
                };

                await _employeeRepository.AddEmployeeAsync(employee);

                reply.Dados = await _employeeRepository.GetAllEmployeesAsync();
                reply.Mensagem = "Employee successfully created";

                return reply;
            }
            catch (DbUpdateException ex)
            {
                throw new DbUpdateException($"Error: {ex.InnerException?.Message}");
            }
        }

        public async Task<ResponseModel<EmployeeModel>> InformationsAboutEmployee(int employeeId)
        {
            ResponseModel<EmployeeModel> reply = new();
            try
            {
               

                reply.Dados = await _employeeRepository.GetAllDetailsAboutEmployeeAsync(employeeId);
                reply.Mensagem = "employee information successfully retrieved";

                return reply;
            }
            catch (DbUpdateException ex)
            {
                throw new DbUpdateException($"Error employee area information: {ex.Message}");
            }
        }

        public async Task<ResponseModel<EmployeeModel>> UpdateEmployee(EditEmployee employeeDto)
        {
            ResponseModel<EmployeeModel> reply = new();
            try
            {
                var employee = await _employeeRepository.GetEmployeeByIdAsync(employeeDto.Id);

                if (employee == null)
                {
                    throw new NotFoundException("Employee not found by ID");
                }


                double salaryDiference = employee.Salary - employeeDto.Salary;

                employee.Name = employeeDto.NameEmployee;
                employee.Salary = employeeDto.Salary;
                employee.AreaId = employeeDto.AreaId;
                employee.IdentificationNumber = employeeDto.IdentificationNumber;
                employee.Position = employeeDto.Position;
                employee.Department = employeeDto.Department;
                

                employee.AreaLinked.Expense += salaryDiference;
                employee.AreaLinked.LinkedBranch.Expense += salaryDiference;

                await _employeeRepository.UpdateEmployeeAsync(employee);

                reply.Dados = await _employeeRepository.GetEmployeeByIdAsync(employee.Id);
                reply.Mensagem = "Employee updated successfully";

                return reply;
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbUpdateException($"Error updating employee: {e.Message}");
            }
        }

        public async Task<ResponseModel<List<EmployeeModel>>> ListAllEmployeesInCompany(int companyId)
        {
            ResponseModel<List<EmployeeModel>> reply = new();
            try
            {
                reply.Dados = await _employeeRepository.GetAllEmployeesInCompanyAsync(companyId);
                reply.Mensagem = "Employees successfully retrieved";
                return reply;
            }
            catch (DbUpdateException ex)
            {
                throw new DbUpdateException($"Error retrieving employees: {ex.Message}");
            }
        }
        public async Task<ResponseModel<List<EmployeeModel>>> ListAllEmployeesInArea(int areaId)
        {
            ResponseModel<List<EmployeeModel>> reply = new();
            try
            {
                reply.Dados = await _employeeRepository.GetEmployeesInAreaAsync(areaId);
                reply.Mensagem = "Employees successfully retrieved";
                return reply;
            }
            catch (DbUpdateException ex)
            {
                throw new DbUpdateException($"Error retrieving employees: {ex.Message}");
            }
        }

        public async Task<ResponseModel<List<EmployeeModel>>> ListAllEmployeesInBranch(int areaId)
        {
            ResponseModel<List<EmployeeModel>> reply = new();
            try
            {
                reply.Dados = await _employeeRepository.GetAllEmployeesInBranchAsync(areaId);
                reply.Mensagem = "Employees successfully retrieved";
                return reply;
            }
            catch (DbUpdateException ex)
            {
                throw new DbUpdateException($"Error retrieving employees: {ex.Message}");
            }
        }

        public async Task<ResponseModel<List<EmployeeModel>>> ListAllEmployees()
        {
            ResponseModel<List<EmployeeModel>> reply = new();
            try
            {
                reply.Dados = await _employeeRepository.GetAllEmployeesAsync();
                reply.Mensagem = "Employees successfully retrieved";
                return reply;
            }
            catch (DbUpdateException ex)
            {
                throw new DbUpdateException($"Error retrieving employees: {ex.Message}");
            }
        }

        public async Task<ResponseModel<double>> ListAllEmployeesExpenseinArea(int areaId)
        {
            ResponseModel<double> reply = new();
            try
            {
                reply.Dados = await _employeeRepository.AllEmployeesExpenseInArea(areaId);
                reply.Mensagem = "Employees expense successfully retrieved";
                return reply;
            }

            catch (DbUpdateException ex)
            {
                throw new DbUpdateException($"Error retrieving expense: {ex.Message}");
            }

        }

        public async Task<ResponseModel<double>> ListAllEmployeesExpenseinBranch(int branchId)
        {
            ResponseModel<double> reply = new();
            try
            {
                reply.Dados = await _employeeRepository.AllEmployeesExpenseInBranch(branchId);
                reply.Mensagem = "Employees expense successfully retrieved";
                return reply;
            }

            catch (DbUpdateException ex)
            {
                throw new DbUpdateException($"Error retrieving expense: {ex.Message}");
            }

        }

        public async Task<ResponseModel<EmployeeModel>> GetEmployee(int employeeId)
        {
            ResponseModel<EmployeeModel> reply = new();

            try
            {
                var employee = await _employeeRepository.GetEmployeeByIdAsync(employeeId);

                reply.Dados = employee;
                reply.Mensagem = "Employee successfully retrieved";
                return reply;

            }
            catch (DbUpdateException ex)
            {
                throw new DbUpdateException($"Error retrieving employee: {ex.Message}");
            }

        }

        public async Task<ResponseModel<bool>> DeleteEmployee(int id)
        {
            ResponseModel<bool> reply = new();
            try
            {
                var employee = await _employeeRepository.GetEmployeeByIdAsync(id);

                if (employee == null)
                {
                    throw new NotFoundException("Employee not found by ID");
                }

                await _employeeRepository.DeleteEmployeeAsync(employee);

                reply.Dados = true;
                reply.Mensagem = "Employee successfully Delete";

                return reply;


            }
            catch (Exception ex)
            {
                throw new Exception($"Error deleting employee: {ex.Message}");
            }


        }
    }
}
