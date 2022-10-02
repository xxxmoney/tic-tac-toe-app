using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Core.Services;

namespace TicTacToe.Test.Tests.Services
{
    public class BoardBuilderTest
    {
        [Test]
        public void Build()
        {
            // Arrange
            var builder = new BoardBuilder() as IBoardInitBuilder;
            int expectedSize = 4;

            // Act
            var board = builder
                .Start()
                .WithSize(expectedSize)
                .Build();
            
            // Assert
            Assert.That(board.Size, Is.EqualTo(expectedSize));
            Assert.That(board.Pieces.Length, Is.EqualTo(expectedSize * expectedSize));
        }
    }
}
