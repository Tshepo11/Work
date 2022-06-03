using System;

namespace StudentManagement.Domain.Entities
{
    public class BaseEntity
    {
        public DateTime? CreatedAt { get; set; } = DateTime.Now;
        public DateTime? DeletedAt { get; set; }
        public Guid Id { get; set; }
        public bool IsDeactivated { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }
    }
}