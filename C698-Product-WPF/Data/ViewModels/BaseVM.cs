using System.ComponentModel;

namespace C698_Product_WPF.Data.ViewModels
{
  public abstract class BaseVM : INotifyPropertyChanged
  {
    public event PropertyChangedEventHandler PropertyChanged;

    protected void OnPropertyChanged(string propName)
    {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
    }

    private int? id;
    public int? Id
    {
      get { return id; }
      set
      {
        id = value;
        OnPropertyChanged(nameof(Id));
      }
    }

    private string name;
    public string Name
    {
      get { return name; }
      set
      {
        name = value;
        OnPropertyChanged(nameof(Name));
      }
    }
  }
}
