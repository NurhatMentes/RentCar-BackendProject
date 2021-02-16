﻿using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Core.Utilities;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class UserManager:IUserService
    {
        private IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IDataResult<List<User>> GetAll()
        {
            if (DateTime.Now.Hour==23)
            {
                return new ErrorDataResult<List<User>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<User>>(_userDal.GetAll());
        }

        public IDataResult<User> GetById(int id)
        {
            if (DateTime.Now.Hour == 23)
            {
                return new ErrorDataResult<User>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<User>(_userDal.Get(u=>u.Id==id));
        }

        public IResult Add(User user)
        {
            if (DateTime.Now.Hour == 23)
            {
                return new ErrorResult(false,Messages.MaintenanceTime);
            }
            _userDal.Add(user);
            return new SuccessResult(true);
        }

        public IResult Delete(User user)
        {
            if (DateTime.Now.Hour == 23)
            {
                return new ErrorResult(false,Messages.MaintenanceTime);
            }
            _userDal.Delete(user);
            return new SuccessResult(true);
        }

        public IResult Update(User user)
        {
            if (DateTime.Now.Hour == 23)
            {
                return new ErrorResult(false, Messages.MaintenanceTime);
            }
            _userDal.Delete(user);
            return new SuccessResult(true);
        }
    }
}