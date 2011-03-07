
using NotesApp.Views;

namespace NotesApp.Controllers
{
  public abstract class ControllerBase<T> : IController<T>
    where T : IView
  {
    public T View { get; set; }

    public abstract void Initialize();
    public virtual void Show() { View.Show(); }
  }
}
