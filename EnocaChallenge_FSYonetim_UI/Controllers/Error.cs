using Microsoft.AspNetCore.Mvc;

namespace EnocaChallenge_FSYonetim_UI.Controllers
{
    public class Error : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Error1()
        {
            return View();
        }

        public IActionResult Error2()
        {
            return View();
        }
    }
}
