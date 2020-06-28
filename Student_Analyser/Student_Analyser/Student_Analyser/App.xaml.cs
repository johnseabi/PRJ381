using Student_Analyser.Views.Forms;
using Student_Analyser.Views.Home;
using System;
using System.Timers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Student_Analyser
{
    public partial class App : Application
    {
        /// <summary>
        /// DateTime variable, holds the initial datetime value
        /// </summary>
        static DateTime initialDateTime;

        /// <summary>
        /// Integer variable, holds the total time in milliseconds
        /// </summary>
        static double timeInMilliSeconds;

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Log_In());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
            initialDateTime = DateTime.Now;

        }

        protected override void OnResume()
        {
            // Handle when your app resumes
            timeInMilliSeconds = TimeElapsed(initialDateTime);

            if (ToggleFlag(timeInMilliSeconds))
            {
                MainPage = new NavigationPage(new Home_view());
            }
            else
            {
                MainPage = new NavigationPage(new Log_In());
            }
        }

        /// <summary>
        /// Calculates the totaltime in millisecondselapsed since application went on sleep mode.
        /// </summary>
        /// <param name="initialDateTime"></param>
        /// <returns>int</returns>
        private double TimeElapsed(DateTime initialDateTime)
        {
            TimeSpan timeSpan = DateTime.Now.Subtract(initialDateTime);
            double millisecondsLapsed = (double)timeSpan.TotalMilliseconds; 
            return millisecondsLapsed;
        }

        /// <summary>
        /// Sets the logged-in status to true or false
        /// </summary>
        /// <param name="millisecondsLapsed"></param>
        /// <returns></returns>
        public bool ToggleFlag(double millisecondsLapsed)
        {
            if (millisecondsLapsed > 300000.0)
            {
                Log_In.LoggedInFlag = false;
            }
            else
            {
                Log_In.LoggedInFlag = true;
            }

            return Log_In.LoggedInFlag;
        }
    }
}