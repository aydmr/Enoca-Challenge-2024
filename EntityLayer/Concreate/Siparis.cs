using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concreate
{
    public class Siparis
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Firma")]
        public int FirmaId { get; set; }

        [ForeignKey("Urun")]
        public int UrunId { get; set; }

        public string SiparisiVerenKisi { get; set; }
        public DateTime SiparisTarihi { get; set; }
        public Firma Firma { get; set; }
        public Urun Urun { get; set; }

        public ICollection<Siparis> Siparisler { get; set; }

    }
}
