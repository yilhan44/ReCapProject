using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{Id=1, BrandId=1, ColorId=1, DailyPrice=300, ModelYear=2005, Description="Honda"},
                new Car{Id=2, BrandId=1, ColorId=1, DailyPrice=400, ModelYear=2010, Description="Audi"},
                new Car{Id=3, BrandId=2, ColorId=2, DailyPrice=500, ModelYear=2015, Description="Bmw"},
                new Car{Id=4, BrandId=2, ColorId=2, DailyPrice=600, ModelYear=2020, Description="Mercedes"},
                new Car{Id=5, BrandId=3, ColorId=3, DailyPrice=700, ModelYear=2023, Description="Togg"},

            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car deleteCar = _cars.SingleOrDefault(c => c.Id == car.Id);
            _cars.Remove(deleteCar);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }


        public void Update(Car car)
        {
            Car UpdateCar = _cars.SingleOrDefault(c => c.Id == car.Id);
            UpdateCar.BrandId = car.BrandId;
            UpdateCar.ColorId = car.ColorId;
            UpdateCar.DailyPrice = car.DailyPrice;
            UpdateCar.ModelYear = car.ModelYear;
            UpdateCar.Description = car.Description;
        }

        public Car GetById(int carId)
        {
            return _cars.SingleOrDefault(c => c.Id == carId);
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Car GetById(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }
    }
}
