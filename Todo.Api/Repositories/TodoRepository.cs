using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Todo.Api.Database;
using Todo.Domain.Entities;

namespace Todo.Api.Repositories
{
  public class TodoRepository : ITodoRepository
  {
    private readonly IDbConnectionFactory _connectionFactory;

    public TodoRepository(IDbConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public async Task<bool> CreateAsync(TodoItem todo)
    {
        using var connection = await _connectionFactory.CreateConnectionAsync();
        var result = await connection.ExecuteAsync(
            @"INSERT INTO TODO (Title, Note, Done, LimitDate, Priority, CreatedDate, LastModifiedDate)
            VALUES (@Title, @Note, @Done, @LimitDate, @Priority, @CreatedDate, @LastModifiedDate)",
            todo);
        return result > 0;
    }

    public Task<bool> DeleteAsync(int id)
    {
      throw new NotImplementedException();
    }

    public Task<IEnumerable<TodoItem>> GetAllAsync()
    {
      throw new NotImplementedException();
    }

    public Task<TodoItem?> GetAsync(int id)
    {
      throw new NotImplementedException();
    }

    public Task<bool> UpdateAsync(TodoItem customer)
    {
      throw new NotImplementedException();
    }
  }
}