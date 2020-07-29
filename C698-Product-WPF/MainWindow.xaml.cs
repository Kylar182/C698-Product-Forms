using System.Threading.Tasks;
using System.Windows;
using C698_Product_WPF.Persistence.Repositories.Interfaces;

namespace C698_Product_WPF
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    private readonly IPartRepository _partRepository;
    private readonly IProductRepository _productRepository;

    public MainWindow(IPartRepository partRepository, IProductRepository productRepository)
    {
      _partRepository = partRepository;
      _productRepository = productRepository;
      InitializeComponent();
      GetData();
    }

    private async Task GetData()
    {
      PartsGrid.ItemsSource = await _partRepository.GetAll();
      ProductsGrid.ItemsSource = await _productRepository.GetAll();
    }

    private void Exit_Click(object s, RoutedEventArgs e)
    {

    }

    private void Parts_Add_Click(object s, RoutedEventArgs e)
    {

    }

    private void Parts_Modify_Click(object s, RoutedEventArgs e)
    {

    }

    private void Parts_Delete_Click(object s, RoutedEventArgs e)
    {

    }

    private void Products_Add_Click(object s, RoutedEventArgs e)
    {

    }

    private void Products_Modify_Click(object s, RoutedEventArgs e)
    {

    }

    private void Products_Delete_Click(object s, RoutedEventArgs e)
    {

    }
  }
}
