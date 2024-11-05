using CompanyAPI.Dto.CompanyDTOS;
using CompanyAPI.Dto.EmployeeDTOS;
using CompanyAPI.Services.Area;
using CompanyAPI.Services.Company;
using CompanyAPI.Services.Employee;
using CompanyAPI.Services.Equipment;
using CompanyAPI.Services.Exceptions;
using CompanyAPI.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CompanyAPI.Controllers
{
    [Authorize]
    [Route("Employees")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeInterface _employeeInterface;
        
        public EmployeesController(IEmployeeInterface employeeInterface)
        {
            _employeeInterface = employeeInterface;
        }


        // POST: Create Employee
        [HttpPost("CreateEmployee")]
        [Authorize]
        public async Task<ActionResult<ResponseModel<List<EmployeeModel>>>> CreateEmployee(CreateEmployeeDto employeeDto)
        {
            var employee = await _employeeInterface.CreateEmployee(employeeDto);
            return Ok(employee);
        }

        // POST: Edit Employee
        [HttpPut("EditEmployee")]
        public async Task<ActionResult<ResponseModel<EmployeeModel>>> EditEmployee([FromBody] EditEmployee employeeDto)
        {
            var updatedEmployee = await _employeeInterface.UpdateEmployee(employeeDto);
            return Ok(updatedEmployee);
        }




        // GET: Employee Details 
        [HttpGet("DetailsEmployee/{employeeId:int}")]
        public async Task<IActionResult> DetailsEmployee(int employeeId)
        {
            try
            {
                var response = await _employeeInterface.InformationsAboutEmployee(employeeId);
                if (response.Dados == null)
                {
                    return NotFound(response.Mensagem);
                }
                return Ok(response);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }


        // GET: GET Employee
        [HttpGet("GetEmployee/{employeeId:int}")]
        public async Task<ActionResult<ResponseModel<EmployeeModel>>> GetEmployee([FromRoute] int employeeId)
        {
            var employee = await _employeeInterface.GetEmployee(employeeId);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }


        // GET: List All Employees
        [HttpGet("AllEmployees")]
        public async Task<ActionResult<ResponseModel<List<EmployeeModel>>>> AllEmployees()
        {
            var employees = await _employeeInterface.ListAllEmployees();
            return Ok(employees);
        }


        // GET: List All Employees in Branch
        [HttpGet("AllEmployeesInCompany/{companyId:int}")]
        public async Task<ActionResult<ResponseModel<List<EmployeeModel>>>> AllEmployeesInCompany(int companyId)
        {
            var employees = await _employeeInterface.ListAllEmployeesInCompany(companyId);
            return Ok(employees);
        }

        // GET: List All Employees In Branch
        [HttpGet("AllEmployeesInBranch/{branchId:int}")]
        public async Task<ActionResult<ResponseModel<List<EmployeeModel>>>> AllEmployeesInBranch(int branchId)
        {
            var employees = await _employeeInterface.ListAllEmployeesInBranch(branchId);
            return Ok(employees);
        }

        // GET: List All 
        [HttpGet("AllEmployeesInArea/{areaId:int}")]
        public async Task<ActionResult<ResponseModel<List<EmployeeModel>>>> AllEmployeesInArea(int areaId)
        {
            var employees = await _employeeInterface.ListAllEmployeesInArea(areaId);
            return Ok(employees);
        }

        // GET: List All Expense in Area
        [HttpGet("AllEmployeesExpenseInArea/{areaId:int}")]
        public async Task<ActionResult<ResponseModel<double>>> AllEmployeesExpenseInArea(int areaId)
        {
            var result = await _employeeInterface.ListAllEmployeesExpenseinArea(areaId);
            return Ok(result);
        }

        // GET: List All Expense in Branch
        [HttpGet("AllEmployeesExpenseInBranch/{branchId:int}")]
        public async Task<ActionResult<ResponseModel<double>>> AllEmployeesExpenseInBranch(int branchId)
        {
            var result = await _employeeInterface.ListAllEmployeesExpenseinArea(branchId);
            return Ok(result);
        }

        // DELETE: Delete employee
        [HttpDelete("DeleteEmployee/{employeeId:int}")]
        public async Task<ActionResult<ResponseModel<bool>>> DeleteEmployee([FromRoute] int employeeid)
        {
            var result = await _employeeInterface.DeleteEmployee(employeeid);
            return Ok(result);
        }

    }
}
