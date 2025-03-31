using CsvHelper.Configuration.Attributes;

namespace App.Models;

public class FoodWasteData
{
    [Name("Country")]
    public string Country { get; set; } = "";

    [Name("Year")]
    public int Year { get; set; }

    [Name("Food Category")]
    public string FoodCategory { get; set; } = "";

    [Name("Total Waste (Tons)")]
    public double TotalWasteTons { get; set; }

    [Name("Economic Loss (Million $)")]
    public decimal EconomicLoss { get; set; }

    [Name("Avg Waste per Capita (Kg)")]
    public double AvgWaste { get; set; }

    [Name("Population (Million)")]
    public double Population { get; set; }

    [Name("Household Waste (%)")]
    public double HouseholdWaste { get; set; }
    
}