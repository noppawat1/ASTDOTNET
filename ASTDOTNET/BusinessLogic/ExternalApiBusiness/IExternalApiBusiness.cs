using ASTDOTNET.Models.Response;

namespace ASTDOTNET.BusinessLogic.ExternalApiBusiness
{
    public interface IExternalApiBusiness
    {
        Task<ExternalApiResponse> GetTodoAsync();
    }
}
