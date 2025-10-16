using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoopHospitalHRM.Models;
using CoopHospitalHRM.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoopHospitalHRM.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly AppDbContext _context;

        public EmployeeService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Employee>> GetAllEmployeesAsync()
        {
            return await _context.Employee
                .Include(e => e.Department)
                .Include(e => e.Designation)
                .ToListAsync();
        }

        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {
            return await _context.Employee
                .Include(e => e.Department)
                .Include(e => e.Designation)
                .FirstOrDefaultAsync(e => e.EmployeeID == id);
        }

        public async Task CreateEmployeeAsync(Employee employee)
        {
            employee.CreatedAt = DateTime.Now;
            _context.Employee.Add(employee);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateEmployeeAsync(Employee employee)
        {
            employee.UpdatedAt = DateTime.Now;
            _context.Employee.Update(employee);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteEmployeeAsync(int id)
        {
            var employee = await _context.Employee.FindAsync(id);
            if (employee != null)
            {
                _context.Employee.Remove(employee);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Department>> GetDepartmentsAsync()
        {
            return await _context.Department.ToListAsync();
        }

        public async Task<List<Designation>> GetDesignationsAsync()
        {
            return await _context.Designation.ToListAsync();
        }
    }
}
