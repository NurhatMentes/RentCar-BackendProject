using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;

namespace ReCapProject.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            // CarTest();
            // BrandTest();
            // ColorTest();
            // UserTest();
            CustomerTest();
            RentalTest();
            Console.ReadLine();
        }

        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());

            colorManager.GetColors();
        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            foreach (var brand in brandManager.GetBrands())
            {
                Console.WriteLine(brand.BrandName);
            }
        }

        private static void UserTest()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            var result = userManager.GetAll();
            foreach (var user in result.Data)
            {
                Console.WriteLine(user.FirstName);
            }
        }

        private static void RentalTest()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            var result = rentalManager.GetAll();
            foreach (var rental in result.Data)
            {
                Console.WriteLine(rental.Id);
            }
            rentalManager.Add(new Rental { Id = 1, CarId = 1, CustomerId = 1, RentDate = DateTime.Now , RetunDate = DateTime.Today});
            rentalManager.Update(new Rental { Id = 1, CarId = 1, CustomerId = 1, RentDate = DateTime.Now, RetunDate = DateTime.MaxValue});
            rentalManager.Delete(new Rental { Id = 1 });
        }

        private static void CustomerTest()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            var result = customerManager.GetAll();
            foreach (var customer in result.Data)
            {
                Console.WriteLine(customer.CompanyName);
            }
            customerManager.Add(new Customer { CustomerId = 5, UserId = 1, CompanyName = "şirket1" });
            customerManager.Update(new Customer { CustomerId = 5, UserId = 1, CompanyName = "HızCar" });
            customerManager.Delete(new Customer { CustomerId = 5 });
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            var result = carManager.GetCarDetail();

            if (!result.Success) 
            {
                Console.WriteLine(result.Message);
            }
            else
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.Id + "," + car.BrandName + "," + car.ModelYear + "," + car.ColorName + "," +
                                      car.Description + "," + car.DailyPrice);
                }
            }

        }
    }
}
