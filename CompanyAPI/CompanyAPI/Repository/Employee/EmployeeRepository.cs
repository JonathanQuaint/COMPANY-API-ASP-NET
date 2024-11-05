using CompanyAPI.Data;
using CompanyAPI.Services.Exceptions;
using CompanyAPI.ViewModel;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;

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

            bool areaExist = await _context.Areas.AnyAsync(c => c.Id == employee.AreaId);

            if (!areaExist)
            {
                throw new NotFoundException("Area not found by Id");
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

            var branch = areaLinked.LinkedBranch; 

            areaLinked.EmployeesExpense += employee.Salary;
            areaLinked.Expense += employee.Salary;

            branch.EmployeesExpense += employee.Salary;
            branch.Expense += employee.Salary;

            employee.AreaLinked = areaLinked;

            areaLinked.Employees.Add(employee);
            branch.Employees.Add(employee);

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
            return await _context.Employees.FirstOrDefaultAsync(e =>  e.Id == employeeId);
        }

        public async Task<List<EmployeeModel>> GetEmployeesInAreaAsync(int areaId)
        {
            bool areaExist = await _context.Areas.AnyAsync(c => c.Id == areaId);

            if (!areaExist)
            {
                throw new NotFoundException("Area not found by Id");
            }

            return await _context.Employees.Where(e => e.AreaId == areaId).ToListAsync();
        }

        public async Task<List<EmployeeModel>> GetAllEmployeesInBranchAsync(int branchId)
        {
            bool branchExist = await _context.Branchs.AnyAsync(c => c.Id == branchId);

            if (!branchExist)
            {
                throw new NotFoundException("Branch not found by Id");
            }
            return await _context.Branchs
                .Where(b => b.Id == branchId)
                .SelectMany(b => b.Employees)
                .ToListAsync();
        }

        public async Task<List<EmployeeModel>> GetAllEmployeesInCompanyAsync(int companyId)
        {
            bool companyExist = await _context.Company.AnyAsync(c => c.Id == companyId);

            if (!companyExist)
            {
                throw new NotFoundException("Company not found by Id");
            }

            return await _context.Branchs
                 .Where(b => b.Id == companyId)
                .SelectMany(b => b.Employees)
                .ToListAsync();
        }


        public async Task<bool> CheckEmployeeExistByIdAsync(int employeeId)
        {
            return await _context.Employees.AnyAsync(e => e.Id == employeeId);
        }

        public async Task<EmployeeModel?> GetAllDetailsAboutEmployeeAsync(int employeeId)
        {
            var employee = await _context.Employees
                .Include(e => e.AreaLinked)
                .ThenInclude(a => a.LinkedBranch)
                .FirstOrDefaultAsync(e => e.Id == employeeId);

            if (employee == null)
            {
                throw new NotFoundException("Employee not found");
            }

            return employee;
        }

        public async Task<double> AllEmployeesExpenseInArea(int areaId)
        {
            return await _context.Areas
                .Where(x => x.Id == areaId)
                .Select(x => x.EmployeesExpense)
                .FirstOrDefaultAsync();

        }

        public async Task<double> AllEmployeesExpenseInBranch(int branchId)
        {
            return await _context.Branchs
                .Where(x => x.Id == branchId)
                .Select(x => x.EmployeesExpense)
                .FirstOrDefaultAsync();

        }

    }
}
