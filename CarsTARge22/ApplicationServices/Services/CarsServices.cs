using CarsTARge22.Core.Domain;
using CarTARge22.Data;
using CarsTARge22.Core.Dto;
using CarsTARge22.Core.ServiceInterface;
using Microsoft.EntityFrameworkCore;

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

        public async Task<Car> DetailsAsync(Guid id)
        {
            var result = await _context.Cars
                .FirstOrDefaultAsync(x => x.Id == id);

            return result;
        }

        public async Task<Car> Update(CarDto dto)
        {
            var domain = new Car()
            {
                Id = dto.Id,
                Brand = dto.Brand,
                Type = dto.Type,
                Year = dto.Year,
                CreatedAt = DateTime.Now,
                ModifiedAt = DateTime.Now
            };

            _context.Cars.Update(domain);
            await _context.SaveChangesAsync();
            return domain;
        }

        public async Task<Car> Delete(Guid Id)
        {
            var carId = await _context.Cars
                .FirstOrDefaultAsync(x => x.Id == Id);
            _context.Cars.Remove(carId);
            await _context.SaveChangesAsync();

            return carId;
        }
    }
}
