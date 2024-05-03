
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
    public class SiparislerManager : ISiparislerService
    {

        ISiparislerDal _siparislerdal;

        public SiparislerManager(ISiparislerDal siparislerdal)
        {
            _siparislerdal=siparislerdal;
        }

        public Siparis Get(int id)
        {
            return _siparislerdal.GetListByFilter(x=> x.Id == id).FirstOrDefault();
        }

        public void TAdd(Siparis t)
        {
            _siparislerdal.Insert(t);
        }

        public void TDelete(Siparis t)
        {
            _siparislerdal.Delete(t);
        }

        public List<Siparis> TGetList()
        {
            return _siparislerdal.GetList();
        }

        public void TUpdate(Siparis t)
        {
            _siparislerdal.Update(t);
        }

     
    }
}
