using System.ComponentModel.DataAnnotations;

namespace ApparelShoppingAppAPI.Models.DB_Models
{
    public enum Role
    {
        Customer,
        Seller,
        Admin
    }

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
        [Required]
        public Role Role { get; set; } = Role.Customer;

        //navigation property
        public virtual Customer? Customer { get; set; }


    }
}
