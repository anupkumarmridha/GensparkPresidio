using DoctorAppoinmentAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace DoctorAppoinmentAPI.Controllers.InputModels
{
    public class CreateUserModel
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        [EnumDataType(typeof(Role))]
        public Role UserRole { get; set; }
    }
}
