﻿using Core.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFrameWork
{
    public class EfCarDal : EfEntityFrameworkBase<Car, ReCapContex>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (ReCapContex context=new ReCapContex())
            {
                var result = from c in context.Cars
                             join b in context.Brands on c.BrandId equals b.Id
                             join r in context.Colors on c.ColorId equals r.Id
                             select new CarDetailDto
                             {
                                 CarName = c.CarName,
                                 BrandName = b.Name,
                                 ColorName = r.Name
                             };
                return result.ToList();
            }
        }
    }
}
