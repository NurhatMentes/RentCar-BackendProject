using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal: EfEntityRepositoryBase<Car, RentA_CarContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetail()
        {
            using ( RentA_CarContext context = new RentA_CarContext())
            {
                var result = from c in context.Cars
                    from b in context.Brands
                    join color in context.Colors on c.Id equals color.ColorId
                    select new CarDetailDto
                    {
                        BrandName = b.BrandName, ModelYear = c.ModelYear, Description = c.Description,
                        ColorName = color.ColorName, DailyPrice = c.DailyPrice
                    };
                return result.ToList();
            }
        }
    }
}
