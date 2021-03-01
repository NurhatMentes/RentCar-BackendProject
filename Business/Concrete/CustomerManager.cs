using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Core.Utilities;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class CustomerManager:ICustomerService
    {
        ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public IDataResult<List<Customer>> GetAll()
        {
            if (DateTime.Now.Hour == 23)
            {
                return new ErrorDataResult<List<Customer>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll());
        }

        public IDataResult<Customer> GetById(int id)
        {
            if (DateTime.Now.Hour == 23)
            {
                return new ErrorDataResult<Customer>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<Customer>(_customerDal.Get(c => c.UserId == id));
        }

        public IResult Add(Customer customer)
        {
            if (DateTime.Now.Hour == 23)
            {
                return new ErrorResult(false, Messages.MaintenanceTime);
            }
            _customerDal.Add(customer);
            return new SuccessResult(true);
        }

        public IResult Delete(Customer customer)
        {
            if (DateTime.Now.Hour == 23)
            {
                return new ErrorResult(false, Messages.MaintenanceTime);
            }
            _customerDal.Delete(customer);
            return new SuccessResult(true);
        }

        public IResult Update(Customer customer)
        {

            if (DateTime.Now.Hour == 23)
            {
                return new ErrorResult(false, Messages.MaintenanceTime);
            }
            _customerDal.Delete(customer);
            return new SuccessResult(true);
        }
    }
}
