using EnocaChallenge_FSYonetim_UI.Models.FSYonetim;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace EnocaChallenge_FSYonetim_UI.Controllers
{
    public class SiparislerControllerUI : Controller
    {
        private readonly IHttpClientFactory _httpclientfactory;

        public SiparislerControllerUI(IHttpClientFactory httpclientfactory)
        {
            _httpclientfactory = httpclientfactory;
        }


        public async Task<IActionResult> Listele()
        {
            var client = _httpclientfactory.CreateClient();

            var response = await client.GetAsync("https://localhost:7009/api/SiparislerApi");

            if (response.IsSuccessStatusCode)
            {
                var jsondata = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<SiparisModals>>(jsondata);
                return View(values);
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Ekle()
        { 
            SiparislerEkleModals model = new SiparislerEkleModals();

            var client = _httpclientfactory.CreateClient();

            var response = await client.GetAsync("https://localhost:7009/api/FirmaApi");
            if (response.IsSuccessStatusCode)
            {
                var jsondata = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<FirmaModals>>(jsondata);
                model.firmamodalslist = values;
            }

            var response2 = await client.GetAsync("https://localhost:7009/api/UrunlerApi");

            if (response2.IsSuccessStatusCode)
            {
                var jsondata2 = await response2.Content.ReadAsStringAsync();
                var values2 = JsonConvert.DeserializeObject<List<UrunModals>>(jsondata2);
                model.urunmodalslist = values2;
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Ekle(SiparislerEkleModals m)
        {
            var client = _httpclientfactory.CreateClient();

            m.siparismodel.SiparisiVerenKisi = "Çalışan 1";
            m.siparismodel.SiparisTarihi = DateTime.Now;

            var response = await client.GetAsync("https://localhost:7009/api/FirmaApi/"+m.siparismodel.FirmaId);
            if (response.IsSuccessStatusCode)
            {
                var jsondata = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<FirmaModals>(jsondata);
                
                if(values.SiparisIzinBaslangicSaati < DateTime.Now.TimeOfDay && DateTime.Now.TimeOfDay < values.SiparisIzinBitisSaati)
                {
                    var jsondata2 = JsonConvert.SerializeObject(m.siparismodel);
                    StringContent stringcontent = new StringContent(jsondata2, Encoding.UTF8, "application/json");
                    var responsemessage = await client.PostAsync("https://localhost:7009/api/SiparislerApi", stringcontent);
                    if (responsemessage.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Listele");
                    }
                }
                else if(values.OnayDurumu ==false)
                {
                    return RedirectToAction("/Error/Error2");
                }
                else
                {
                    return RedirectToAction("/Error/Error1");
                }


            }
            return View();
        }
    }
}
