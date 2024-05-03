using EnocaChallenge_FSYonetim_UI.Models.FSYonetim;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Reflection;
using System.Text;

namespace EnocaChallenge_FSYonetim_UI.Controllers
{
    public class FirmaControllerUI : Controller
    {

        private readonly IHttpClientFactory _httpclientfactory;

        public FirmaControllerUI(IHttpClientFactory httpclientfactory)
        {
            _httpclientfactory= httpclientfactory;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Listele() 
        {
            var client = _httpclientfactory.CreateClient();

            var response = await client.GetAsync("https://localhost:7009/api/FirmaApi");
            if(response.IsSuccessStatusCode)
            { 
            var jsondata=await response.Content.ReadAsStringAsync();
            var values=JsonConvert.DeserializeObject<List<FirmaModals>>(jsondata);
            return View(values);
            }
           
            return View();
            
        }

        [HttpGet]
        public IActionResult Ekle()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Ekle(FirmaModals m)
        {
            var client = _httpclientfactory.CreateClient();
            var jsondata = JsonConvert.SerializeObject(m);
            StringContent stringcontent = new StringContent(jsondata,Encoding.UTF8,"application/json");
            var responsemessage = await client.PostAsync("https://localhost:7009/api/FirmaApi", stringcontent);
            if(responsemessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Listele");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Guncelle(int id)
        {
            var client = _httpclientfactory.CreateClient();

            var response = await client.GetAsync("https://localhost:7009/api/FirmaApi/"+id);
            if (response.IsSuccessStatusCode)
            {
                var jsondata = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<FirmaModals>(jsondata);
                return View(values);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Guncelle(FirmaModals m) 
        {
            var client = _httpclientfactory.CreateClient();
            var jsondata = JsonConvert.SerializeObject(m);
            StringContent stringcontent = new StringContent(jsondata, Encoding.UTF8, "application/json");
            var responsemessage = await client.PutAsync("https://localhost:7009/api/FirmaApi", stringcontent);
            if (responsemessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Listele");
            }
            return View();
        }

    }
}
