using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concreate
{
    public class Urun
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Firma")]
        public int FirmaId { get; set; }

        public string Adi { get; set; }
        public int Stok { get; set; }
        public string Fiyat { get; set; }
        public Firma Firma { get; set; }

        public ICollection<Siparis> Siparisler { get; set; }
    }
}
