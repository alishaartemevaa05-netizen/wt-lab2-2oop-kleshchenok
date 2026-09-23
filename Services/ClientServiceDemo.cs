using wt_lab2_2oop_kleshchenok.Models;

namespace wt_lab2_2oop_kleshchenok.Services;

public static class ClientServiceDemo
{
    public static readonly List<Client> Clients = new()
    {
        new Client(1, "Иванов Иван", "+79001112233", "AB123456"),
        new Client(2, "Петрова Анна", "+79004445566", "CD789012"),
        new Client(3, "Сидоров Пётр", "+79007778899", "EF345678"),
        new Client(4, "Кузнецова Мария", "+79002223344", "GH901234"),
        new Client(5, "Смирнов Олег", "+79005556677", "IJ567890"),
        new Client(6, "Волкова Елена", "+79008889900", "KL123456"),
        new Client(7, "Морозов Дмитрий", "+79003334455", "MN789012")
    };

    public static void ShowAllClients()
    {
        Console.WriteLine("── Все клиенты ──");
        foreach (var client in Clients)
            client.PrintInfo();
    }
}