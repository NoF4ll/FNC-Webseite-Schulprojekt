using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebProjekt_Beispiel.Models
{
    public class Registration
    {
        public string username { get; set; }

        public string password { get; set; }
        
        public Registration() : this("", "") { }
        public Registration( string username, string password)
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
