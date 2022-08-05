using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.Domain.Common
{
    public abstract class Entity
    {
        public int Id { get; protected set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }

        public Entity()
        {
            CreatedDate = DateTime.Now;
        }
    }
}
