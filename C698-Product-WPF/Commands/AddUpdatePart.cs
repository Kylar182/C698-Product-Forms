using System;
using System.Windows.Input;
using C698_Product_WPF.Data.EntityModels.Types;
using C698_Product_WPF.Data.ViewModels;

namespace C698_Product_WPF.Commands
{
  public class AddUpdatePart : ICommand
  {
    public event EventHandler CanExecuteChanged;

    public PartVM Part { get; set; }

    public AddUpdatePart(PartVM vm)
    {
      Part = vm;
    }

    public bool CanExecute(object parameter)
    {
      if (Part.InStock > Part.Min && Part.InStock < Part.Max)
        return true;

      return false;
    }

    public async void Execute(object parameter)
    {
      if (Part.CUD == CUD.Add)
        await Part.Add();
      else
        await Part.Update();
    }
  }
}
