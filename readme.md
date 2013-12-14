gNFOViewer
=========

I knocked up a quick NFO file viewer a few years back and just rediscovered the source.

Its written in C# under Mono, so you'll need Mono and GTK# at the very least. Check the README for details

**INSTALL NOTES:**


You'll need mono, mono-mcs and gtk-sharp2
    
To compile, change to the source directory (after extracting it) and type :-


`mcs -pkg:gtk-sharp-2.0 
-pkg:glade-sharp-2.0 -out:GNFOView.exe ./gtk-gui/generated.cs MainWindow.cs main.cs`

**USAGE NOTES:**

You can pass a filename to open as a command line parameter.

In the viewer, **CTRL-O** to open a file, **CTRL-I** to invert the colours, **CTRL-Q** to quit. Or use the menus, its up to you.  