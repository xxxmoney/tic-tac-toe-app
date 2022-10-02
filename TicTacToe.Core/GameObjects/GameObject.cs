using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Core.Models
{
    public class GameObject
    {
        public Guid Guid { get; } = Guid.NewGuid();
    }
}
