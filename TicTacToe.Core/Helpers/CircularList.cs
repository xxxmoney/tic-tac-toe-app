using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Core.Helpers
{
    /// <summary>
    /// Used to operate circulary on array of items. 
    /// Use Next() to move through items.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal class CircularList<T>
    {
        /// <summary>
        /// Array of items to be circulated.
        /// </summary>
        private readonly T[] items;
        private int startAt;
        /// <summary>
        /// Index of the current item.
        /// </summary>
        private int currentIndex;
        /// <summary>
        /// Current item.
        /// </summary>
        public T Current
        {
            get
            {
                if (this.currentIndex == -1)
                {
                    return default(T);
                }

                return this.items[this.currentIndex];
            }
        }

        /// <summary>
        /// Initializes with items array.
        /// </summary>
        /// <param name="items"></param>
        /// <param name="startAt">At what index to start at.</param>
        public CircularList(T[] items, StartAtEnum startAt = StartAtEnum.NoItem)
        {
            this.items = items;
            this.currentIndex = startAt switch
            {
                StartAtEnum.NoItem => -1,
                StartAtEnum.FirstItem => 0,
                _ => throw new Exception("Unknown enum."),
            };
            this.startAt = this.currentIndex;
        }

        /// <summary>
        /// Moves to next item and returns it.
        /// </summary>
        /// <returns></returns>
        public T Next()
        {
            if (++currentIndex >= this.items.Length)
            {
                this.currentIndex = 0;
            }

            return this.Current;
        }

        /// <summary>
        /// Reset to initial position;
        /// </summary>
        public void Reset()
        {
            this.currentIndex = this.startAt;
        }
    
        public enum StartAtEnum
        {
            NoItem,
            FirstItem
        }
    }

    
}
