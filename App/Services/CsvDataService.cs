using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using FoodWasteViz.Models;
using CsvHelper;
using CsvHelper.Configuration;

namespace FoodWasteViz.Services;

public interface IDataService
{
    IEnumerable<FoodWasteData> LoadData(string filePath);
}

public class CsvDataService : IDataService
{
    public IEnumerable<FoodWasteData> LoadData(string filePath)
    {
        try
        {
            using var reader = new StreamReader(filePath);
            var csvConfig = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = true,
                HeaderValidated = null,
                MissingFieldFound = null
            };

            using var csv = new CsvReader(reader, csvConfig);
            var records = csv.GetRecords<FoodWasteData>().ToList();
            return records;
        }
        catch (Exception ex)
        {
            System.Console.WriteLine($"Error loading Csv data: {ex.Message}");
            return Enumerable.Empty<FoodWasteData>();
        }
    }
}