
using System;
using NotesApp.Services;
using NotesApp.Views;
using NotesApp.Models;

namespace NotesApp.Controllers
{
  public abstract class ControllerBase<T> : IController<T>
    where T : class, IView
  {
    public INotificationService Notifier { get; set; }
    public virtual T View { get; set; }


    public abstract void Initialize();

    public virtual void Show() { View.Show(); }
    public virtual void ShowModal() { View.ShowDialog(); }

    protected virtual void Close() { View.Close(); }


    protected void DomainChecked(Action act, Action onCatch = null)
    {
      try { act(); }
      catch (DomainException de) {
        Notifier.NotifyError(de.Message);
        if (onCatch != null) onCatch();
      }
    }
  }

  public abstract class ControllerBase<TView, TResult> :
    ControllerBase<TView>, IController<TView, TResult>
    where TView : class, IView
  {
    private bool _resultIsSet = false;
    private TResult _result;

    public TResult Result
    {
      get { return _result; }
      protected set
      {
        _result = value;
        _resultIsSet = true;
      }
    }

    public override TView View
    {
      get { return base.View; }
      set
      {
        if (value == base.View)
          return;

        if (base.View != null)
          base.View.Closing -= ClosingHandler;

        (base.View = value).Closing += ClosingHandler;
      }
    }


    protected override void Close()
    {
      ensureResult();
      base.Close();
    }

    protected void ClosingHandler(object sender, EventArgs e)
    {
      ensureResult();
    }


    private void ensureResult()
    {
      if (!_resultIsSet)
        throw new InvalidOperationException("Result property must be set before Close()-ing.");
    }

  }
}
