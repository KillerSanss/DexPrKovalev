namespace KovalevDiscord;

/// <summary>
/// Класс параметров для создания сервера (гильдии)
/// </summary>
public class CreateDiscordGuildParams
{
    /// <summary>
    /// Принимает
    /// </summary>
    public string Accept { get; init; }
    
    /// <summary>
    /// Язык
    /// </summary>
    public string AcceptLanguage { get; init; }
    
    /// <summary>
    /// Опции дебага
    /// </summary>
    public string DebugOptions { get; init; }
    
    /// <summary>
    /// Язык дискорда
    /// </summary>
    public string DiscordLocale { get; init; }
    
    /// <summary>
    /// Временной пояс
    /// </summary>
    public string DiscordTimezone { get; init; }
    
    /// <summary>
    /// Супер параметры
    /// </summary>
    public string SuperProps { get; init; }
}
