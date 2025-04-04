using Avalonia.Controls;
using FoodWasteViz.ViewModels;
using FoodWasteViz.Services;

namespace FoodWasteViz.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        DataContext = new MainWindowViewModel(new CsvDataService(), new ChartService());
    }
}