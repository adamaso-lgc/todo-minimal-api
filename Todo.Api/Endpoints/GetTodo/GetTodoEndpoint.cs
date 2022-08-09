using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FastEndpoints;
using Microsoft.AspNetCore.Authorization;
using Todo.Api.Repositories;

namespace Todo.Api.Endpoints.GetTodo
{
    [HttpGet("todo/{id:guid}"), AllowAnonymous]
    public class GetTodoEndpoint : Endpoint<GetTodoRequest, TodoDto>
    {
        private readonly ITodoRepository _todoRepository;

        public GetTodoEndpoint(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        public async override Task HandleAsync(GetTodoRequest req, CancellationToken ct)
        {
            var todo = await _todoRepository.GetAsync(req.Id);

            if (todo is null)
            {
                await SendNotFoundAsync(ct);
                return;
            }

            var todoResponse = new TodoDto
            {
                Id = todo.Id,
                Title = todo.Title,
                Note = todo.Note,
                Done = todo.Done,
                LimitDate = todo.LimitDate
            };
            
            await SendOkAsync(todoResponse, ct);
        }
    }
}