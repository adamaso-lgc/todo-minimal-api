using System.Net;
using System.Net.Http.Json;
using Bogus;
using FluentAssertions;
using Todo.Api.Endpoints.CreateTodo;
using Todo.Domain.Enums;

namespace Todo.Tests.Integration
{
    public class CreateTodoEndpointTest : IClassFixture<TodoApiFactory>
    {
        private readonly HttpClient _httpClient;
        private readonly Faker<CreateTodoRequest> _todoRequestGenerator = new Faker<CreateTodoRequest>()
                        .RuleFor(x => x.Title, faker => faker.Commerce.ProductName())
                        .RuleFor(x => x.Priority, faker => faker.PickRandom<PriorityLevel>())
                        .RuleFor(x => x.LimitDate, faker => faker.Date.Future());

        public CreateTodoEndpointTest(TodoApiFactory apiFactory)
        {
            _httpClient = apiFactory.CreateClient();
        }

        [Fact]
        public async Task CreateTodo_WhenCreate_ReturnsCreated()
        {
            // arrange
            var todoRequest = _todoRequestGenerator.Generate();

            // act
            var response = await _httpClient.PostAsJsonAsync("todo", todoRequest);

            // assert
            var todoResponse = await response.Content.ReadFromJsonAsync<Guid>();
            response.StatusCode.Should().Be(HttpStatusCode.Created);
            response.Headers.Location!.ToString().Should().Be($"http://localhost/todo/{todoResponse}");
        }

        [Fact]
        public async Task CreateTodo_InvalidRequest_ReturnsValidationFailureResponse()
        {
            // arrange
            var todoRequest = _todoRequestGenerator.Clone()
                .RuleFor(x => x.Title, "")
                .Generate();

            // act
            var response = await _httpClient.PostAsJsonAsync("todo", todoRequest);

            // assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }
    } 
}