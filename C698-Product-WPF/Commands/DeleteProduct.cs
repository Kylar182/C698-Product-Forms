using System;
using System.Windows;
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
      if (Product.Id != null
        && Product.CUD == CUD.Delete
        && Product.PartProducts.Count < 1)
        return true;

      return false;
    }

    public async void Execute(object parameter)
    {
      MessageBoxResult result = MessageBox.Show("Are you sure you want to Delete " + Product.Name + "?", "Confirm Delete", MessageBoxButton.OKCancel);
      if (result == MessageBoxResult.OK)
        await Product.Delete();
    }
  }
}
