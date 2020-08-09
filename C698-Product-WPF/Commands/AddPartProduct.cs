using System;
using System.Windows.Input;
using C698_Product_WPF.Data.EntityModels;
using C698_Product_WPF.Data.ViewModels;

namespace C698_Product_WPF.Commands
{
  public class AddPartProduct : ICommand
  {
    public event EventHandler CanExecuteChanged;

    public ProductVM Product { get; set; }

    public AddPartProduct(ProductVM vm)
    {
      Product = vm;
    }

    public bool CanExecute(object parameter)
    {
      return true;
    }

    public void Execute(object parameter)
    {
      Part part = (Part)parameter;
      Product.AddPart(part);
    }
  }
}
