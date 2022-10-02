using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Core.Enums;
using TicTacToe.Core.Exceptions;

namespace TicTacToe.Core.Models
{
    public class Piece
    {
        public Piece(Position position, PieceStateEnum state = PieceStateEnum.Unmarked)
        {
            State = state;
            Position = position;
        }

        public PieceStateEnum State { get; internal set; }
        public Player MarkedBy { get; internal set; }
        public bool IsMarked => this.MarkedBy != null;
        public Position Position { get; internal set; }

        public void Mark(Player player)
        {
            if (this.State == PieceStateEnum.Marked)
            {
                throw new PieceMarkedException($"Piece already marked at {this.Position} by player {this.MarkedBy}.");
            }

            this.MarkedBy = player;
            this.State = PieceStateEnum.Marked;
        }

    }
}
