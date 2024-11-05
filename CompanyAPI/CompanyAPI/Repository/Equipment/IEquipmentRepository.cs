
using CompanyAPI.ViewModel;
using Microsoft.EntityFrameworkCore;

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
    Task<List<EquipmentModel>> GetAllEquipmentsInCompanyAsync(int companyId);
    Task<List<EquipmentModel>> GetAllEquipmentsInBranchAsync(int branchId);
    Task<double> AllEquipmentExpenseInArea(int areaId);

    Task<double> AllEquipmentExpenseInBranch(int branchId);

}


