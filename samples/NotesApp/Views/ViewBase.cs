
using System;
using System.Windows.Forms;

namespace NotesApp.Views
{
  public class ViewBase : Form, IView
  {
    public event EventHandler Closing;

    // prevent instantiation while allowing the designer view
    protected ViewBase() { }

    protected override void OnFormClosing(FormClosingEventArgs e)
    {
      if (Closing != null)
        Closing(this, EventArgs.Empty);

      base.OnFormClosing(e);
    }

    // Show() ShowDialog() and Close() are implemented in Form already
  }
}
