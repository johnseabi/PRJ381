using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;

namespace iOSClassLibrary
{
   public class iOSModuleClass
    {
        private int studentNumber;
        private string subjectCode;
        private string subjectName;
        private double modulePercentage;

        public int StudentNumber
        {
            get { return studentNumber; }
            set { studentNumber = value; }
        }
        public string SubjectCode
        {
            get { return subjectCode; }
            set { subjectCode = value; }
        }
        public string SubjectName
        {
            get { return subjectName; }
            set { subjectName = value; }
        }
        public double ModulePercentage
        {
            get { return modulePercentage; }
            set { modulePercentage = value; }
        }
        public iOSModuleClass(int studentNumber, string subjectCode
            , string subjectName, double modulePercentage)
        {
            this.studentNumber = studentNumber;
            this.subjectCode = subjectCode;
            this.subjectName = subjectName;
            this.modulePercentage = modulePercentage;
        }

    }
}