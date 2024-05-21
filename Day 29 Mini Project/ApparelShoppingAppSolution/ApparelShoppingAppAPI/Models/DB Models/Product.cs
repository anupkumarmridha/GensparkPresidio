using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApparelShoppingAppAPI.Models.DB_Models
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

      
        [Required]
        public int Quantity { get; set; }

        [Required]
        public DateTime CreationDate { get; set; } = DateTime.Now;
        [Required]
        public DateTime LastUpdatedDate { get; set; }

        [Required]
        public double Price { get; set; }

        public string? ImageUrl { get; set; }

        [Required]
        public int CategoryId { get; set; }

        // Navigation properties
        public virtual Category? Category { get; set; }
        public virtual ICollection<Review>? Reviews { get; set; }



    }
}
