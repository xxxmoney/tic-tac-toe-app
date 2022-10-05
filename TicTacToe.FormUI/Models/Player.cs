using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.FormUI.Models
{
    public class Player : INotifyPropertyChanged
    {
        private string name;
        public string Name {
            get => this.name; 
            set
            {
                if (this.name != value)
                {
                    this.name = value;
                    this.NotifyPropertyChanged();
                }
            }
        }

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
