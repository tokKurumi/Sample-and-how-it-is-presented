using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace Sample_and_how_it_is_presented.Core
{
	public static class ControlExtenssion
	{
		public static void UpdateControlSafe(this Control control, Action code)
		{
			if (!control.Dispatcher.CheckAccess())
			{
				control.Dispatcher.BeginInvoke(code);
			}
			else
			{
				code.Invoke();
			}
		}
	}
}
