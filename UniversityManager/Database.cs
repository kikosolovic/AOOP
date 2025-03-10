using System.Collections.Generic;
using UniversityManager.Models;

namespace UniversityManager;

public class Database
{
    private const string FilePath = "data.json";

    public List<Student> Students { get; set; } = new List<Student>();
    public List<Teacher> Teachers { get; set; } = new List<Teacher>();
    public List<Subject> Subjects { get; set; } = new List<Subject>();

    //Dokoncim len sa mi nechce

}