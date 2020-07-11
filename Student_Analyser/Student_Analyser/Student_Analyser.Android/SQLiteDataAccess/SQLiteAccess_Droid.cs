using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using SQLite;

using Student_Analyser.Droid;

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

        public static SQLiteConnection DBConnection()
        {
            // throw new NotImplementedException();
            var fileName = "AnalyzerDB.db3";
            var path = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), fileName);
            var connection = new SQLiteConnection(path);

            return connection;

        }
        private static void CopyDatabaseIfNotExists(string dbPath)
        {
            if (!File.Exists(dbPath))
            {
                using (var br = new BinaryReader(Application.Context.Assets.Open("Analyzer.db3")))
                {
                    using (var bw = new BinaryWriter(new FileStream(dbPath, FileMode.Create)))
                    {
                        byte[] buffer = new byte[2048];
                        int length = 0;
                        while ((length = br.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            bw.Write(buffer, 0, length);
                        }
                    }
                }
            }
        }
    }
}