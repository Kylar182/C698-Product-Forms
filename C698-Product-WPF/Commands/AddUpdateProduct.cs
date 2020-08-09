using System;
using System.Windows.Input;
using C698_Product_WPF.Data.ViewModels;

namespace C698_Product_WPF.Commands
{
  public class AddUpdateProduct : ICommand
  {
    public event EventHandler CanExecuteChanged;

    public ProductVM Product { get; set; }

    public AddUpdateProduct(ProductVM vm)
    {
      Product = vm;
    }

    public bool CanExecute(object parameter)
    {
      if (Product.InStock > Product.Min
        && Product.InStock < Product.Max
        && Product.Min < Product.Max)
        return true;

      return false;
    }

    public async void Execute(object parameter)
    {
      if (Product.Id == null)
        await Product.Add();
      else
        await Product.Update();
    }
  }
}
