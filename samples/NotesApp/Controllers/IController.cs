
using NotesApp.Views;

namespace NotesApp.Controllers
{
  public interface IController
  {
    void Initialize();

    void Show();
    void ShowModal();
  }

  public interface IController<out T> : IController where T : IView
  {
    // TODO: How to hook into View events such as .Closing() in ControllerBase s ?
    //   since we can't be sure the child will call base.Initialize() we can't use
    //   it.
    T View { get; }
  }

  public interface IController<out TView, out TResult> : IController<TView>
    where TView : IView
  {
    TResult Result { get; }
  }
}
