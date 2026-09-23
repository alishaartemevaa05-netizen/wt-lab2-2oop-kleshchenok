using wt_lab2_2oop_kleshchenok.Models;

namespace wt_lab2_2oop_kleshchenok.Services;

public static class RentalServiceDemo
{
    private static readonly List<RentalContract> _contracts = new();
    private static readonly List<Manager> _managers = new()
    {
        new Manager(1, "Орлов Виктор", "Отдел аренды"),
        new Manager(2, "Зайцева Ольга", "Отдел корпоративных клиентов")
    };
    private static int _nextId = 1;

    static RentalServiceDemo()
    {
        // Пара демонстрационных договоров
        var client1 = ClientServiceDemo.Clients[0];
        var client2 = ClientServiceDemo.Clients[1];
        var car1 = CarServiceDemo.Service.GetById(1)!;
        var car2 = CarServiceDemo.Service.GetById(2)!;

        CreateContractInternal(client1, car1, _managers[0], 5);
        CreateContractInternal(client2, car2, _managers[1], 3);
    }

    public static void ShowAllRentals()
    {
        Console.WriteLine("── Все договоры аренды ──");
        if (_contracts.Count == 0)
        {
            Console.WriteLine("Договоров пока нет.");
            return;
        }
        foreach (var c in _contracts)
            c.PrintInfo();
    }

    public static void CreateRental()
    {
        Console.WriteLine("── Оформление новой аренды ──");

        // 1. Клиент
        Console.WriteLine("Доступные клиенты:");
        foreach (var c in ClientServiceDemo.Clients)
            Console.WriteLine($"  {c.Id}. {c.FullName}");

        Console.Write("Введите Id клиента: ");
        if (!int.TryParse(Console.ReadLine(), out int clientId))
        {
            Console.WriteLine("Некорректный Id.");
            return;
        }
        var client = ClientServiceDemo.Clients.FirstOrDefault(c => c.Id == clientId);
        if (client == null) { Console.WriteLine("Клиент не найден."); return; }

        // 2. Автомобиль
        Console.WriteLine();
        Console.WriteLine("Доступные автомобили:");
        foreach (var car in CarServiceDemo.Service.GetAll().Where(c => c.IsAvailable))
            Console.WriteLine($"  {car.Id}. {car.GetShortDescription()} — {car.PricePerDay:C}/сутки");

        Console.Write("Введите Id автомобиля: ");
        if (!int.TryParse(Console.ReadLine(), out int carId))
        {
            Console.WriteLine("Некорректный Id.");
            return;
        }
        var selectedCar = CarServiceDemo.Service.GetById(carId);
        if (selectedCar == null || !selectedCar.IsAvailable)
        {
            Console.WriteLine("Автомобиль недоступен.");
            return;
        }

        // 3. Срок
        Console.Write("Сколько дней аренды? ");
        if (!int.TryParse(Console.ReadLine(), out int days) || days <= 0)
        {
            Console.WriteLine("Некорректный срок.");
            return;
        }

        // 4. Менеджер
        var manager = _managers[0];

        // 5. Создание
        var contract = CreateContractInternal(client, selectedCar, manager, days);
        Console.WriteLine();
        Console.WriteLine("✔ Договор оформлен:");
        contract.PrintInfo();
    }

    private static RentalContract CreateContractInternal(Client client, Car car,
                                                         Manager manager, int days)
    {
        var contract = new RentalContract(_nextId++, client, car, manager,
                                          DateTime.Now, days);
        _contracts.Add(contract);
        car.SetAvailable(false);   // авто уходит в аренду
        return contract;
    }
}