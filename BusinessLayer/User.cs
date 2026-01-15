using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
   public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Username { get; set; } = null!;

        [Required]
        [MaxLength(100)]
        public string Password { get; set; } = null!;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [MaxLength(20)]
        public string Telephone { get; set; } = null!;

        public User() { }

        public User(string username, string password, string email, string telephone)
        {
            Username = username;
            Password = password;
            Email = email;
            Telephone = telephone;
        }
    }
}
