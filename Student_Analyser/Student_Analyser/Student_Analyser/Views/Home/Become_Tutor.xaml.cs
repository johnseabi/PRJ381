using Android.App;
using Android.Content;
using Android.Widget;
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
    public partial class Become_Tutor : ContentPage
    {
        public Become_Tutor()
        {
            InitializeComponent();
        }
        private void MotivationEditorTextChanged(object obj, TextChangedEventArgs textChangedEventArgs)
        {
            Editor editor = (Editor)obj;
            CheckMaximumChar(editor);
            
        }

        private  void submitBtnClicked(Object obj, EventArgs args)
        {
            Context context = Android.App.Application.Context;

            Toast.MakeText(context, "Your application's is being processed, please wait...", ToastLength.Long).Show();
        }

        private void CheckMaximumChar( Editor editor)
        {
            editor.MaxLength = 150;

            if (editor.Text.Count() >= editor.MaxLength)
            {
                
                DisplayAlert("Info", "Reached 150 charecters!", "OK");
            }
        }
    }
}