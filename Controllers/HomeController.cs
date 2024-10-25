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
            //caso os dados sejam v�lidos
            if (!ModelState.IsValid)
            {
                return View(response);
            }
            Repository.AddResponse(response);
            return View("RegisterComplete", response);


        }
        public IActionResult ListResponses(){
            if(Repository.Responses.Count() > 0)
            {
                return View(Repository.Responses);
            }
            else
            {
                return View("NoRegistrations");
            }
            
        }
        public IActionResult PeopleAttending()
        {
            /* List<GuestResponse> peopleAttending = new List<GuestResponse>();
             foreach(var response in Repository.Responses)
             {
                 if(response.WillAttend == true)
                 {
                     peopleAttending.Add(response);
                 }
             }*/
            //var peopleAttending = Repository.Responses.Where(r=>r.WillAttend == true);//apenas as pessoas que v�o
            var peopleAttending = from r in Repository.Responses 
                                  where r.WillAttend == true
                                  select r;
            return View("ListResponses", peopleAttending);
        }
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
