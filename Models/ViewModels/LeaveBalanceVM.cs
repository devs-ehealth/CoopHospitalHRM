namespace CoopHospitalHRM.Models.ViewModels
{
    public class LeaveBalanceVM
    {
        public string LeaveTypeName { get; set; } = string.Empty;
        public decimal TotalEntitlement { get; set; }
        public decimal Used { get; set; }
        public decimal Balance { get; set; }
        public string ColorCode { get; set; } = "#007bff";
    }

}
