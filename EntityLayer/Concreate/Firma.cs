using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concreate
{
    public class Firma
    {
        [Key]
        public int Id { get; set; }
        public string Adi { get; set; }
        public bool OnayDurumu { get; set; }
        public TimeSpan SiparisIzinBaslangicSaati { get; set; }
        public TimeSpan SiparisIzinBitisSaati { get; set; }

        public ICollection<Urun> Urunler { get; set; }
        public ICollection<Siparis> Siparisler { get; set; }
    }
}
