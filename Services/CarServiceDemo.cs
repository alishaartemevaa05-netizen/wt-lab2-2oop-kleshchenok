using wt_lab2_2oop_kleshchenok.Interfaces;
using wt_lab2_2oop_kleshchenok.Models;

namespace wt_lab2_2oop_kleshchenok.Services;

public static class CarServiceDemo
{
    // Ссылка на интерфейс
    private static readonly ICarService _service = new CarService();

    static CarServiceDemo()
    {
        _service.Add(new Car(1, "Toyota", "Camry", 2022, 5000m));
        _service.Add(new ElectricCar(2, "Tesla", "Model 3", 2023, 9000m, 500));
        _service.Add(new Truck(3, "Volvo", "FH16", 2021, 15000m, 20m));
        _service.Add(new Car(4, "Kia", "Rio", 2020, 3000m));
        _service.Add(new Car(5, "BMW", "X5", 2023, 12000m));
        _service.Add(new ElectricCar(6, "Nissan", "Leaf", 2022, 6000m, 350));
    }

    public static ICarService Service => _service;

    public static void ShowAllCars()
    {
        Console.WriteLine("── Все автомобили ──");
        foreach (var car in _service.GetAll())
            car.PrintInfo();
    }
}