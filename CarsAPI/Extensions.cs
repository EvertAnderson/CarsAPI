using CarsAPI.Dtos;
using CarsAPI.Entitites;

namespace CarsAPI
{
    public static class Extensions
    {
        public static CarDto AsDto(this Car item)
        {
            return new CarDto
            {
                Id = item.Id,
                Color = item.Color,
                Doors = item.Doors,
                Make = item.Make,
                Model = item.Model,
                Price = item.Price,
                Year = item.Year
            };
        }
    }
}
