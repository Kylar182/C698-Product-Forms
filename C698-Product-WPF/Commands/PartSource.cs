using System;
using System.Windows.Input;
using C698_Product_WPF.Data.EntityModels.Types;
using C698_Product_WPF.Data.ViewModels;

namespace C698_Product_WPF.Commands
{
  public class PartSource : ICommand
  {
    public PartVM Part { get; set; }
    public event EventHandler CanExecuteChanged;

    public PartSource(PartVM vm)
    {
      Part = vm;
    }

    public bool CanExecute(object parameter)
    {
      if (Part.CUD != CUD.Delete)
        return true;
      else
        return false;
    }

    public void Execute(object parameter)
    {
      if ((string)parameter == "0")
        Part.Source = Source.InHouse;
      else if ((string)parameter == "1")
        Part.Source = Source.OutSourced;
    }
  }
}
