﻿using System;
using System.Collections.Generic;
using System.Text;

namespace NeonWorld.ViewModels.System.Users
{
    public class UserChangePassword
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string NewPassword { get; set; }
    }
}
