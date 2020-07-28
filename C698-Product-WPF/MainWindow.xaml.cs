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
      GetDataAsync();
    }

    private async Task GetDataAsync()
    {
      PartsGrid.ItemsSource = await _partRepository.GetAll();
      ProductsGrid.ItemsSource = await _productRepository.GetAll();
    }
  }
}
