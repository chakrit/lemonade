
using System;
using System.Windows.Forms;

namespace NotesApp.Views
{
  public interface IView
  {
    event EventHandler Closing;

    void Show();
    DialogResult ShowDialog();

    void Close();
  }
}
