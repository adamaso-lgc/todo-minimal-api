using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FastEndpoints;

namespace Todo.Api.Endpoints.GetTodo
{
    public class GetTodoSummary : Summary<GetTodoEndpoint>
    {
        public GetTodoSummary()
        {
            Summary = "Returns a single todo by id";
            Description = "Returns a single todo by id";
            Response<TodoDto>(200, "Successfully found and returned the todo");
            Response(404, "The todo does not exist in the system");
        }
    }
}