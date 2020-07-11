﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SQLite;
using ImageCircle.Forms.Plugin.iOS;

using Foundation;
using UIKit;
using SQLite.Net.Platform.XamarinIOS;

namespace Student_Analyser.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        public static SQLiteConnection connection;
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();

            connection= FileAccessHelper.DBConnection();

            LoadApplication(new App());

            ImageCircleRenderer.Init();
            return base.FinishedLaunching(app, options);
        }
    }
}
