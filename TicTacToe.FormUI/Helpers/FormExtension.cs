using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.FormUI.Helpers
{
    internal static class FormExtension
    {
        /// <summary>
        /// Locks resizing from default size based on flags enum.
        /// </summary>
        /// <param name="form"></param>
        /// <param name="lockEnum"></param>
        public static void LockResising(this Form form, ResizeLockEnum lockEnum)
        {
            if (lockEnum.HasFlag(ResizeLockEnum.ShrinkLock))
                form.MinimumSize = form.Size;
            if (lockEnum.HasFlag(ResizeLockEnum.GrowLock))
                form.MaximumSize = form.Size;
        }

        [Flags]
        public enum ResizeLockEnum
        {
            ShrinkLock = 0,
            GrowLock = 1,
        }
    }
}
