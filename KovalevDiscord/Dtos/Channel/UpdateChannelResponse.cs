namespace KovalevDiscord.Dtos.Channel;

/// <summary>
/// Дто ответа на обновление канала
/// </summary>
public class UpdateChannelResponse : BaseChannelDto
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public string Id { get; init; }
}