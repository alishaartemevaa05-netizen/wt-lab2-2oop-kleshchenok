using wt_lab2_2oop_kleshchenok.Interfaces;
using wt_lab2_2oop_kleshchenok.Models;

namespace wt_lab2_2oop_kleshchenok.Services;

public class CarService : ICarService
{
    private readonly List<Car> _cars = new();

    public void Add(Car car)
    {
        if (car == null) throw new ArgumentNullException(nameof(car));
        _cars.Add(car);
    }

    public Car? GetById(int id) => _cars.FirstOrDefault(c => c.Id == id);

    public IEnumerable<Car> GetAll() => _cars;

    public IEnumerable<Car> FindByBrand(string brand)
        => _cars.Where(c => c.Brand.Equals(brand, StringComparison.OrdinalIgnoreCase));

    public IEnumerable<Car> FindByPrice(decimal maxPrice)
        => _cars.Where(c => c.PricePerDay <= maxPrice);

    public bool Remove(int id)
    {
        var car = GetById(id);
        return car != null && _cars.Remove(car);
    }
}