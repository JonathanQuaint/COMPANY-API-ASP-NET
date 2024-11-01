using CompanyAPI.Repository.Area;
using CompanyAPI.Repository.Branch;
using CompanyAPI.Repository.Company;
using CompanyAPI.Repository.Employee;
using CompanyAPI.Repository.Equipment;
using CompanyAPI.Services.Area;
using CompanyAPI.Services.Branch;
using CompanyAPI.Services.Company;
using CompanyAPI.Services.Employee;
using CompanyAPI.Services.Equipment;

namespace CompanyAPI.Extensions
{
    public static class Extensions
    {
        public static IServiceCollection AddExtensionsServices(this IServiceCollection services)
        {
            services.AddScoped<IBranchService, BranchService>();
            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddScoped<IBranchRepository, BranchRepository>();
            services.AddScoped<ICompanyInterface, CompanyService>();
            services.AddScoped<IAreaRepository, AreaRepository>();
            services.AddScoped<IAreaInterface, AreaService>();
            services.AddScoped<IEquipmentRepository, EquipmentRepository>();
            services.AddScoped<IEquipmentInterface, EquipmentService>();
            services.AddScoped<IEmployeeInterface, EmployeeService>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<ICompanyInterface, CompanyService>();

            return services;
        }
    }
}
