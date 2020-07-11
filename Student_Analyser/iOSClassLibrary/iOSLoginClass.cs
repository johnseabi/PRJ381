﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;

namespace iOSClassLibrary
{
   public class iOSLoginClass
    {
        private string name;
        private string passWord;
        private string securityQuestion;  //This will come from SQLite Database provided when the user signs up
        private string securityAnswer;   
        private string newPassWord;      //To reset existing password
        private string confirmNewPassWord;  //Confirm new password

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string PassWord
        {
            get { return passWord; }
            set { passWord = value; }
        }
        public string SecurityQuestion
        {
            get { return securityQuestion; }
            set { securityQuestion = value; }
        }
        public string SecurityAnswer
        {
            get { return securityAnswer; }
            set { securityAnswer = value; }
        }
        public string NewPassWord
        {
            get { return newPassWord; }
            set { newPassWord = value; }
        }
        public string ConfirmNewPassWord
        {
            get { return confirmNewPassWord; }
            set { confirmNewPassWord = value; }
        }


        //Constructor specifically for logging in.
        public iOSLoginClass(string name, string passWord)
        {
            this.name = name;
            this.passWord = passWord;
        }
        //Constructor specifically for reseting password.
        public iOSLoginClass(string securityQuestion, string securityAnswer, 
            string newPassWord, string confirmNewPassWord)
        {
            this.securityQuestion = securityQuestion;
            this.securityAnswer = securityAnswer;
            this.newPassWord = newPassWord;
            this.confirmNewPassWord = confirmNewPassWord;
        }

    }
}