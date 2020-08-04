using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using C698_Product_WPF.Data.EntityModels;
using C698_Product_WPF.Data.EntityModels.Types;
using C698_Product_WPF.Data.Supervisors.Interfaces;
using C698_Product_WPF.Data.ViewModels;

namespace C698_Product_WPF.Windows.Dialogs
{
  /// <summary>
  /// Interaction logic for Part.xaml
  /// </summary>
  public partial class PartDialog : Window
  {
    private readonly IPartSupervisor _supervisor;
    protected string WindowLabel;
    protected string InOut;
    protected CUD CUD;
    protected Part Part;
    protected int id;
    protected Source source;

    public PartDialog(IPartSupervisor supervisor)
    {
      _supervisor = supervisor;
      WindowLabel = CUD.ToString() + " Part";
      InitializeComponent();
      WindowStartupLocation = WindowStartupLocation.CenterScreen;
    }

    public async Task ActivateAsync(object cud, object idin, object sourcein)
    {
      CUD = (CUD)cud;
      id = (int)idin;
      if (CUD != CUD.Add)
      {
        source = (Source)sourcein;

        PartVM part = await _supervisor.GetById(id);

        partId.Text = part.Id.ToString();
        name.Text = part.Name;
        inventory.Text = part.InStock.ToString();
        price.Text = part.Price.ToString();
        max.Text = part.Max.ToString();
        min.Text = part.Min.ToString();

        InOutSet(part.Source);
      }
    }

    private void InOutSet(Source source)
    {
      InputScope scope = new InputScope();
      InputScopeName scopeName = new InputScopeName();

      if (source == Source.InHouse)
      {
        InOut = "Machine ID";
        scopeName.NameValue = InputScopeNameValue.Number;
        scope.Names.Add(scopeName);
      }
      else
      {
        InOut = "Company Name";
        scopeName.NameValue = InputScopeNameValue.Default;
        scope.Names.Add(scopeName);
      }

      inOut.InputScope = scope;
    }
  }
}
