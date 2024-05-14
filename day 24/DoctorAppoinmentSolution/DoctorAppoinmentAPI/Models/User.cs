using System.ComponentModel.DataAnnotations;

namespace DoctorAppoinmentAPI.Models
{
    public enum Role
    {
        Admin,
        Doctor,
        Patient
    }

    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        [EnumDataType(typeof(Role))]
        public Role UserRole { get; set; }

        public virtual bool PasswordCheck(string password)
        {
            return this.Password == password;
        }
    }
}
