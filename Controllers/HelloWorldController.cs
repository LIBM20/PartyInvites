using Microsoft.AspNetCore.Mvc;

namespace PartyInvites.Controllers
{
    public class HelloWorldController : Controller
    {
        //
        //GET: /HelloWorld/
        public IActionResult Index()
        {
            DateTime dateTime = DateTime.Now;
            int hour = dateTime.Hour;

            string timeOfDay;
            if(hour>=6 && hour <= 12)
            {
                timeOfDay = "morning";

            }else if (hour >12 && hour <20)
            {
                timeOfDay = "afternoon";
            }
            else
            {
                timeOfDay = "night";
            }

            ViewBag.Time = timeOfDay;
            return View();
        }

        //
        //GET: /HelloWorld/Welcome
        public ViewResult Welcome()
        {
            ViewBag.Title = "Welcome from Hello World";
            return View();
        }
    }
}
