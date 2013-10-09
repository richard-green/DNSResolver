﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DnsResolver
{
    public static class ControlExtensions
    {
        /// <summary>
        /// Calls Invoke on the control if it is required - use this in multi-threaded situations
        /// </summary>
        public static void InvokeAction<T>(this T control, Action<T> action) where T : Control
        {
            if (control.InvokeRequired)
            {
                try
                {
                    control.Invoke
                    (
                        new Action<T, Action<T>>(InvokeAction),
                        new object[] { control, action }
                    );
                }
                catch (ObjectDisposedException)
                {
                }
            }
            else
            {
                action(control);
            }
        }
    }
}
