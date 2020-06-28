using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Student_Analyser.Views.Home
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Tutor_view : ContentPage
    {
        static int rate;

        public Tutor_view()
        {
            InitializeComponent();

            Rate.Text = "5";
        }


        private void SliderValueChanged(object obj, ValueChangedEventArgs valueChanged)
        {
            rate = (int)valueChanged.NewValue;

            Rate.Text = rate.ToString(); ;
        }
    }
}