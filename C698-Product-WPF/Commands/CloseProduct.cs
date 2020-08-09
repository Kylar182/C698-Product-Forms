using System;
using System.Windows.Input;
using C698_Product_WPF.Data.ViewModels;

namespace C698_Product_WPF.Commands
{
  public class CloseProduct : ICommand
  {
    public ProductVM Product { get; set; }
    public event EventHandler CanExecuteChanged;

    public CloseProduct(ProductVM vm)
    {
      Product = vm;
    }

    public bool CanExecute(object parameter)
    {
      return true;
    }

    public void Execute(object parameter)
    {
      Product.Close();
    }
  }
}
