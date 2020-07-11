using SQLite;
using Student_Analyser.Views.Home;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Student_Analyser
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(true)]
    public partial class MainPage : ContentPage
    {
        public SQLiteConnection conn;
        public User_Account regmodel;
        public MainPage()
        {
            InitializeComponent();
            conn = DependencyService.Get<ISqlite>().GetConnection();
            conn.CreateTable<User_Account>();
        }
    }
}
