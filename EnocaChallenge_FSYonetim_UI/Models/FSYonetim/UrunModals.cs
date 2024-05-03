using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnocaChallenge_FSYonetim_UI.Models.FSYonetim
{
    public class UrunModals
    {
        public int Id { get; set; }
        public int FirmaId { get; set; }

        public string Adi { get; set; }
        public int Stok { get; set; }
        public string Fiyat { get; set; }

    }
}
