using System.Collections.Generic;
using Avalonia.Controls.Converters;

namespace UniversityManager.Models;

public class Subject
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public int TeacherId {get; set; }
    public List<int>? StudentsEnrolled { get; set; } = new List<int>();
}