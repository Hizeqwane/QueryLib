using QueryLib.Specifications;

namespace QueryLib.Models;

/// <summary>
/// Модификатор запроса
/// </summary>
public class Modifier<TResponse>(
    string key,
    ModifierDelegate<TResponse> modificationFunc)
{
    /// <summary>
    /// Ключ
    /// </summary>
    public string Key { get; } = key;
    
    /// <summary>
    /// Делегат модификации ответа
    /// </summary>
    public ModifierDelegate<TResponse> ModificationFunc { get; } = modificationFunc;
}