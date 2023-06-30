
using Domain.Abstractions;
using Domain.Exceptions;
using Domain.Models;

namespace Domain.Context
{
    public class GameContext : IGameContext
    {
        private readonly IFeedGateway feedGateway  ;
        public GameContext(IFeedGateway feedGateway)
        {
            this.feedGateway = feedGateway;
        }
        public async Task<PagedResult<Game>> GetGames(int offset, int limit, CancellationToken token)
        {
            if(limit > 10)
            {
                throw new PageSizeIsTooLongException();
            }

            return await this.feedGateway.GetGames(offset,limit, token);
        }        
    }
}
