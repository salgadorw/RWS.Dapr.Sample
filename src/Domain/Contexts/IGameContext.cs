using Domain.Models;

namespace Domain.Context
{
    public interface IGameContext
    {
        Task<PagedResult<Game>> GetGames(int offset, int limit, CancellationToken token);
       
    }
}
