using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnocaChallenge_FSYonetim_UI.Models.FSYonetim
{
    public class SiparisModals
    {
      
        public int Id { get; set; }
        public int FirmaId { get; set; }
        public int UrunId { get; set; }

        public string SiparisiVerenKisi { get; set; }
        public DateTime SiparisTarihi { get; set; }
        
    }
}
