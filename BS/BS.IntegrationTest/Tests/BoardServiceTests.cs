using BS.Core.Services;
using FluentAssertions;
using FluentResults.Extensions.FluentAssertions;

namespace BS.IntegrationTest.Tests
{
    public class BoardServiceTests
    {
        private IBoardService _service;
        private const int InputSize = 10;
        private const int ExpectedHeight = 10;
        private const int ExpectedWidth = 10;

        [SetUp]
        public void Setup()
        {
            _service = new BoardService();
        }

        [Test]
        public void When_creating_board_it_should_be_created_successfully()
        {
            var result = _service.InitializeBoard(InputSize);

            result.Should().BeSuccess();
        }

        [Test]
        public void When_creating_board_it_should_have_correct_height()
        {
            var result = _service.InitializeBoard(InputSize);
            var boardHeight = result.Value.Height;

            boardHeight.Should().Be(ExpectedHeight);
        }
        [Test]
        public void When_creating_board_it_should_have_correct_width()
        {
            var result = _service.InitializeBoard(InputSize);
            var boardWidth = result.Value.Width;

            boardWidth.Should().Be(ExpectedWidth);
        }
    }
}