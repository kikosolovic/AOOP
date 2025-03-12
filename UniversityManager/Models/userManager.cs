using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using UniversityManager.Models;

namespace UniversityManager.Models
{
    public static class userManager
    {
        public static List<Student> students = new List<Student>();
        public static List<Subject> subjects = new List<Subject>();
        public static List<Teacher> teachers = new List<Teacher>();

        public static user? currentUser = null;

        public static void loadData()
        {
            string json = File.ReadAllText("Assets/users/students.json");
            students = JsonSerializer.Deserialize<List<Student>>(json);
            json = File.ReadAllText("Assets/users/teachers.json");
            teachers = JsonSerializer.Deserialize<List<Teacher>>(json);
            json = File.ReadAllText("Assets/users/subjects.json");
            subjects = JsonSerializer.Deserialize<List<Subject>>(json);

        }
        public static void saveData()
        {
            string json = JsonSerializer.Serialize(students, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText("Assets/users/students.json", json);
            json = JsonSerializer.Serialize(teachers, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText("Assets/users/teachers.json", json);
            json = JsonSerializer.Serialize(subjects, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText("Assets/users/subjects.json", json);
        }
    }
}