using System.Windows;
using C698_Product_WPF.Persistence;
using C698_Product_WPF.Persistence.Repositories;
using C698_Product_WPF.Persistence.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace C698_Product_WPF
{
  /// <summary>
  /// Interaction logic for App.xaml
  /// </summary>
  public partial class App : Application
  {
    private ServiceProvider provider;

    public App()
    {
      ServiceCollection services = new ServiceCollection();
      services.AddDbContext<InventoryDBContext>(option =>
      {
        option.UseSqlite("Data Source = Inventory.db");
      });

      services.AddSingleton<MainWindow>();
      services.AddScoped<IPartRepository, PartRepository>();
      services.AddScoped<IProductRepository, ProductRepository>();

      provider = services.BuildServiceProvider();
    }

    private void OnStartup(object s, StartupEventArgs e)
    {
      var main = provider.GetService<MainWindow>();
      main.Show();
    }
  }
}
