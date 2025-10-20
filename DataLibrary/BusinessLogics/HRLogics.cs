using CoopHospitalHRM.DataLibrary.DataAccess;
using CoopHospitalHRM.Models.ViewModels;
using Dapper;

namespace CoopHospitalHRM.DataLibrary.BusinessLogics
{
    public class HRLogics
    {

        public List<EmployeeDetailVM> EmpDetails()
        {
            string sql = "SELECT e.EmployeeID, e.EmployeeCode, e.FullName, e.InitialName, e.NIC, e.DOB, e.Gender, e.Email, e.Phone, e.Address, e.JoinDate, dep.DepartmentName, d.DesignationName, ec.CategoryName AS EmployeeCategoryName, ws.ScheduleName AS WorkScheduleName, sg.GradeName, e.MedicalLicenseNo, e.Specialization, e.YearsOfExperience, e.EmergencyContact, e.EmergencyPhone, e.BloodGroup, e.BankAccountNumber, e.BankName, e.BranchName, e.Status, DATEDIFF(YEAR, e.DOB, GETDATE()) AS Age, DATEDIFF(YEAR, e.JoinDate, GETDATE()) AS YearsOfService FROM HR_Employees e LEFT JOIN HR_Departments dep ON e.DepartmentID = dep.DepartmentID LEFT JOIN HR_Designations d ON e.DesignationID = d.DesignationID LEFT JOIN HR_EmployeeCategories ec ON e.EmployeeCategoryID = ec.EmployeeCategoryID LEFT JOIN HR_WorkSchedules ws ON e.WorkScheduleID = ws.WorkScheduleID LEFT JOIN HR_SalaryGrades sg ON e.GradeID = sg.GradeID";
            // Implement business logic here
            return new SQLDataAccess.LoadData<EmployeeDetailVM>(sql);
        }
        public void createEmp()
        {
            string sql = "SELECT e.EmployeeID, e.EmployeeCode, e.FullName, e.InitialName, e.NIC, e.DOB, e.Gender, e.Email, e.Phone, e.Address, e.JoinDate, dep.DepartmentName, d.DesignationName, ec.CategoryName AS EmployeeCategoryName, ws.ScheduleName AS WorkScheduleName, sg.GradeName, e.MedicalLicenseNo, e.Specialization, e.YearsOfExperience, e.EmergencyContact, e.EmergencyPhone, e.BloodGroup, e.BankAccountNumber, e.BankName, e.BranchName, e.Status, DATEDIFF(YEAR, e.DOB, GETDATE()) AS Age, DATEDIFF(YEAR, e.JoinDate, GETDATE()) AS YearsOfService FROM HR_Employees e LEFT JOIN HR_Departments dep ON e.DepartmentID = dep.DepartmentID LEFT JOIN HR_Designations d ON e.DesignationID = d.DesignationID LEFT JOIN HR_EmployeeCategories ec ON e.EmployeeCategoryID = ec.EmployeeCategoryID LEFT JOIN HR_WorkSchedules ws ON e.WorkScheduleID = ws.WorkScheduleID LEFT JOIN HR_SalaryGrades sg ON e.GradeID = sg.GradeID";
          
         new SQLDataAccess().SaveData(sql);
        }
    }
}
