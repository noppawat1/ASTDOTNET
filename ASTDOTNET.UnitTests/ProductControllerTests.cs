using ASTDOTNET.Controllers;
using ASTDOTNET.BusinessLogic.ProductBusiness;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;
using ASTDOTNET.Models.Response;

namespace ASTDOTNET.UnitTests.Controllers
{
    public class ProductControllerTests
    {
        private readonly Mock<IProductBusiness> _productBusinessMock;
        private readonly ProductController _controller;

        public ProductControllerTests()
        {
            _productBusinessMock = new Mock<IProductBusiness>();
            _controller = new ProductController(_productBusinessMock.Object);
        }

        [Fact]
        public void Get_ShouldReturnOk_WithProductList()
        {
            var products = new List<ProductResponse>
            {
                new ProductResponse { Id = 1, ProductName = "Product A", Price = 100 },
                new ProductResponse { Id = 2, ProductName = "Product B", Price = 200 }
            };

            _productBusinessMock
                .Setup(x => x.GetProducts())
                .Returns(products);

            var result = _controller.Get();

            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<List<ProductResponse>>(okResult.Value);

            Assert.Equal(2, returnValue.Count);
            Assert.Equal("Product A", returnValue[0].ProductName);
        }
    }
}
