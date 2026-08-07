using Microsoft.AspNetCore.Mvc;

namespace MyGreetingApp.Controllers
{
    public class GreetingController : Controller
    {
        // GET: Shows the form to enter name
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        // POST: Handles form submission and shows greeting
        [HttpPost]
        public IActionResult Index(string name)
        {
            string timeGreeting = GetTimeBasedGreeting();
            string fullGreeting = timeGreeting + ", " + name + "!";

            ViewBag.Greeting = fullGreeting;
            ViewBag.TimeOfDay = GetTimeOfDayKey();
            return View();
        }

        // Helper method to decide greeting based on current time
        private string GetTimeBasedGreeting()
        {
            int hour = DateTime.Now.Hour;

            if (hour < 12)
            {
                return "Good Morning";
            }
            else if (hour < 17)
            {
                return "Good Afternoon";
            }
            else
            {
                return "Good Evening";
            }
        }

        // Helper method used to pick a color theme based on time of day
        private string GetTimeOfDayKey()
        {
            int hour = DateTime.Now.Hour;

            if (hour < 12)
            {
                return "morning";
            }
            else if (hour < 17)
            {
                return "afternoon";
            }
            else
            {
                return "evening";
            }
        }
    }
}
