using BusinessLayer.Abstract.FSYonetim;
using DataAccessLayer.Abstract.FSYonetim;
using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concreate.FSYonetim
{
    public class UrunlerManager:IUrunlerService
    {

        IUrunlerDal _urunlerdal;

        public UrunlerManager(IUrunlerDal urunlerdal)
        {
            _urunlerdal=urunlerdal;
        }

        public Urun Get(int id)
        {
            return _urunlerdal.GetListByFilter(x=> x.Id == id).FirstOrDefault();
        }

        public void TAdd(Urun t)
        {
            _urunlerdal.Insert(t);
        }

        public void TDelete(Urun t)
        {
            _urunlerdal.Delete(t);
        }

        public List<Urun> TGetList()
        {
            return _urunlerdal.GetList();
        }

        public void TUpdate(Urun t)
        {
            _urunlerdal.Update(t);
        }
    }
}
