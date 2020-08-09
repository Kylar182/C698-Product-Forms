using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using C698_Product_WPF.Data.DTOs;
using C698_Product_WPF.Data.EntityModels.Types;
using C698_Product_WPF.Data.Supervisors.Interfaces;
using C698_Product_WPF.Data.ViewModels;
using C698_Product_WPF.Extensions;
using C698_Product_WPF.Views.Dialogs;

namespace C698_Product_WPF
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    private readonly IPartSupervisor _partSupervisor;
    private readonly IProductSupervisor _productSupervisor;

    List<PartDTO> parts;
    List<ProductDTO> products;

    public MainWindow(
      IPartSupervisor partSupervisor,
      IProductSupervisor productSupervisor
      )
    {
      _partSupervisor = partSupervisor;
      _productSupervisor = productSupervisor;
      InitializeComponent();
      WindowStartupLocation = WindowStartupLocation.CenterScreen;
      GetData();
    }

    private async Task GetData()
    {
      parts = await _partSupervisor.GetAll();
      products = await _productSupervisor.GetAll();
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

    private async void Parts_Add_Click(object s, RoutedEventArgs e)
    {
      PartDialog dialog = new PartDialog();
      PartVM vm = new PartVM(_partSupervisor, CUD.Add);
      vm.CloseAction = new Action(() => dialog.Close());
      dialog.MainGrid.DataContext = vm;
      bool? result = dialog.ShowDialog();
      if (dialog.DialogResult.HasValue && dialog.DialogResult.Value)
      {
        await GetData();
      }
    }

    private async void Parts_Modify_Click(object s, RoutedEventArgs e)
    {
      PartDTO selected = (PartDTO)PartsGrid.SelectedItem;
      if (selected != null && selected != default(PartDTO))
      {
        PartDialog dialog = new PartDialog();
        PartVM vm = PartVM.LoadVM(_partSupervisor, selected.Id.Value, CUD.Modify);
        vm.CloseAction = new Action(() => dialog.Close());
        dialog.MainGrid.DataContext = vm;
        dialog.ShowDialog();
        if (dialog.DialogResult.HasValue && dialog.DialogResult.Value)
        {
          await GetData();
        }
      }
    }

    private async void Parts_Delete_Click(object s, RoutedEventArgs e)
    {
      PartDTO selected = (PartDTO)PartsGrid.SelectedItem;
      if (selected != null && selected != default(PartDTO))
      {
        PartDialog dialog = new PartDialog();
        PartVM vm = PartVM.LoadVM(_partSupervisor, selected.Id.Value, CUD.Delete);
        vm.CloseAction = new Action(() => dialog.Close());
        dialog.MainGrid.DataContext = vm;
        bool? result = dialog.ShowDialog();
        if (dialog.DialogResult.HasValue && dialog.DialogResult.Value)
        {
          await GetData();
        }
      }
    }

    private async void Products_Add_Click(object s, RoutedEventArgs e)
    {
      ProductDialog dialog = new ProductDialog();
      ProductVM vm = new ProductVM(_productSupervisor, CUD.Add);
      vm.CloseAction = new Action(() => dialog.Close());
      dialog.MainGrid.DataContext = vm;
      bool? result = dialog.ShowDialog();
      if (dialog.DialogResult.HasValue && dialog.DialogResult.Value)
      {
        await GetData();
      }
    }

    private async void Products_Modify_Click(object s, RoutedEventArgs e)
    {
      ProductDTO selected = (ProductDTO)ProductsGrid.SelectedItem;
      if (selected != null && selected != default(ProductDTO))
      {
        ProductDialog dialog = new ProductDialog();
        ProductVM vm = ProductVM.LoadVM(_productSupervisor, selected.Id.Value, CUD.Modify);
        vm.CloseAction = new Action(() => dialog.Close());
        dialog.MainGrid.DataContext = vm;
        bool? result = dialog.ShowDialog();
        if (dialog.DialogResult.HasValue && dialog.DialogResult.Value)
        {
          await GetData();
        }
      }
    }

    private async void Products_Delete_Click(object s, RoutedEventArgs e)
    {
      ProductDTO selected = (ProductDTO)ProductsGrid.SelectedItem;
      if (selected != null && selected != default(ProductDTO))
      {
        ProductDialog dialog = new ProductDialog();
        ProductVM vm = ProductVM.LoadVM(_productSupervisor, selected.Id.Value, CUD.Delete);
        vm.CloseAction = new Action(() => dialog.Close());
        dialog.MainGrid.DataContext = vm;
        bool? result = dialog.ShowDialog();
        if (dialog.DialogResult.HasValue && dialog.DialogResult.Value)
        {
          await GetData();
        }
      }
    }

    private void Exit_Click(object s, RoutedEventArgs e)
    {
      Application.Current.Shutdown();
    }
  }
}
