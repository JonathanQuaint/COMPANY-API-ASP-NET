using CompanyAPI.Dto.EquipmentDTOS;
using CompanyAPI.Services.Employee;
using CompanyAPI.Services.Equipment;
using CompanyAPI.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CompanyAPI.Controllers
{
    [Authorize]
    [Route("Equipments")]
    [ApiController]
    public class EquipmentsController : ControllerBase
    {
        private readonly IEquipmentInterface _equipmentInterface;

        public EquipmentsController(IEquipmentInterface equipmentInterface)
        {
            _equipmentInterface = equipmentInterface;
        }

        // POST: Create Equipment
        [HttpPost("CreateEquipment")]
      
        public async Task<ActionResult<ResponseModel<List<EquipmentModel>>>> CreateEquipment([FromBody] CreateEquipmentDto createEquipment)
        {
            var equipment = await _equipmentInterface.CreateEquipment(createEquipment);
            return Ok(equipment);
        }

        //PUT: Edit Equipment
        [HttpPut("{id}")]
        public async Task<ActionResult<ResponseModel<EquipmentModel>>> EditEquipment([FromBody] EditEquipmentDto editEquipment)
        {
            var updateEquipment = await _equipmentInterface.UpdateEquipment(editEquipment);

            return Ok(updateEquipment);
        }


        // GET: GET Equipment
        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseModel<EquipmentModel>>> GetEquipment([FromRoute] int id)
        {
            var equipment = await _equipmentInterface.GetEquipment(id);
            if (equipment == null)
            {
                return NotFound();
            }
            return Ok(equipment);
        }


        
        // GET: List All Expense in Area
        [HttpGet("AllEquipmentExpenseInArea")]
        public async Task<ActionResult<ResponseModel<double>>> AllEquipmentExpenseInArea(int areaId)
        {
            var result = await _equipmentInterface.ListAllEquipmentsExpenseinArea(areaId);
            return Ok(result);
        }

        // GET: List All Expense in Branch
        [HttpGet("AllEquipmentExpenseInBranch")]
        public async Task<ActionResult<ResponseModel<double>>> AllEquipmentExpenseInBranch(int branchId)
        {
            var result = await _equipmentInterface.ListAllEquipmentsExpenseinBranch(branchId);
            return Ok(result);
        }

        // GET: List All Equipment
        [HttpGet("AllEquipments")]
        public async Task<ActionResult<ResponseModel<List<EquipmentModel>>>> AllEquipments()
        {
            var equipments = await _equipmentInterface.AllEquipments();
            return Ok(equipments);

        }

        // DELETE: Delete Equipment
        [HttpDelete("Equipment{id}")]
        public async Task<ActionResult<ResponseModel<bool>>> DeleteEquipment([FromRoute] int id)
        {
            var result = await _equipmentInterface.DeleteEquipment(id);
            return Ok(result);
        }

    }


}
