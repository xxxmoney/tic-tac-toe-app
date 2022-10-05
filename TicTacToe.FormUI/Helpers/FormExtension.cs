using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TicTacToe.FormUI.Forms;

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

        /// <summary>
        /// Applies resource to form and children controls.
        /// </summary>
        /// <param name="control"></param>
        /// <param name="cmp"></param>
        public static void ApplyResourceToControl(
           this Form form)
        {
            var cmp = new ComponentResourceManager(form.GetType());
            cmp.ApplyResources(form, form.Name, Thread.CurrentThread.CurrentCulture);

            foreach (Control child in form.Controls)
                child.ApplyResourceToControl(cmp);
        }

        /// <summary>
        /// Applies resource to control and children controls.
        /// </summary>
        /// <param name="control"></param>
        /// <param name="cmp"></param>
        public static void ApplyResourceToControl(
           this Control control,
           ComponentResourceManager cmp)
        {
            cmp.ApplyResources(control, control.Name, Thread.CurrentThread.CurrentCulture);

            foreach (Control child in control.Controls)
                child.ApplyResourceToControl(cmp);
        }


    }
}
