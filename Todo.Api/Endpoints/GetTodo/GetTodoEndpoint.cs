using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FastEndpoints;
using Microsoft.AspNetCore.Authorization;

namespace Todo.Api.Endpoints.GetTodo
{
    [HttpGet("todo/{id}"), AllowAnonymous]
    public class GetTodoEndpoint : Endpoint<int, TodoDto>
    {
            

        public override Task HandleAsync(int req, CancellationToken ct)
        {
            return base.HandleAsync(req, ct);
        }
    }
}