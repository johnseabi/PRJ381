﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;

using Foundation;
using SQLite;
using Student_Analyser.iOS;
using UIKit;


[assembly: Xamarin.Forms.Dependency(typeof(SQLiteAccess_iOS))]
namespace Student_Analyser.iOS
{
    public class SQLiteAccess_iOS : ISqlite
    {
        /// <summary>
        /// Gets the platform iOS specific path for SQLite database
        /// </summary>
        /// <returns>connection</returns>
        public SQLiteConnection GetConnection()
        {
            var fileName = "AnalyzerDB.db3";
            string personalFolder = System.Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libraryFolder = Path.Combine(personalFolder, "...", "Library");
            var path = Path.Combine(libraryFolder, fileName);

            //var platform = new SQLite.Net.Platform.XamarinIOS.SQLitePlatformIOS();
            var connection = new SQLiteConnection(path);

            return connection;
        }
    }
}