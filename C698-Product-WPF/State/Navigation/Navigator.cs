using System.Windows.Input;
using C698_Product_WPF.Commands;
using C698_Product_WPF.Data.ViewModels;
using C698_Product_WPF.Models;

namespace C698_Product_WPF.State.Navigation
{
  public class Navigator : ObservableObject, INavigator
  {
    private BaseView _currentVM;

    public BaseView CurrentVM
    {
      get
      {
        return _currentVM;
      }
      set
      {
        _currentVM = value;
        OnPropChange(nameof(CurrentVM));
      }
    }

    public ICommand UpdateCurrentVM => new UpdateCurrentVM(this);
  }
}
