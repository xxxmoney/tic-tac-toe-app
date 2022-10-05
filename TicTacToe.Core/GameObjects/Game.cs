using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Core.Enums;

namespace TicTacToe.Core.Models
{
    public class Game
    {
        public Board Board { get; internal set; }
        public int WinCount { get; internal set; }
        public int BoardSize => this.Board.Size;
        public GameStateEnum State { get; internal set; }
        public Player Winner { get; internal set; }
        public Dictionary<Guid, Player> Players { get; internal set; }
        public int PlayerCount { get; internal set; }
        
        public Game()
        {
            this.Initialize();
        }

        /// <summary>
        /// Initializes game state and sets resets winner => null.
        /// </summary>
        private void Initialize()
        {
            this.State = GameStateEnum.NotRunning;
            this.Winner = null;
        }

        /// <summary>
        /// Resets game while keeping game configured.
        /// </summary>
        public void Reset()
        {
            this.Initialize();
            this.Board.Reset();
        }

        /// <summary>
        /// Starts the game setting the state to running.
        /// </summary>
        public void Start()
        {
            this.State = GameStateEnum.Running;
        }

        /// <summary>
        /// Makes turn at position for player.
        /// </summary>
        /// <param name="position"></param>
        /// <param name="playerId"></param>
        /// <returns></returns>
        public TurnInfo MakeTurn(Position position, Guid playerId)
        {
            // Gets player by player id.
            if (!this.Players.TryGetValue(playerId, out Player player))
            {
                throw new Exception($"Could not find player with id '{playerId}'");
            }

            // Gets piece by position.
            var piece = this.Board[position];

            // Checks whether piece if free.
            piece.Mark(player);        

            return new TurnInfo(piece, player);
        }

    }
}
