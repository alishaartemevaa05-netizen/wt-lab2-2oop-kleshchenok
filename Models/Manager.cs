namespace wt_lab2_2oop_kleshchenok.Models;

public class Manager : BaseEntity
{
    public string FullName { get; private set; }
    public string Department { get; private set; }

    public Manager(int id, string fullName, string department)
        : base(id)
    {
        FullName = fullName;
        Department = department;
    }

    public override string GetShortDescription() => $"{FullName} ({Department})";

    public override void PrintInfo()
    {
        Console.WriteLine($"[Manager #{Id}] {FullName}, отдел: {Department}");
    }
}