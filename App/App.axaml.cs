using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using FoodWasteViz.ViewModels;
using FoodWasteViz.Views;
using FoodWasteViz.Services;
using Microsoft.Extensions.DependencyInjection;

namespace FoodWasteViz;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            var services = new ServiceCollection();

            // Register services
            services.AddSingleton<IDataService, CsvDataService>();
            services.AddSingleton<IChartService, ChartService>();

            // Register viewmodels
            services.AddTransient<MainWindowViewModel>();

            var serviceProvider = services.BuildServiceProvider();

            desktop.MainWindow = new MainWindow
            {
                DataContext = serviceProvider.GetRequiredService<MainWindowViewModel>()
            };
        }

        base.OnFrameworkInitializationCompleted();
    }
}
