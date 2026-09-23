using wt_lab2_2oop_kleshchenok.Models;

namespace wt_lab2_2oop_kleshchenok.Services;

public static class AsyncDemo
{
    // ─────────── УРОВЕНЬ 1 ───────────

    /// <summary>
    /// Имитация длительной операции: задержка 1 секунда.
    /// </summary>
    public static async Task SimulateLongOperationAsync()
    {
        Console.WriteLine("  → Начало длительной операции...");
        await Task.Delay(1000);
        Console.WriteLine("  → Операция завершена.");
    }

    public static async Task RunAsync()
    {
        Console.WriteLine("── Асинхронная демонстрация ──");
        await SimulateLongOperationAsync();

        Console.WriteLine();
        Console.WriteLine("── Загрузка автомобилей из БД ──");
        var cars = await LoadCarsFromDbAsync();
        Console.WriteLine($"Загружено автомобилей: {cars.Count}");
        foreach (var c in cars) c.PrintInfo();
    }

    // ─────────── УРОВЕНЬ 2 ───────────

    /// <summary>
    /// Имитация загрузки с обработкой ошибок.
    /// </summary>
    public static async Task<List<Car>> LoadCarsFromDbAsync()
    {
        Console.WriteLine("  → Загрузка автомобилей из БД...");
        try
        {
            await Task.Delay(1500);

            // Имитация возможной ошибки 
            if (DateTime.Now.Second % 30 == 0)
                throw new InvalidOperationException("Сбой подключения к БД.");

            return new List<Car>
            {
                new Car(101, "Audi", "A6", 2023, 11000m),
                new ElectricCar(102, "Nissan", "Leaf", 2022, 6000m, 350),
                new Truck(103, "MAN", "TGX", 2020, 18000m, 25m)
            };
        }
        catch (Exception ex)
        {
            Console.WriteLine($"  ✖ Ошибка: {ex.Message}");
            return new List<Car>();
        }
        finally
        {
            Console.WriteLine("  → Блок finally выполнен (освобождение ресурсов).");
        }
    }

    // ─────────── УРОВЕНЬ 3 ───────────

    /// <summary>
    /// Параллельная загрузка трёх независимых источников + отмена.
    /// </summary>
    public static async Task RunParallelAndCancelAsync()
    {
        Console.WriteLine("── Параллельная загрузка (Task.WhenAll) ──");

        var task1 = LoadCarsFromDbAsync();
        var task2 = LoadClientsFromApiAsync();
        var task3 = LoadContractsFromFileAsync();

        await Task.WhenAll(task1, task2, task3);

        Console.WriteLine();
        Console.WriteLine($"Итого: машин — {task1.Result.Count}, " +
                          $"клиентов — {task2.Result.Count}, " +
                          $"договоров — {task3.Result.Count}");

        Console.WriteLine();
        Console.WriteLine("── Отмена длительной операции (CancellationToken) ──");
        using var cts = new CancellationTokenSource();
        cts.CancelAfter(600);   // отменить через 600 мс

        try
        {
            await LongOperationWithCancellationAsync(cts.Token);
        }
        catch (OperationCanceledException)
        {
            Console.WriteLine("  ✖ Операция отменена по таймауту.");
        }
    }

    private static async Task<List<Client>> LoadClientsFromApiAsync()
    {
        Console.WriteLine("  → Загрузка клиентов из API...");
        await Task.Delay(1200);
        return ClientServiceDemo.Clients.Take(3).ToList();
    }

    private static async Task<List<string>> LoadContractsFromFileAsync()
    {
        Console.WriteLine("  → Чтение договоров из файла...");
        await Task.Delay(800);
        return new List<string> { "Договор #1", "Договор #2" };
    }

    private static async Task LongOperationWithCancellationAsync(CancellationToken token)
    {
        for (int i = 1; i <= 10; i++)
        {
            token.ThrowIfCancellationRequested();
            Console.WriteLine($"  Шаг {i}/10...");
            await Task.Delay(200, token);
        }
        Console.WriteLine("  ✔ Операция завершена полностью.");
    }
}