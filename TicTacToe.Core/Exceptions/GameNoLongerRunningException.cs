using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Core.Exceptions
{
    public class GameNoLongerRunningException : Exception
    {
        public GameNoLongerRunningException(string message) : base(message)
        {
        }
    }
}
