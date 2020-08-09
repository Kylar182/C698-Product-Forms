using System;
using System.Windows.Input;
using C698_Product_WPF.Data.EntityModels.Types;
using C698_Product_WPF.Data.ViewModels;

namespace C698_Product_WPF.Commands
{
  public class DeleteProduct : ICommand
  {
    public ProductVM Product { get; set; }
    public event EventHandler CanExecuteChanged;

    public DeleteProduct(ProductVM vm)
    {
      Product = vm;
    }

    public bool CanExecute(object parameter)
    {
      if (Product.Id != null && Product.CUD == CUD.Delete)
        return true;

      return false;
    }

    public async void Execute(object parameter)
    {
      await Product.Delete();
    }
  }
}
