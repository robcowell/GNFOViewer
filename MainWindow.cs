using System;
using Gtk;
using System.IO;
using System.Text;
using Gdk;


public class MainWindow: Gtk.Window
{
	protected Gtk.TextView textview1;
	protected Gtk.Toolbar toolbar1;
	public bool inverted=false;
	private FileSelection file_selection;
		
	public MainWindow (string[] args): base ("")
	{
		Stetic.Gui.Build (this, typeof(MainWindow));
		Pango.FontDescription fontdesc = Pango.FontDescription.FromString("Lucida ConsoleP,Monospace 9");
		this.textview1.ModifyBase(StateType.Normal,new Gdk.Color(0,0,0));
		this.textview1.ModifyText(StateType.Normal,new Gdk.Color(255,255,255));
		this.textview1.ModifyFont(fontdesc);
		this.textview1.PixelsAboveLines=-1;
		StreamReader reader;
		if (args!=null)
		{
			if(args.Length != 0)
			{
				reader = new StreamReader(args[0],Encoding.GetEncoding(437));			
				this.textview1.Buffer.Text = reader.ReadToEnd();
			}
		}
	}
	
	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}

	protected virtual void OnInvertActivated(object sender, System.EventArgs e)
	{
		if(inverted)
		{
			this.textview1.ModifyBase(StateType.Normal,new Gdk.Color(0,0,0));
			this.textview1.ModifyText(StateType.Normal, new Gdk.Color(255,255,255));
			inverted=false;
		}
		else
		{
			this.textview1.ModifyBase(StateType.Normal,new Gdk.Color(255,255,255));
			this.textview1.ModifyText(StateType.Normal, new Gdk.Color(0,0,0));
			inverted=true;
		}
			
	}

	protected virtual void OnOpenActivated(object sender, System.EventArgs e)
	{
		//Open fileselector
		file_selection = new FileSelection("Select an NFO file");
		file_selection.Complete("*.NFO");
		file_selection.OkButton.Clicked += new EventHandler(sel_OK_Clicked);
		file_selection.CancelButton.Clicked += new EventHandler(sel_Cancel_Clicked);
		file_selection.HideFileopButtons();
		file_selection.Run();
	}

	protected virtual void OnQuitActivated(object sender, System.EventArgs e)
	{
		Application.Quit();
	}

	private void sel_OK_Clicked (object obj, EventArgs args)
	{
		if(file_selection.Filename != string.Empty)
		{
			StreamReader reader;
			this.textview1.Buffer.Clear();
			reader = new StreamReader(file_selection.Filename,Encoding.GetEncoding(437));
			this.textview1.Buffer.Text=reader.ReadToEnd();
			file_selection.Hide();
		}				
	}

	private void sel_Cancel_Clicked (object obj, EventArgs args)
	{
		file_selection.Hide();
	}
}