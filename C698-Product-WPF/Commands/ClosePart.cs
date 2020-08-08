using System;
using System.Windows.Input;
using C698_Product_WPF.Data.ViewModels;

namespace C698_Product_WPF.Commands
{
  public class ClosePart : ICommand
  {
    public PartVM Part { get; set; }
    public event EventHandler CanExecuteChanged;

    public ClosePart(PartVM vm)
    {
      Part = vm;
    }

    public bool CanExecute(object parameter)
    {
      return true;
    }

    public void Execute(object parameter)
    {
      Part.Close();
    }
  }
}
