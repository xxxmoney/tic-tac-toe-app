using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Core.Models;

namespace TicTacToe.Core.Helpers
{
    public static class PositionHelper
    {
        /// <summary>
        /// Gets the left corner of the main diagonal - top left corner to the bottom right corner.
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public static Position GetMainDiagonalLeftCorner(Position position)
        {
            int difference = Math.Abs(position.X - position.Y);

            if (position.X < position.Y)
                return new Position
                {
                    X = 0,
                    Y = difference
                };
            else if (position.X > position.Y)
                return new Position
                {
                    X = difference,
                    Y = 0
                };

            return new Position
            {
                X = 0,
                Y = 0
            };
        }

        /// <summary>
        /// Gets the left corner of the anti diagonal the top right to the bottom left corner
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public static Position GetAntiDiagonalLeftCorner(Position position, int yLimit)
        {
            int x = position.X;
            int y = position.Y;

            while (x > 0 && y < yLimit - 1)
            {
                --x;
                ++y;
            }

            return new Position
            {
                X = x,
                Y = y
            };
        }
    }
}
