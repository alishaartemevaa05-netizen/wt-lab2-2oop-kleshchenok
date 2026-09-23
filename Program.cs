using wt_lab2_2oop_kleshchenok.Services;

Console.OutputEncoding = System.Text.Encoding.UTF8;

Console.WriteLine("╔══════════════════════════════════════════╗");
Console.WriteLine("║   АВТОСАЛОН / АРЕНДА АВТОМОБИЛЕЙ         ║");
Console.WriteLine("║   Лабораторная работа №2                 ║");
Console.WriteLine("╚══════════════════════════════════════════╝");
Console.WriteLine();
//коммит
//коммит
bool running = true;
while (running)
{
    Console.WriteLine("Выберите действие:");
    Console.WriteLine("1. Показать все автомобили");
    Console.WriteLine("2. Показать всех клиентов");
    Console.WriteLine("3. Оформить аренду");
    Console.WriteLine("4. Показать все договоры аренды");
    Console.WriteLine("5. Статистика (LINQ)");
    Console.WriteLine("6. Асинхронная загрузка данных");
    Console.WriteLine("7. Параллельная загрузка + отмена");
    Console.WriteLine("0. Выход");
    Console.Write("> ");

    var choice = Console.ReadLine();
    Console.WriteLine();

    switch (choice)
    {
        case "1": CarServiceDemo.ShowAllCars(); break;
        case "2": ClientServiceDemo.ShowAllClients(); break;
        case "3": RentalServiceDemo.CreateRental(); break;
        case "4": RentalServiceDemo.ShowAllRentals(); break;
        case "5": LinqDemo.Run(); break;
        case "6": await AsyncDemo.RunAsync(); break;
        case "7": await AsyncDemo.RunParallelAndCancelAsync(); break;
        case "0": running = false; break;
        default: Console.WriteLine("Неверный выбор."); break;
    }

    if (running)
    {
        Console.WriteLine();
        Console.WriteLine("Нажмите Enter для продолжения...");
        Console.ReadLine();
        Console.Clear();
    }
}

Console.WriteLine("До свидания!");