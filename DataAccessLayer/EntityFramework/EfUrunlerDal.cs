﻿using DataAccessLayer.Abstract.FSYonetim;
using DataAccessLayer.Repository;
using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfUrunlerDal: GenericRepository<Urun>,IUrunlerDal
    {
    }
}
