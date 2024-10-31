using CompanyAPI.ViewModel;

namespace CompanyAPI.Repository.Area
{
    public interface IAreaRepository
    {
        Task AddAreaAsync(AreaModel area);
        Task UpdateAreaAsync(AreaModel area);
        Task DeleteAreaAsync(AreaModel area);
        Task<List<AreaModel>> GetAllAreasAsync();
        Task<AreaModel> GetAreaByIdAsync(int areaId);
        Task<List<AreaModel>> GetAreasInBranchAsync(int branchId);
        Task<bool> CheckAreaExistByIdAsync(int areaId);
        Task<AreaModel> GetAllDetailsAboutAreaAsync(int areaId);
        Task<bool> CheckBranchExistByIdAsync(int Branch);
       



    }
}
