using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace darylStudentProject
{
  


  public  class StudentsInformation
    {
       public  StudentsInformation(string[,] StudentNameArray, int[,] StudentArray)
        {
            int j=0; int k=0;
            this.StudentName = StudentNameArray[j,k];
            this.StudentArrays = StudentArray[j,k];

        }


        public string StudentName { get; 
            
            private set; }
        public int StudentArrays { get; private set; }
    }








}
