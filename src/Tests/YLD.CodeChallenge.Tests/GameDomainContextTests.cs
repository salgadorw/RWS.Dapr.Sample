using Domain.Abstractions;
using Moq;
using Microsoft.Extensions.Options;
using Domain.Context;
using Domain.Exceptions;
using Infrastructure.Gateway;
using Infrastructure.Gateway.Options;

namespace Tests
{
    public class GameDomainContextTests
    {
        private readonly IFeedGateway feedGateway;
        public GameDomainContextTests() {

            var optionsMoq= new Mock<IOptions<FeedGatewayOptions>>();
            optionsMoq.Setup(s=> s.Value).Returns(new FeedGatewayOptions() {
                FeedUrl= "https://yld-recruitment-resources.s3.eu-west-2.amazonaws.com/steam_games_feed.json"
            });
            
            feedGateway = new FeedGateway(optionsMoq.Object, new HttpClient());   
            
        }

        [Fact]
        public async Task GetGames_LimitParameterBiggerThan10_ThrowsException()
        {
            //arrange

            var gameContext = new GameContext(feedGateway);

            
            //assert

               await Assert.ThrowsAsync<PageSizeIsTooLongException>(async ()=>
                                                                  //act
                                                                  await gameContext.GetGames(0, 11, default));
        }

        [Fact]
        public async Task GetGames_offset5Limit5_ReturnFive()
        {
            //arrange

            var gameContext = new GameContext(feedGateway);

            //act
            var result = await gameContext.GetGames(5, 5, default);
            //assert

            Assert.Equal(5,result.Items.Count);
        }
        [Fact]
        public async Task GetGames_offset0Limit0_Return0()
        {
            //arrange

            var gameContext = new GameContext(feedGateway);

            //act
            var result = await gameContext.GetGames(0, 0, default);

            //assert
            Assert.Equal(0, result.Items.Count);
        }
    }
}
