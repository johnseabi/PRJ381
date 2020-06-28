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
        public Sign_Up()
        {
            InitializeComponent();
        }
        private async void LoginButtonClicked(object obj, EventArgs args)
        {
            await this.Navigation.PopAsync(true);
            await Navigation.PushAsync(new Log_In());
        }
    }
}