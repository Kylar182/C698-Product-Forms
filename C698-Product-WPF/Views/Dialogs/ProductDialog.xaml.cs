using System.Windows;

namespace C698_Product_WPF.Views.Dialogs
{
  /// <summary>
  /// Interaction logic for ProductDialog.xaml
  /// </summary>
  public partial class ProductDialog : Window
  {
    public ProductDialog()
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
