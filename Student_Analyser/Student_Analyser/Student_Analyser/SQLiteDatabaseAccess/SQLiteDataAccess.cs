using System;
using System.Collections.Generic;
using System.Linq;
using SQLite;
using Xamarin.Forms;

namespace Student_Analyser
{
    public class SQLiteDataAccess
    {
        private static SQLiteConnection conn = null;

        public SQLiteDataAccess()
        {
            conn = DependencyService.Get<ISqlite>().GetConnection();
            conn.CreateTable<User_Account>();
        }
        /// <summary>
        /// Loads User account details from local SQLite database
        /// </summary>
        /// <returns><list type="<User_Account>"</returns>
        public List<User_Account> LoadUserAccount()
        {
            using (conn)
            {
                return (from table in conn.Table<User_Account>() select table).ToList();
            }
        }

        /// <summary>
        /// Checks if the user exists in the local database and logs them in
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool LoginValidate(string username, string password)
        {
            var data = conn.Table<User_Account>();
            var returnData = data.Where(x => x.Username == username && x.Password == password).FirstOrDefault();
            if (returnData != null)
            {
                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// Adds a new user to the local database
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public string AddUserAccount(User_Account user, SQLiteConnection connection)
        {
            if (connection.Insert(user) == 1)
                return "Sucessfully Added";
            else
                return "Failed Operation";
        }

        /// <summary>
        /// Udates the user password on local database
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool UpdateUserPassword(User_Account user)
        {
            var data = conn.Table<User_Account>();
            var returnData = (from values in data
                              where values.Username == user.Username
                              select values).FirstOrDefault();
            if (returnData != null)
            {
                returnData.Password = user.Password;
                conn.Update(returnData);
                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// Updates the user security question and security question answer
        /// </summary>
        /// <param name="securityQuestion"></param>
        /// <param name="answer"></param>
        public bool UpdateUserSecurity(string securityQuestion, string answer)
        {
            var data = conn.Table<User_Account>();
            
            var returnData = data.FirstOrDefault();

            if (returnData != null)
            {
                returnData.SecurityQuestion = securityQuestion;
                returnData.Answer = answer;
                conn.Update(returnData);

                return true;
            }
            else
                return false;
        }
    }
}
