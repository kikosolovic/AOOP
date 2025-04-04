using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FoodWasteViz.Models;
using FoodWasteViz.Services;
using LiveChartsCore.SkiaSharpView;
using System.Collections.Generic;
namespace FoodWasteViz.ViewModels;

public class MainWindowViewModel : ObservableObject
{
    private readonly IDataService _dataService;
    private readonly IChartService _chartService;
    private readonly string _csvFilePath = "../Assets/GlobalFoodWastage.csv";

    public ObservableCollection<ChartViewModel> ActiveCharts { get; } = new ObservableCollection<ChartViewModel>();
    public ObservableCollection<string> AvailableQueries { get; } = new ObservableCollection<string>(PresetQueries.GetQueryList());

    private string? _selectedQuery;
    public string? SelectedQuery
    {
        get => _selectedQuery;
        set
        {
            SetProperty(ref _selectedQuery, value);
            if (value != null)
            {
                AddChart(value);
            }
        }
    }

    public ICommand RemoveChartCommand { get; }

    public MainWindowViewModel(IDataService dataService, IChartService chartService)
    {
        _dataService = dataService;
        _chartService = chartService;
        RemoveChartCommand = new RelayCommand<ChartViewModel>(RemoveChart);
    }

    private void AddChart(string queryName)
    {
        var data = _dataService.LoadData(_csvFilePath);
        IEnumerable<dynamic> queryResult = PresetQueries.ExecuteQuery(queryName, data);
    
        string chartType = queryName switch
            {
                "Top 5 Countries by Total Waste" => "PieChart",
                "Economic Loss by Food Category" => "ColumnChart",
                "Average Waste per Capita by Country" => "ColumnChart",
                "Household Waste Percentage by Food Category" => "ColumnChart",
                "Total Waste by Year" => "ColumnChart",
                _ => ""
            };

            string xTitle = queryName switch
            {
                "Economic Loss by Food Category" => "Food Category",
                "Average Waste per Capita by Country" => "Country",
                "Household Waste Percentage by Food Category" => "Food Category",
                "Total Waste by Year" => "Year",
                _ => ""
            };

            string yTitle = queryName switch
            {
                "Economic Loss by Food Category" => "Economic Loss (Million $)",
                "Average Waste per Capita by Country" => "Average Waste per Capita (Kg)",
                "Household Waste Percentage by Food Category" => "Household Waste Percentage (%)",
                "Total Waste by Year" => "Total Waste (Tons)",
                _ => ""
            };

            try
            {
                var chart = _chartService.GenerateChart(queryResult, chartType, xTitle, yTitle);
                ActiveCharts.Add(new ChartViewModel(queryName, chart));
            }
            catch (Exception ex)
            {
                System.Console.WriteLine($"Error with generating the stupid graph: {ex.Message}");
            }
    }

    private void RemoveChart(ChartViewModel? chartToRemove)
    {
        if (chartToRemove != null)
        {
            ActiveCharts.Remove(chartToRemove);
        }
    }

}