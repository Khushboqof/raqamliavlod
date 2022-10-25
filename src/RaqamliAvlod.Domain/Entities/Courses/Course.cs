using RaqamliAvlod.Domain.Common;
using RaqamliAvlod.Domain.Entities.Users;
using System.ComponentModel.DataAnnotations;

namespace RaqamliAvlod.Domain.Entities.Courses
{
    public class Course : Auditable
    {
        public string Title { get; set; } = String.Empty;
        public string Info { get; set; } = String.Empty;

        [MaxLength(100)]
        public string Type { get; set; } = String.Empty;

        [MaxLength(100)]
        public string ImagePath { get; set; } = String.Empty;
        public decimal Price { get; set; }
        public DateTime UpdatedAt { get; set; }

        public long OwnerId { get; set; }
        public virtual User? User { get; set; }
    }
}
