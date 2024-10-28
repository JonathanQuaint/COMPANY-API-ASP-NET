using CompanyAPI.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace CompanyAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<CompanyModel> Company { get; set; }

        public DbSet<BranchModel> Branchs { get; set; }

        public DbSet<AreaModel> Areas { get; set; }

        public DbSet<EmployeeModel> Employees { get; set; }

        public DbSet<EquipmentModel> Equipments { get; set; }
    }
}
