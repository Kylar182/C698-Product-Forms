using System;
using System.Windows.Input;
using C698_Product_WPF.Data.DTOs;
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
      if (Product.PartSelected != null && Product.PartSelected != default(PartDTO))
        return true;
      return false;
    }

    public void Execute(object parameter)
    {
      Product.AddPart(Product.PartSelected);
    }
  }
}
