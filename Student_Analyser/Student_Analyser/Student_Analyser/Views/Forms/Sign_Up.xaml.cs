using Android.Widget;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Student_Analyser.Views.Forms
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Sign_Up : ContentPage
    {
        public User_Account user = new User_Account();
        public List<User_Account> users = new List<User_Account>();
        public SQLiteConnection conn;
        public static SQLiteDataAccess sqliteDataAccessObject = new SQLiteDataAccess();
        string _email = null;

        public Sign_Up()
        {
            InitializeComponent();

            //get connection to or create database
            conn = DependencyService.Get<ISqlite>().GetConnection();

            //cretes the table
            conn.CreateTable<User_Account>();

            btnRegister.IsEnabled = false;
            NavigationPage.SetHasBackButton(this, false);
            username.ReturnCommand = new Command(() => schoolEmail.Focus());
            schoolEmail.ReturnCommand = new Command(() => password.Focus());
            password.ReturnCommand = new Command(() => confirmPassword.Focus());
        }
        private async void LoginButtonClicked(object obj, EventArgs args)
        {
            
            await this.Navigation.PopAsync(true);
            await Navigation.PushAsync(new Log_In());

            schoolEmail.Text = string.Empty;
            username.Text = string.Empty;
            password.Text = string.Empty;
            confirmPassword.Text = string.Empty;
        }
        private void ConfirmPasswordTextChanged(object obj, TextChangedEventArgs textChangedEventArgs)
        {

            if (!((string.IsNullOrWhiteSpace(username.Text)) && (string.IsNullOrWhiteSpace(schoolEmail.Text))))
                if (password.ToString() == confirmPassword.ToString())
                    btnRegister.IsEnabled = true;
        }

        private void EmailTextChanged(object obj, TextChangedEventArgs textChangedEventArgs)
        {
            //StringBuilder emailBuilder = new StringBuilder();
             //schoolEmail.Text = emailBuilder.Append(schoolEmail.Text).ToString() + "@student.belgiumcampus.ac.za";
        }

        private async void SignupValidation_ButtonClicked(object sender, EventArgs e)
        {
            start:
            if ((string.IsNullOrWhiteSpace(username.Text)) || (string.IsNullOrWhiteSpace(schoolEmail.Text)) ||
                (string.IsNullOrWhiteSpace(password.Text)) || (string.IsNullOrWhiteSpace(confirmPassword.Text)))
            {
                await DisplayAlert("Enter Data", "Enter Valid Data", "OK");
                goto start;
            }
            else if (!(schoolEmail.Text.Contains("@student.belgiumcampus.ac.za")) && (schoolEmail.Text.Length) >= 34)
            {
                schoolEmail.Text = string.Empty;
                schoolEmail.Placeholder = "Enter a valid email";
            }
            else
            {
                user.Email_address = schoolEmail.Text;
                user.Username = username.Text;
                user.Password = password.Text;
                user.StudentNo = user.Email_address.Substring(0, 6);
                try
                {
                    await SQLDataAccess.InsertUserAsync(user);

                    var retrunvalue = await Task.Run(() => sqliteDataAccessObject.AddUserAccount(user, conn));

                    if (retrunvalue == "Sucessfully Added")
                    {
                        await DisplayAlert("User Add", retrunvalue, "OK");
                        await Navigation.PushAsync(new Log_In());
                    }
                    else
                    {
                        await DisplayAlert("User Add", retrunvalue, "OK");

                        schoolEmail.Text = string.Empty;
                        username.Text = string.Empty;
                        password.Text = string.Empty;
                        confirmPassword.Text = string.Empty;

                    }
                }
                catch (Exception )
                {
                    await DisplayAlert("Error", "Process failed!", "OK");
                    schoolEmail.Text = string.Empty;
                    username.Text = string.Empty;
                    password.Text = string.Empty;
                    confirmPassword.Text = string.Empty;
                }
            }
        }
    }
}