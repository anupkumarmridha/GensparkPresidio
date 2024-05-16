using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PizzaHutAPI.Models.DB_Models
{
    [Index(nameof(Name), IsUnique = true)]
    public class Pizza
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public double Price { get; set; }
        public string? ImageUrl { get; set; }

        //navigation property
        public virtual Stock? Stock { get; set; }

    }
}
