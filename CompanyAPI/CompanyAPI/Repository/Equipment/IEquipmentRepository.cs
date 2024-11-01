
using CompanyAPI.ViewModel;

public interface IEquipmentRepository
{
    Task AddEquipmentAsync(EquipmentModel equipment);
    Task UpdateEquipmentAsync(EquipmentModel equipment);
    Task DeleteEquipmentAsync(EquipmentModel equipment);
    Task<List<EquipmentModel>> GetAllEquipmentsAsync();
    Task<EquipmentModel?> GetEquipmentByIdAsync(int equipmentId);
    Task<List<EquipmentModel>> GetEquipmentsInAreaAsync(int areaId);
    Task<bool> CheckEquipmentExistByIdAsync(int equipmentId);
    Task<EquipmentModel?> GetAllDetailsAboutEquipmentAsync(int equipmentId);
    Task<List<EquipmentModel>> GetAllEquipmentsInCompany(int companyId);
    Task<List<EquipmentModel>> GetAllEquipmentsInBranch(int branchId); 
    Task<bool> CheckAreaExistByIdAsync(int areaId); 
}


