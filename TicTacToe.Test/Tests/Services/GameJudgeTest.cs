using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Core.Enums;
using TicTacToe.Core.Models;
using TicTacToe.Core.Services;

namespace TicTacToe.Test.Tests.Services
{
    public class GameJudgeTest
    {
        private Game BuildGame()
        {
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
            return builder
                .Start()
                .WithBoard(board)
                .WithWinCount(winCount)
                .WithPlayerCount(playerCount)
                .WithPlayers(players)
                .Build();
        }

        static object[] IsConsecutiveForPlayerCaseSource =
        {
            new object[] 
            { 
                9,
                new Position[]
                {
                    new Position(0, 0),
                    new Position(1, 1),
                    new Position(2, 2),
                },
                3,
                true,
                JudgeSearchEnum.MainDiagonal
            },
            new object[]
            {
                9,
                new Position[]
                {
                    new Position(5, 5),
                    new Position(4, 4),
                    new Position(3, 3),
                },
                3,
                true,
                JudgeSearchEnum.MainDiagonal
            },
            new object[]
            {
                9,
                new Position[]
                {
                    new Position(5, 5),
                    new Position(4, 4),
                    new Position(2, 2),
                },
                3,
                false,
                JudgeSearchEnum.MainDiagonal
            },
            new object[]
            {
                9,
                new Position[]
                {
                    new Position(2, 0),
                    new Position(1, 1),
                    new Position(0, 2),
                },
                3,
                true,
                JudgeSearchEnum.AntiDiagonal
            },
            new object[]
            {
                9,
                new Position[]
                {
                    new Position(5, 5),
                    new Position(4, 5),
                    new Position(3, 5),
                    new Position(2, 5),
                },
                4,
                true,
                JudgeSearchEnum.Horizontal
            },
            new object[]
            {
                9,
                new Position[]
                {
                    new Position(3, 5),
                    new Position(3, 6),
                    new Position(3, 7),
                    new Position(3, 8),
                },
                4,
                true,
                JudgeSearchEnum.Vertical
            },
            new object[]
            {
                9,
                new Position[]
                {
                    new Position(3, 5),
                    new Position(3, 6),
                    new Position(2, 7),
                    new Position(3, 8),
                },
                4,
                false,
                JudgeSearchEnum.Vertical
            }
        };

        [Test]
        [TestCaseSource(nameof(IsConsecutiveForPlayerCaseSource))]
        public void IsConsecutiveForPlayer(int size, Position[] marked, int winCount, bool shouldWin, JudgeSearchEnum searchType)
        {
            // Arrange
            var judge = new GameJudge() as IGameJudge;
            var player = new Player("John");
            var pieces = new Piece[size, size];
            foreach (var position in marked)
            {
                var piece = new Piece(position);
                piece.Mark(player);
                pieces[position.X, position.Y] = piece;
            }

            // Act
            var result = judge.IsConsecutiveForPlayer(pieces, marked.Last(), player, winCount, searchType);

            // Assert
            Assert.That(result, Is.EqualTo(shouldWin));
        }

        [Test]
        public void FindAnyWinning()
        {
            // Arrange
            var judge = new GameJudge() as IGameJudge;
            var game = this.BuildGame();

            game.Start();

            var player = game.Players.First().Value;
            game.Board[new Position(0, 0)].Mark(player);
            game.Board[new Position(1, 1)].Mark(player);
            game.Board[new Position(2, 2)].Mark(player);

            // Act
            var result = judge.FindAnyWinning(game, new TurnInfo(game.Board[new Position(2, 2)], player));

            // Assert
            Assert.That(result, Is.True);
        }

        [Test]
        public void Judge()
        {
            // Arrange
            var judge = new GameJudge() as IGameJudge;
            var game = this.BuildGame();

            game.Start();

            var player = game.Players.First().Value;
            game.Board[new Position(0, 0)].Mark(player);
            game.Board[new Position(0, 1)].Mark(player);
            game.Board[new Position(0, 2)].Mark(player);

            // Act
            var judgement = judge.Judge(game, new TurnInfo(game.Board[new Position(0, 2)], player));

            // Assert
            Assert.That(judgement.State, Is.EqualTo(Core.Enums.GameStateEnum.SomeoneWon));
            Assert.That(judgement.Player, Is.EqualTo(player));
        }
    }
}
