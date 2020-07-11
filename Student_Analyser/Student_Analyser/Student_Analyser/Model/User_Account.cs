using SQLite;
using System;

namespace Student_Analyser
{
    public class User_Account
    {
        private int id;
        private string email_address;
        private string username ;
        private string password ;
        private string securityQuestion = "Null";
        private string answer = "Null";
        private string studentNo;

        public int Id
        {
            get { return id;}
            set{ id = RandomID();}
        }

        public string Email_address
        {
            get { return email_address; }
            set { email_address = value; } 
        }

        public string Username
        {
            get { return username; }
            set { username = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public string SecurityQuestion
        {
            get { return securityQuestion; }
            set { securityQuestion = "Null"; }
        }

        public string StudentNo
        {
            get { return studentNo; }
            set { studentNo = value; }
        }
        public string Answer
        {
            get { return answer; }
            set { answer = "Null"; }
        }

        public User_Account()
        {

        }
        public User_Account( string username, string email, string password)
        {
            this.Username = username;
            this.Email_address = email;
            this.Password = password;
        }

        public User_Account(int id,  string email, string username, string password, string securityQuestion, string answer, string studentNo)
        {
            this.Id = id;
            this.Email_address = email;
            this.Username = username;
            this.Password = password;
            this.SecurityQuestion = securityQuestion;
            this.Answer = answer;
            this.StudentNo = studentNo;
        }
        public User_Account(int id, string email, string username, string password, string studentNo)
        {
            this.Id = id;
            this.Email_address = email;
            this.Username = username;
            this.Password = password;
            this.StudentNo = studentNo;
        }
        public User_Account( string email, string username, string password, string securityQuestion, string answer, string studentNo)
        {
            this.Email_address = email;
            this.Username = username;
            this.Password = password;
            this.SecurityQuestion = securityQuestion;
            this.Answer = answer;
            this.StudentNo = studentNo;
        }

        private static int RandomID()
        {
            Random ran = new Random();
            return ran.Next(1, int.MaxValue);
        }
    }
}
