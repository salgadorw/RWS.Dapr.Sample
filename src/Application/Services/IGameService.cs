using Application.DTOs;

namespace Application.Services
{
    public interface IGameService
    {
        Task<ApiPagedResult<GameDto>> GetGames(int? offset, int? limit, CancellationToken token);
      
    }
}
