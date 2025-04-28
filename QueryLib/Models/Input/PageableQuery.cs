namespace QueryLib.Models.Input;

/// <summary>
/// Запрос с пагинацией
/// </summary>
public abstract class PageableQuery
{
    /// <summary>
    /// Не позволяем брать больше 1_000
    /// </summary>
    private const int MaxTake = 1_000;

    private int _skip;
    
    /// <summary>
    /// Пропустить
    /// </summary>
    public int? Skip
    {
        get => _skip;
        set => _skip = value is > 0
            ? value.Value 
            : 0;
    }

    private int? _take;

    /// <summary>
    /// Взять
    /// </summary>
    public int? Take
    {
        get => _take ?? MaxTake;
        set => _take = value is not >= 0 or > MaxTake
            ? MaxTake
            : value.Value;
    }
}