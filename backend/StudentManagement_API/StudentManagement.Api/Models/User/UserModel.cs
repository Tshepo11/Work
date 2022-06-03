using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudentManagement.Api.Models
{
    public class UserModel : BaseModel
    {
        [Required]
        public int AccessFailedCount { get; set; }

        [EmailAddress()]
        [Required(AllowEmptyStrings = false)]
        [StringLength(50)]
        public string Email { get; set; }

        public bool EmailConfirmed { get; set; }

        public bool LockoutEnabled { get; set; }

        public DateTimeOffset? LockoutEnd { get; set; }

        public bool IsActive { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        public bool PhoneNumberConfirmed { get; set; }

        public string SecurityStamp { get; set; }

        public string UserName { get; set; }

    }
}
