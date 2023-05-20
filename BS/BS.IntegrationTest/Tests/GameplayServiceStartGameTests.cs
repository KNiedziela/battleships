using BS.Core.Entities.Ships;
using BS.Core.Services;
using BS.IntegrationTest.Helpers;
using FluentAssertions;
using FluentResults.Extensions.FluentAssertions;

namespace BS.IntegrationTest.Tests
{
    public class GameplayServiceStartGameTests
    {
        private IGameplayService _service;
        private readonly Dictionary<ShipType, int> _ships = new()
        {
            { ShipType.Battleship,1},
            { ShipType.Destroyer,2},
        };

        [SetUp]
        public void Setup()
        {
            _service = ContainerHelper.GetService<IGameplayService>();
        }

        [Test]
        public void When_starting_game_it_should_be__success()
        {
            var result = _service.StartGame(_ships);

            result.Should().BeSuccess();
        }
        [Test]
        public void When_starting_game_it_should_contain_correct_ship_amount()
        {
            _service.StartGame(_ships);

            var result = _service.GetAliveShips();
            result.Should().BeSuccess();

            var expectedAmount = _ships.Sum(pair => pair.Value);

            result.Value.Count.Should().Be(expectedAmount);
        }

    }
}