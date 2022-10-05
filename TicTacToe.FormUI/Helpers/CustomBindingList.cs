using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.FormUI.Helpers
{
    /// <summary>
    /// Binding list that has event before remove.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal class CustomBindingList<T> : BindingList<T>
    {
        protected override void RemoveItem(int itemIndex)
        {
            T deletedItem = this.Items[itemIndex];

            if (BeforeRemove != null)
                BeforeRemove?.Invoke(deletedItem);

            base.RemoveItem(itemIndex);
        }

        public delegate void CustomDelegate(T deletedItem);
        public event CustomDelegate BeforeRemove;
    }
}
