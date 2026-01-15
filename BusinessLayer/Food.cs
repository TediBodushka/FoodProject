using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class Food
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = null!;

        [Required]
        [Range(0, int.MaxValue)]
        public int Quantity { get; set; }

        [Required]
        public double Price { get; set; }

        public int? UserId { get; set; }
        public User? User { get; set; }

        public Food() { }

        public Food(string name, int quantity, double price, int? userId = null)
        {
            Name = name;
            Quantity = quantity;
            Price = price;
            UserId = userId;
        }
    }
}
