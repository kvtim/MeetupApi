using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meetup.Data.Dtos.User
{
    public class RegisterUserDto
    {
        [Required]
        public string? FirstName { get; set; }

        [Required]
        public string? LastName { get; set; }

        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        [MinLength(3), MaxLength(32)]
        public string? UserName { get; set; }

        [Required]
        [MinLength(6), MaxLength(127)]
        public string? Password { get; set; }
    }
}
