using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChatBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {

        // Send response when Chat is called
        [HttpGet]       
        public IActionResult Chat()
        {
            return Ok();
        }
       
    }
}
