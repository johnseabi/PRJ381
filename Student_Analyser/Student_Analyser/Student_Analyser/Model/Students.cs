using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Student_Analyser.Model
{
    public class Students
    {
        public int student_No { get; set; }
        public string full_names { get; set; }
        public double age { get; set; }
        public string  campus_name{get; set;}
        public string qualification { get; set; }
        public string enrolled_for { get; set; }
        public string enrolled_as { get; set; }
        public string email_address { get; set; }

       // public DataSet RetrieveData()
       // {
           // DataSet data = new [method from DAL]().[MethodAccessException to read all data from students table]
            //loop through dataset and save all to local list or relevant data structure

           // return data;
      //  }
    }
}
