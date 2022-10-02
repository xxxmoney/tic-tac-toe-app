using Serilog;
using Serilog.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Test
{
    public class ConsoleLogger : ILogger
    {
        public void Write(LogEvent logEvent)
        {
            Console.WriteLine(logEvent.RenderMessage());
        }
    }
}
