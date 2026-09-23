namespace wt_lab2_2oop_kleshchenok.Services;

public static class LinqDemo
{
    public static void Run()
    {
        var cars = CarServiceDemo.Service.GetAll().ToList();

        // 1. Where — фильтрация
        Console.WriteLine("── Автомобили дешевле 10 000 ──");
        var cheap = cars.Where(c => c.PricePerDay < 10000m);
        foreach (var c in cheap) c.PrintInfo();

        // 2. OrderBy / OrderByDescending — сортировка
        Console.WriteLine();
        Console.WriteLine("── Сортировка по цене (возрастание) ──");
        foreach (var c in cars.OrderBy(c => c.PricePerDay))
            Console.WriteLine($"{c.GetShortDescription(),-40} {c.PricePerDay:C}");

        Console.WriteLine();
        Console.WriteLine("── Сортировка по году (убывание) ──");
        foreach (var c in cars.OrderByDescending(c => c.Year))
            Console.WriteLine($"{c.GetShortDescription(),-40} {c.Year}");

        // 3. Select — проекция
        Console.WriteLine();
        Console.WriteLine("── Проекция: бренд, модель, цена ──");
        var projection = cars.Select(c => new { c.Brand, c.Model, c.PricePerDay });
        foreach (var p in projection)
            Console.WriteLine($"{p.Brand} {p.Model} — {p.PricePerDay:C}");

        // 4. Агрегаты
        Console.WriteLine();
        Console.WriteLine("── Агрегаты ──");
        Console.WriteLine($"Всего: {cars.Count}");
        Console.WriteLine($"Сумма цен: {cars.Sum(c => c.PricePerDay):C}");
        Console.WriteLine($"Средняя цена: {cars.Average(c => c.PricePerDay):C}");
        Console.WriteLine($"Мин. цена: {cars.Min(c => c.PricePerDay):C}");
        Console.WriteLine($"Макс. цена: {cars.Max(c => c.PricePerDay):C}");

        // 5. GroupBy — группировка
        Console.WriteLine();
        Console.WriteLine("── Группировка по бренду ──");
        var groups = cars.GroupBy(c => c.Brand);
        foreach (var g in groups)
        {
            Console.WriteLine($"Бренд {g.Key}: {g.Count()} шт., " +
                              $"средняя цена {g.Average(c => c.PricePerDay):C}");
        }
    }
}