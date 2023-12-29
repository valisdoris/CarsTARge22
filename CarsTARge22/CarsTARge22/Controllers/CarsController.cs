using CarsTARge22.Core.Dto;
using CarsTARge22.Core.ServiceInterface;
using CarsTARge22.Models.Cars;
using CarTARge22.Data;
using Microsoft.AspNetCore.Mvc;

namespace CarsTARge22.Controllers
{
    public class CarsController : Controller
    {
        private readonly CarTARge22Context _context;
        private readonly ICarsServices _carsServices;

        public CarsController(CarTARge22Context context, ICarsServices carsServices)
        {
            _context = context;
            _carsServices = carsServices;
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

            var result = await _carsServices.Create(dto);

            if (result == null)
            {
                return RedirectToAction(nameof(Index));

            }

            return RedirectToAction(nameof(Index), vm);
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var car = await _carsServices.DetailsAsync(id);

            if (car == null)
            {
                return NotFound();
            }

            var vm = new CarDetailsViewModel();
            vm.Id = car.Id;
            vm.Brand = car.Brand;
            vm.Type = car.Type;
            vm.Year = car.Year;
            vm.CreatedAt = car.CreatedAt;
            vm.ModifiedAt = car.ModifiedAt;

            return View(vm);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var car = await _carsServices.DetailsAsync(id);
            if (car != null)
            {
                return NotFound();
            }

            var vm = new CarDeleteViewModel();
            vm.Id = car.Id;
            vm.Brand = car.Brand;
            vm.Type = car.Type;
            vm.Year = car.Year;
            vm.CreatedAt = car.CreatedAt;
            vm.ModifiedAt = car.ModifiedAt;

            return View(vm);
        }
        
    }
}
