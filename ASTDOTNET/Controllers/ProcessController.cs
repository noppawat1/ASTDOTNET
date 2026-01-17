using ASTDOTNET.BusinessLogic.ProcessBusiness;
using ASTDOTNET.Models.Request;
using ASTDOTNET.Models.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ASTDOTNET.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ProcessController : ControllerBase
    {
        private readonly IProcessBusiness _processBusiness;
        public ProcessController(IProcessBusiness processBusiness)
        {
            _processBusiness = processBusiness;
        }
        [HttpPost]
        public IActionResult Process([FromBody] string? input )
        {
            input ??= "string,string,1,2,1,3,5,4,2,4"; /// ใช้ตอนเทส
            try
            {
                var result = _processBusiness.ProcessInput(input);
                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
