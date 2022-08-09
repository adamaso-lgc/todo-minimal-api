using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using Todo.Domain.Enums;

namespace Todo.Api.Endpoints.CreateTodo
{
    public class CreateTodoRequest
    {
        public string Title { get; set; }
        public string Note { get; set; }
        public PriorityLevel Priority { get; set; }
        public DateTime LimitDate { get; set; }

        public class CreateTodoCommandValidator : AbstractValidator<CreateTodoRequest>
        {
            public CreateTodoCommandValidator()
            {
                RuleFor(v => v.Title).MaximumLength(200).NotEmpty();
                RuleFor(v => v.LimitDate).NotEmpty();
            }
        }
    }
    
}