using System;
using System.Collections.Generic;
using System.Text;

namespace NeonWorld.ViewModels.System.Users
{
    public class RegisterRequest
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public DateTime Dob { get; set; }
    }
}
