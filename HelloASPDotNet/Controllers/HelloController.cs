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
            return View("index");
        }

        // Get: /hello/welcome
        //[HttpGet]
        //[Route("/helloworld/welcome/{name?}")]
        
        [HttpGet("welcome/{name?}")]
        [HttpPost]
        public IActionResult Welcome(string name = "World", string lang = "en")
        {
            ViewBag.person = name;
            ViewBag.greeting = CreateMessage(name, lang);
            return View();
        }

        public static string CreateMessage(string name, string lang)
        {
            string greeting = lang switch
            {
                "fr" => "Bonjour, ",
                "sp" => "Hola, ",
                "kr" => "Ahn Nyeong, ",
                "se" => "Hej, ",
                _ => "Hello, ",
            };
            return greeting + name;
        }
    }
}
