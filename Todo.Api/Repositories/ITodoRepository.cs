using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Todo.Domain.Entities;

namespace Todo.Api.Repositories
{
    public interface ITodoRepository
    {
        Task<bool> CreateAsync(TodoItem todo);
        Task<TodoItem?> GetAsync(Guid id);
        Task<IEnumerable<TodoItem>> GetAllAsync();
        Task<bool> UpdateAsync(TodoItem todo);
        Task<bool> DeleteAsync(Guid id);
    }
}