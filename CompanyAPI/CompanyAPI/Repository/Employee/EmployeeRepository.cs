using CompanyAPI.Data;
using CompanyAPI.Services.Exceptions;
using CompanyAPI.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace CompanyAPI.Repository.Employee
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _context;

        public EmployeeRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddEmployeeAsync(EmployeeModel employee)
        {
            if (!await CheckAreaExistByIdAsync(employee.AreaId))
            {
                throw new NotFoundException("Id of the area not found");
            }
            var areaLinked = await _context.Areas.FindAsync(employee.AreaId);

            if (areaLinked != null)
            {
                employee.AreaLinked = areaLinked;
                areaLinked.Employees.Add(employee);
            }

            await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateEmployeeAsync(EmployeeModel employee)
        {
            if (!await CheckAreaExistByIdAsync(employee.AreaId))
            {
                throw new NotFoundException("Id of the area not found");
            }

            if (employee.AreaLinked == null)
            {
                throw new InvalidOperationException("AreaLinked property cannot be null");
            }

            bool areaIsSimilar = employee.AreaId == employee.AreaLinked.Id;

            if (!areaIsSimilar)
            {
                var currentArea = await _context.Areas.FindAsync(employee.AreaLinked.Id);
                if (currentArea == null)
                {
                    throw new NotFoundException("Current linked area not found");
                }

                currentArea.Employees.Remove(employee);

                employee.AreaLinked = await _context.Areas.FindAsync(employee.AreaId);
                if (employee.AreaLinked == null)
                {
                    throw new NotFoundException("New linked area not found");
                }
            }

            _context.Employees.Update(employee);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteEmployeeAsync(EmployeeModel employee)
        {
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
        }

        public async Task<List<EmployeeModel>> GetAllEmployeesAsync()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<EmployeeModel> GetEmployeeByIdAsync(int employeeId)
        {
            return await _context.Employees.FindAsync(employeeId);
        }

        public async Task<List<EmployeeModel>> GetEmployeesInAreaAsync(int areaId)
        {
            return await _context.Employees.Where(e => e.AreaId == areaId).ToListAsync();
        }

        public async Task<bool> CheckEmployeeExistByIdAsync(int employeeId)
        {
            return await _context.Employees.AnyAsync(e => e.Id == employeeId);
        }

        public async Task<EmployeeModel> GetAllDetailsAboutEmployeeAsync(int employeeId)
        {
            return await _context.Employees
                .Include(e => e.AreaLinked)
                .FirstOrDefaultAsync(e => e.Id == employeeId);
        }

        public async Task<bool> CheckAreaExistByIdAsync(int areaId)
        {
            return await _context.Areas.AnyAsync(a => a.Id == areaId);
        }
    }
}
