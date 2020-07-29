using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using C698_Product_WPF.EntityModels;
using C698_Product_WPF.Extensions;
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
    List<Part> parts;
    List<Product> products;

    public MainWindow(IPartRepository partRepository, IProductRepository productRepository)
    {
      _partRepository = partRepository;
      _productRepository = productRepository;
      InitializeComponent();
      GetData();
    }

    private async Task GetData()
    {
      parts = await _partRepository.GetAll();
      products = await _productRepository.GetAll();
      PartsGrid.ItemsSource = parts;
      ProductsGrid.ItemsSource = products;
    }

    private void Parts_Search_Click(object s, RoutedEventArgs e)
    {
      if (Parts_Search.Text.TrimFix() != null && Parts_Search.Text.TrimFix().Length > 0)
      {
        PartsGrid.ItemsSource = parts.Where(x => x.Name.ToLower().Contains(Parts_Search.Text.ToLower())).ToList();
      }
      else
        PartsGrid.ItemsSource = parts;
    }

    private void Products_Search_Click(object s, RoutedEventArgs e)
    {
      if (Products_Search.Text.TrimFix() != null && Products_Search.Text.TrimFix().Length > 0)
      {
        ProductsGrid.ItemsSource = products.Where(x => x.Name.ToLower().Contains(Products_Search.Text.ToLower())).ToList();
      }
      else
        ProductsGrid.ItemsSource = products;
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

    private void Exit_Click(object s, RoutedEventArgs e)
    {
      Application.Current.Shutdown();
    }
  }
}
