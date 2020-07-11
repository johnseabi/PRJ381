using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace Student_Analyser
{
     public class Connection
    {

        private readonly string dataSource = "prj381server.database.windows.net";
        private readonly string userID = "john";
        private readonly string password = "StudentAnalyser123";
        private readonly string initialCatalog = "StudentAnalyzerDB";

        public string DataSource { get => dataSource; }
        public string UserID { get => userID; }
        public string Password { get => password; }
        public string InitialCatalog { get => initialCatalog; }

        public static SqlConnectionStringBuilder ConnectionStringBuilder()
        {
            Connection connectionObject = new Connection();
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = connectionObject.DataSource;
            builder.UserID = connectionObject.UserID;
            builder.Password = connectionObject.Password;
            builder.InitialCatalog = connectionObject.InitialCatalog;

            return builder;
        }
    }
}
