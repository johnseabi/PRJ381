using Android.Content;
using Android.Widget;
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
    public partial class Forgot_Password : ContentPage
    {
        public static List<User_Account> users;
        public static User_Account user;
        private static SQLiteDataAccess sqliteDataAccessObject = new SQLiteDataAccess();

        public Forgot_Password()
        {
            InitializeComponent();
            user = new User_Account();
        }

        /// <summary>
        /// Not sure if this will work
        /// </summary>
        /// <returns></returns>
        private async Task<List<User_Account>> GetUser_Accounts()
        {
            return users = await SQLDataAccess.GetUsersAsync();
        }

        private async void SubmitBtnClicked(Object obj, EventArgs eventArgs)
        {
            start:
            User_Account user_Account = new User_Account();
            bool isFound = false;
            //Check if name and security question match
            foreach (User_Account user in users)
            {
                if(user.Answer == AnswerToSecurityQuestion.Text && user.Email_address == Email.Text)
                {
                    user_Account = user;
                    isFound = true;
                }
            }

            if (isFound)
            {
                if (NewPassword.Text == confirmNewPassword.Text)
                {
                    user_Account.Password = NewPassword.Text;
                    await SQLDataAccess.ResetPassword(user_Account.Password, user_Account.Email_address);
                    bool isUpdated = sqliteDataAccessObject.UpdateUserPassword(user_Account);
                    if (isUpdated)
                    {
                        Toast.MakeText(Android.App.Application.Context, "Password reset successfully", ToastLength.Short);
                        await Navigation.PopAsync(true);
                        await Navigation.PushAsync(new Log_In());
                    }
                }
            }
            if (!isFound)
            {
                bool x = await DisplayAlert("Info", "Incorrect answer or email.\nPlease enter valid credentials","OK", "Cancel");
                if (x)
                {
                    AnswerToSecurityQuestion.Text = string.Empty;
                    confirmNewPassword.Text = string.Empty;
                    Email.Text = string.Empty;
                    goto start;
                }
                else
                {
                    await this.Navigation.PopAsync();
                    await Navigation.PushAsync(new Log_In());
                }
            }
        }

        /// <summary>
        /// this method does not work s it should, to be fixed
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="eventArgs"></param>
        private async void SignUpBtnClicked(Object obj, EventArgs eventArgs)
        {
            await this.Navigation.PopAsync(true);
            await Navigation.PushAsync(new Sign_Up());
        }
    }
}