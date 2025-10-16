namespace CoopHospitalHRM.Models.ViewModels
{
    public class AttendanceSummaryVM
    {
        public int PresentDays { get; set; }
        public int AbsentDays { get; set; }
        public int LateDays { get; set; }
        public decimal TotalWorkingHours { get; set; }
        public decimal AverageHoursPerDay { get; set; }
    }

}
