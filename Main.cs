// project created on 3/5/2007 at 12:08 PM
using System;
using Gtk;

namespace GNFOView
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Application.Init ();
			MainWindow win = new MainWindow (args);
			win.Show ();
			Application.Run ();
		}
	}
}