namespace wt_lab2_2oop_kleshchenok.Models;

public class Car : BaseEntity
{
    public string Brand { get; private set; }
    public string Model { get; private set; }
    public int Year { get; private set; }
    public decimal PricePerDay { get; private set; }
    public bool IsAvailable { get; protected set; } = true;

    public Car(int id, string brand, string model, int year, decimal pricePerDay)
        : base(id)
    {
        Brand = brand;
        Model = model;
        Year = year;
        PricePerDay = pricePerDay;
    }

    /// <summary>
    /// Обновление цены с валидацией. Прямое присваивание запрещено (private set).
    /// </summary>
    public void UpdatePrice(decimal newPrice)
    {
        if (newPrice <= 0)
            throw new ArgumentException("Цена должна быть положительной.");
        if (newPrice > 1_000_000m)
            throw new ArgumentException("Слишком высокая цена — проверьте данные.");

        PricePerDay = newPrice;
    }

    public void SetAvailable(bool value) => IsAvailable = value;

    public override string GetShortDescription()
        => $"{Brand} {Model} ({Year})";

    public override void PrintInfo()
    {
        Console.WriteLine($"[Car #{Id}] {Brand} {Model} ({Year}) — {PricePerDay:C}/сутки, " +
                          $"{(IsAvailable ? "доступен" : "в аренде")}");
    }
}