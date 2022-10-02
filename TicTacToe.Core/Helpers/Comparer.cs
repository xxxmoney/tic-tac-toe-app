using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Core.Helpers
{
    internal static class Comparer
    {
        public static bool IsInRange(int value, int from, int to) => value >= from && value <= to;
    }
}
