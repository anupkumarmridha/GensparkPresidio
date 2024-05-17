namespace EmployeeRequestTrackerAPI.Models.DTOModels
{
    public class ReturnUserActivationDTO
    {
        public int UserId { get; set; }
        public string Status { get; set; }
        public string Role { get; set; }
    }
}
