using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Core.Models;
using TicTacToe.Core.Services;

namespace TicTacToe.Test.Tests.Services
{
    public class GameBuilderTest
    {
        [Test]
        public void Build()
        {
            // Arrange
            var builder = new GameBuilder() as IGameInitBuilder;
            var board = (new BoardBuilder() as IBoardInitBuilder)
                .Start()
                .WithSize(4)
                .Build();
            int winCount = 3;
            int playerCount = 2;
            var players = new Player[]
            {
                new Player("Josh"),
                new Player("Jacob")
            };

            // Act
            var game = builder
                .Start()
                .WithBoard(board)
                .WithWinCount(winCount)
                .WithPlayerCount(playerCount)
                .WithPlayers(players)
                .Build();

            // Assert
            Assert.That(game.WinCount, Is.EqualTo(winCount));
            Assert.That(game.PlayerCount, Is.EqualTo(playerCount));
            Assert.That(game.Players.Count, Is.EqualTo(playerCount));
            foreach (var player in players)
            {
                Assert.That(game.Players[player.Guid].Name, Is.EqualTo(player.Name));
            }
        }

    }
}
