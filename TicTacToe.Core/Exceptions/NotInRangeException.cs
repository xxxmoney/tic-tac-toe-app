using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Core.Exceptions
{
    internal class NotInRangeException : Exception
    {
        public NotInRangeException(string message) : base(message)
        {
        }
    }
}
