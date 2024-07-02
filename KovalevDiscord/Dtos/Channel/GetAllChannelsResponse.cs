namespace KovalevDiscord.Dtos.Channel;

/// <summary>
/// Дто ответа на получение всех каналов
/// </summary>
public class GetAllChannelsResponse : BaseChannelDto
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public string Id { get; init; }
}