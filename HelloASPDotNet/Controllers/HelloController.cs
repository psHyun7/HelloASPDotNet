using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace HelloASPDotNet.Controllers
{
    [Route("/helloworld")]
    public class HelloController : Controller
    {
        // GET: /<controller>/
        [HttpGet]
        public IActionResult Index()
        {
            string html = "<form method='post' action='/helloworld/'>" +
                "<input type='text' name='name' />" +
                "<select name='lang'>" +
                    "<option value='en'>English</option>" +
                    "<option value='fr'>French</option>" +
                    "<option value='sp'>Spanish</option>" +
                    "<option value='kr'>Korean</option>" +
                    "<option value='se'>Swedish</option>" +
                "</select>" +
                "<input type='submit' value='GreetMe!' />" +
                "</form>";
            return Content(html, "text/html");
        }

        // Get: /hello/welcome
        //[HttpGet]
        //[Route("/helloworld/welcome/{name?}")]
        
        [HttpGet("welcome/{name?}")]
        [HttpPost]
        public IActionResult Welcome(string name = "World", string lang = "en")
        {
            string greeting = CreateMessage(name, lang);
            return Content("<h1>" + greeting + "!</h1>", "text/html");
        }

        public static string CreateMessage(string name, string lang)
        {
            string greeting;
            switch (lang)
            {
                case "fr":
                    greeting = "Bonjour, ";
                    break;
                case "sp":
                    greeting = "Hola, ";
                    break;
                case "kr":
                    greeting = "Ahn Nyeong, ";
                    break;
                case "se":
                    greeting = "Hej, ";
                    break;
                default:
                    greeting = "Hello, ";
                    break;
            }
            return greeting + name;
        }
    }
}
