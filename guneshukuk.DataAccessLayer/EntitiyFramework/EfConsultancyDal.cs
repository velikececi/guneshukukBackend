﻿using guneshukuk.DataAccessLayer.Abstract;
using guneshukuk.DataAccessLayer.Concrete;
using guneshukuk.DataAccessLayer.Repositories;
using guneshukuk.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace guneshukuk.DataAccessLayer.EntitiyFramework
{
    public class EfConsultancyDal : GenericRepository<Consultancy>, IConsultancyDal
    {
        public EfConsultancyDal(GuneshukukContext context) : base(context)
        {
        }
    }
}
