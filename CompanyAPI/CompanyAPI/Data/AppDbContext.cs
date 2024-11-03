using CompanyAPI.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace CompanyAPI.Data
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<CompanyModel> Company { get; set; }

        public DbSet<BranchModel> Branchs { get; set; }

        public DbSet<AreaModel> Areas { get; set; }

        public DbSet<EmployeeModel> Employees { get; set; }

        public DbSet<EquipmentModel> Equipments { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            List<IdentityRole> roles = new List<IdentityRole>
                {
                    new IdentityRole
                    {
                        Name = "Admin",
                        NormalizedName = "ADMIN"
                    },
                    new IdentityRole
                    {
                        Name = "User",
                        NormalizedName = "USER"
                    },
                };
            builder.Entity<IdentityRole>().HasData(roles);

            builder.Entity<CompanyModel>()
                .HasMany(c => c.Branch)
                .WithOne(b => b.CompanyLinked)
                .HasForeignKey(b => b.CompanyID)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<BranchModel>()
                .HasMany(c => c.Areas)
                .WithOne(b => b.LinkedBranch)
                .HasForeignKey(a => a.BranchId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<AreaModel>()
                .HasMany<EmployeeModel>()
                .WithOne(b => b.AreaLinked)
                .HasForeignKey(b => b.AreaId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<AreaModel>()
                .HasMany<EquipmentModel>()
                .WithOne(b => b.AreaLinked)
                .HasForeignKey(b => b.AreaId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
