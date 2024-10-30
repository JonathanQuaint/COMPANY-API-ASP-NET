using CompanyAPI.Data;
using CompanyAPI.Services.Exceptions;
using CompanyAPI.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace CompanyAPI.Repository.Area
{
    public class AreaRepository : IAreaRepository
    {
        private readonly AppDbContext _context;

        public AreaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAreaAsync(AreaModel area)
        {
            if (!await CheckBranchExistByIdAsync(area.BranchId))
            {
                throw new NotFoundException("Id of the branch not found");
            }
            var branchLinked = await _context.Branchs.FindAsync(area.BranchId);

            if (branchLinked != null)
            {
                area.LinkedBranch = branchLinked;
                branchLinked.Areas.Add(area);
            }


            await _context.Areas.AddAsync(area);
            await _context.SaveChangesAsync();
        }
      
        public async Task UpdateAreaAsync(AreaModel area)
        {
            if (!await CheckBranchExistByIdAsync(area.BranchId))
            {
                throw new NotFoundException("Id of the branch not found");
            }

            if (area.LinkedBranch == null)
            {
                throw new InvalidOperationException("LinkedBranch property cannot be null");
            }

            bool branchIsSimilar = area.BranchId == area.LinkedBranch.Id;

            if (!branchIsSimilar)
            {
                var currentBranch = await _context.Branchs.FindAsync(area.LinkedBranch.Id);
                if (currentBranch == null)
                {
                    throw new NotFoundException("Current linked branch not found");
                }

                currentBranch.Areas.Remove(area);

                area.LinkedBranch = await _context.Branchs.FindAsync(area.BranchId);
                if (area.LinkedBranch == null)
                {
                    throw new NotFoundException("New linked branch not found");
                }
            }

            _context.Areas.Update(area);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAreaAsync(AreaModel area)
        {
            _context.Areas.Remove(area);
            await _context.SaveChangesAsync();
        }

        public async Task<List<AreaModel>> GetAllAreasAsync()
        {
            return await _context.Areas.ToListAsync();
        }

        public async Task<AreaModel> GetAreaByIdAsync(int areaId)
        {
            return await _context.Areas.FindAsync(areaId);
        }

        public async Task<AreaModel> GetAreaByBranchAsync(int branchId)
        {
            return await _context.Areas.FirstOrDefaultAsync(a => a.BranchId == branchId);
        }

        public async Task<List<AreaModel>> GetAreasInBranchAsync(int branchId)
        {
            return await _context.Areas.Where(a => a.BranchId == branchId).ToListAsync();
        }

        public async Task<bool> CheckAreaExistByIdAsync(int areaId)
        {
            return await _context.Areas.AnyAsync(a => a.Id == areaId);
        }


        public async Task<AreaModel> GetAllDetailsAboutAreaAsync(int areaId)
        {
            return await _context.Areas
                .Include(a => a.Employees)
                .Include(a => a.Equipments)
                .FirstOrDefaultAsync(a => a.Id == areaId);
        }

        public async Task<bool> CheckBranchExistByIdAsync(int Branch)
        {
            return await _context.Branchs.AnyAsync(c => c.Id == Branch);
        }

        public async Task<List<AreaModel>> GetAllEmployeesInArea(int areaId)
        {
            return await _context.Areas
                .Include(a => a.Employees)
                .Where(a => a.Id == areaId)
                .ToListAsync();

        }

        public async Task<List<AreaModel>> GetAllEquipmentsInArea(int areaId)
        {
            return await _context.Areas
                .Include(a => a.Equipments)
                .Where(a => a.Id == areaId)
                .ToListAsync();

        }
    }
}
