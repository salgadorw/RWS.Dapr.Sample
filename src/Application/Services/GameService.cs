using AutoMapper;
using Application.DTOs;
using Domain.Context;
using Dapr.Client;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Domain.Models;

namespace Application.Services
{
    public class GameService : IGameService
    {
        private readonly IGameContext gameContext;
        private readonly IMapper mapper;
        private readonly DaprClient daprClient;
        public GameService(IGameContext gameContext, IMapper mapper, DaprClient daprClient)
        {
            this.gameContext = gameContext;
            this.mapper = mapper;
            this.daprClient = daprClient;
        }
        public async Task<ApiPagedResult<GameDto>> GetGames(int? offset, int? limit, CancellationToken token)
        {
            var gamePageResultCache = await daprClient.GetStateAsync<PagedResult<Game>>(nameof(GameService), offset.ToString() + limit.ToString(), cancellationToken: token).ConfigureAwait(false);
            var gamesPagedResult = gamePageResultCache?? await gameContext.GetGames(offset??0,limit??2, token);            
            var pagedResult = mapper.Map<ApiPagedResult<GameDto>>(gamesPagedResult);

            await daprClient.SaveStateAsync<PagedResult<Game>>(nameof(GameService), offset.ToString() + limit.ToString(), gamesPagedResult, cancellationToken: token).ConfigureAwait(false);

            return pagedResult;
        }

    }
}
