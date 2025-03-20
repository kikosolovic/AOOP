using System;
using System.Collections.Generic;
using Avalonia.Controls.Converters;
using CommunityToolkit.Mvvm.Input;
namespace UniversityManager.Models;

public class Subject
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public int TeacherId { get; set; }
    public List<int>? StudentsEnrolled { get; set; } = new List<int>();


    public void details(Subject sub)
    {
        Console.WriteLine(sub.Name);
        Console.WriteLine(sub.Description);
        Console.WriteLine("teacher id:");
        Console.WriteLine(sub.TeacherId);
        Console.WriteLine("Ids of enroled students:");
        Console.WriteLine(sub.StudentsEnrolled);

    }
}