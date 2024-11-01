using CompanyAPI.Dto.EquipmentDTOS;
using CompanyAPI.Services.Employee;
using CompanyAPI.Services.Equipment;
using CompanyAPI.ViewModel;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CompanyAPI.Controllers
{
    [Route("api/[controller]")]
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




        // DELETE: Delete Equipment
        [HttpDelete("{id}")]
        public async Task<ActionResult<ResponseModel<bool>>> DeleteEquipment([FromRoute] int id)
        {
            var result = await _equipmentInterface.DeleteEquipment(id);
            return Ok(result);
        }
    }
}
