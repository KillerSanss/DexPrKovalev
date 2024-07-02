namespace KovalevDiscord.Dtos.Channel;

/// <summary>
/// Дто ответа на создание канала
/// </summary>
public class CreateChannelResponse : BaseChannelDto
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public string Id { get; init; }
}