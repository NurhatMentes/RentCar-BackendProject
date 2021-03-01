using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Core.Utilities;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore.Internal;

namespace Business.Concrete
{
    public class RentalManager:IRentalService
    {
        private IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IDataResult<List<Rental>> GetAll()
        {
            if (DateTime.Now.Hour == 23)
            {
                return new ErrorDataResult<List<Rental>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }

        public IDataResult<Rental> GetById(int id)
        {
            if (DateTime.Now.Hour == 23)
            {
                return new ErrorDataResult<Rental>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<Rental>(_rentalDal.Get(u => u.Id == id));
        }

        public IResult Add(Rental rental)
        {
            if (DateTime.Now.Hour == 23)
            {
                return new ErrorResult(false, Messages.MaintenanceTime);
            }
            _rentalDal.Add(rental);
            return new SuccessResult(true);
        }

        public IResult Delete(Rental rental)
        {
            if (DateTime.Now.Hour == 23)
            {
                return new ErrorResult(false, Messages.MaintenanceTime);
            }
            _rentalDal.Delete(rental);
            return new SuccessResult(true);
        }

        public IResult Update(Rental rental)
        {

            if (DateTime.Now.Hour == 23)
            {
                return new ErrorResult(false, Messages.MaintenanceTime);
            }
            _rentalDal.Delete(rental);
            return new SuccessResult(true);
        }
    }
}
