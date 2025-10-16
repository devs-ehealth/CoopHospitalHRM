using CoopHospitalHRM.Models.Entities;

namespace CoopHospitalHRM.Services
{
    public interface IEmployeeService
    {
        Task<List<Employee>> GetAllEmployeesAsync();
        Task<Employee> GetEmployeeByIdAsync(int id);
        Task CreateEmployeeAsync(Employee employee);
        Task UpdateEmployeeAsync(Employee employee);
        Task DeleteEmployeeAsync(int id);
        Task<List<Department>> GetDepartmentsAsync();
        Task<List<Designation>> GetDesignationsAsync();
    }
}
