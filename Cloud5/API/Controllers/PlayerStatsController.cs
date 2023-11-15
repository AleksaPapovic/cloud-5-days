using Cloud5.API.Dto;
using Cloud5.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Cloud5.API.Controllers
{
    [ApiController]
    [Route("stats")]
    public class PlayerStatsController : ControllerBase
    {

        private readonly IPlayerStatsService _playerStatsService;
        public PlayerStatsController(IPlayerStatsService playerStatsService)
        {
            _playerStatsService = playerStatsService;
        }

        [HttpGet("player/{playerName}")]
        public async Task<ActionResult<PlayerStatsDto>> UploadCsvFile([FromRoute]GetPlayerStatsDto getPlayerStats)
        {
            return Ok(await _playerStatsService.GeneratePlayerStatsFromCsv(getPlayerStats));
        }
    }
}
