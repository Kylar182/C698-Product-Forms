using System.Windows.Input;
using C698_Product_WPF.Commands;
using C698_Product_WPF.Data.ViewModels;

namespace C698_Product_WPF.State.Navigation
{
  public enum ViewType
  {
    Part,
    Product
  }
  public interface INavigator
  {
    BaseView CurrentVM { get; set; }
    ICommand UpdateCurrentVM => new UpdateCurrentVM(this);
  }
}
