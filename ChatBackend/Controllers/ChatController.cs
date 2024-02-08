using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

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

        private string[] profanityWords = { "badword1", "badword2", "badword3" };

        public string FilterProfanity(string text)
        {
            if (text == null)
                throw new ArgumentNullException(nameof(text));

            foreach (string profanityWord in profanityWords)
            {
                string pattern = "\\b" + profanityWord + "\\b";
                text = Regex.Replace(text, pattern, "***", RegexOptions.IgnoreCase);
            }

            return text;
        }

    }
}
