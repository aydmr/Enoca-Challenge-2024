using Microsoft.AspNetCore.Mvc;
using BusinessLayer.Concreate.FSYonetim;
using Newtonsoft.Json;
using EntityLayer.Concreate;
using BusinessLayer.Modals;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EnocaChallenge_FSYonetim_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FirmaApi : ControllerBase
    {

        private readonly FirmalarManager _firmalarmanager;

        public FirmaApi(FirmalarManager firmalarmanager)
        {
            _firmalarmanager=firmalarmanager;
        }

        
        
        [HttpGet]
        public IActionResult Get()
        {
            var firmalar = _firmalarmanager.TGetList();
            var firmalarModals = firmalar.Select(firma => new FirmaModals
            {
                Id = firma.Id,
                Adi = firma.Adi,
                SiparisIzinBaslangicSaati=firma.SiparisIzinBaslangicSaati,
                SiparisIzinBitisSaati=firma.SiparisIzinBitisSaati,
                OnayDurumu=firma.OnayDurumu
            });

            var firmalarJson = JsonConvert.SerializeObject(firmalarModals);
            return Ok(firmalarJson);
        }

        
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var firma = _firmalarmanager.Get(id);
            if (firma == null)
            {
                return NotFound();
            }

            var firmaJson = JsonConvert.SerializeObject(firma);
            return Ok(firmaJson);
        }

        
        [HttpPost]
        public IActionResult Post([FromBody] FirmaModals firma)
        {
            try
            {
                Firma yeniFirma = new Firma
                {
                    Adi = firma.Adi,
                    SiparisIzinBaslangicSaati = firma.SiparisIzinBaslangicSaati,
                    SiparisIzinBitisSaati = firma.SiparisIzinBitisSaati,
                    OnayDurumu = firma.OnayDurumu
                };

                _firmalarmanager.TAdd(yeniFirma);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

       
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var deletedfirma = _firmalarmanager.Get(id);
                _firmalarmanager.TDelete(deletedfirma);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody] FirmaModals firma)
        {
            try
            {
                var updatefirma = _firmalarmanager.Get(firma.Id);

                updatefirma.Adi=firma.Adi;
                updatefirma.SiparisIzinBitisSaati=firma.SiparisIzinBitisSaati;
                updatefirma.SiparisIzinBaslangicSaati = firma.SiparisIzinBaslangicSaati;
                updatefirma.OnayDurumu = firma.OnayDurumu;

                _firmalarmanager.TUpdate(updatefirma);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}
