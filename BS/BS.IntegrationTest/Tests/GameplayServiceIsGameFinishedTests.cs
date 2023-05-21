using BS.Common.Builders.Builders;
using BS.Core.Entities;
using BS.Core.Repositories;
using BS.Core.Services;
using BS.IntegrationTest.Helpers;
using FluentResults.Extensions.FluentAssertions;

namespace BS.IntegrationTest.Tests
{
    public class GameplayServiceIsGameFinishedTests
    {
        private IGameplayService _service;
        private IBoardRepository _repository;

        [SetUp]
        public void Setup()
        {
            _service = ContainerHelper.GetService<IGameplayService>();
            _repository = ContainerHelper.GetService<IBoardRepository>();
        }

        [Test]
        public void When_checking_if_finished_should_be_success()
        {
            var board = GameBoardBuilder.Build(10);

            _repository.AddGameBoard(board);

            var result = _service.IsGameFinished();

            result.Should().BeSuccess();
        }

        [Test]
        public void When_checking_if_finished_with_empty_board()
        {
            var board = GameBoardBuilder.Build(10);

            _repository.AddGameBoard(board);

            var result = _service.IsGameFinished();

            result.Should().HaveValue(true);
        }

        [Test]
        public void When_ship_alive_should_be_false()
        {
            var testShip = ShipBuilder.BuildDestroyer()
                .WithCoordinates(Coordinates.Create(1, 1), true);
            var board = GameBoardBuilder.Build(10)
                .WithShip(testShip);

            _repository.AddGameBoard(board);

            var result = _service.IsGameFinished();

            result.Should().HaveValue(false);
        }
        [Test]
        public void When_ship_dead_should_be_true()
        {
            var testShip = ShipBuilder.BuildDestroyer()
                .WithCoordinates(Coordinates.Create(1, 1), true)
                .WithHitPoints(0);
            var board = GameBoardBuilder.Build(10)
                .WithShip(testShip);

            _repository.AddGameBoard(board);

            var result = _service.IsGameFinished();

            result.Should().HaveValue(true);
        }
    }
}