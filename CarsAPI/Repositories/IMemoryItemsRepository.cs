using CarsAPI.Entitites;

namespace CarsAPI.Repositories
{
    public interface IMemoryItemsRepository
    {
        Car GetCar(int id);
        IEnumerable<Car> GetCars();
        int GetCarsCount();
        void CreateCar(Car car);
        void UpdateCar(Car car);
        void DeleteCar(int id);
    }
}