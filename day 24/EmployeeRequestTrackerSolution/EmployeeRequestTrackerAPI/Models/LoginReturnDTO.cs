namespace EmployeeRequestTrackerAPI.Models
{
    public class LoginReturnDTO
    {
        public int EmployeeID { get; set; }
        public string Token { get; set; }
        public string Role { get; set; }
    }
}
