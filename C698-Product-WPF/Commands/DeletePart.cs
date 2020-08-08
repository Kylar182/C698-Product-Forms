using System;
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
      else
        return false;
    }

    public async void Execute(object parameter)
    {      
      await Part.Delete();
    }
  }
}
