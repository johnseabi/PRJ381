using SQLite;
using Student_Analyser.Droid;
using System.IO;

[assembly: Xamarin.Forms.Dependency(typeof(SQLiteAccess_Droid))]
namespace Student_Analyser.Droid
{
    public class SQLiteAccess_Droid : ISqlite
    {
        /// <summary>
        /// Gets the platform Android specific path for SQLite database
        /// </summary>
        /// <returns>connection</returns>
        public SQLiteConnection GetConnection()
        {
            var dbName = "AnalyzerDB.db3";
            string dbPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData);
            string path = Path.Combine(dbPath, dbName);
            var connection = new SQLiteConnection(path);
            return connection;
        }
    }
}