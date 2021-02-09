using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal:ICarDal
    {
        private List<Car> _carList;

        public InMemoryCarDal()
        {
            _carList = new List<Car>
            {
                new Car{ Id=1,BrandId=1,ColorId=4,DailyPrice=140, ModelYear="2014",Description="" },
                new Car{ Id=2,BrandId=2,ColorId=3,DailyPrice=125,ModelYear="2012",Description="" },
                new Car{ Id=3,BrandId=3,ColorId=5,DailyPrice=150,ModelYear="2015",Description="" },
                new Car{ Id=4,BrandId=4,ColorId=4,DailyPrice=210,ModelYear="2018",Description="" },
                new Car{ Id=5,BrandId=5,ColorId=8,DailyPrice=180,ModelYear="2016",Description="" }

            };
        }
        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Add(Car entity)
        {
            _carList.Add(entity);
        }

        public void Update(Car entity)
        {
            Car _updateToCar = _carList.FirstOrDefault(c => c.Id == entity.Id);
            _updateToCar.BrandId = entity.BrandId;
            _updateToCar.ColorId = entity.ColorId;
            _updateToCar.DailyPrice = entity.DailyPrice;
            _updateToCar.ModelYear = entity.ModelYear;
            _updateToCar.Description = entity.Description;
        }

        public void Delete(Car entity)
        {
            Car _deleteToCar = _carList.FirstOrDefault(c => c.Id == entity.Id);
            _carList.Remove(_deleteToCar);
        }

        public List<CarDetailDto> GetCarDetail()
        {
            throw new NotImplementedException();
        }
    }
}
