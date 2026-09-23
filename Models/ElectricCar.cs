namespace wt_lab2_2oop_kleshchenok.Models;

public class ElectricCar : Car
{
    public int BatteryRangeKm { get; private set; }

    public ElectricCar(int id, string brand, string model, int year,
                       decimal pricePerDay, int batteryRangeKm)
        : base(id, brand, model, year, pricePerDay)
    {
        BatteryRangeKm = batteryRangeKm;
    }

    public override void PrintInfo()
    {
        base.PrintInfo();
        Console.WriteLine($"    → Электромобиль, запас хода: {BatteryRangeKm} км");
    }

    public override string GetShortDescription()
        => base.GetShortDescription() + $" [EV, {BatteryRangeKm} км]";
}