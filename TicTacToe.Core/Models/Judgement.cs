using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Core.Enums;

namespace TicTacToe.Core.Models
{
    public class Judgement
    {
        public Judgement(GameStateEnum state, Player player = null)
        {
            State = state;
            Player = player;
        }

        public GameStateEnum State { get; }
        public Player Player { get; }
    }
}
