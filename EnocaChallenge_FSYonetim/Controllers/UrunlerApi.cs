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
    public class UrunlerApi : ControllerBase
    {
        private readonly UrunlerManager _urunlermanager;

        public UrunlerApi(UrunlerManager urunlermanager)
        {
            _urunlermanager = urunlermanager;
        }



        [HttpGet]
        public IActionResult Get()
        {
            var urunler = _urunlermanager.TGetList();
            var urunlermodals = urunler.Select(urunler => new UrunModals
            {
                Id = urunler.Id,
                Adi=urunler.Adi,
                FirmaId=urunler.FirmaId,
                Stok=urunler.Stok,
                Fiyat=urunler.Fiyat
            });

            var urunlerJson = JsonConvert.SerializeObject(urunlermodals);
            return Ok(urunlerJson);
        }


        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var urun = _urunlermanager.Get(id);
            if (urun == null)
            {
                return NotFound();
            }

            var urunmodals = new UrunModals
            {
                Id = urun.Id,
                Adi = urun.Adi,
                FirmaId = urun.FirmaId,
                Stok = urun.Stok,
                Fiyat = urun.Fiyat
            };

            var urunJson = JsonConvert.SerializeObject(urunmodals);
            return Ok(urunJson);
        }


        [HttpPost]
        public IActionResult Post([FromBody] UrunModals urun)
        {
            try
            {
                Urun yeniUrun = new Urun
                {
                    Adi = urun.Adi,
                    Fiyat=urun.Fiyat,
                    FirmaId=urun.FirmaId,
                    Stok=urun.Stok
                };

                _urunlermanager.TAdd(yeniUrun);
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
                var deletedfirma = _urunlermanager.Get(id);
                _urunlermanager.TDelete(deletedfirma);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody] UrunModals urun)
        {
            try
            {
                var updateurun = _urunlermanager.Get(urun.Id);


                updateurun.Adi = urun.Adi;
                updateurun.Stok = urun.Stok;
                updateurun.Fiyat = urun.Fiyat;
                updateurun.FirmaId = urun.FirmaId;

                _urunlermanager.TAdd(updateurun);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}

