namespace CarsAPI.Dtos
{
    public class CreateCarDto
    {
        public string Make { get; init; }
        public string Model { get; init; }
        public int Year { get; init; }
        public int Doors { get; init; }
        public string Color { get; init; }
        public int Price { get; init; }
    }
}
