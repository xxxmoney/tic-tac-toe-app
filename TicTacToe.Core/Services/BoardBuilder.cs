using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Core.Exceptions;
using TicTacToe.Core.Models;

namespace TicTacToe.Core.Services
{
    public interface IBoardInitBuilder
    {
        /// <summary>
        /// Starts building process.
        /// </summary>
        /// <returns></returns>
        IBoardSizeBuilder Start();
    }
    public interface IBoardSizeBuilder
    {
        /// <summary>
        /// Configures board size.
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        IBoardFinalBuilder WithSize(int size);
    }

    public interface IBoardFinalBuilder
    {
        /// <summary>
        /// Finalizes - builds board.
        /// </summary>
        /// <returns></returns>
        Board Build();
    }


    public class BoardBuilder : IBoardInitBuilder, IBoardSizeBuilder, IBoardFinalBuilder
    {
        private Board board;

        public IBoardSizeBuilder Start()
        {
            this.board = new Board();
            return this;
        }

        public IBoardFinalBuilder WithSize(int size)
        {
            if (!Helpers.Comparer.IsInRange(size, Constants.MinimumBoardSize, Constants.MaximumBoardSize))
            {
                throw new NotInRangeException($"Board size was not in allowed range value: {size}.");
            }

            this.board.InitPieces(size);
            return this;
        }

        public Board Build()
        {
            return this.board;
        }


    }
}
