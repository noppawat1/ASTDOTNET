using ASTDOTNET.Models.Response;

namespace ASTDOTNET.BusinessLogic.ProductBusiness
{
    public interface IProductBusiness
    {
        List<ProductResponse> GetProducts();
    }
}
