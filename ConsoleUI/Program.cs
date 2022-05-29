using Business.Concrete;
using DataAccess.Concrete.EntityFrameWork;
using DataAccess.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //CarDetailTest();
            //CustomerAddTest();
            RentalAddTest();


        }
        private static void RentalAddTest()
        {
            Rental rental = new Rental();
            rental.Id = 2;
            rental.CarId = 2;
            rental.CustomerId = 2;
            rental.RentDate = Convert.ToDateTime("01.06.2022");
            rental.ReturnDate = Convert.ToDateTime("01.07.2022");

            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            var result = rentalManager.Add(rental);
            Console.WriteLine(result.Message);
        }
        private static void CustomerAddTest()
        {
            Customer customer = new Customer();
            customer.CustomerId = 2;
            customer.UserId = 2;
            customer.CompanyName = "malatya";

            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            var result = customerManager.Add(customer);
            Console.WriteLine(result.Message);
        }
        private static void CarAddTest()
        {
            Car c = new Car();
            c.Id = 6;
            c.BrandId = 4;
            c.ColorId = 3;
            c.ModelYear = 2015;
            c.DailyPrice = 800;
            c.Description = "Çok Güzel Araba";
            c.CarName = "Sead";
            CarManager carManager = new CarManager(new EfCarDal());

            var result = carManager.Add(c);
            Console.WriteLine(result.Message);
        }
        private static void CarDeleteTest()
        {
            Car c = new Car();
            c.Id = 6;
            c.BrandId = 4;
            c.ColorId = 3;
            c.ModelYear = 2015;
            c.DailyPrice = 800;
            c.Description = "Çok Güzel Araba";
            c.CarName = "Sead";
            CarManager carManager = new CarManager(new EfCarDal());

            var result = carManager.Delete(c);
            Console.WriteLine(result.Message);
        }
        private static void CarUptadeTest()
        {
            Car c = new Car();
            c.Id = 6;
            c.BrandId = 4;
            c.ColorId = 3;
            c.ModelYear = 2015;
            c.DailyPrice = 800;
            c.Description = "Çok Güzel Araba";
            c.CarName = "Sead";
            CarManager carManager = new CarManager(new EfCarDal());

            var result = carManager.Update(c);
            Console.WriteLine(result.Message);
        }
        private static void CarDetailTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            var result = carManager.GetCarDetails();
            if (result.Success)
            {
                foreach (var car in carManager.GetCarDetails().Data)
                {
                    Console.WriteLine(car.CarName + "-" + car.BrandName + "/" + car.ColorName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }
    }
}
