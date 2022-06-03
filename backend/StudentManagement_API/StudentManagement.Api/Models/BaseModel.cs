using System;

namespace StudentManagement.Api.Models
{
    public class BaseModel
    {
        public DateTime? CreatedAt { get; set; } = DateTime.Now;
        public Guid Id { get; set; }
        public bool IsDeactivated { get; set; } = false;
        public DateTime? UpdatedAt { get; set; } = DateTime.Now;
    }
}
