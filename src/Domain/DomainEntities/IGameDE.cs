using Domain.Models;

namespace Domain.DomainEntities
{
    public interface IGameDE
    {
        Task<PagedResult<Game>> GetGames(int offset, int limit, CancellationToken token);
       
    }
}
