using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Core.Models
{
    public class PlayerChangeEventArgs : EventArgs
    {
        public Player Player { get; }

        public PlayerChangeEventArgs(Player player)
        {
            Player = player;
        }
        
    }
}
