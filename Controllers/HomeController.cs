using Microsoft.AspNetCore.Mvc;
using PartyInvites.Models;
using System.Diagnostics;

namespace PartyInvites.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        //Views do controlador HomeController est�o na pasta home
        //podemos criar as a��es atrav�s de fun��es que fa�am return do que se quer ver
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        //qualquer a��o tem de ser p�blica sen�o n�o d� para chamar
        //string pode ser em minusculas
        public  string Contact()
        {
            return "Contact information is not currently available";
        }

        //GET: /Home/Register
        public IActionResult Register() => View(); //abrevia��o :)
        
        //fica sempre antes do objeto que est� a ser anotado
        [HttpPost]
        public IActionResult Register(GuestResponse response)
        {
            Repository.AddResponse(response);
            return View("RegisterComplete", response);
        }
        public IActionResult ListResponses() => View(Repository.Responses);
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
