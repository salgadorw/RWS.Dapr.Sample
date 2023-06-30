using System.Net;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.Swagger.Annotations;
using Application.DTOs;
using Application.Services;
using Domain.Exceptions;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly IGameService gameService;
        public GamesController(IGameService gameService)
        {
            this.gameService = gameService;
        }
      
        [HttpGet]
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(ApiPagedResult<GameDto>))]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [SwaggerResponse(HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Get([FromQuery] int offset, [FromQuery] int limit, CancellationToken token = default)
        {
            try
            {
                var result = await gameService.GetGames(offset, limit, token);
                return Ok(result);
            }
            catch (PageSizeIsTooLongException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                throw;
            }
        } 

    }
}
