using System;
using System.Windows.Input;
using C698_Product_WPF.Data.ViewModels;

namespace C698_Product_WPF.Commands
{
  public class SearchParts : ICommand
  {
    public event EventHandler CanExecuteChanged;

    public ProductVM Product { get; set; }

    public SearchParts(ProductVM vm)
    {
      Product = vm;
    }

    public bool CanExecute(object parameter)
    {
      return true;
    }

    public async void Execute(object parameter)
    {
      await Product.SearchPart();
    }
  }
}
