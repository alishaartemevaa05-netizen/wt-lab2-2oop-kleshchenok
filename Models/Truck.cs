namespace wt_lab2_2oop_kleshchenok.Models;

public class Truck : Car
{
    public decimal LoadCapacityTons { get; private set; }

    public Truck(int id, string brand, string model, int year,
                 decimal pricePerDay, decimal loadCapacityTons)
        : base(id, brand, model, year, pricePerDay)
    {
        LoadCapacityTons = loadCapacityTons;
    }

    public override void PrintInfo()
    {
        base.PrintInfo();
        Console.WriteLine($"    → Грузовик, грузоподъёмность: {LoadCapacityTons} т");
    }

    public override string GetShortDescription()
        => base.GetShortDescription() + $" [Truck, {LoadCapacityTons} т]";
}