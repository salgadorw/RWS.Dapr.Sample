
using Domain.Contracts;
using Domain.Exceptions;
using Domain.Models;

namespace Domain.DomainEntities
{
    public class GameDE : IGameDE
    {
        private readonly IFeedGateway feedGateway  ;
        public GameDE(IFeedGateway feedGateway)
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
