using Microsoft.AspNetCore.Mvc;

namespace EnocaChallenge_FSYonetim_UI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
