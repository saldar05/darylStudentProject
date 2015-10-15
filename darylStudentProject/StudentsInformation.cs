using System;


using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

 namespace darylStudentProject
 { 

    public class StudentsInformation
    {
        public StudentsInformation(string[,] StudentNameArray, int[,] StudentArray)
        {
            this.StudentName = StudentNameArray;
            this.StudentArray = StudentArray;
           
        }


        public string StudentName { get; private set; }
        public string StudentArrays { get; private set; }
    }
}
