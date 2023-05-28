using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bussnies_application.BL
{
    public class UsersData
    {
        public string name;
        public string password;
        public string role;
       
        public UsersData(string name,string password, string role)
        {
            this.name = name;
            this.password = password;
            this.role = role;
        }
    }
}
