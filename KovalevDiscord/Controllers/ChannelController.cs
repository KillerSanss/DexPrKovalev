using KovalevDiscord.Dtos.Channel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace KovalevDiscord.Controllers;

/// <summary>
/// Контроллер каналов на сервере (гильдии)
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class ChannelController : ControllerBase
{
    private readonly IDiscordApi _discordApi;
    private readonly AuthorizationToken _authorizationToken;

    public ChannelController(IDiscordApi discordApi, IOptions<AuthorizationToken> authorizationToken)
    {
        _discordApi = discordApi;
        _authorizationToken = authorizationToken.Value;
    }
    
    /// <summary>
    /// Получение всех каналов на сервере (гильдии)
    /// </summary>
    /// <param name="guildId">Идентификатор сервера (гильдии).</param>
    /// <returns>Список все каналов.</returns>
    [HttpGet("get_all_guild_channels")]
    public async Task<ActionResult<List<GetAllChannelsResponse>>> GetGuildChannelsAsync(string guildId)
    {
        var channels  = await _discordApi.GetChannelsAsync(guildId, _authorizationToken.Token);
        return Ok(channels);
    }

    /// <summary>
    /// Получение канала по идентификатору
    /// </summary>
    /// <param name="channelId">Идентификатор канала.</param>
    /// <returns>Канал.</returns>
    [HttpGet("get_by_id_channel")]
    public async Task<ActionResult<GetByIdChannelResponse>> GetChannelByIdAsync(string channelId)
    {
        var channel = await _discordApi.GetChannelAsync(channelId, _authorizationToken.Token);
        return Ok(channel);
    }

    /// <summary>
    /// Создание канала
    /// </summary>
    /// <param name="guildId">Идентификатор сервера (гильдии).</param>
    /// <param name="channel">Данные канала.</param>
    /// <returns>Созданный канал.</returns>
    [HttpPost("create_channel")]
    public async Task<ActionResult<CreateChannelResponse>> CreateChannelAsync(string guildId, [FromBody] CreateChannelRequest channel)
    {
        var createdChannel = await _discordApi.CreateChannelAsync(guildId, channel,  _authorizationToken.Token);
        return Ok(createdChannel);
    }
    
    /// <summary>
    /// Обновление канала
    /// </summary>
    /// <param name="channelId">Идентификатор канала.</param>
    /// <param name="channel">Данные для обновления.</param>
    /// <returns>Обновленный канал.</returns>
    [HttpPatch("update_channel")]
    public async Task<ActionResult<UpdateChannelResponse>> UpdateChannelAsync(string channelId, [FromBody] UpdateChannelRequest channel)
    {
        var updatedChannel = await _discordApi.UpdateChannelAsync(channelId, channel, _authorizationToken.Token);
        return Ok(updatedChannel);
    }

    /// <summary>
    /// Удаление канала
    /// </summary>
    /// <param name="channelId">Идентификатор канала.</param>
    [HttpDelete("delete_channel")]
    public async Task<ActionResult> DeleteChannelAsync(string channelId)
    {
        await _discordApi.DeleteChannelAsync(channelId, _authorizationToken.Token);
        return NoContent();
    }
}