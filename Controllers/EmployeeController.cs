using Microsoft.AspNetCore.Mvc;
using CoopHospitalHRM.Models.ViewModels;
using CoopHospitalHRM.DataLibrary.BusinessLogics;

namespace CoopHospitalHRM.Controllers
{
    public class EmployeeController : Controller
    {
       

        

        // GET: Employee/Index
        public async Task<IActionResult> Index(string searchTerm, string departmentFilter, string statusFilter, int page = 1, int pageSize = 10)
        {
            try
            {
                var emp = new HRLogics().EmpDetails();
                return View(emp);
            }
            catch (Exception ex)
            {
                
                TempData["ErrorMessage"] = "Error loading employees. Please try again.";
                return View(new EmployeeListVM { Employees = new List<EmployeeListVM>() });
            }
        }

        // GET: Employee/Details/5
        //public async Task<IActionResult> Details(int id)
        //{
        //    try
        //    {
        //        var employee = await _employeeService.GetEmployeeDetailAsync(id);

        //        if (employee == null)
        //        {
        //            return NotFound();
        //        }
        //        return View(employee);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex, "Error loading employee details for ID {EmployeeId}", id);
        //        TempData["ErrorMessage"] = "Error loading employee details.";
        //        return RedirectToAction(nameof(Index));
        //    }
        //}

        //// GET: Employee Statistics for Dashboard
        //[HttpGet]
        //public async Task<JsonResult> GetEmployeeStats()
        //{
        //    try
        //    {
        //        var stats = await _employeeService.GetEmployeeStatsAsync();
        //        return Json(stats);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex, "Error getting employee statistics");
        //        return Json(new EmployeeStatsVM());
        //    }
        //}

        //// GET: Employee/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Employee/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create(EmployeeVM employee)
        //{
        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            var result = await _employeeService.CreateEmployeeAsync(employee);
        //            if (result)
        //            {
        //                TempData["SuccessMessage"] = "Employee created successfully!";
        //                return RedirectToAction(nameof(Index));
        //            }
        //            TempData["ErrorMessage"] = "Error creating employee.";
        //        }
        //        return View(employee);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex, "Error creating employee");
        //        TempData["ErrorMessage"] = "Error creating employee. Please try again.";
        //        return View(employee);
        //    }
        //}

        //// GET: Employee/Edit/5
        //public async Task<IActionResult> Edit(int id)
        //{
        //    try
        //    {
        //        var employee = await _employeeService.GetEmployeeDetailAsync(id);
        //        if (employee == null)
        //        {
        //            return NotFound();
        //        }
        //        // Convert to EmployeeVM (you'll need mapping logic here)
        //        var employeeVM = new EmployeeVM
        //        {
        //            EmployeeID = employee.EmployeeID,
        //            EmployeeCode = employee.EmployeeCode,
        //            FullName = employee.FullName,
        //            // ... map other properties
        //        };
        //        return View(employeeVM);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex, "Error loading employee for edit");
        //        TempData["ErrorMessage"] = "Error loading employee.";
        //        return RedirectToAction(nameof(Index));
        //    }
        //}

        //// POST: Employee/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, EmployeeVM employee)
        //{
        //    try
        //    {
        //        if (id != employee.EmployeeID)
        //        {
        //            return NotFound();
        //        }

        //        if (ModelState.IsValid)
        //        {
        //            var result = await _employeeService.UpdateEmployeeAsync(employee);
        //            if (result)
        //            {
        //                TempData["SuccessMessage"] = "Employee updated successfully!";
        //                return RedirectToAction(nameof(Index));
        //            }
        //            TempData["ErrorMessage"] = "Error updating employee.";
        //        }
        //        return View(employee);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex, "Error updating employee");
        //        TempData["ErrorMessage"] = "Error updating employee. Please try again.";
        //        return View(employee);
        //    }
        //}
    }
}