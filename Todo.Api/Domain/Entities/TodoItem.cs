using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Domain.Common;
using Todo.Domain.Enums;

namespace Todo.Domain.Entities
{
    public class TodoItem : Entity
    {
        public string Title { get; set; }
        public string Note { get; set; }
        public bool Done { get; set; }
        public DateTime LimitDate { get; set; }
        public PriorityLevel Priority { get; set; }
    }
}
