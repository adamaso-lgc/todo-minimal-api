using DotNet.Testcontainers.Builders;
using DotNet.Testcontainers.Configurations;
using DotNet.Testcontainers.Containers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Todo.Api.Database;

namespace Todo.Tests
{
    public class TodoApiFactory : WebApplicationFactory<Program>, IAsyncLifetime
    {
        private string Password => "a12345678?";
        private readonly MsSqlTestcontainer _dbContainer = 
            new TestcontainersBuilder<MsSqlTestcontainer>()
                .WithDatabase(new MsSqlTestcontainerConfiguration
                {
                    Password = "a12345678?"
                }).Build();

        protected override void ConfigureWebHost(IWebHostBuilder builder)
            {
                builder.ConfigureTestServices(services =>
                {
                    var port = _dbContainer.ContainerPort;
                    services.RemoveAll(typeof(IDbConnectionFactory));
                    services.AddSingleton<IDbConnectionFactory>(_ =>
                        new SqlConnectionFactory($"Server=127.0.0.1,{port};Database=TodoMinimal;User ID=sa;Password=a12345678?"));
                       // new SqlConnectionFactory(_dbContainer.ConnectionString));
                });


            }

        public async Task InitializeAsync()
        {
            await _dbContainer.StartAsync();
        }

        public new async Task DisposeAsync()
        {
            await _dbContainer.StopAsync();
        }
    }
}