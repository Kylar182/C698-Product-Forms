using System;
using System.Windows.Input;
using C698_Product_WPF.Data.ViewModels;

namespace C698_Product_WPF.Commands
{
  public class AddUpdatePart : ICommand
  {
    public PartVM Part { get; set; }

    public AddUpdatePart(PartVM vm)
    {
      Part = vm;
    }

    public bool CanExecute(object parameter)
    {
      return true;
    }

    public event EventHandler CanExecuteChanged
    {
      add { CommandManager.RequerySuggested += value; }
      remove { CommandManager.RequerySuggested -= value; }
    }

    public async void Execute(object parameter)
    {
      if (Part.Id == null)
        await Part.Add();
      else
        await Part.Update();
    }
  }
}
