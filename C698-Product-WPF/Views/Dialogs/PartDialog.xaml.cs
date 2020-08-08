using System.Windows;

namespace C698_Product_WPF.Views.Dialogs
{
  /// <summary>
  /// Interaction logic for PartDialog.xaml
  /// </summary>
  public partial class PartDialog : Window
  {
    public PartDialog()
    {
      InitializeComponent();
      WindowStartupLocation = WindowStartupLocation.CenterScreen;
    }

    private void Dialog_True(object sender, RoutedEventArgs e)
    {
      DialogResult = true;
    }

    private void Dialog_False(object sender, RoutedEventArgs e)
    {
      DialogResult = false;
    }
  }
}
