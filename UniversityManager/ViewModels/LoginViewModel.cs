using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UniversityManager.ViewModels
{
    public class LoginViewModel
    {
        public bool checkCredentials(string username, string password)
        {
            if (username == "kokot" && password == "pica")
            {

                return true;
            }
            return false;

        }
    }
}