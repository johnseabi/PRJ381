using Android.Content;
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
        public Forgot_Password()
        {
            InitializeComponent();
        }

        private async void SubmitBtnClicked(Object obj, EventArgs eventArgs)
        {
            //Check if name and security question match

            //if sucessfully changed password
            await DisplayAlert("Info", "Password sucessfully changed", "OK");
            await this.Navigation.PopAsync();
            await Navigation.PushAsync(new Log_In());
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