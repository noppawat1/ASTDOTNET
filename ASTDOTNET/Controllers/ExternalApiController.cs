using ASTDOTNET.BusinessLogic.ExternalApiBusiness;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ASTDOTNET.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ExternalApiController : ControllerBase
    {
        private readonly IExternalApiBusiness _business;

        public ExternalApiController(IExternalApiBusiness business)
        {
            _business = business;
        }

        [HttpGet("todo")]
        public async Task<IActionResult> GetTodo()
        {
            var result = await _business.GetTodoAsync();
            return Ok(result);
        }
    }
}
