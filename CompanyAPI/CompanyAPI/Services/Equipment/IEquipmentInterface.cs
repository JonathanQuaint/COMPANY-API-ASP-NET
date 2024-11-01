using CompanyAPI.Dto.EquipmentDTOS;
using CompanyAPI.ViewModel;

namespace CompanyAPI.Services.Equipment
{
    public interface IEquipmentInterface
    {
        Task<ResponseModel<List<EquipmentModel>>> CreateEquipment(CreateEquipmentDto equipmentDto);
        Task<ResponseModel<EquipmentModel>> UpdateEquipment(EditEquipmentDto equipmentDto);
        Task<ResponseModel<EquipmentModel>> GetEquipment(int equipmentId);
        Task<ResponseModel<List<EquipmentModel>>> ListAllEquipmentsInCompany(int companyId);
        Task<ResponseModel<EquipmentModel>> DetailsAboutEquipment(int id);
        Task<ResponseModel<bool>> DeleteEquipment(int equipmentId);

    }
}
