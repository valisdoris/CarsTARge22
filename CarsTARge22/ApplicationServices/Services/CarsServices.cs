using CarsTARge22.Core.Domain;
using CarTARge22.Data;
using CarsTARge22.Core.Dto;

namespace CarsTARge22.ApplicationServices.Services
{
    public class CarsServices
    {
        private readonly CarTARge22Context _context;

        public CarsServices(CarTARge22Context context)
        {
            _context = context;
        }

    //    public async Task<Car> Create(CarDto dto)
    //    {
    //        Car car = new Car();
    //        car.Id = Guid.NewGuid();
    //    }
    //}
}
