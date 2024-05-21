using System.ComponentModel.DataAnnotations;

namespace EmployeeRequestTrackerAPI.Models.DTOModels
{
    public class UserLoginDTO
    {
        [Required(ErrorMessage = "User email cannot be empty")]
        //[Range(100, 999, ErrorMessage = "Invalid entry for employee ID")]
        public string Email { get; set; } = string.Empty;

        [MinLength(6, ErrorMessage = "Password has to be minmum 6 chars long")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Password cannot be empty")]
        public string Password { get; set; } = string.Empty;
    }
}
