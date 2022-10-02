using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Core.Models
{
    public class TurnInfo
    {
        public TurnInfo(Piece piece, Player player)
        {
            Piece = piece;
            Player = player;
        }

        public Piece Piece { get; }
        public Player Player { get; }
    }
}
