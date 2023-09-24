using Domain.Contracts;
using Moq;
using Microsoft.Extensions.Options;
using Domain.DomainEntities;
using Domain.Exceptions;
using Infrastructure.Gateway;
using Infrastructure.Gateway.Options;

namespace Tests
{
    public class GameDomainDomainEntitiesTests
    {
        private readonly IFeedGateway feedGateway;
        public GameDomainDomainEntitiesTests() {

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

            var gameDomainEntities = new GameDE(feedGateway);

            
            //assert

               await Assert.ThrowsAsync<PageSizeIsTooLongException>(async ()=>
                                                                  //act
                                                                  await gameDomainEntities.GetGames(0, 11, default));
        }

        [Fact]
        public async Task GetGames_offset5Limit5_ReturnFive()
        {
            //arrange

            var gameDomainEntities = new GameDE(feedGateway);

            //act
            var result = await gameDomainEntities.GetGames(5, 5, default);
            //assert

            Assert.Equal(5,result.Items.Count);
        }
        [Fact]
        public async Task GetGames_offset0Limit0_Return0()
        {
            //arrange

            var gameDomainEntities = new GameDE(feedGateway);

            //act
            var result = await gameDomainEntities.GetGames(0, 0, default);

            //assert
            Assert.Equal(0, result.Items.Count);
        }
    }
}
