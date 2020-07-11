using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace AndroidClassLibrary
{
   public class AndroidTutorClass
    {
        private string fullNames;
        private string module;
        private string campus;
        private string contactNumber;
        private string communicationMode; //E.g WatsApp, email or phone call
        private string motivation;

        public string FullNames
        {
            get { return fullNames; }
            set { fullNames = value; }
        }
        public string Module
        {
            get { return module; }
            set { module = value; }
        }
        public string Campus
        {
            get { return campus; }
            set { campus = value; }
        }
        public string Motivation
        {
            get { return motivation; }
            set { motivation = value; }
        }
        public string ContactNumber
        {
            get { return contactNumber; }
            set { contactNumber = value; }
        }
       public string CommunicationMode
        {
            get { return communicationMode; }
            set { communicationMode = value; }
        }

        public AndroidTutorClass(string fullNames, string module, string campus
            , string contactNumber, string communicationMode,string motivation)
        {
            this.fullNames = fullNames;
            this.module = module;
            this.campus = campus;
            this.contactNumber = contactNumber;
            this.communicationMode = communicationMode;
            this.motivation = motivation;
        }
    }
}