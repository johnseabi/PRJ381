
using Student_Analyser.Views.Home;
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
    public partial class Log_In : ContentPage
    {
        private static bool loggedInFlag;

        public static bool LoggedInFlag { get => loggedInFlag; set => loggedInFlag = value; }

        public Log_In()
        {
            InitializeComponent();
        }
        private async void SignUpButtonClicked(object obj, EventArgs args )
        {
            await this.Navigation.PopAsync(true);
            await Navigation.PushAsync(new Sign_Up());
        }

        private async void LoginButtonClicked(object obj, EventArgs args )
        {
            await Navigation.PopAsync(true);
            await Navigation.PushAsync(new Home_view());
            LoggedInFlag = true;
        }
        private async void ForgotPasswordBtnbClicked(object obj, EventArgs eventArgs)
        {
            await Navigation.PopAsync(true);
            await Navigation.PushAsync(new Forgot_Password());
        }
    }
}