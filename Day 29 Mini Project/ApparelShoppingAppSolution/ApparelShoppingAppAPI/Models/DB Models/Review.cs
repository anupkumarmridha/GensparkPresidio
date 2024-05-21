using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ApparelShoppingAppAPI.Models.DB_Models
{
    public class Review
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ReviewId { get; set; }

        [Required]
        public int ProductId { get; set; }

        [Required]
        public int CustomerId { get; set; }

        [Required]
        public int Rating { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Comment { get; set; }

        [Required]
        public DateTime ReviewDate { get; set; } = DateTime.Now;

        // Navigation properties
        public virtual Product? Product { get; set; }
        public virtual Customer? Customer { get; set; }
    }
}
