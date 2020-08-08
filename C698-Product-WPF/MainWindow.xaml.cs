using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using C698_Product_WPF.Data.DTOs;
using C698_Product_WPF.Data.EntityModels;
using C698_Product_WPF.Data.EntityModels.Types;
using C698_Product_WPF.Data.Supervisors.Interfaces;
using C698_Product_WPF.Data.ViewModels;
using C698_Product_WPF.Extensions;
using C698_Product_WPF.Persistence.Repositories.Interfaces;
using C698_Product_WPF.Views.Dialogs;

namespace C698_Product_WPF
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    private readonly IPartSupervisor _partSupervisor;
    private readonly IProductRepository _productRepository;
    private readonly IPartRepository _partRepository;

    List<PartDTO> parts;
    List<Product> products;

    public MainWindow(
      IPartSupervisor partSupervisor,
      IProductRepository productRepository,
      IPartRepository partRepository
      )
    {
      _partSupervisor = partSupervisor;
      _productRepository = productRepository;
      _partRepository = partRepository;
      InitializeComponent();
      WindowStartupLocation = WindowStartupLocation.CenterScreen;
      GetData();
    }

    private async Task GetData()
    {
      parts = await _partSupervisor.GetAll();
      products = await _productRepository.GetAll();
      PartsGrid.ItemsSource = parts;
      ProductsGrid.ItemsSource = products;
    }

    private void Parts_Search_Click(object s, RoutedEventArgs e)
    {
      if (Parts_Search.Text.TrimFix() != null && Parts_Search.Text.TrimFix().Length > 0)
      {
        PartsGrid.ItemsSource = parts.Where(x => x.Id.ToString().ToLower().Contains(Parts_Search.Text.ToLower())).ToList();
      }
      else
        PartsGrid.ItemsSource = parts;
    }

    private void Products_Search_Click(object s, RoutedEventArgs e)
    {
      if (Products_Search.Text.TrimFix() != null && Products_Search.Text.TrimFix().Length > 0)
      {
        ProductsGrid.ItemsSource = products.Where(x => x.Id.ToString().ToLower().Contains(Products_Search.Text.ToLower())).ToList();
      }
      else
        ProductsGrid.ItemsSource = products;
    }

    private void Parts_Add_Click(object s, RoutedEventArgs e)
    {
      PartDialog dialog = new PartDialog();
      dialog.MainGrid.DataContext = new PartVM(_partRepository, CUD.Add);
      dialog.ShowDialog();
    }

    private void Parts_Modify_Click(object s, RoutedEventArgs e)
    {
      PartDTO selected = (PartDTO)PartsGrid.SelectedItem;
      if (selected != null && selected != default(PartDTO))
      {
        PartDialog dialog = new PartDialog();
        dialog.MainGrid.DataContext = PartVM.LoadVM(_partRepository, selected.Id.Value, CUD.Modify);
        dialog.ShowDialog();
      }
    }

    private void Parts_Delete_Click(object s, RoutedEventArgs e)
    {
      PartDTO selected = (PartDTO)PartsGrid.SelectedItem;
      if (selected != null && selected != default(PartDTO))
      {
        PartDialog dialog = new PartDialog();
        dialog.MainGrid.DataContext = PartVM.LoadVM(_partRepository, selected.Id.Value, CUD.Delete);
        dialog.ShowDialog();
      }
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
