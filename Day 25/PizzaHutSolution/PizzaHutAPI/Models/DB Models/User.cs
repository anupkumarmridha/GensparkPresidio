using System.ComponentModel.DataAnnotations;

namespace PizzaHutAPI.Models.DB_Models
{

    public class User
    {
        [Key]
        public int CustomerId { get; set; }

        [Required]
        public byte[] Password { get; set; }

        [Required]
        public byte[] PasswordHashKey { get; set; }

        [Required]
        public bool IsAdmin { get; set; }= false;

        //navigation property
        public virtual Customer Customer { get; set; }


    }
}
