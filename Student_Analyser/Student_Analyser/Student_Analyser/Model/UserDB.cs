using System;
using System.Collections.Generic;
using System.Text;
using Student_Analyser.Model;
using SQLite;
using System.Linq;
using Xamarin.Forms;


namespace Student_Analyser
{
    public class UserDB
    {
        private SQLiteConnection conn;
        public UserDB()
        {
            conn = DependencyService.Get<ISqlite>().GetConnection();
            conn.CreateTable<Login>();
        }

        //get all user
        private IEnumerable<Login> GetUsers()
        {
            return (from t in conn.Table<Login>()
                    select t).ToList();

        }

        //Login validation

        public bool LoginValidate(string userName1, string pass)
        {
            var data = conn.Table<Login>();
            var d1 = data.Where(x => x.Name == userName1 && x.Password == pass).FirstOrDefault();
            if (d1 != null)
            {
                return true;
            }
            else
                return false;
        }

        //Sign up or add user
        public string AddUser(User_Account user)
        {
            var data = conn.Table<User_Account>();
            //check if user exits
            var returnData = data.Where(x => x.Username == user.Username && x.Email_address == user.Email_address).FirstOrDefault();
            if (returnData == null)
            {
                conn.Insert(user);
                return "User Added Successfully";
            }
            else
                return "User Already Exists";
        }

        //update Login/User table after user has changed password/ Forgot password
        

        public bool updateUser(string username, string pwd)
        {
            var data = conn.Table<Login>();
            var d1 = (from values in data
                      where values.Name == username
                      select values).Single();
            if (true)
            {
                d1.Password = pwd;
                conn.Update(d1);
                return true;
            }
            else
                return false;
        }
    }
}
