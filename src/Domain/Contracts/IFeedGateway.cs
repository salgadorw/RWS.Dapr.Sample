using Domain;
using Domain.Models;

namespace Domain.Contracts
{
    public interface IFeedGateway
    {
        public Task<PagedResult<Game>> GetGames(int offset, int limit, CancellationToken token);
                       
    }
}
