using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentManagement.Domain.Entities
{
    public class User : BaseEntity
    {
        [Required]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        public DateTime DOB { get; set; }

        public bool Gender { get; set; }

        public string grade { get; set; }

        public string SchoolName { get; set; }

        [Required]
        public string SchoolCode { get; set; }

    }
}
