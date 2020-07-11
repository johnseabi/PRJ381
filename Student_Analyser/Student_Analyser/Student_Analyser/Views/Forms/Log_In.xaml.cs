using Student_Analyser.Views.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Android.Widget;

namespace Student_Analyser.Views.Forms
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Log_In : ContentPage
    {
        public User_Account user = new User_Account();
        public List<User_Account> users = new List<User_Account>();
        public SQLiteConnection conn;
        public static SQLiteDataAccess sqliteDataAccessObject = new SQLiteDataAccess();

        private static bool loggedInFlag;

        public static bool LoggedInFlag { get => loggedInFlag; set => loggedInFlag = value; }

        public Log_In()
        {
            //get connection to or create database
            conn = DependencyService.Get<ISqlite>().GetConnection();

            //cretes the table
            conn.CreateTable<User_Account>();

            InitializeComponent();

            users = sqliteDataAccessObject.LoadUserAccount();

            username.ReturnCommand = new Command(() => password.Focus());
        }
        private async void SignUpButtonClicked(object obj, EventArgs args )
        {
            await this.Navigation.PopAsync(true);
            await Navigation.PushAsync(new Sign_Up());
        }

        private async void LoginButtonClicked(object obj, EventArgs args)
        {
            //Check made the very first time the aplication runs
            if (users.Count == 0)
            {
                bool x = await DisplayAlert("Info", "User does not exist.\nRegister now?", "OK", "NO");
                if (x)
                {
                    username.Text = string.Empty;
                    password.Text = string.Empty;

                    await Navigation.PopAsync(true);
                    await Navigation.PushAsync(new Sign_Up());
                }

            }
            else
            {
                //checks made after a user has registered
                if (string.IsNullOrWhiteSpace(username.Text) || string.IsNullOrWhiteSpace(password.Text))
                {
                    await DisplayAlert("Info", "Incorrect credentials.", "OK");
                }
                if (user.Username != username.Text || user.Password != password.Text)
                {
                    await DisplayAlert("Info", "Incorrect username or password.", "OK");
                }
                if (user.Username == username.Text && user.Password == password.Text && !string.IsNullOrWhiteSpace(user.Username) && !string.IsNullOrWhiteSpace(user.Username))
                {
                    Toast.MakeText(Android.App.Application.Context, "Welcome " + user.Username, ToastLength.Long);
                    await Navigation.PopAsync(true);
                    await Navigation.PushAsync(new Home_view());
                    LoggedInFlag = true;
                }
            }
        }

        private async void ForgotPasswordBtnbClicked(object obj, EventArgs eventArgs)
        {
            await Navigation.PopAsync(true);
            await Navigation.PushAsync(new Forgot_Password());
        }
    }
}