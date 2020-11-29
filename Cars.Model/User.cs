﻿using Cars.Model.Common;

namespace Cars.Model
{
    public class User : IUser
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
