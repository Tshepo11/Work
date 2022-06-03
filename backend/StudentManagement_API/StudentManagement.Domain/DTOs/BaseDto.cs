using System;

namespace StudentManagement.Domain.DTOs
{
    public class BaseDto
    {
        public DateTime? CreatedAt { get; set; }
        public Guid Id { get; set; }
        public bool IsDeactivated { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
