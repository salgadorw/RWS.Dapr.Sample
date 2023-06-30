using Domain;
using Domain.Models;

namespace Domain.Abstractions
{
    public interface IFeedGateway
    {
        public Task<PagedResult<Game>> GetGames(int offset, int limit, CancellationToken token);
                       
    }
}
