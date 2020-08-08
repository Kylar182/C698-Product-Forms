using C698_Product_WPF.State.Navigation;

namespace C698_Product_WPF.Data.ViewModels
{
  public class MainVM : BaseVM
  {
    public INavigator Navigator { get; set; } = new Navigator();
  }
}
