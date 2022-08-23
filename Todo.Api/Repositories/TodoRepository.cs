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
            @"INSERT INTO TODO (TodoId, Title, Note, Done, LimitDate, Priority, CreatedDate, LastModifiedDate)
            VALUES (@Id, @Title, @Note, @Done, @LimitDate, @Priority, @CreatedDate, @LastModifiedDate)",
            todo);
        return result > 0;
    }

    public Task<bool> DeleteAsync(Guid id)
    {
      throw new NotImplementedException();
    }

    public Task<IEnumerable<TodoItem>> GetAllAsync()
    {
      throw new NotImplementedException();
    }

    public async Task<TodoItem?> GetAsync(Guid id)
    {
      using var connection = await _connectionFactory.CreateConnectionAsync();
        return await connection.QuerySingleOrDefaultAsync<TodoItem>(
            "SELECT * FROM Todo WHERE TodoId = @Id ", new { Id = id.ToString()});
    }

    public Task<bool> UpdateAsync(TodoItem todo)
    {
      throw new NotImplementedException();
    }
  }
}