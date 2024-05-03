using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Modals
{
    public class FirmaModals
    {
        public int Id { get; set; }
        public string Adi { get; set; }
        public bool OnayDurumu { get; set; }
        public TimeSpan SiparisIzinBaslangicSaati { get; set; }
        public TimeSpan SiparisIzinBitisSaati { get; set; }
    }
}
