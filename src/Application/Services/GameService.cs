using AutoMapper;
using Application.DTOs;
using Domain.Context;

namespace Application.Services
{
    public class GameService : IGameService
    {
        private readonly IGameContext gameContext;
        private readonly IMapper mapper;
        public GameService(IGameContext gameContext, IMapper mapper)
        {
            this.gameContext = gameContext;
            this.mapper = mapper;
        }
        public async Task<ApiPagedResult<GameDto>> GetGames(int? offset, int? limit, CancellationToken token)
        {
            var gamesPagedResult = await gameContext.GetGames(offset??0,limit??2, token);            
            var pagedResult = mapper.Map<ApiPagedResult<GameDto>>(gamesPagedResult);
            
            return pagedResult;
        }

    }
}
