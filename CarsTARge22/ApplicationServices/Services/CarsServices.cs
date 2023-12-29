using CarsTARge22.Core.Domain;
using CarTARge22.Data;
using CarsTARge22.Core.Dto;
using CarsTARge22.Core.ServiceInterface;

namespace CarsTARge22.ApplicationServices.Services
{
    public class CarsServices : ICarsServices
    {
        private readonly CarTARge22Context _context;

        public CarsServices(CarTARge22Context context)
        {
            _context = context;
        }

        public async Task<Car> Create(CarDto dto)
        {
            Car car = new Car();
            car.Id = Guid.NewGuid();
            car.Brand = dto.Brand;
            car.Type = dto.Type;
            car.Year = dto.Year;
            car.CreatedAt = DateTime.Now;
            car.ModifiedAt = DateTime.Now;

            await _context.Cars.AddAsync(car);
            await _context.SaveChangesAsync();

            return car;
        }
    }
}
