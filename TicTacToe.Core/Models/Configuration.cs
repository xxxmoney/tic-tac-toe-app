using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Core.Models
{
    public class Configuration
    {
        public Configuration(int gridSize, int playersCount, int winCount, params string[] playerNames)
        {
            GridSize = gridSize;
            PlayersCount = playersCount;
            WinCount = winCount;
            PlayerNames = playerNames;
        }

        public int GridSize { get; }
        public int PlayersCount { get; }
        public int WinCount { get; set; }
        public string[] PlayerNames { get; set; }
    }
}
