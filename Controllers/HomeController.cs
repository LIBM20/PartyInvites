using Microsoft.AspNetCore.Mvc;
using PartyInvites.Models;
using System.Diagnostics;

namespace PartyInvites.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        //Views do controlador HomeController estão na pasta home
        //podemos criar as ações através de funções que façam return do que se quer ver
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        //qualquer ação tem de ser pública senão não dá para chamar
        //string pode ser em minusculas
        public  string Contact()
        {
            return "Contact information is not currently available";
        }

        //GET: /Home/Register
        public IActionResult Register() => View(); //abreviação :)
        
        //fica sempre antes do objeto que está a ser anotado
        [HttpPost]
        public IActionResult Register(GuestResponse response)
        {
            //caso os dados sejam válidos
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
            //var peopleAttending = Repository.Responses.Where(r=>r.WillAttend == true);//apenas as pessoas que vão
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
