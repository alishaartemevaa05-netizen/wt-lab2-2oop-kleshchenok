namespace wt_lab2_2oop_kleshchenok.Models;

public class RentalContract : BaseEntity
{
    public Client Client { get; private set; }
    public Car Car { get; private set; }
    public Manager Manager { get; private set; }
    public DateTime StartDate { get; private set; }
    public int Days { get; private set; }
    public decimal TotalPrice { get; private set; }
    public bool IsClosed { get; private set; }

    public RentalContract(int id, Client client, Car car, Manager manager,
                          DateTime startDate, int days)
        : base(id)
    {
        if (days <= 0) throw new ArgumentException("Срок аренды должен быть > 0.");

        Client = client;
        Car = car;
        Manager = manager;
        StartDate = startDate;
        Days = days;
        TotalPrice = car.PricePerDay * days;
        IsClosed = false;
    }

    public void Close() => IsClosed = true;

    public override string GetShortDescription()
        => $"Договор #{Id}: {Client.FullName} → {Car.GetShortDescription()}";

    public override void PrintInfo()
    {
        Console.WriteLine($"[Договор #{Id}] {StartDate:yyyy-MM-dd}, {Days} дн., " +
                          $"итого {TotalPrice:C}, {(IsClosed ? "закрыт" : "активен")}");
        Console.WriteLine($"    Клиент:  {Client.FullName} ({Client.Phone})");
        Console.WriteLine($"    Авто:    {Car.GetShortDescription()}");
        Console.WriteLine($"    Менеджер:{Manager.FullName}");
    }
}