using ASTDOTNET.Models.Response;
using ASTDOTNET.Repository.GenericRepository;
using Microsoft.EntityFrameworkCore;

namespace ASTDOTNET.BusinessLogic.ProductBusiness
{
    public class ProductBusiness : IProductBusiness
    {
        private readonly IGenericRepository<Product> _repository;

        public ProductBusiness(IGenericRepository<Product> repository)
        {
            _repository = repository;
        }

        public List<ProductResponse> GetProducts()
        {
            return _repository.GetAll(p => p.Category).Include(p => p.Category)
                .Select(p => new ProductResponse
                {
                    Id = p.Id,
                    ProductName = p.Name,
                    Price = p.Price,
                    Stock = p.Stock,
                    CategoryName = p.Category.Name
                })
                .ToList();
        }
    }
}
