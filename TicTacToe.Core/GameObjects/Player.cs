using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Core.Models
{
    public class Player : GameObject
    {
        public Player(string name)
        {
            Name = name;
        }

        public string Name { get; }

        public override string ToString()
        {
            return $"Id: {this.Guid} Name: {this.Name}";
        }

        public override bool Equals(object obj)
        {
            if (obj is Player player)
            {
                return player.Guid == this.Guid;
            }

            return false;
        }
    }
}
