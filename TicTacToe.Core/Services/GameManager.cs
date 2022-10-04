using Newtonsoft.Json;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Core.Exceptions;
using TicTacToe.Core.Helpers;
using TicTacToe.Core.Helpers.Extensions;
using TicTacToe.Core.Models;

namespace TicTacToe.Core.Services
{
    /// <summary>
    /// Manages game.
    /// </summary>
    public interface IGameManager
    {
        /// <summary>
        /// Configures game with game configuration.
        /// </summary>
        /// <param name="configuration"></param>
        void Configure(Configuration configuration);
        /// <summary>
        /// Configuration used by game. 
        /// </summary>
        Configuration Configuration { get; }
        bool IsConfigured { get; }
        Game Game { get; }

        Player CurrentPlayer { get; }

        /// <summary>
        /// Fires after completed turn.
        /// </summary>
        event EventHandler<TurnEventArgs> OnTurn;
        /// <summary>
        /// Fires after player change.
        /// </summary>
        event EventHandler<PlayerChangeEventArgs> OnPlayerChange;

        /// <summary>
        /// Resets game status.
        /// </summary>
        void Reset();

        /// <summary>
        /// Starts game moving to first player.
        /// </summary>
        void Start();

        /// <summary>
        /// Makes turn for current player and moves to the next one.
        /// </summary>
        /// <param name="position"></param>
        /// <param name="playerId"></param>
        /// <returns></returns>
        TurnInfo MakeTurn(Position position);

    }

    public class GameManager : IGameManager
    {
        private readonly ILogger logger;
        private readonly IBoardInitBuilder boardBuilder;
        private readonly IGameInitBuilder gameBuilder;
        private readonly IGameJudge gameJudge;
        private CircularList<Guid> playerIds;
        /// <summary>
        /// The game configuration.
        /// </summary>
        public Configuration Configuration { get; private set; }
        public bool IsConfigured => this.Configuration != null;
        /// <summary>
        /// The game instance of game manager.
        /// </summary>
        public Game Game { get; private set; }
        /// <summary>
        /// Gets the current player.
        /// When the game is not running, exception is thrown.
        /// </summary>
        public Player CurrentPlayer
        {
            get
            {
                this.Game.Players.TryGetValue(this.playerIds.Current, out Player player);
                return player;
            }
        }
        public event EventHandler<TurnEventArgs> OnTurn;
        public event EventHandler<PlayerChangeEventArgs> OnPlayerChange;

        public GameManager(
            ILogger logger, 
            IBoardInitBuilder boardBuilder,
            IGameInitBuilder gameBuilder,
            IGameJudge boardJudge)
        {
            this.logger = logger.Here();
            this.boardBuilder = boardBuilder;
            this.gameBuilder = gameBuilder;
            this.gameJudge = boardJudge;
        }

        public void Configure(Configuration configuration)
        {
            this.logger.Information($"Configuring game with configuration: '{JsonConvert.SerializeObject(configuration)}'");
            this.Configuration = configuration;

            // Builds board with settings.
            var board = this.boardBuilder
                .Start()
                .WithSize(configuration.GridSize)
                .Build();
            // Builds game with settings.
            this.Game = this.gameBuilder
                .Start()
                .WithBoard(board)
                .WithWinCount(configuration.WinCount)
                .WithPlayerCount(configuration.PlayerNames.Length)
                .WithPlayers(configuration.PlayerNames.Select(name => new Player(name)).ToArray())
                .Build();
            // Sets player ids from players.
            this.playerIds = new CircularList<Guid>(this.Game.Players.Select(pair => pair.Key).ToArray());

            this.logger.Information($"Configuration successful game: '{JsonConvert.SerializeObject(this.Game)}'");
        }

        public TurnInfo MakeTurn(Position position)
        {
            if (!this.IsConfigured)
            {
                throw new GameNotConfiguredException("Game is not configured properly by configuration.");
            }

            // Checks whether game is running.
            if (this.Game.State != Enums.GameStateEnum.Running)
            {
                throw new GameNoLongerRunningException("Cannot make turn - game is no longer running.");
            }            

            this.logger.Information($"Making turn at position {position} by player id '{this.playerIds.Current}'.");
            // Makes turn in game.
            var turn = this.Game.MakeTurn(position, this.playerIds.Current);

            // Gets judgement from game judge.
            var judgement = this.gameJudge.Judge(this.Game, turn);
            this.logger.Information($"Judgement: '{JsonConvert.SerializeObject(judgement)}'.");
            // Sets game state from judgement.
            this.Game.State = judgement.State;
            
            this.logger.Information($"Invoking {nameof(this.OnTurn)}.");
            // Invokes event OnTurn.
            this.OnTurn?.Invoke(this, new TurnEventArgs(turn, judgement.State));

            this.logger.Information("Turn finished.");
            if (this.Game.State == Enums.GameStateEnum.Running)
            {
                // Moves to next player.
                this.MoveToNextPlayer();
            }
            else
            {
                this.logger.Information($"Game finished with state {this.Game.State}.");
            }
                       
            return turn;
        }

        /// <summary>
        /// Moves to next player.
        /// </summary>
        private void MoveToNextPlayer()
        {
            var id = this.playerIds.Next();
            this.logger.Information($"Moving to next player id '{id}'");
            this.logger.Information($"Invoking {nameof(this.OnPlayerChange)}.");
            this.OnPlayerChange?.Invoke(this, new PlayerChangeEventArgs(this.Game.Players[id]));
        }

        public void Reset()
        {
            this.logger.Information("Resetting game...");

            this.Game.Reset();
            this.playerIds.Reset();
        }

        public void Start()
        {
            this.logger.Information("Starting game...");

            this.Game.Start();
            this.MoveToNextPlayer();
        }
    }
   
}
