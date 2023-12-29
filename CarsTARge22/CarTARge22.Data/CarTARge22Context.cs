using CarsTARge22.Core.Domain;
using Microsoft.EntityFrameworkCore;


namespace CarTARge22.Data
{
    public class CarTARge22Context : DbContext
    {
        public CarTARge22Context(DbContextOptions<CarTARge22Context> options)
            : base(options) { }

        public DbSet<Car> Cars {  get; set; }
    }
}
