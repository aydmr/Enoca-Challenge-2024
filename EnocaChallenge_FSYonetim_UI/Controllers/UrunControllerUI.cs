using EnocaChallenge_FSYonetim_UI.Models.FSYonetim;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;

namespace EnocaChallenge_FSYonetim_UI.Controllers
{
    public class UrunControllerUI : Controller
    {

        private readonly IHttpClientFactory _httpclientfactory;

        public UrunControllerUI(IHttpClientFactory httpclientfactory)
        {
            _httpclientfactory = httpclientfactory;
        }

        public async Task<IActionResult> Listele()
        {
            var client = _httpclientfactory.CreateClient();

            var response = await client.GetAsync("https://localhost:7009/api/UrunlerApi");

            if (response.IsSuccessStatusCode)
            {
                var jsondata = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<UrunModals>>(jsondata);
                return View(values);
            }

            return View();

        }

        [HttpGet]
        public async Task<IActionResult> Ekle() 
        {
            var client = _httpclientfactory.CreateClient();
            UrunEkleModels model = new UrunEkleModels();

            var response = await client.GetAsync("https://localhost:7009/api/FirmaApi");
            if (response.IsSuccessStatusCode)
            {
                var jsondata = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<FirmaModals>>(jsondata);                
                model.firmamodelslist = values;
            }
            

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Ekle(UrunEkleModels m)
        {
            var client = _httpclientfactory.CreateClient();
            var jsondata = JsonConvert.SerializeObject(m.UrunModals);
            StringContent stringcontent = new StringContent(jsondata, Encoding.UTF8, "application/json");
            var responsemessage = await client.PostAsync("https://localhost:7009/api/UrunlerApi", stringcontent);
            if (responsemessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Listele");
            }
            return View();
        }
    }
}
