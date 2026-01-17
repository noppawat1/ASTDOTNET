using ASTDOTNET.Controllers;
using ASTDOTNET.BusinessLogic.ExternalApiBusiness;
using ASTDOTNET.Models.Response;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace ASTDOTNET.UnitTests.Controllers
{
    public class ExternalApiControllerTests
    {
        private readonly Mock<IExternalApiBusiness> _businessMock;
        private readonly ExternalApiController _controller;

        public ExternalApiControllerTests()
        {
            _businessMock = new Mock<IExternalApiBusiness>();
            _controller = new ExternalApiController(_businessMock.Object);
        }

        [Fact]
        public async Task GetTodo_ShouldReturnOk_WithExpectedResponse()
        {
            // Arrange
            var expected = new ExternalApiResponse
            {
                url = "https://jsonplaceholder.typicode.com/todos/1",
                method = "GET",
                response = new
                {
                    userId = 1,
                    id = 1,
                    title = "test title",
                    completed = false
                }
            };

            _businessMock
                .Setup(x => x.GetTodoAsync())
                .ReturnsAsync(expected);

            // Act
            var result = await _controller.GetTodo();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var value = Assert.IsType<ExternalApiResponse>(okResult.Value);

            Assert.Equal(expected.url, value.url);
            Assert.Equal(expected.method, value.method);
            Assert.NotNull(value.response);
        }
    }
}
