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


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CompanyModel>()
                .HasMany(c => c.Branch).WithOne(b => b.CompanyLinked).HasForeignKey(b => b.CompanyID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<BranchModel>()
                .HasMany(c => c.Areas).WithOne( b => b.LinkedBranch).HasForeignKey(a => a.BranchId).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<AreaModel>()
                .HasMany<EmployeeModel>().WithOne(b => b.AreaLinked).HasForeignKey(b => b.AreaId).OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<AreaModel>()
                .HasMany<EquipmentModel>().WithOne(b => b.AreaLinked).HasForeignKey(b => b.AreaId).OnDelete(DeleteBehavior.Cascade);

        }
    }
}
