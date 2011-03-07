
using System.Windows.Forms;

namespace NotesApp.Views
{
  public class ViewBase : Form, IView
  {
    // prevent instantiation while allowing the designer view
    protected ViewBase() { }
  }
}
