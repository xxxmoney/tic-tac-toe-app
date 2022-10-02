using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Core.Exceptions;
using TicTacToe.Core.Models;

namespace TicTacToe.Core.Services
{
    public interface IGameInitBuilder
    {
        IGameBoardBuilder Start();
    }

    public interface IGameBoardBuilder
    {
        IGameWinCountBuilder WithBoard(Board board);
    }

    public interface IGameWinCountBuilder
    {
        IGamePlayerCountBuilder WithWinCount(int winCount);
    }

    public interface IGamePlayerCountBuilder
    {
        IGamePlayersBuilder WithPlayerCount(int playerCount);
    }

    public interface IGamePlayersBuilder
    {
        IGameFinalBuilder WithPlayers(Player[] players);
    }

    public interface IGameFinalBuilder
    {
        Game Build();
    }

    public class GameBuilder : IGameInitBuilder, IGameBoardBuilder, IGameWinCountBuilder, IGamePlayerCountBuilder, IGamePlayersBuilder, IGameFinalBuilder
    {
        private Game game;

        public IGameBoardBuilder Start()
        {
            this.game = new Game();
            return this;
        }

        public IGameWinCountBuilder WithBoard(Board board)
        {
            this.game.Board = board ?? throw new Exception("Invalid board.");
            return this;
        }

        public IGamePlayerCountBuilder WithWinCount(int winCount)
        {
            bool rangeCheck = Helpers.Comparer.IsInRange(winCount, Constants.MinimumWinCount, Constants.MaximumWinCount);
            bool isOkWithBoardSize = winCount <= this.game.Board.Size;
            if (!rangeCheck || !isOkWithBoardSize)
            {
                throw new NotInRangeException($"Win count {winCount} was not in allowed range.");
            }

            this.game.WinCount = winCount;
            return this;
        }

        public IGamePlayersBuilder WithPlayerCount(int playerCount)
        {
            if (!Helpers.Comparer.IsInRange(playerCount, Constants.MinimumPlayerCount, Constants.MaximumPlayerCount))
            {
                throw new NotInRangeException($"Player count {playerCount} was not in allowed range.");
            }

            this.game.PlayerCount = playerCount;
            return this;
        }

        public IGameFinalBuilder WithPlayers(Player[] players)
        {
            if (players.Length != this.game.PlayerCount && players.Any(player => player == null))
            {
                throw new Exception("Invalid players.");
            }
           
            this.game.Players = players.ToDictionary(key => key.Guid, value => value);
            
            return this;
        }

        public Game Build()
        {
            return this.game;
        }
    }
}
