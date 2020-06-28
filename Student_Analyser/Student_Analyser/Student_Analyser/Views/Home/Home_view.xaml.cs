using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Android.App;
using Xamarin.Forms.Xaml;

using Student_Analyser.Views.Home;

namespace Student_Analyser.Views.Home
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Home_view : TabbedPage
    {
        static Label label;

        public Home_view()
        {
            InitializeComponent();


            //need code for Theme setting
            label = (Label)FindByName("ThemeType");

            //sample code for sessions list needs to be replaced
            List<ListItem> ListItems = new List<ListItem>
            {
            new ListItem {Title = "DBD281", Description="Session with John Seabi"},
            new ListItem {Title = "PRG281", Description="Session with Thabiso"},
            new ListItem {Title = "PRG381", Description="Session with Lerato Thelele"},
            new ListItem {Title = "PRG381", Description="Session with Lerato Thelele"},
            new ListItem {Title = "PRG281", Description="Session with  Sebaka"},
            new ListItem {Title = "PRG381", Description="Session with Lerato Thelele"}
            };
            DataModelList.ItemsSource = ListItems;
            DataModelList2.ItemsSource = ListItems;

        }
        //sample class for the sessions list
        internal class ListItem
        {
            public string Title { get; set; }
            public string Description { get; set; }
        }

        /// <summary>
        /// This method does not worlk well, to be fixed
        /// </summary>
        /// <returns></returns>
        protected override bool OnBackButtonPressed()
        {
            return true;
        }


        /// <summary>
        /// Toggles the opacity of the Homeview icons
        /// </summary>
        /// <param name="sender"></param>
        private void ConfirmTap(Object sender)
        {
            Image image = ((Image)sender);
            image.Opacity = .3;
            Task.Delay(200);
            image.Opacity = 1;
        }

        private async void ModulesImageTapped(object obj, EventArgs tapped)
        {
            ConfirmTap(obj);
            await Navigation.PushAsync(new Modules());
        }

        private async void TutorImageTapped(object obj, EventArgs tapped)
        {
            ConfirmTap(obj);
            await Navigation.PushAsync(new Tutor_view());
        }

        private async void AboutImageTapped(object obj, EventArgs tapped)
        {
            ConfirmTap(obj);
            await Navigation.PushAsync(new About());
        }

        private async void BeTutorImageTapped(object obj, EventArgs tapped)
        {
            ConfirmTap(obj);
            await Navigation.PushAsync(new Become_Tutor());
        }


        //----Settings View Tab----------------------------------------------------------------//
        private void ThemeSwitchToggled(object obj, ToggledEventArgs toggledEvent)
        {

            if (toggledEvent.Value)
            {
                label.Text = "Dark";
                label.TextColor = Color.DeepSkyBlue;
            }
            else
            {
                label.Text = "Default";
                label.TextColor = Color.Black;
            }
        }


        private void KeepLoggedSwitchToggled(object obj, ToggledEventArgs toggledEvent)
        {
            if (toggledEvent.Value)
            {
                DisplayAlert("Info", "Password remembered, you will be kept logged in", "OK");
            }
            else    DisplayAlert("Info", "Your password will not be remembered, password will be required on login", "OK");
        }

        //-----------Profile Tab---------------------------------------------------------------------------//


        /// <summary>
        /// Method for setting up profile picture
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="tappedEvent"></param>
        private  async void ProfileImageTapped(object obj, EventArgs tappedEvent)
        {
            //to add code to enable profile picture to be loaded at runtime
        }
    }
}