using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WpfAppDemoCRUD.Data;
namespace WpfAppDemoCRUD
{

    public partial class App : Application
    {
        private ServiceProvider serviceProvider;

        public App()
        {    // This is the place where we can register our DBcontext. 
            ServiceCollection services = new ServiceCollection();
            services.AddDbContext<ProductDbContext>(option =>
            {
                option.UseSqlite("Data Source = Product.db");
            });
            
            // Register main window as singleton
            services.AddSingleton<MainWindow>();
            serviceProvider = services.BuildServiceProvider();
        }

        private void OnStartup(object s, StartupEventArgs e)
        {    // Get main window instance from service provider and show it
            var mainWindow = serviceProvider.GetService<MainWindow>();
            mainWindow.Show();
        }
    }
}
