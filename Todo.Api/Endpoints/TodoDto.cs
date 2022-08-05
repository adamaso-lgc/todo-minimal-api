using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Todo.Api.Endpoints
{
    public class TodoDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Note { get; set; }
        public bool Done { get; set; }
        public DateTime LimitDate { get; set; }
    }
}