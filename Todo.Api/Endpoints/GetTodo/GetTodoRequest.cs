using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Todo.Api.Endpoints.GetTodo
{
    public class GetTodoRequest
    {
        public Guid Id { get; init; }
    }
}