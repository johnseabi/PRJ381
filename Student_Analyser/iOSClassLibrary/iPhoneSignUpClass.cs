using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iOSClassLibrary
{
    public class iPhoneSignUpClass
    {
        private string names;
        private string email;
        private string passWord;
        private string confirmPassWord;
       

        public string Names
        {
            get { return names; }
            set { names = value; }
        }
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        
        public string PassWord
        {
            get { return passWord; }
            set { passWord = value; }
        }
        public string ConfirmPassWord
        {
            get { return confirmPassWord; }
            set { confirmPassWord = value; }
        }
        public iPhoneSignUpClass(string names, string email, string passWord
            , string confirmPassWord)
        {
            this.names = names;
            this.email = email;
            this.passWord = passWord;
            this.confirmPassWord = confirmPassWord;
            
        }
       
        
    }
}
