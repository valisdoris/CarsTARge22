using CarsTARge22.Core.Dto;
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
            return View(result);
        }

        [HttpGet]
        public IActionResult Create()
        {
            CarCreateViewModel result = new CarCreateViewModel();

            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CarCreateViewModel vm)
        {

            var dto = new CarDto()
            {
                Id = vm.Id,
                Brand = vm.Brand,
                Type = vm.Type,
                Year = vm.Year,
                CreatedAt = vm.CreatedAt,
                ModifiedAt = vm.ModifiedAt
            };

            return RedirectToAction("Index");
        }
            



        
    }
}
