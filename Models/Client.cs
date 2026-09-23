namespace wt_lab2_2oop_kleshchenok.Models;

public class Client : BaseEntity
{
    public string FullName { get; private set; }
    public string Phone { get; private set; }
    public string DriverLicense { get; private set; }

    public Client(int id, string fullName, string phone, string driverLicense)
        : base(id)
    {
        FullName = fullName;
        Phone = phone;
        DriverLicense = driverLicense;
    }

    public override string GetShortDescription() => $"{FullName} ({Phone})";

    public override void PrintInfo()
    {
        Console.WriteLine($"[Client #{Id}] {FullName}, тел: {Phone}, ВУ: {DriverLicense}");
    }
}