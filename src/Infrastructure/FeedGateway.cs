using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Domain.Contracts;
using Domain.Models;
using Infrastructure.Gateway.Options;

namespace Infrastructure.Gateway
{
    public class FeedGateway : IFeedGateway
    {
        private readonly IOptions<FeedGatewayOptions> options;
        private readonly HttpClient httpClient;
        public FeedGateway(IOptions<FeedGatewayOptions> options, HttpClient client)
        {
           httpClient = client;
           this.options = options;
        }

        private async Task<string> ReadFile()
        {
            return await File.ReadAllTextAsync(AppContext.BaseDirectory + "\\data\\steam_games_feed.json").ConfigureAwait(false);
        }

        public async Task<PagedResult<Game>> GetGames(int offset, int limit, CancellationToken token)
        {
            var games = new List<Game>();          
            var jsonString = string.Empty;

            try
            {
               var response = await httpClient.GetAsync(options.Value.FeedUrl).ConfigureAwait(false);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    jsonString = await response.Content.ReadAsStringAsync(token);
                else
                    jsonString = await ReadFile();
            }
            catch (Exception e)
            {
                jsonString = await ReadFile();
                
            }

            games = JsonConvert.DeserializeObject<List<Game>>(jsonString);

            var result = new PagedResult<Game>()
            {
                Items = games.OrderByDescending(o => o.ReleaseDate).Skip(offset).Take(limit).ToList(),
                TotalItems = games.Count()
            };

            return result;
        }       
    }
}
