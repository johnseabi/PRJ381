using System;
using System.Collections.Generic;
using System.Text;
using SQLitePCL;
using SQLite.Net.Attributes;

namespace Student_Analyser.Model
{
    class Login
    {
       [PrimaryKey, AutoIncrement]
       public int ID { get; set; }
       public string Name { get; set; }
       public string Password { get; set; }

        

        public Login()
        {

        }
    }
}
