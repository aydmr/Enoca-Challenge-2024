using BusinessLayer.Concreate.FSYonetim;
using BusinessLayer.Modals;
using EntityLayer.Concreate;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace EnocaChallenge_FSYonetim_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SiparislerApi : ControllerBase
    {
        private readonly SiparislerManager _siparislermanager;
        public SiparislerApi(SiparislerManager siparislermanager) 
        {
            _siparislermanager=siparislermanager;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var siparisler = _siparislermanager.TGetList();
            var siparislermodals = siparisler.Select(siparisler => new SiparisModals
            {
                Id =siparisler.Id,
                FirmaId = siparisler.FirmaId,
                SiparisiVerenKisi=siparisler.SiparisiVerenKisi,
                SiparisTarihi=siparisler.SiparisTarihi,
                UrunId=siparisler.UrunId

            });

            var siparislerJson = JsonConvert.SerializeObject(siparislermodals);
            return Ok(siparislerJson);
        }


        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var siparis = _siparislermanager.Get(id);
            if (siparis == null)
            {
                return NotFound();
            }

            var siparismodals = new SiparisModals
            {
                Id = siparis.Id,
                FirmaId = siparis.FirmaId,
                SiparisiVerenKisi = siparis.SiparisiVerenKisi,
                SiparisTarihi = siparis.SiparisTarihi,
                UrunId = siparis.UrunId
            };

            var siparisJson = JsonConvert.SerializeObject(siparismodals);
            return Ok(siparisJson);
        }


        [HttpPost]
        public IActionResult Post([FromBody] SiparisModals siparis)
        {
            try
            {
                Siparis yeniSipariş = new Siparis
                {
                    FirmaId=siparis.FirmaId,
                    SiparisiVerenKisi=siparis.SiparisiVerenKisi,
                    SiparisTarihi=siparis.SiparisTarihi,
                    UrunId=siparis.UrunId
                };

                _siparislermanager.TAdd(yeniSipariş);
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
                var deletedsiparis = _siparislermanager.Get(id);
                _siparislermanager.TDelete(deletedsiparis);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody] SiparisModals siparis)
        {
            try
            {
                var updatesiparis = _siparislermanager.Get(siparis.Id);


                updatesiparis.SiparisTarihi = siparis.SiparisTarihi;
                updatesiparis.SiparisiVerenKisi = siparis.SiparisiVerenKisi;
                updatesiparis.FirmaId = siparis.FirmaId;
                updatesiparis.UrunId = siparis.UrunId;


                _siparislermanager.TAdd(updatesiparis);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

    }
}
