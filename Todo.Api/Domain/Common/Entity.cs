using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.Domain.Common
{
    public abstract class Entity
    {
        public Guid Id { get; init; } = Guid.NewGuid();
        public DateTime CreatedDate { get; init; } = DateTime.Now;
        public DateTime? LastModifiedDate { get; set; }

        // public Entity()
        // {
        //     CreatedDate = DateTime.Now;
        // }
    }
}
