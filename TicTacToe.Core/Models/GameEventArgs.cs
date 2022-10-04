using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Core.Enums;

namespace TicTacToe.Core.Models
{
    public class TurnEventArgs : EventArgs
    {
        public TurnInfo TurnInfo { get; }
        public GameStateEnum GameState { get; }

        public TurnEventArgs(TurnInfo turnInfo, GameStateEnum gameState)
        {
            this.TurnInfo = turnInfo;
            this.GameState = gameState;
        }

    }
}
