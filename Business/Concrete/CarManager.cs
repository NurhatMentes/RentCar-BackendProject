using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class CarManager:ICarService
    {
        private ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        
        [SecuredOperation("car.getall")]
        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(),Messages.CarsListed);
        }

        [ValidationAspect(typeof(CarValidator))]
        [SecuredOperation("car.add")]
        public IResult Add(Car car)
        {
            if (car.DailyPrice<10)
            {
                return new ErrorResult(false,Messages.CarPriceInvalid);
            }
            _carDal.Add(car);
            return new Result(true, Messages.CarAdded);
        }

        [ValidationAspect(typeof(CarValidator))]
        [SecuredOperation("car.delete")]
        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new Result(true, Messages.CarDeleted);
        }

        [ValidationAspect(typeof(CarValidator))]
        [SecuredOperation("car.update")]
        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new Result(true, Messages.CarUpdated);
        }

        [SecuredOperation("car.getcardetail")]
        public IDataResult<List<CarDetailDto>> GetCarDetail()
        {
            if (DateTime.Now.Hour == 17)
            {
                return new ErrorDataResult<List<CarDetailDto>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(), Messages.CarsListed);
        }

        [SecuredOperation("car.getbtid")]
        public IDataResult<Car> GetById(int id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.Id == id));
        }
    }
}
