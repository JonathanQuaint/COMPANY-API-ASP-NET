using CompanyAPI.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace CompanyAPI.Services.Equipment
{
    public class EquipmentService
    {
        private readonly IEquipmentRepository _equipmentRepository;

        public EquipmentService(IEquipmentRepository EquipmentRepository)
        {
            _equipmentRepository = EquipmentRepository;
        }

        public async Task<ResponseModel<List<EquipmentModel>>> ListAllEquipmentsInCompany(int companyId)
        {
            ResponseModel<List<EquipmentModel>> reply = new();
            try
            {
                reply.Dados = await _equipmentRepository.GetAllEquipmentsInCompany(companyId);
                reply.Mensagem = "Equipments successfully retrieved";
                return reply;
            }
            catch (DbUpdateException ex)
            {
                throw new DbUpdateException($"Error retrieving equipments: {ex.Message}");
            }
        }
    }
}
