using CompanyAPI.ViewModel;
using Microsoft.EntityFrameworkCore;

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
        Task<List<AreaModel>> GetAreasInCompanyAsync(int companyId);
        Task<AreaModel> GetAllDetailsAboutAreaAsync(int areaId);
        Task<double> GetExpenseInAreaAsync(int areaId);
    
       



    }
}
