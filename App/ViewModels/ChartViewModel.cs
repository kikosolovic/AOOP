using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;

namespace FoodWasteViz.ViewModels;

public class ChartViewModel : ObservableObject
{
    private string _title = "";
    public string Title
    {
        get => _title;
        set => SetProperty(ref _title, value);
    }

    private Control? _chartView;
    public Control? ChartView
    {
        get => _chartView;
        set => SetProperty(ref _chartView, value);
    }

    public ChartViewModel(string title, Control chartView)
    {
        Title = title;
        ChartView = chartView;
    }
}
