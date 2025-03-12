using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Avalonia.Controls;

namespace UniversityManager.Models
{
    public class user
    {
        public string Name;
        public string Role;

        public user(string name, string role)
        {
            Name = name;
            Role = role;

        }
    }
}