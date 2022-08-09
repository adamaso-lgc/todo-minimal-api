using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Todo.Api.Endpoints
{
    public class TodoDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Note { get; set; }
        public bool Done { get; set; }
        public DateTime LimitDate { get; set; }

        // public TodoDto(int id, string title, string note, bool done, DateTime limitDate)
        // {
        //     Id = id;
        //     Title = title;
        //     Note = note;
        //     Done = done;
        //     LimitDate = limitDate;
        // }
    }
}