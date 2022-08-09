using Dapper;

namespace Todo.Api.Database;

public class DatabaseInitializer
{
    private readonly IDbConnectionFactory _connectionFactory;

    public DatabaseInitializer(IDbConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public async Task InitializeAsync()
    {
        using var connection = await _connectionFactory.CreateConnectionAsync();
        await connection.ExecuteAsync(@"CREATE TABLE IF NOT EXISTS TODO (
        [TodoId] [nvarchar](36) PRIMARY KEY,
        [Title] [nvarchar](200) NOT NULL,
        [Note] [nvarchar](max) NOT NULL,
        [Done] [bit] NOT NULL,
        [LimitDate] [datetime2](7) NOT NULL,
        [Priority] [int] NOT NULL,
        [CreatedDate] [datetime2](7) NOT NULL,
        [LastModifiedDate] [datetime2](7) NULL)");
    }
}
