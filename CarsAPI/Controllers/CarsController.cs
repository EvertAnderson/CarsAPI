using CarsAPI.Dtos;
using CarsAPI.Entitites;
using CarsAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly IMemoryItemsRepository repository;

        public CarsController(IMemoryItemsRepository repository)
        {
            this.repository = repository;
        }

        // GET /cars
        [HttpGet]
        public IActionResult GetCars()
        {
            return Ok(repository.GetCars().Select(item => item.AsDto()));
        }

        // GET /cars/id
        [HttpGet("{id}")]
        public IActionResult GetCar(int id)
        {
            var car = repository.GetCar(id);

            if (car is null)
            {
                return NotFound();
            }

            return Ok(car.AsDto());
        }

        // GET /cars/randomCar
        [HttpGet("randomCar")]
        public IActionResult GetCar()
        {
            Random rnd = new Random();
            int r = rnd.Next(repository.GetCarsCount());
            var cars = repository.GetCars().ToList();

            return Ok(cars[r].AsDto());
        }

        // POST //cars
        [HttpPost]
        public IActionResult CreateCar(CreateCarDto carDto)
        {
            Car car = new()
            {
                Id = repository.GetCars().Max(x => x.Id) + 1,
                Color = carDto.Color,
                Doors = carDto.Doors,
                Make = carDto.Make,
                Model = carDto.Model,
                Price = carDto.Price,
                Year = carDto.Year
            };

            repository.CreateCar(car);
            return CreatedAtAction(nameof(GetCar), new { id = car.Id }, car.AsDto());
        }

        // PUT /cars/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateCar(int id, UpdateCarDto carDto)
        {
            var existingItem = repository.GetCar(id);

            if (existingItem is null)
                return NotFound();

            Car updatedCar = existingItem with
            {
                Color = carDto.Color,
                Doors = carDto.Doors,
                Make = carDto.Make,
                Model = carDto.Model,
                Price = carDto.Price,
                Year = carDto.Year
            };

            repository.UpdateCar(updatedCar);
            return NoContent();
        }

        // DELETE /cars/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteCar(int id)
        {
            var existingItem = repository.GetCar(id);

            if (existingItem is null)
            {
                return NotFound();
            }

            repository.DeleteCar(id);
            return NoContent();
        }
    }
}
