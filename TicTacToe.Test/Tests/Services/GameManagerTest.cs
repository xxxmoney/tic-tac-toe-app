using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Core.Models;
using TicTacToe.Core.Services;
using TicTacToe.Test.Tests.Helpers;

namespace TicTacToe.Test.Tests.Services
{
    public class GameManagerTest
    {
        private IGameManager GetGameManager()
        {
            var gameManager = new GameManager(
                new ConsoleLogger(),
                new BoardBuilder(), 
                new GameBuilder(), 
                new GameJudge()
            ) as IGameManager;

            return gameManager;
        }

        public static object[] ClassicConfigurationSource =
        {
            new object[] { new Configuration(3, 2, 3, "Josh", "Jacob") }
        };

        [Test]
        [TestCaseSource(nameof(ClassicConfigurationSource))]
        public void Configure(Configuration configuration)
        {
            // Arrange
            var gameManager = this.GetGameManager();

            // Act
            gameManager.Configure(configuration);

            // Assert
            Assert.That(gameManager.Game.Board.Size, Is.EqualTo(configuration.GridSize));
            Assert.That(gameManager.Game.PlayerCount, Is.EqualTo(configuration.PlayersCount));
            Assert.That(gameManager.Game.Players.Count, Is.EqualTo(configuration.PlayersCount));
            Assert.That(gameManager.Game.WinCount, Is.EqualTo(configuration.WinCount));
            Assert.IsTrue(Enumerable.SequenceEqual(gameManager.Game.Players.Select(pair => pair.Value.Name), configuration.PlayerNames));
        }

        [Test]
        [TestCaseSource(nameof(ClassicConfigurationSource))]
        public void Start(Configuration configuration)
        {
            // Arrange
            var gameManager = this.GetGameManager();
            gameManager.Configure(configuration);

            // Act
            gameManager.Start();

            // Assert
            Assert.That(gameManager.Game.State, Is.EqualTo(Core.Enums.GameStateEnum.Running));
            Assert.That(gameManager.CurrentPlayer, Is.Not.Null);
        }

        [Test]
        [TestCaseSource(nameof(ClassicConfigurationSource))]
        public void Reset(Configuration configuration)
        {
            // Arrange
            var gameManager = this.GetGameManager();
            gameManager.Configure(configuration);

            // Act
            gameManager.Start();
            gameManager.Reset();

            // Assert
            Assert.That(gameManager.Game.State, Is.Not.EqualTo(Core.Enums.GameStateEnum.Running));
            Assert.That(gameManager.CurrentPlayer, Is.Null);
        }

        static object[] PlaySource =
        {
            new object[] 
            { 
                new Configuration(9, 2, 3, "Josh", "Jacob"),
                new Position[]
                {
                    new Position(0, 0),
                    new Position(8, 8),
                    new Position(1, 1),
                    new Position(7, 5),
                    new Position(2, 2),
                }
            }
        };

        [Test]
        [TestCaseSource(nameof(PlaySource))]
        public void Play(Configuration configuration, Position[] turns)
        {
            // Arrange
            var gameManager = this.GetGameManager();
            gameManager.Configure(configuration);

            // Act
            gameManager.Start();
            var winningPlayer = gameManager.CurrentPlayer;
            foreach (var position in turns)
            {
                gameManager.MakeTurn(position);
            }
            
            // Assert
            Assert.That(gameManager.Game.State, Is.EqualTo(Core.Enums.GameStateEnum.SomeoneWon));
            Assert.That(gameManager.CurrentPlayer, Is.EqualTo(winningPlayer));
        }

    }
}
