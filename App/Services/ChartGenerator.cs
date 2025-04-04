using System;
using System.Collections.Generic;
using System.Linq;
using Avalonia.Controls;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Avalonia;
using LiveChartsCore.SkiaSharpView.Painting;
using SkiaSharp;

namespace FoodWasteViz.Services;

public interface IChartService
{
    Control GenerateChart(IEnumerable<dynamic> data, string chartType, string xTitle, string yTitle);
}

public class ChartService : IChartService
{
    public Control GenerateChart(IEnumerable<dynamic> data, string chartType, string xTitle, string yTitle)
    {
        return chartType switch
        {
            "PieChart" => GenerateBarChart(data, xTitle, yTitle),
            "ColumnChart" => GenerateColumnChart(data, xTitle, yTitle),
            _ => throw new ArgumentException("Invalid chart type")
        };
    }

private Control GenerateBarChart(IEnumerable<dynamic> data, string xTitle, string yTitle)
{
    // Convert dynamic labels to List<string> using OfType<string> to filter non-strings
    var labels = data.Select(item => item.Country?.ToString())
                    .OfType<string>()
                    .ToList();

    // Convert dynamic values to double[] with explicit casting
    var values = data.Select(item => (double)item.TotalWaste)
                    .ToArray();

    var barSeries = new RowSeries<double>
    {
        Values = values, // Now IEnumerable<double>
        Name = yTitle,
        TooltipLabelFormatter = point => $"{labels[point.Context.Index]}: {point.PrimaryValue:N1} tons"
    };

    var chart = new CartesianChart
    {
        Series = new List<ISeries> { barSeries },
        XAxes = new List<Axis>
        {
            new Axis { Labels = labels } // Now IList<string>
        },
        YAxes = new List<Axis>
        {
            new Axis { Labeler = value => value.ToString("N0") }
        }
    };

    return chart;
}


private Control GenerateColumnChart(IEnumerable<dynamic> data, string xTitle, string yTitle)
{
    var xValues = data.Select(item => item.Category?.ToString()).OfType<string>().ToList();
    var yValues = data.Select(item => Convert.ToDouble(item.TotalLoss)).Cast<double>();

    var columnSeries = new ColumnSeries<double>
    {
        Values = yValues,
        Name = yTitle
    };

    var chart = new CartesianChart
    {
        Series = new List<ISeries> { columnSeries },
        XAxes = new List<Axis> { new Axis { Labels = xValues } },
        YAxes = new List<Axis> { new Axis { Labeler = value => value.ToString() } }
    };

    return chart;
}

}
