using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebProjekt_Beispiel.Models
{
    public class Login
    {
        public string username { get; set; }

        public string password { get; set; }

        public Login() : this("", "") { }
        public Login(string username, string password)
        {
            this.username = username;
            this.password = password;
        }

        public override string ToString()
        {
            return this.username + " " + this.password;
        }
    }
}
