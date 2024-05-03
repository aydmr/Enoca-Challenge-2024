using BusinessLayer.Abstract.FSYonetim;
using BusinessLayer.Modals;
using DataAccessLayer.Abstract.FSYonetim;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concreate.FSYonetim
{
    public class FirmalarManager:IFirmaService
    {
        IFirmalarDal _firmalardal;

        public FirmalarManager(IFirmalarDal firmalardal) 
        {
            _firmalardal=firmalardal;
        }

        public Firma Get(int id)
        {
            return _firmalardal.GetListByFilter(x=>x.Id ==id).FirstOrDefault();
        }

        public void TAdd(Firma t)
        {
            _firmalardal.Insert(t);
        }

        public void TDelete(Firma t)
        {
            _firmalardal.Delete(t);
        }

        public List<Firma> TGetList()
        {
            return _firmalardal.GetList();
        }

        public void TUpdate(Firma t)
        {
            _firmalardal.Update(t);
        }
    }
}
