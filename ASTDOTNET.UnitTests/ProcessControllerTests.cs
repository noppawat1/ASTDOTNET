using ASTDOTNET.Controllers;
using ASTDOTNET.BusinessLogic.ProcessBusiness;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace ASTDOTNET.UnitTests.Controllers
{
    public class ProcessControllerTests
    {
        private readonly Mock<IProcessBusiness> _processBusinessMock;
        private readonly ProcessController _controller;

        public ProcessControllerTests()
        {
            _processBusinessMock = new Mock<IProcessBusiness>();
            _controller = new ProcessController(_processBusinessMock.Object);
        }

        [Fact]
        public void Process_ShouldReturnOk_WhenInputIsValid()
        {
            // Arrange
            var input = "1,2,1,3,5,4,2,4";
            var expectedResult = new List<string> { "1", "2", "4" };

            _processBusinessMock
                .Setup(x => x.ProcessInput(input))
                .Returns(expectedResult);

            // Act
            var result = _controller.Process(input);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var value = Assert.IsType<List<string>>(okResult.Value);

            Assert.Equal(expectedResult, value);
        }

        [Fact]
        public void Process_ShouldReturnBadRequest_WhenBusinessThrowsException()
        {
            // Arrange
            var input = "";
            var errorMessage = "Input is required";

            _processBusinessMock
                .Setup(x => x.ProcessInput(input))
                .Throws(new ArgumentException(errorMessage));

            // Act
            var result = _controller.Process(input);

            // Assert
            var badRequest = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal(errorMessage, badRequest.Value);
        }

        [Fact]
        public void Process_ShouldUseDefaultInput_WhenInputIsNull()
        {
            // Arrange
            string input = null!;
            var defaultInput = "string,string,1,2,1,3,5,4,2,4";
            var expectedResult = new List<string> { "string", "1", "2", "4" };

            _processBusinessMock
                .Setup(x => x.ProcessInput(defaultInput))
                .Returns(expectedResult);

            // Act
            var result = _controller.Process(input);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var value = Assert.IsType<List<string>>(okResult.Value);

            Assert.Equal(expectedResult, value);
        }
    }
}
