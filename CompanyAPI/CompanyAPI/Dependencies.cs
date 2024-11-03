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
using CompanyAPI.Services.Token;

namespace CompanyAPI.Dependencies
{
    public static class Dependencies
    {
        public static IServiceCollection AddDependenciesServices(this IServiceCollection services)
        {
            services.AddScoped<ICompanyInterface, CompanyService>();
            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddScoped<IBranchService, BranchService>();       
            services.AddScoped<IBranchRepository, BranchRepository>();    
            services.AddScoped<IAreaRepository, AreaRepository>();
            services.AddScoped<IAreaInterface, AreaService>();
            services.AddScoped<IEquipmentRepository, EquipmentRepository>();
            services.AddScoped<IEquipmentInterface, EquipmentService>();
            services.AddScoped<IEmployeeInterface, EmployeeService>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<ITokenService, TokenService>();

            return services;
        }
    }
}
