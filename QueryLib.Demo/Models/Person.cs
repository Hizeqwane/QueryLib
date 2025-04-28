namespace QueryLib.Demo.Models;

/// <summary>
/// Человек
/// </summary>
public class Person(int id, string name) : EntityId(id)
{
    /// <summary>
    /// Имя
    /// </summary>
    public string Name { get; } = name;
}