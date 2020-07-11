using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Data;
using System.Configuration;
using Dapper;
using System.Xml;
using System.Linq;

namespace Student_Analyser.Droid
{
    public class SQLiteDataAccess
    {
        ///// <summary>
        ///// Loads User account details from local SQLite database
        ///// </summary>
        ///// <returns><list type="<User_Account>"</returns>
        //public List<User_Account> LoadUserAccount()
        //{
        //    using (IDbConnection connection = SQLiteAccess_Droid.DBConnection())
        //    {
        //        var user = connection.Query<User_Account>("SELECT * FROM User_Account", new DynamicParameters());
        //    return user.ToList();
        //    }
        //}

        ///// <summary>
        ///// Updates the user security question and security question answer
        ///// </summary>
        ///// <param name="securityQuestion"></param>
        ///// <param name="answer"></param>
        //public void  UpdateUserAccount(string securityQuestion, string answer)
        //{
        //    using (IDbConnection connection = SQLiteAccess_Droid.DBConnection())
        //    {
        //        connection.Execute("UPDATE User_Account SET Securityquestion = '" + securityQuestion + "', Answer = '" + answer + "'");
        //    }
        //}
    }
}
