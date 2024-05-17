namespace EmployeeRequestTrackerAPI.Models.DTOModels
{
    public class UserActivationDTO
    {
        public string Email { get; set; } = string.Empty;
        public bool Activation { get; set; }=true;
        public bool IsAdmin { get; set; }= false;
    }
}
