using CarsTARge22.Models.Cars;
using CarTARge22.Data;
using Microsoft.AspNetCore.Mvc;

namespace CarsTARge22.Controllers
{
    public class CarsController : Controller
    {
        private readonly CarTARge22Context _context;

        public CarsController(CarTARge22Context context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var result = _context.Cars
                .Select(x => new CarsIndexViewModel
                {
                    Id = x.Id,
                    Brand = x.Brand,
                    Type = x.Type,
                    Year = x.Year
                });
            return View();
        }
    }
}
