﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;

namespace iOSClassLibrary
{
   public class iPhoneRequestTutorClass
    {
        private string fullNames;
        private string troublingModule;
        private string campusName;
        private string contactNumber;
        private string communicationMode;


        public string FullNames
        {
            get { return fullNames; }
            set { fullNames = value; }
        }
        public string TroublingModule
        {
            get { return troublingModule; }
            set { troublingModule = value; }
        }
        public string CampusName
        {
            get { return campusName; }
            set { campusName = value; }
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
        public iPhoneRequestTutorClass(string fullNames, string troublingModule, string campusName
            , string contactNumber, string communicationMode)
        {
            this.fullNames = fullNames;
            this.troublingModule = troublingModule;
            this.campusName = campusName;
            this.contactNumber = contactNumber;
            this.communicationMode = communicationMode;
        }
    }
}