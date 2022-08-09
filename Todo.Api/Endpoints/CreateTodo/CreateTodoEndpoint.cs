using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FastEndpoints;
using Microsoft.AspNetCore.Authorization;
using Todo.Api.Endpoints.GetTodo;
using Todo.Api.Repositories;
using Todo.Domain.Entities;

namespace Todo.Api.Endpoints.CreateTodo
{
    [HttpPost("todo"), AllowAnonymous]
    public class CreateTodoEndpoint : Endpoint<CreateTodoRequest, Guid>
    {
        private readonly ITodoRepository _todoRepository;

        public CreateTodoEndpoint(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        public override async Task HandleAsync(CreateTodoRequest req, CancellationToken ct) 
        {
            var todo = new TodoItem 
            {
                Title = req.Title,
                Note = req.Note,
                Done = false,
                LimitDate = req.LimitDate
            };
    
            await _todoRepository.CreateAsync(todo);

            await SendCreatedAtAsync<GetTodoEndpoint>(new { Id = todo.Id }, todo.Id, generateAbsoluteUrl: true, cancellation: ct);
        }       

    }
}