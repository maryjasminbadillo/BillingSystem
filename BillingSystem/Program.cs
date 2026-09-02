using System;
using System.Windows.Forms;

namespace BillingSystem;

internal static class Program
{
	[STAThread]
	private static void Main()
	{
		ApplicationConfiguration.Initialize();
		Application.Run(new LoginForm()); // J.B. Version
	}
}
