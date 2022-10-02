using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Core.Models
{
    public class Board : GameObject
    {
        public Piece[,] Pieces { get; private set; }
        public int Size { get; private set; }
        public int PieceCount => Size * Size;        

        /// <summary>
        /// Inits pieces array with specified size (size X size);
        /// </summary>
        /// <param name="size"></param>
        public void InitPieces(int size)
        {
            this.Size = size;   
            this.Pieces = new Piece[this.Size, this.Size];
        }

        public void Reset()
        {
            this.InitPieces(this.Size);
        }

        /// <summary>
        /// Checks whether position is valid - is in pieces array boundaries.
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        private bool ValidatePosition(Position position) =>
            position.X >= 0 &&
            position.X < this.Pieces.GetLength(0) &&
            position.Y >= 0 &&
            position.Y < this.Pieces.GetLength(1);
        public Piece this[Position position]
        {
            get
            {
                if (!this.ValidatePosition(position))
                {
                    throw new Exception($"Invalid position {position}.");
                }

                // Creates new piece if null.
                if (this.Pieces[position.X, position.Y] == null)
                {
                    this.Pieces[position.X, position.Y] = new Piece(position);
                }

                return this.Pieces[position.X, position.Y];
            }
            set
            {
                if (!this.ValidatePosition(position))
                {
                    throw new Exception($"Invalid position {position}.");
                }

                this.Pieces[position.X, position.Y] = value;
            }
        }

        /// <summary>
        /// Whether the board is fully marked.
        /// </summary>
        /// <returns></returns>
        public bool IsFullyMarked 
        {
            get 
            {
                foreach (var piece in this.Pieces)
                {
                    if (piece == null || !piece.IsMarked)
                    {
                        return false;
                    }
                }

                return true;
            }
        }
    }
}
