using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NeonWorld.ViewModels.System.Users
{
    public class RegisterRequest
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MaxLength(10)]
        [Phone]
        public string Phone { get; set; }

        [Required]
        [MaxLength(20)]
        [MinLength(10)]
        public string Password { get; set; }
        public DateTime Dob { get; set; }
    }
}
