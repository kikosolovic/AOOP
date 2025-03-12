using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniversityManager.Models;

namespace UniversityManager.ViewModels
{
    public class LoginViewModel
    {
        public bool checkCredentials(string username, string password)
        {
            userManager.loadData();
            foreach (var user in userManager.students)
            {
                if (username == user.Username && password == user.Password)
                {
                    userManager.currentUser = new user(username, "student");
                    return true;
                }
            }

            foreach (var user in userManager.teachers)
            {
                if (username == user.Username && password == user.Password)
                {
                    userManager.currentUser = new user(username, "teacher");
                    return true;
                }
            }

            return false;


        }
    }
}