namespace wt_lab2_2oop_kleshchenok.Interfaces;

/// <summary>
/// Контракт для сущностей, которые можно хранить в репозитории.
/// </summary>
public interface IStorable
{
    int Id { get; }
    DateTime CreatedAt { get; }
    string GetShortDescription();
}