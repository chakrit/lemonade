
using NotesApp.Views;

namespace NotesApp.Controllers
{
  public interface IController
  {
    void Initialize();
    void Show();
  }

  public interface IController<out T> : IController where T : IView
  {
    T View { get; }
  }
}
