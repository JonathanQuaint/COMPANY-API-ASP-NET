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
            if (employee == null)
            {
                throw new ArgumentNullException(nameof(employee), "Employee cannot be null");
            }

            if (!await CheckAreaExistByIdAsync(employee.AreaId))
            {
                throw new NotFoundException("Id of the area not found");
            }

            var areaLinked = await _context.Areas
                .Include(a => a.LinkedBranch)
                .ThenInclude(b => b.Employees)
                .FirstOrDefaultAsync(a => a.Id == employee.AreaId);

            if (areaLinked == null)
            {
                throw new NotFoundException("Area not found");
            }

            if (areaLinked.LinkedBranch == null)
            {
                throw new NotFoundException("Linked branch not found");
            }

            if (areaLinked.Employees == null)
            {
                areaLinked.Employees = new List<EmployeeModel>();
            }

            if (areaLinked.LinkedBranch.Employees == null)
            {
                areaLinked.LinkedBranch.Employees = new List<EmployeeModel>();
            }

            areaLinked.EmployeesExpense += employee.Salary;
            employee.AreaLinked = areaLinked;
            areaLinked.Employees.Add(employee);
            areaLinked.LinkedBranch.Employees.Add(employee);

            await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();
        }





        public async Task UpdateEmployeeAsync(EmployeeModel employee)
        {
            var employeeExist = await _context.Employees.FindAsync(employee.Id);

            if (employeeExist == null)
            {
                throw new NotFoundException("Employee not found");
            }

            if (employeeExist.AreaId != employee.AreaId)
            {
                var newArea = await _context.Areas.Include(x => x.LinkedBranch).FirstOrDefaultAsync(a => a.Id == employee.AreaLinked.Id);

                if (newArea == null)
                {
                    throw new NotFoundException("Current linked area not found");
                }

                employeeExist.AreaLinked.Employees.Remove(employeeExist);
                employeeExist.AreaLinked.LinkedBranch.Employees.Remove(employeeExist);

                newArea.Employees.Add(employeeExist);
                newArea.LinkedBranch.Employees.Add(employeeExist);

                employeeExist.AreaLinked = newArea;
                employeeExist.AreaId = newArea.Id;
            }

            _context.Employees.Update(employeeExist);
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

        public async Task<List<EmployeeModel>> GetAllEmployeesInBranch(int branchId)
        {
            return await _context.Branchs
                .Where(b => b.Id == branchId)
                .SelectMany(b => b.Employees)
                .ToListAsync();
        }

        public async Task<List<EmployeeModel>> GetAllEmployeesInCompany(int companyId)
        {
            return await _context.Branchs
                 .Where(b => b.Id == companyId)
                .SelectMany(b => b.Employees)
                .ToListAsync();
        }


        public async Task<bool> CheckEmployeeExistByIdAsync(int employeeId)
        {
            return await _context.Employees.AnyAsync(e => e.Id == employeeId);
        }

        public async Task<EmployeeModel> GetAllDetailsAboutEmployeeAsync(int employeeId)
        {
            return await _context.Employees
                .Include(e => e.AreaLinked)
                .Include(e => e.Salary)

                .FirstOrDefaultAsync(e => e.Id == employeeId);
        }

        public async Task<bool> CheckAreaExistByIdAsync(int areaId)
        {
            return await _context.Areas.AnyAsync(a => a.Id == areaId);
        }
    } 
}
