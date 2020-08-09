using System;
using System.Windows.Input;
using C698_Product_WPF.Data.DTOs;
using C698_Product_WPF.Data.ViewModels;

namespace C698_Product_WPF.Commands
{
  public class RemovePartProduct : ICommand
  {
    public event EventHandler CanExecuteChanged;

    public ProductVM Product { get; set; }

    public RemovePartProduct(ProductVM vm)
    {
      Product = vm;
    }

    public bool CanExecute(object parameter)
    {
      if (Product.PartProductSelected != null
        && Product.PartProductSelected != default(PartProductDTO))
        return true;
      return false;
    }

    public void Execute(object parameter)
    {
      Product.RemovePart(Product.PartProductSelected);
    }
  }
}
