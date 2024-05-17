namespace EmployeeRequestTrackerAPI.Models.DTOModels
{
    public class LoginReturnDTO
    {
        public int EmployeeID { get; set; }
        public string Token { get; set; }
        public string Role { get; set; }
    }
}
