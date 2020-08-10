using System.Windows;
using C698_Product_WPF.Data.Supervisors;
using C698_Product_WPF.Data.Supervisors.Interfaces;
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
    private readonly ServiceProvider provider;

    protected override void OnStartup(StartupEventArgs e)
    {
      MainWindow main = provider.GetService<MainWindow>();
      main.Show();
    }

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
      services.AddScoped<IPartSupervisor, PartSupervisor>();
      services.AddScoped<IProductSupervisor, ProductSupervisor>();

      provider = services.BuildServiceProvider();
    }
  }
}
