using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract.FSYonetim
{
    public interface IFirmaService : IGenericService<Firma>
    {
        Firma Get(int id);
    }
}
