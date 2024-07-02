namespace KovalevDiscord.Dtos.Channel;

/// <summary>
/// Базовое дто для канала
/// </summary>
public class BaseChannelDto
{
    /// <summary>
    /// Название канала
    /// </summary>
    public string Name { get; init; }
    
    /// <summary>
    /// Тип канала
    /// </summary>
    public int Type { get; init; }
}