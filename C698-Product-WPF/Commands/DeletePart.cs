using System;
using System.Windows;
using System.Windows.Input;
using C698_Product_WPF.Data.EntityModels.Types;
using C698_Product_WPF.Data.ViewModels;

namespace C698_Product_WPF.Commands
{
  public class DeletePart : ICommand
  {
    public PartVM Part { get; set; }
    public event EventHandler CanExecuteChanged;

    public DeletePart(PartVM vm)
    {
      Part = vm;
    }

    public bool CanExecute(object parameter)
    {
      if (Part.Id != null && Part.CUD == CUD.Delete)
        return true;

      return false;
    }

    public async void Execute(object parameter)
    {
      MessageBoxResult result = MessageBox.Show("Are you sure you want to Delete " + Part.Name + "?", "Confirm Delete", MessageBoxButton.OKCancel);
      if (result == MessageBoxResult.OK)
        await Part.Delete();
    }
  }
}
