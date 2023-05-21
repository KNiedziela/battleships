using BS.Common.Builders.Builders;
using BS.Core.Entities;
using BS.Core.Models;
using BS.Core.Repositories;
using BS.Core.Services;
using BS.IntegrationTest.Helpers;
using FluentResults.Extensions.FluentAssertions;

namespace BS.IntegrationTest.Tests
{
    public class GameplayServiceTakeShotTests
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
        public void When_taking_a_shot_should_be_success()
        {
            var testShip = ShipBuilder.BuildDestroyer()
                .WithCoordinates(Coordinates.Create(1, 1), true);
            var board = GameBoardBuilder.Build(10)
                .WithShip(testShip);

            _repository.AddGameBoard(board);

            var result = _service.TakeShot(new TakeShootInputModel
            {
                TargetField = "A1"
            });

            result.Should().BeSuccess();
        }
        [Test]
        public void When_taking_a_shot_should_be_failed_when_targeting_same_position()
        {
            var coordinates = Coordinates.Create(3, 2);
            var board = GameBoardBuilder.Build(10)
                .WithShotHistoryEntry(coordinates);

            _repository.AddGameBoard(board);

            var result = _service.TakeShot(new TakeShootInputModel
            {
                TargetField = "B3"
            });

            result.Should().BeFailure();
        }

        [TestCase("A1", ExpectedResult = true)]
        [TestCase("A6", ExpectedResult = false)]
        [TestCase("B1", ExpectedResult = false)]
        [TestCase("C1", ExpectedResult = false)]
        public bool When_taking_a_shot_should_be_success(string targetField)
        {
            var testShip = ShipBuilder.BuildDestroyer()
                .WithCoordinates(Coordinates.Create(1, 1), true);
            var board = GameBoardBuilder.Build(10)
                .WithShip(testShip);

            _repository.AddGameBoard(board);

            var result = _service.TakeShot(new TakeShootInputModel
            {
                TargetField = targetField
            });

            return result.Value;
        }

    }
}