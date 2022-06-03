using System;
using System.Collections.Generic;

namespace StudentManagement.Domain.DTOs
{
    public class UserDto : BaseDto
    {
        public int AccessFailedCount { get; set; }

        public string Email { get; set; }

        public bool EmailConfirmed { get; set; }

        public bool LockoutEnabled { get; set; }

        public DateTimeOffset? LockoutEnd { get; set; }

        public bool IsActive { get; set; }

        public string PhoneNumber { get; set; }

        public bool PhoneNumberConfirmed { get; set; }

        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
