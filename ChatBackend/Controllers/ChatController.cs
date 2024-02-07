using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChatBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {

        // Offer the Chat view when the Chat action is called
        [HttpGet]       
        public IActionResult Chat()
        {
            return Ok();
        }
       
    }
}
