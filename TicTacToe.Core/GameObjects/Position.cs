using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Core.Models
{
    public struct Position
    {
        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; internal set; }
        public int Y { get; internal set; }

        public override string ToString()
        {
            return $"X: {this.X} Y: {this.Y}";
        }
    }
}
