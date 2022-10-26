using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaqamliAvlod.Domain.Common
{
    public class Auditable : BaseEntity
    {
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
