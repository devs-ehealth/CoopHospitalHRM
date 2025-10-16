using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoopHospitalHRM.Migrations
{
    /// <inheritdoc />
    public partial class CreateHRTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HR_Departments",
                columns: table => new
                {
                    DepartmentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    DepartmentName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DepartmentType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HR_Departments", x => x.DepartmentID);
                });

            migrationBuilder.CreateTable(
                name: "HR_EmployeeCategories",
                columns: table => new
                {
                    EmployeeCategoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CategoryType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HR_EmployeeCategories", x => x.EmployeeCategoryID);
                });

            migrationBuilder.CreateTable(
                name: "HR_HospitalAllowances",
                columns: table => new
                {
                    AllowanceID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AllowanceName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    AllowanceCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    AllowanceType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ApplicableTo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    IsTaxable = table.Column<bool>(type: "bit", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HR_HospitalAllowances", x => x.AllowanceID);
                });

            migrationBuilder.CreateTable(
                name: "HR_LeaveTypes",
                columns: table => new
                {
                    LeaveTypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    AnnualLimit = table.Column<int>(type: "int", nullable: true),
                    CanCarryForward = table.Column<bool>(type: "bit", nullable: true),
                    MaxCarryForward = table.Column<int>(type: "int", nullable: true),
                    RequiresApproval = table.Column<bool>(type: "bit", nullable: true),
                    ColorCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HR_LeaveTypes", x => x.LeaveTypeID);
                });

            migrationBuilder.CreateTable(
                name: "HR_SalaryGrades",
                columns: table => new
                {
                    GradeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GradeName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BasicSalary = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HR_SalaryGrades", x => x.GradeID);
                });

            migrationBuilder.CreateTable(
                name: "HR_SystemRoles",
                columns: table => new
                {
                    RoleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    RoleType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HR_SystemRoles", x => x.RoleID);
                });

            migrationBuilder.CreateTable(
                name: "HR_WorkSchedules",
                columns: table => new
                {
                    WorkScheduleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ScheduleName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ScheduleType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    StartTime = table.Column<TimeSpan>(type: "time", nullable: true),
                    EndTime = table.Column<TimeSpan>(type: "time", nullable: true),
                    BreakMinutes = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HR_WorkSchedules", x => x.WorkScheduleID);
                });

            migrationBuilder.CreateTable(
                name: "HR_Designations",
                columns: table => new
                {
                    DesignationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DesignationName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    EmployeeCategoryID = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HR_Designations", x => x.DesignationID);
                    table.ForeignKey(
                        name: "FK_HR_Designations_HR_EmployeeCategories_EmployeeCategoryID",
                        column: x => x.EmployeeCategoryID,
                        principalTable: "HR_EmployeeCategories",
                        principalColumn: "EmployeeCategoryID");
                });

            migrationBuilder.CreateTable(
                name: "HR_Employees",
                columns: table => new
                {
                    EmployeeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    InitialName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    NIC = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    JoinDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DepartmentID = table.Column<int>(type: "int", nullable: true),
                    DesignationID = table.Column<int>(type: "int", nullable: true),
                    GradeID = table.Column<int>(type: "int", nullable: true),
                    EmployeeCategoryID = table.Column<int>(type: "int", nullable: true),
                    WorkScheduleID = table.Column<int>(type: "int", nullable: true),
                    MedicalLicenseNo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Specialization = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    YearsOfExperience = table.Column<int>(type: "int", nullable: true),
                    EmergencyContact = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    EmergencyPhone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    BloodGroup = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    BankAccountNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BankName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    BranchName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValue: "Active"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HR_Employees", x => x.EmployeeID);
                    table.ForeignKey(
                        name: "FK_HR_Employees_HR_Departments_DepartmentID",
                        column: x => x.DepartmentID,
                        principalTable: "HR_Departments",
                        principalColumn: "DepartmentID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HR_Employees_HR_Designations_DesignationID",
                        column: x => x.DesignationID,
                        principalTable: "HR_Designations",
                        principalColumn: "DesignationID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HR_Employees_HR_EmployeeCategories_EmployeeCategoryID",
                        column: x => x.EmployeeCategoryID,
                        principalTable: "HR_EmployeeCategories",
                        principalColumn: "EmployeeCategoryID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HR_Employees_HR_SalaryGrades_GradeID",
                        column: x => x.GradeID,
                        principalTable: "HR_SalaryGrades",
                        principalColumn: "GradeID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HR_Employees_HR_WorkSchedules_WorkScheduleID",
                        column: x => x.WorkScheduleID,
                        principalTable: "HR_WorkSchedules",
                        principalColumn: "WorkScheduleID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HR_Attendance",
                columns: table => new
                {
                    AttendanceID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeID = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ClockIn = table.Column<TimeSpan>(type: "time", nullable: true),
                    ClockOut = table.Column<TimeSpan>(type: "time", nullable: true),
                    ShiftIn = table.Column<TimeSpan>(type: "time", nullable: true),
                    ShiftOut = table.Column<TimeSpan>(type: "time", nullable: true),
                    LunchStart = table.Column<TimeSpan>(type: "time", nullable: true),
                    LunchEnd = table.Column<TimeSpan>(type: "time", nullable: true),
                    TotalHours = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    OvertimeHours = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    ShiftType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    WardName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsOnCall = table.Column<bool>(type: "bit", nullable: true),
                    OnCallHours = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    AttendanceType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValue: "Present"),
                    IsManualEntry = table.Column<bool>(type: "bit", nullable: true),
                    ApprovedBy = table.Column<int>(type: "int", nullable: true),
                    Comments = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HR_Attendance", x => x.AttendanceID);
                    table.ForeignKey(
                        name: "FK_HR_Attendance_HR_Employees_ApprovedBy",
                        column: x => x.ApprovedBy,
                        principalTable: "HR_Employees",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HR_Attendance_HR_Employees_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "HR_Employees",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HR_EmployeeAllowances",
                columns: table => new
                {
                    EmployeeAllowanceID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeID = table.Column<int>(type: "int", nullable: false),
                    AllowanceID = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    EffectiveDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HR_EmployeeAllowances", x => x.EmployeeAllowanceID);
                    table.ForeignKey(
                        name: "FK_HR_EmployeeAllowances_HR_Employees_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "HR_Employees",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HR_EmployeeAllowances_HR_HospitalAllowances_AllowanceID",
                        column: x => x.AllowanceID,
                        principalTable: "HR_HospitalAllowances",
                        principalColumn: "AllowanceID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HR_EmployeePerformance",
                columns: table => new
                {
                    PerformanceID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeID = table.Column<int>(type: "int", nullable: false),
                    ReviewDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ReviewerID = table.Column<int>(type: "int", nullable: false),
                    PerformanceRating = table.Column<decimal>(type: "decimal(3,2)", nullable: true),
                    Comments = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Goals = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HR_EmployeePerformance", x => x.PerformanceID);
                    table.ForeignKey(
                        name: "FK_HR_EmployeePerformance_HR_Employees_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "HR_Employees",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HR_EmployeePerformance_HR_Employees_ReviewerID",
                        column: x => x.ReviewerID,
                        principalTable: "HR_Employees",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HR_EPFETFInfo",
                columns: table => new
                {
                    EPFETFID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeID = table.Column<int>(type: "int", nullable: false),
                    EPFNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ETFNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EPFPercentage = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    ETFPercentage = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    EffectiveDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HR_EPFETFInfo", x => x.EPFETFID);
                    table.ForeignKey(
                        name: "FK_HR_EPFETFInfo_HR_Employees_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "HR_Employees",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HR_LeaveBalances",
                columns: table => new
                {
                    LeaveBalanceID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeID = table.Column<int>(type: "int", nullable: false),
                    LeaveTypeID = table.Column<int>(type: "int", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: true),
                    TotalEntitlement = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    Used = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    Balance = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    CarriedForward = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HR_LeaveBalances", x => x.LeaveBalanceID);
                    table.ForeignKey(
                        name: "FK_HR_LeaveBalances_HR_Employees_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "HR_Employees",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HR_LeaveBalances_HR_LeaveTypes_LeaveTypeID",
                        column: x => x.LeaveTypeID,
                        principalTable: "HR_LeaveTypes",
                        principalColumn: "LeaveTypeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HR_Leaves",
                columns: table => new
                {
                    LeaveID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeID = table.Column<int>(type: "int", nullable: false),
                    LeaveTypeID = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TotalDays = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    Reason = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValue: "Pending"),
                    AppliedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ApprovedBy = table.Column<int>(type: "int", nullable: true),
                    ApprovedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RejectionReason = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HR_Leaves", x => x.LeaveID);
                    table.ForeignKey(
                        name: "FK_HR_Leaves_HR_Employees_ApprovedBy",
                        column: x => x.ApprovedBy,
                        principalTable: "HR_Employees",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HR_Leaves_HR_Employees_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "HR_Employees",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HR_Leaves_HR_LeaveTypes_LeaveTypeID",
                        column: x => x.LeaveTypeID,
                        principalTable: "HR_LeaveTypes",
                        principalColumn: "LeaveTypeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HR_Loans",
                columns: table => new
                {
                    LoanID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeID = table.Column<int>(type: "int", nullable: false),
                    LoanAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    EMIAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TotalInstallments = table.Column<int>(type: "int", nullable: true),
                    InstallmentsPaid = table.Column<int>(type: "int", nullable: true),
                    LoanStartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LoanEndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HR_Loans", x => x.LoanID);
                    table.ForeignKey(
                        name: "FK_HR_Loans_HR_Employees_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "HR_Employees",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HR_MedicalQualifications",
                columns: table => new
                {
                    QualificationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeID = table.Column<int>(type: "int", nullable: false),
                    DegreeName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    University = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    YearCompleted = table.Column<int>(type: "int", nullable: true),
                    RegistrationNo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Specialization = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HR_MedicalQualifications", x => x.QualificationID);
                    table.ForeignKey(
                        name: "FK_HR_MedicalQualifications_HR_Employees_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "HR_Employees",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HR_OnCallSchedule",
                columns: table => new
                {
                    OnCallID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeID = table.Column<int>(type: "int", nullable: false),
                    OnCallDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StartTime = table.Column<TimeSpan>(type: "time", nullable: true),
                    EndTime = table.Column<TimeSpan>(type: "time", nullable: true),
                    DepartmentID = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HR_OnCallSchedule", x => x.OnCallID);
                    table.ForeignKey(
                        name: "FK_HR_OnCallSchedule_HR_Departments_DepartmentID",
                        column: x => x.DepartmentID,
                        principalTable: "HR_Departments",
                        principalColumn: "DepartmentID");
                    table.ForeignKey(
                        name: "FK_HR_OnCallSchedule_HR_Employees_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "HR_Employees",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HR_Payrolls",
                columns: table => new
                {
                    PayrollID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeID = table.Column<int>(type: "int", nullable: false),
                    PayPeriodStart = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PayPeriodEnd = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BasicSalary = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    Allowances = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Bonuses = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Deductions = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    NetPay = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    GeneratedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HR_Payrolls", x => x.PayrollID);
                    table.ForeignKey(
                        name: "FK_HR_Payrolls_HR_Employees_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "HR_Employees",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HR_SalaryStructures",
                columns: table => new
                {
                    SalaryStructureID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeID = table.Column<int>(type: "int", nullable: false),
                    BasicSalary = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    FixedAllowances = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    MedicalAllowance = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TransportAllowance = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    OtherAllowances = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    GradeID = table.Column<int>(type: "int", nullable: true),
                    EffectiveDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HR_SalaryStructures", x => x.SalaryStructureID);
                    table.ForeignKey(
                        name: "FK_HR_SalaryStructures_HR_Employees_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "HR_Employees",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HR_SalaryStructures_HR_SalaryGrades_GradeID",
                        column: x => x.GradeID,
                        principalTable: "HR_SalaryGrades",
                        principalColumn: "GradeID");
                });

            migrationBuilder.CreateTable(
                name: "HR_SystemUsers",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeID = table.Column<int>(type: "int", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PasswordHash = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    RoleID = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    LastLogin = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HR_SystemUsers", x => x.UserID);
                    table.ForeignKey(
                        name: "FK_HR_SystemUsers_HR_Employees_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "HR_Employees",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HR_SystemUsers_HR_SystemRoles_RoleID",
                        column: x => x.RoleID,
                        principalTable: "HR_SystemRoles",
                        principalColumn: "RoleID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HR_WardAssignments",
                columns: table => new
                {
                    AssignmentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeID = table.Column<int>(type: "int", nullable: false),
                    WardName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    AssignmentDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Shift = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HR_WardAssignments", x => x.AssignmentID);
                    table.ForeignKey(
                        name: "FK_HR_WardAssignments_HR_Employees_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "HR_Employees",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HR_EPFContributions",
                columns: table => new
                {
                    ContributionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PayrollID = table.Column<int>(type: "int", nullable: false),
                    EmployeeContribution = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    EmployerContribution = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TotalContribution = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ContributionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HR_EPFContributions", x => x.ContributionID);
                    table.ForeignKey(
                        name: "FK_HR_EPFContributions_HR_Payrolls_PayrollID",
                        column: x => x.PayrollID,
                        principalTable: "HR_Payrolls",
                        principalColumn: "PayrollID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HR_ETFContributions",
                columns: table => new
                {
                    ContributionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PayrollID = table.Column<int>(type: "int", nullable: false),
                    EmployerContribution = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ContributionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HR_ETFContributions", x => x.ContributionID);
                    table.ForeignKey(
                        name: "FK_HR_ETFContributions_HR_Payrolls_PayrollID",
                        column: x => x.PayrollID,
                        principalTable: "HR_Payrolls",
                        principalColumn: "PayrollID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HR_PayrollTransactions",
                columns: table => new
                {
                    TransactionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PayrollID = table.Column<int>(type: "int", nullable: false),
                    TransactionType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Reference = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HR_PayrollTransactions", x => x.TransactionID);
                    table.ForeignKey(
                        name: "FK_HR_PayrollTransactions_HR_Payrolls_PayrollID",
                        column: x => x.PayrollID,
                        principalTable: "HR_Payrolls",
                        principalColumn: "PayrollID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HR_Attendance_ApprovedBy",
                table: "HR_Attendance",
                column: "ApprovedBy");

            migrationBuilder.CreateIndex(
                name: "IX_HR_Attendance_EmployeeID",
                table: "HR_Attendance",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_HR_Designations_EmployeeCategoryID",
                table: "HR_Designations",
                column: "EmployeeCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_HR_EmployeeAllowances_AllowanceID",
                table: "HR_EmployeeAllowances",
                column: "AllowanceID");

            migrationBuilder.CreateIndex(
                name: "IX_HR_EmployeeAllowances_EmployeeID",
                table: "HR_EmployeeAllowances",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_HR_EmployeePerformance_EmployeeID",
                table: "HR_EmployeePerformance",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_HR_EmployeePerformance_ReviewerID",
                table: "HR_EmployeePerformance",
                column: "ReviewerID");

            migrationBuilder.CreateIndex(
                name: "IX_HR_Employees_DepartmentID",
                table: "HR_Employees",
                column: "DepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_HR_Employees_DesignationID",
                table: "HR_Employees",
                column: "DesignationID");

            migrationBuilder.CreateIndex(
                name: "IX_HR_Employees_Email",
                table: "HR_Employees",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_HR_Employees_EmployeeCategoryID",
                table: "HR_Employees",
                column: "EmployeeCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_HR_Employees_EmployeeCode",
                table: "HR_Employees",
                column: "EmployeeCode",
                unique: true,
                filter: "[EmployeeCode] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_HR_Employees_GradeID",
                table: "HR_Employees",
                column: "GradeID");

            migrationBuilder.CreateIndex(
                name: "IX_HR_Employees_NIC",
                table: "HR_Employees",
                column: "NIC",
                unique: true,
                filter: "[NIC] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_HR_Employees_WorkScheduleID",
                table: "HR_Employees",
                column: "WorkScheduleID");

            migrationBuilder.CreateIndex(
                name: "IX_HR_EPFContributions_PayrollID",
                table: "HR_EPFContributions",
                column: "PayrollID");

            migrationBuilder.CreateIndex(
                name: "IX_HR_EPFETFInfo_EmployeeID",
                table: "HR_EPFETFInfo",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_HR_ETFContributions_PayrollID",
                table: "HR_ETFContributions",
                column: "PayrollID");

            migrationBuilder.CreateIndex(
                name: "IX_HR_LeaveBalances_EmployeeID_LeaveTypeID_Year",
                table: "HR_LeaveBalances",
                columns: new[] { "EmployeeID", "LeaveTypeID", "Year" },
                unique: true,
                filter: "[Year] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_HR_LeaveBalances_LeaveTypeID",
                table: "HR_LeaveBalances",
                column: "LeaveTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_HR_Leaves_ApprovedBy",
                table: "HR_Leaves",
                column: "ApprovedBy");

            migrationBuilder.CreateIndex(
                name: "IX_HR_Leaves_EmployeeID",
                table: "HR_Leaves",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_HR_Leaves_LeaveTypeID",
                table: "HR_Leaves",
                column: "LeaveTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_HR_Loans_EmployeeID",
                table: "HR_Loans",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_HR_MedicalQualifications_EmployeeID",
                table: "HR_MedicalQualifications",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_HR_OnCallSchedule_DepartmentID",
                table: "HR_OnCallSchedule",
                column: "DepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_HR_OnCallSchedule_EmployeeID",
                table: "HR_OnCallSchedule",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_HR_Payrolls_EmployeeID",
                table: "HR_Payrolls",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_HR_PayrollTransactions_PayrollID",
                table: "HR_PayrollTransactions",
                column: "PayrollID");

            migrationBuilder.CreateIndex(
                name: "IX_HR_SalaryStructures_EmployeeID",
                table: "HR_SalaryStructures",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_HR_SalaryStructures_GradeID",
                table: "HR_SalaryStructures",
                column: "GradeID");

            migrationBuilder.CreateIndex(
                name: "IX_HR_SystemUsers_EmployeeID",
                table: "HR_SystemUsers",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_HR_SystemUsers_RoleID",
                table: "HR_SystemUsers",
                column: "RoleID");

            migrationBuilder.CreateIndex(
                name: "IX_HR_WardAssignments_EmployeeID",
                table: "HR_WardAssignments",
                column: "EmployeeID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HR_Attendance");

            migrationBuilder.DropTable(
                name: "HR_EmployeeAllowances");

            migrationBuilder.DropTable(
                name: "HR_EmployeePerformance");

            migrationBuilder.DropTable(
                name: "HR_EPFContributions");

            migrationBuilder.DropTable(
                name: "HR_EPFETFInfo");

            migrationBuilder.DropTable(
                name: "HR_ETFContributions");

            migrationBuilder.DropTable(
                name: "HR_LeaveBalances");

            migrationBuilder.DropTable(
                name: "HR_Leaves");

            migrationBuilder.DropTable(
                name: "HR_Loans");

            migrationBuilder.DropTable(
                name: "HR_MedicalQualifications");

            migrationBuilder.DropTable(
                name: "HR_OnCallSchedule");

            migrationBuilder.DropTable(
                name: "HR_PayrollTransactions");

            migrationBuilder.DropTable(
                name: "HR_SalaryStructures");

            migrationBuilder.DropTable(
                name: "HR_SystemUsers");

            migrationBuilder.DropTable(
                name: "HR_WardAssignments");

            migrationBuilder.DropTable(
                name: "HR_HospitalAllowances");

            migrationBuilder.DropTable(
                name: "HR_LeaveTypes");

            migrationBuilder.DropTable(
                name: "HR_Payrolls");

            migrationBuilder.DropTable(
                name: "HR_SystemRoles");

            migrationBuilder.DropTable(
                name: "HR_Employees");

            migrationBuilder.DropTable(
                name: "HR_Departments");

            migrationBuilder.DropTable(
                name: "HR_Designations");

            migrationBuilder.DropTable(
                name: "HR_SalaryGrades");

            migrationBuilder.DropTable(
                name: "HR_WorkSchedules");

            migrationBuilder.DropTable(
                name: "HR_EmployeeCategories");
        }
    }
}
