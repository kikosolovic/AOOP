using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using UniversityManager.Models;

namespace UniversityManager.Models
{
    public class userManager
    {
        public List<Student> students = new List<Student>();
        public List<Subject> subjects = new List<Subject>();
        public List<Teacher> teachers = new List<Teacher>();

        public void loadData()
        {

            string json = File.ReadAllText("Assets/users/students.json");
            students = JsonSerializer.Deserialize<List<Student>>(json);
            json = File.ReadAllText("Assets/users/teachers.json");
            teachers = JsonSerializer.Deserialize<List<Teacher>>(json);
            json = File.ReadAllText("Assets/users/subjects.json");
            subjects = JsonSerializer.Deserialize<List<Subject>>(json);

        }
        public void saveData()
        {

        }
    }
}