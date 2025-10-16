using CoopHospitalHRM.Models.Entities;
using CoopHospitalHRM.Services;
using HospitalHRM.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using System.Threading.Tasks;

namespace CoopHospitalHRM.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public async Task<IActionResult> Index()
        {
            var employees = await _employeeService.GetAllEmployeesAsync();
            return View(employees);
        }

        public async Task<IActionResult> Create()
        {
            var departments = await _employeeService.GetDepartmentsAsync();
            var designations = await _employeeService.GetDesignationsAsync();

            var model = new EmployeeVM
            {
                Departments = departments.Select(d => new SelectListItem
                {
                    Value = d.DepartmentID.ToString(),
                    Text = d.DepartmentName
                }).ToList(),

                Designations = designations.Select(des => new SelectListItem
                {
                    Value = des.DesignationID.ToString(),
                    Text = des.DesignationName
                }).ToList()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(EmployeeVM model)
        {
            if (ModelState.IsValid)
            {
                var employee = new Employee
                {
                    EmployeeCode = model.EmployeeCode,
                    FullName = model.FullName,
                    NIC = model.NIC,
                    DOB = model.DOB,
                    Gender = model.Gender,
                    Email = model.Email,
                    Phone = model.Phone,
                    Address = model.Address,
                    JoinDate = model.JoinDate,
                    DepartmentID = model.DepartmentID,
                    DesignationID = model.DesignationID,
                    GradeID = model.GradeID,
                    EmployeeCategoryID = model.EmployeeCategoryID,
                    WorkScheduleID = model.WorkScheduleID,
                    MedicalLicenseNo = model.MedicalLicenseNo,
                    Specialization = model.Specialization,
                    YearsOfExperience = model.YearsOfExperience,
                    EmergencyContact = model.EmergencyContact,
                    EmergencyPhone = model.EmergencyPhone,
                    BloodGroup = model.BloodGroup,
                    BankAccountNumber = model.BankAccountNumber,
                    BankName = model.BankName,
                    BranchName = model.BranchName,
                    Status = model.Status
                };

                await _employeeService.CreateEmployeeAsync(employee);
                return RedirectToAction(nameof(Index));
            }

            // If model validation fails, re-populate dropdowns
            model.Departments = (await _employeeService.GetDepartmentsAsync())
                .Select(d => new SelectListItem
                {
                    Value = d.DepartmentID.ToString(),
                    Text = d.DepartmentName
                }).ToList();

            model.Designations = (await _employeeService.GetDesignationsAsync())
                .Select(des => new SelectListItem
                {
                    Value = des.DesignationID.ToString(),
                    Text = des.DesignationName
                }).ToList();

            return View(model);
        }
    }
}
