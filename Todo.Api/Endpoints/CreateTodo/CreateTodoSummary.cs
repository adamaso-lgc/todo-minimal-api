using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FastEndpoints;
using Todo.Api.Middlewares;

namespace Todo.Api.Endpoints.CreateTodo
{
    public class CreateTodoSummary : Summary<CreateTodoEndpoint>
    {
        public CreateTodoSummary()
        {
            Summary = "Creates a new todo in the system";
            Description = "Creates a new todo in the system";
            Response<int>(201, "Todo was successfully created");
            Response<ValidationFailureResponse>(400, "The request did not pass validation checks");
        }
    }
}