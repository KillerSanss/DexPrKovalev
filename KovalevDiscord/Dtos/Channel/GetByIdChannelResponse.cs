namespace KovalevDiscord.Dtos.Channel;

/// <summary>
/// Дто ответа на получение канала по идентификатору
/// </summary>
public class GetByIdChannelResponse : BaseChannelDto
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public string Id { get; init; }
}