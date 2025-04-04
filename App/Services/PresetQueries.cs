using System.Collections.Generic;
using System.Linq;
using FoodWasteViz.Models;

namespace FoodWasteViz.Services;

public static class PresetQueries
{
    public static List<string> GetQueryList()
    {
        return new List<string>
        {
            "Top 5 Countries by Total Waste",
            "Economic Loss by Food Category",
            "Average Waste per Capita by Country",
            "Household Waste Percentage by Food Category",
            "Total Waste by Year"
        };
    }

    public static IEnumerable<dynamic> ExecuteQuery(string queryName, IEnumerable<FoodWasteData> data)
    {
        return queryName switch
        {
            "Top 5 Countries by Total Waste" => GetTopWasteCountries(data),
            "Economic Loss by Food Category" => GetLossByCategory(data),
            "Average Waste per Capita by Country" => GetAvgWastePerCapitaByCountry(data),
            "Household Waste Percentage by Food Category" => GetHouseholdWastePercentageByCategory(data),
            "Total Waste by Year" => GetTotalWasteByYear(data),
            _ => Enumerable.Empty<dynamic>()
        };
    }

    public static IEnumerable<dynamic> GetTopWasteCountries(IEnumerable<FoodWasteData> data)
    {
        return data.GroupBy(d => d.Country).Select(g => new
        {
            Country = g.Key,
            TotalWaste = g.Sum(x => x.TotalWasteTons)
        }).OrderByDescending(x => x.TotalWaste).Take(5);
    }

    public static IEnumerable<dynamic> GetLossByCategory(IEnumerable<FoodWasteData> data)
    {
        return data.GroupBy(d => d.FoodCategory).Select(g => new
        {
            Category = g.Key,
            TotalLoss = g.Sum(x => x.EconomicLoss)
        }).OrderByDescending(x => x.TotalLoss);
    }
    
    public static IEnumerable<dynamic> GetAvgWastePerCapitaByCountry(IEnumerable<FoodWasteData> data)
    {
        return data.GroupBy(d => d.Country).Select(g => new
        {
            Country = g.Key,
            Averagewaste = g.Average(x => x.AvgWaste)
        }).OrderByDescending(x => x.Averagewaste);
    }

    public static IEnumerable<dynamic> GetHouseholdWastePercentageByCategory(IEnumerable<FoodWasteData> data)
    {
        return data.GroupBy(d => d.FoodCategory).Select(g => new
        {
            Category = g.Key,
            AverageHouseHoldWaste = g.Average(x => x.AvgWaste)
        }).OrderByDescending(x => x.AverageHouseHoldWaste);
    }

    public static IEnumerable<dynamic> GetTotalWasteByYear(IEnumerable<FoodWasteData> data)
    {
        return data.GroupBy(d => d.Year).Select(g => new
        {
            Year = g.Key,
            TotalWaste = g.Sum(x => x.TotalWasteTons)
        }).OrderBy(x => x.Year);
    }
}