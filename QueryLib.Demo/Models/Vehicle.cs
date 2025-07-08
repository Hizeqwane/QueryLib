namespace QueryLib.Demo.Models;

/// <summary>
/// Транспорт
/// </summary>
public class Vehicle(int id, string model) : EntityId(id)
{
    /// <summary>
    /// Модель
    /// </summary>
    public string Model { get; private set; } = model;

    /// <summary>
    /// Изменение модели
    /// </summary>
    public void SetModel(string value) => Model = value;
}