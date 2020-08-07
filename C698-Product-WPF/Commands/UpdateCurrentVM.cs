using System;
using System.Windows.Input;
using C698_Product_WPF.Data.ViewModels;
using C698_Product_WPF.State.Navigation;

namespace C698_Product_WPF.Commands
{
  public class UpdateCurrentVM : ICommand
  {
    public event EventHandler CanExecuteChanged;

    private INavigator _navigator;

    public UpdateCurrentVM(INavigator navigator)
    {
      _navigator = navigator;
    }

    public bool CanExecute(object parameter)
    {
      return true;
    }

    public void Execute(object parameter)
    {
      if (parameter is ViewType)
      {
        ViewType view = (ViewType)parameter;
        switch (view)
        {
          case ViewType.Part:
            _navigator.CurrentVM = new PartVM();
            break;
          case ViewType.Product:
            _navigator.CurrentVM = new ProductVM();
            break;
        }
      }
    }
  }
}
