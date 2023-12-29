using CarsTARge22.ApplicationServices.Services;
using CarsTARge22.Core.Dto;
using CarsTARge22.Core.ServiceInterface;
using ShopTARge22.CarsTest;

namespace CarTARge22.CarsTest
{
    public class CarTests : TestBase
    {

      
        [Fact]
        public async Task Should_UpdateCars_WhenUpdateData()
        {
            CarDto dto = MockCarData();
            var createCar = await Svc<ICarsServices>().Create(dto);

            CarDto update = MockUpdateCarData();
            var result = await Svc<ICarsServices>().Update(update);

            Assert.DoesNotMatch(result.Brand, createCar.Brand);
            //Assert.Matches(result.GroupName, createKindergarten.GroupName);
        }

        [Fact]
        public async Task ShouldNot_AddEmptyCar_WhenReturnResult()
        {
            //Arrange
            CarDto car = new();

            car.Brand = "Nissan";
            car.Type = "Qashqai";
            car.Year = 2009;
            car.CreatedAt = DateTime.Now;
            car.ModifiedAt = DateTime.Now;

            //Act
            var result = await Svc<ICarsServices>().Create(car);

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task Should_CreateCar_WhenValidDataProvided()
        {
            // Arrange
            CarDto carToCreate = new CarDto
            {
                Brand = "Toyota",
                Type = "Camry",
                Year = 2020,
                CreatedAt = DateTime.Now,
                ModifiedAt = DateTime.Now,
            };

            // Act
            var createdCar = await Svc<ICarsServices>().Create(carToCreate);

            // Assert
            Assert.NotNull(createdCar);
            Assert.Equal(carToCreate.Brand, createdCar.Brand);
            Assert.Equal(carToCreate.Type, createdCar.Type);
            Assert.Equal(carToCreate.Year, createdCar.Year);
        }

        [Fact]
        public async Task ShouldNot_UpdateCar_WhenNotUpdateData()
        {

            CarDto dto = MockCarData();
            var createRealestate = await Svc<ICarsServices>().Create(dto);

            CarDto nullUpdate = MockNullCar();
            var result = await Svc<ICarsServices>().Update(nullUpdate);

            var nullId = nullUpdate.Id;


            Assert.True(dto.Id == nullId);
        }



        private CarDto MockCarData()
        {
            CarDto car = new()
            {
                Brand = "Volkswagen",
                Type = "Passat",
                Year = 2008,
                CreatedAt = DateTime.Now,
                ModifiedAt = DateTime.Now,

            };

            return car;
        }

        private CarDto MockUpdateCarData()
        {
            CarDto car = new()
            {
                Brand = "Opel",
                Type = "Astra",
                Year = 1997,
                CreatedAt = DateTime.Now,
                ModifiedAt = DateTime.Now,

            };

            return car;
        }

        private CarDto MockNullCar()
        {
            CarDto nullDto = new()
            {
                Id = null,
                Brand = "Renault",
                Type = "Clio",
                Year = 2018,               
                CreatedAt = DateTime.Now.AddYears(-1),
                ModifiedAt = DateTime.Now.AddYears(-1),
            };
            return nullDto;
        }
    }
}
