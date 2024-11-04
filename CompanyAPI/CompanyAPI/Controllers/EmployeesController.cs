using CompanyAPI.Dto.CompanyDTOS;
using CompanyAPI.Dto.EmployeeDTOS;
using CompanyAPI.Services.Area;
using CompanyAPI.Services.Company;
using CompanyAPI.Services.Employee;
using CompanyAPI.Services.Equipment;
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
        [HttpGet("DetailsEmployee/{id}")]
        public async Task<ActionResult<ResponseModel<EmployeeModel>>> DetailsEmployee([FromRoute]int Id)
        {
            var employee = await _employeeInterface.InformationsAboutEmployee(Id);
            return Ok(employee);
        }


        // GET: GET Employee
        [HttpGet("GetEmployee/{id}")]
        public async Task<ActionResult<ResponseModel<EmployeeModel>>> GetEmployee([FromRoute] int id)
        {
            var employee = await _employeeInterface.GetEmployee(id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }


        // DELETE: Delete Equipment
        [HttpDelete("DeleteEquipment/{id}")]
        public async Task<ActionResult<ResponseModel<bool>>> DeleteEmployee([FromRoute] int id)
        {
            var result = await _employeeInterface.DeleteEmployee(id);
            return Ok(result);
        }

        // GET: List All Employees
        [HttpGet("AllEmployees")]
        public async Task<ActionResult<ResponseModel<List<EmployeeModel>>>> AllEmployees()
        {
            var employees = await _employeeInterface.ListAllEmployees();
            return Ok(employees);
        }


        // GET: List All Employees in Branch
        [HttpGet("AllEmployeesInCompany")]
        public async Task<ActionResult<ResponseModel<List<EmployeeModel>>>> AllEmployeesInCompany(int company)
        {
            var employees = await _employeeInterface.ListAllEmployeesInCompany(company);
            return Ok(employees);
        }

        // GET: List All Employees In Branch
        [HttpGet("AllEmployeesInBranch")]
        public async Task<ActionResult<ResponseModel<List<EmployeeModel>>>> AllEmployeesInBranch(int branchId)
        {
            var employees = await _employeeInterface.ListAllEmployeesInBranch(branchId);
            return Ok(employees);
        }

        // GET: List All 
        [HttpGet("AllEmployeesInArea")]
        public async Task<ActionResult<ResponseModel<List<EmployeeModel>>>> AllEmployeesInArea(int areaId)
        {
            var employees = await _employeeInterface.ListAllEmployeesInArea(areaId);
            return Ok(employees);
        }



    }
}
