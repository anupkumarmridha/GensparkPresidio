using EmployeeRequestTrackerAPI.Models.DBModels;

namespace EmployeeRequestTrackerAPI.Models.DTOModels
{
    public class EmployeeUserDTO : Employee
    {
        public string Password { get; set; }
    }
}
