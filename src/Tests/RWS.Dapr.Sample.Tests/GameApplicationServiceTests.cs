using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Options;
using Moq;
using Application.Mapping;
using Application.Services;
using Domain.Contracts;
using Domain.DomainEntities;
using Domain.Models;
using Infrastructure.Gateway;
using Infrastructure.Gateway.Options;
using Dapr.Client;

namespace Tests
{
    public class GameApplicationServiceTests
    {
        private readonly Mock<IGameDE> gameDomainEntitiesMock;
        private readonly IFeedGateway feedGateway;
        private readonly IMapper mapper;
        public GameApplicationServiceTests() {
            var optionsMoq = new Mock<IOptions<FeedGatewayOptions>>();
            optionsMoq.Setup(s => s.Value).Returns(new FeedGatewayOptions()
            {
                FeedUrl = "https://yld-recruitment-resources.s3.eu-west-2.amazonaws.com/steam_games_feed.json"
            });

            feedGateway = new FeedGateway(optionsMoq.Object, new HttpClient());

            gameDomainEntitiesMock = new Mock<IGameDE>();
            var config = new MapperConfiguration(cfg => cfg.AddProfile<MapperProfile>());
            mapper = config.CreateMapper();           

        }

        [Fact]
        public async Task GetGames_NullParameters_ReplacedForDefaultValues()
        {
            //arrange
            int offset=0;
            int limit =0;
            gameDomainEntitiesMock
                .Setup(s => s.GetGames(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<CancellationToken>())).Returns(feedGateway.GetGames(0,2, default))
                .Callback<int, int, CancellationToken>(async (off, lim, cancelToken) =>
                {
                    offset = off;
                    limit = lim;                    
                });

           
            var gameService = new GameService(gameDomainEntitiesMock.Object, mapper, new DaprClientBuilder().Build());

            //act

            await gameService.GetGames(null, null, default);

            //assert
            Assert.Equal(0, offset);
            Assert.Equal(2,limit);
        }

        [Fact]
        public async Task GetGames_offset5Limit5_ReturnFive()
        {
            //arrange
            int offset = 0;
            int limit = 0;
            gameDomainEntitiesMock
                .Setup(s => s.GetGames(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<CancellationToken>())).Returns(async () => {

                    var result = await feedGateway.GetGames(5, 5, default);
                    
                    return result;
            });
                    
                
            var gameService = new GameService(gameDomainEntitiesMock.Object, mapper, new DaprClientBuilder().Build());

            //act

            var result = await gameService.GetGames(5, 5, default);

            //assert
            Assert.Equal(5,result.Items.Count);
            
        }

    }
}
