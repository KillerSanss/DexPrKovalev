using KovalevDiscord.Dtos.Guild;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace KovalevDiscord.Controllers;

/// <summary>
/// Контроллер серверов (гильдий)
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class GuildsController : ControllerBase
{
    private readonly IDiscordApi _discordApi;
    private readonly AuthorizationToken _authorizationToken;

    public GuildsController(IDiscordApi discordApi, IOptions<AuthorizationToken> authorizationToken)
    {
        _discordApi = discordApi;
        _authorizationToken = authorizationToken.Value;
    }

    /// <summary>
    /// Получение всех серверов (гильдий) пользователя
    /// </summary>
    /// <returns>Список всех серверов (гильдий).</returns>
    [HttpGet("get_all_guilds")]
    public async Task<ActionResult<List<GetAllGuildsResponse>>> GetGuilds()
    {
        var guilds = await _discordApi.GetGuildsAsync(_authorizationToken.Token);
        return Ok(guilds);
    }

    /// <summary>
    /// Получение сервера (гильдии) по идентификатору
    /// </summary>
    /// <param name="guildId">Идентификатор сервера (гильдии).</param>
    /// <returns>Сервер (гильдия).</returns>
    [HttpGet("get_by_id_guild")]
    public async Task<ActionResult<GetByIdGuildResponse>> GetGuild(string guildId)
    {
        var guild = await _discordApi.GetGuildAsync(guildId, _authorizationToken.Token);
        return Ok(guild);
    }
    
    /// <summary>
    /// Создание сервера (гильдии)
    /// </summary>
    /// <param name="guild">Данные сервера (гильдии).</param>
    /// <returns>Созданный сервер (гильдия).</returns>
    [HttpPost("create_guild")]
    public async Task<ActionResult<CreateGuildResponse>> CreateGuild([FromBody] CreateGuildRequest guild)
    {
        var createdGuild = await _discordApi.CreateGuildAsync(guild, _authorizationToken.Token);
        return Ok(createdGuild);
    }

    /// <summary>
    /// Обновление сервера (гильдии).
    /// </summary>
    /// <param name="guildId">Идентификатор сервера (гильдии).</param>
    /// <param name="guild">Данные для обновления.</param>
    /// <returns>Обновленный сервер (гильдия).</returns>
    [HttpPatch("update_guild")]
    public async Task<ActionResult<UpdateGuildResponse>> UpdateGuild(string guildId, [FromBody] UpdateGuildRequest guild)
    {
        var updatedGuild = await _discordApi.UpdateGuildAsync(guildId, guild, _authorizationToken.Token);
        return Ok(updatedGuild);
    }

    /// <summary>
    /// Удаление сервера (гильдии)
    /// </summary>
    /// <param name="guildId">Идентификатор сервера (гильдии).</param>
    [HttpDelete("delete_guild")]
    public async Task<ActionResult> DeleteGuild(string guildId)
    {
        await _discordApi.DeleteGuildAsync(guildId, _authorizationToken.Token);
        return NoContent();
    }
}