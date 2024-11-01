﻿using CompanyAPI.Dto.CompanyDTOS;
using CompanyAPI.Dto.EmployeeDTOS;
using CompanyAPI.Services.Company;
using CompanyAPI.Services.Employee;
using CompanyAPI.Services.Equipment;
using CompanyAPI.ViewModel;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CompanyAPI.Controllers
{
    [Route("api/[controller]")]
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

    }
}
