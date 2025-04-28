namespace QueryLib.Demo.Models;

/// <summary>
/// Сущность
/// </summary>
public abstract class EntityId(int id)
{
    /// <summary>
    /// Id
    /// </summary>
    public int Id { get; } = id;
}