using wt_lab2_2oop_kleshchenok.Interfaces;

namespace wt_lab2_2oop_kleshchenok.Models;

/// <summary>
/// Абстрактный базовый класс для всех сущностей предметной области.
/// </summary>
public abstract class BaseEntity : IStorable
{
    public int Id { get; protected set; }
    public DateTime CreatedAt { get; protected set; } = DateTime.Now;

    protected BaseEntity(int id)
    {
        Id = id;
    }

    public abstract string GetShortDescription();

    public virtual void PrintInfo()
    {
        Console.WriteLine($"[{GetType().Name} #{Id}] создано: {CreatedAt:yyyy-MM-dd HH:mm}");
    }
}