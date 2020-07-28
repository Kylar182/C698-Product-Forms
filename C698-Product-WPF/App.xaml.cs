using System.Windows;
using C698_Product_WPF.Persistence;
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
        option.UseSqlite("Data Source = InventoryDB");
      });

      services.AddSingleton<MainWindow>();

      provider = services.BuildServiceProvider();
    }

    private void OnStartup(object s, StartupEventArgs e)
    {
      var main = provider.GetService<MainWindow>();
      main.Show();
    }
  }
}
