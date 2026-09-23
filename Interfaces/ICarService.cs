using wt_lab2_2oop_kleshchenok.Models;

namespace wt_lab2_2oop_kleshchenok.Interfaces;

public interface ICarService
{
    void Add(Car car);
    Car? GetById(int id);
    IEnumerable<Car> GetAll();
    IEnumerable<Car> FindByBrand(string brand);
    IEnumerable<Car> FindByPrice(decimal maxPrice);
    bool Remove(int id);
}