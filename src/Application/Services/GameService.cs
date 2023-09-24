using AutoMapper;
using Application.DTOs;
using Domain.DomainEntities;
using Dapr.Client;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Domain.Models;

namespace Application.Services
{
    public class GameService : IGameService
    {
        private readonly IGameDE gameDomainEntities;
        private readonly IMapper mapper;
        private readonly DaprClient daprClient;
        public GameService(IGameDE gameDomainEntities, IMapper mapper, DaprClient daprClient)
        {
            this.gameDomainEntities = gameDomainEntities;
            this.mapper = mapper;
            this.daprClient = daprClient;
        }
        public async Task<ApiPagedResult<GameDto>> GetGames(int? offset, int? limit, CancellationToken token)
        {
            var gamePageResultCache = await daprClient.GetStateAsync<PagedResult<Game>>(nameof(GameService), offset.ToString() + limit.ToString(), cancellationToken: token).ConfigureAwait(false);
            var gamesPagedResult = gamePageResultCache?? await gameDomainEntities.GetGames(offset??0,limit??2, token);            
            var pagedResult = mapper.Map<ApiPagedResult<GameDto>>(gamesPagedResult);

            await daprClient.SaveStateAsync<PagedResult<Game>>(nameof(GameService), offset.ToString() + limit.ToString(), gamesPagedResult, cancellationToken: token).ConfigureAwait(false);

            return pagedResult;
        }

    }
}
