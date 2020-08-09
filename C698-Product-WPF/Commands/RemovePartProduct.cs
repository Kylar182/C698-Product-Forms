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
      return true;
    }

    public void Execute(object parameter)
    {
      PartProductDTO part = (PartProductDTO)parameter;
      Product.RemovePart(part);
    }
  }
}
