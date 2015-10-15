using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Globalization;

namespace darylStudentProject
{



    class Program
    {

        public static int[,] Average = new int[24, 25];
        public static int[,] StudentArray = new int[24, 25];
        public static string[,] FirstNameArray = new string[' ', 25];
        public static string[,] LastNameArray = new string[' ', 25];
        public static int MaxValue = 0;
        public static int NumScores = 0;

 static public void SQLDeleteGradeFunction()

    {
       
       string[] FullName = { "" };
       int FullNameValue = 0;
       bool correctformat = false;
       string Pattern = @"[,]";
       int trick = 0;
       string LastName="";
       string FirstName="";
       string colon = ",";
       int GetID = 0;
       string course;
       int numberOfRecords = 0;
       do
       {
           Console.Write("Please enter in the last Name\nfollowed by the first name \n of the person grade you wish to delete(e.g Smith,John):");
           FullName[FullNameValue] = Console.ReadLine();

           Console.Write("Enter in the course of the grade that needs to be deleted:");
           course = Console.ReadLine();

           if (FullName[FullNameValue].Any(char.IsPunctuation))
           {

               if (FullName[FullNameValue].Contains(colon))
               {


                   correctformat = true;
                   break;
               }
               else
               {

                   Console.Write("Please enter in alpha characters only");
                   Console.ReadKey();
                   Console.Clear();
               }
           }

           else if (FullName[FullNameValue].Any(char.IsDigit))
           {
               Console.Write("Please enter in alpha characters");
               Console.ReadKey();
               Console.Clear();

           }
           else if (FullName[FullNameValue].Any(char.IsWhiteSpace))
           {
               Console.Write("Please do not enter in white spaces");
               Console.ReadKey();
               Console.Clear();
           }

       } while (correctformat == false);

       String[] elements = Regex.Split(FullName[FullNameValue], Pattern);

       foreach (var element in elements)
       {

           if (trick == 0)
           {
               LastName = element;
           }
           else
           {
               FirstName = element;
           }
           trick++;
       }

       string sql = "Data Source=SALDAR05-PC;" + "Initial Catalog=TestDaryl;" + "User id=GeoffHise;" + "Password=goldhorse7";
       SqlConnection connection02 = new SqlConnection(sql);
       connection02.Open();
       var mycommand01 = new SqlCommand("Select StudentID,FirstName,LastName from Student where FirstName=@FirstName and LastName=@LastName",
       connection02);

       mycommand01.Parameters.AddWithValue("@FirstName", FirstName);
       mycommand01.Parameters.AddWithValue("@LastName", LastName);
      

       using (var reader = mycommand01.ExecuteReader())
       {
           if (reader.Read())
           {

               GetID = reader.GetInt32(0);
               Console.Write("Record found for");
               Console.Write(" ");
               Console.Write(FirstName);
               Console.Write(" ");
               Console.WriteLine(LastName);
               reader.Close();
               connection02.Close();
           }

           else
           {

               Console.Write("No record found");
               Console.Write(" for ");
               Console.Write(FirstName);
               Console.Write(LastName);
               Console.ReadKey();
               Console.Clear();
               DisplayMenu();

           }

           
           string sql1 = "Data Source=SALDAR05-PC;" + "Initial Catalog=TestDaryl;" + "User id=GeoffHise;" + "Password=goldhorse7";
           SqlConnection connection03 = new SqlConnection(sql1);
           connection03.Open();
           var mycommand011 = new SqlCommand("Delete Exam from Exam inner join Course on Exam.CourseID=Course.CourseID where CourseName=@CourseName and Exam.StudentID=@ID",
           connection03);
           mycommand011.Parameters.AddWithValue("@ID", GetID);
           mycommand011.Parameters.AddWithValue("@CourseName", course);
           numberOfRecords=   mycommand011.ExecuteNonQuery();
           connection03.Close();
       }

       if (numberOfRecords >= 1)
       {
          

           ConsoleKeyInfo c;
           do
           {
               Console.Write("Delete was a success.Hit enter to go back to the main menu");


               c = Console.ReadKey();
           } while (c.Key != ConsoleKey.Enter);
           Console.Clear();
           DisplayMenu();
       }

       else
       {
           ConsoleKeyInfo c;
           do
           {
               Console.Write("No grades to delete.Press enter to go back to the main menu");
              

               c = Console.ReadKey();
           } while (c.Key != ConsoleKey.Enter);
       }

       Console.Clear();
       DisplayMenu();
  }



static public void InsertStudentGrades()
        {
            Boolean NonNumericValue = false;
            int counter = 1;
            ConsoleKeyInfo c;
            int p = 0;
            string[] FullName={" "} ;
            int FullNameValue=0;
            string Pattern=@"[,]";
            string LastName=" ";
            string FirstName= " ";
            int trick = 0;
            string colon = ",";
            bool correctformat=false;
            int GetID = 0;
            int incrementer = 1;
            char caseSwitch;
            var indentAmount = 12;
            String courseName = " ";
           
         do
          {
              if (incrementer > 1)
              {
                  Console.Clear();
              }


            var indent = new string(' ', indentAmount);
            var Newtext = indent.Replace(Environment.NewLine, Environment.NewLine + indent);

            for (int i = 0; i < 10; i++)
            {
                Console.Write("\n");

            } 
 

            Console.Write(Newtext);
            Console.WriteLine("Please select an option below:");
            Console.Write(Newtext);
            Console.WriteLine(" 1. Enter grade(s) for Math course");
            Console.Write(Newtext);
            Console.WriteLine(" 2. Enter grade(s) for Science course");
            Console.Write(Newtext);
            Console.WriteLine(" 3. Enter grade(s) for History course");
            Console.Write(Newtext);
            Console.WriteLine(" 4. Enter grade for English course");
            Console.Write(Newtext);
            Console.WriteLine(" 5. Go back to the main menu");
            Console.Write(Newtext);
            Console.Write("Select an option (1-5)");
            caseSwitch = Console.ReadKey().KeyChar; 
            Console.Write(Newtext);
           
            
          
            
                  if ((char.IsNumber(caseSwitch)) && (caseSwitch<='0' || caseSwitch>'5'))
                {
                    Console.Write("\n");
                    Console.Write("Please select option 1-5 only!");
                    Console.ReadKey();
                    incrementer++;
                 }
              

                else if(char.IsLetter(caseSwitch))
                {
                    Console.Write("\n");
                    Console.Write("Please enter in numeric values only");
                    Console.ReadKey();
                    incrementer++;
                    
                }

                else if (char.IsPunctuation(caseSwitch))
                {
                    Console.Write("\n");
                    Console.Write("Please enter in numeric values only");
                    Console.ReadKey();
                    incrementer++;
                 }

                else if (char.IsSymbol(caseSwitch))
                  {
                    Console.Write("\n");
                    Console.WriteLine("Please enter in numeric values only");
                    Console.ReadKey();
                    incrementer++;
                  }
                  else
                  {
                      break;
                  }
              
                
            }while (caseSwitch <=0 || caseSwitch>5);

               switch (caseSwitch)
            {
                case '1':
                  
                    courseName="Math";
                    Console.Clear();
                    break;
                case '2':
                    courseName="Science";
                    Console.Clear();
                    break;
                case '3':
                   courseName="History";
                   Console.Clear();
                    break;
                case '4':
                    
                    courseName="English";
                    Console.Clear();
                    break;
                case '5':
                    Console.Clear();
                    DisplayMenu();
                    break;
              }
               
       do
       {
             courseName = courseName.ToLower();
             Console.Clear();
             Console.Write("Please enter in the last Name\nfollowed by the first name (e.g Smith,John):");
             FullName[FullNameValue] =Console.ReadLine();

       
            if (FullName[FullNameValue].Any(char.IsPunctuation))
             {

                if (FullName[FullNameValue].Contains(colon))
                  {
                      
                    
                    correctformat = true;
                    break;
                   }
                else
                   {
                    
                      Console.Write("Please enter in alpha characters only");
                      Console.ReadKey();
                      Console.Clear();
                   }
              }

           else if(FullName[FullNameValue].Any(char.IsDigit))
                {
                  Console.Write("Please enter in alpha characters");
                  Console.ReadKey();
                  Console.Clear(); 
              
           }
            else if (FullName[FullNameValue].Any(char.IsWhiteSpace))
               { 
                  Console.Write("Please do not enter in white spaces");
                  Console.ReadKey();
                  Console.Clear();
               }
           
         }while(correctformat==false );

                String [] elements = Regex.Split(FullName[FullNameValue], Pattern);

        foreach (var element in elements)
         {

         if(trick==0 )
            {
              LastName = element;
            }
          else
             {
              FirstName = element;
             }  
             trick++;
          }

              string  sql = "Data Source=SALDAR05-PC;" + "Initial Catalog=TestDaryl;" + "User id=GeoffHise;" + "Password=goldhorse7";
              SqlConnection connection02 = new SqlConnection(sql);
              connection02.Open();
              var mycommand01 = new SqlCommand("Select StudentID,FirstName,LastName from Student where FirstName=@FirstName and LastName=@LastName", 
              connection02);
              mycommand01.Parameters.AddWithValue("@FirstName",FirstName);
              mycommand01.Parameters.AddWithValue("@LastName", LastName);

                 
              using (var reader = mycommand01.ExecuteReader())
                 {
                     if (reader.Read())
                     {
                       
                          GetID=reader.GetInt32(0);
                         Console.Write("Record found for");
                         Console.Write(" ");
                         Console.Write(FirstName);
                         Console.Write(" ");
                         Console.WriteLine(LastName);
                         
                     }
                     else
                     {
                         Console.Write("No record found for ");
                         Console.Write(FirstName);
                         Console.Write(LastName);
                         Console.ReadKey();
                         Console.Clear();
                         DisplayMenu();
                     }
                 }

         

            counter = 1;
            int Exam = 1;
            
            
            do
            {       int k=0;
                    int j = 0;
                    Console.Write("Enter in ");
                    Console.Write(FirstName );
                    Console.Write(" ");
                    Console.Write("Exam score for ");
                    Console.Write(courseName);
                    Console.Write(":");
                    try
                    {
                       
                            StudentArray[j, k] = Int32.Parse(Console.ReadLine());
                           
                            if (StudentArray[j, k] > 100 || StudentArray[j, k] < 0)
                              {
                                Console.WriteLine("Please enter in a value between 0 and 100");
                                k = k - 1;
                              }
                            else
                              {
                                Exam++;
                              }

                        
                        counter = counter + 1;
                        
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Please enter in numeric values only.Press enter to continue");
                        Console.ReadKey();
                        ClearLine();
                        NonNumericValue = true;
                    }
               


            } while (NonNumericValue == true);

              SQLInsertFunction(GetID,courseName);
              do
              {
              Console.WriteLine("Press enter to go back to the main menu");

         
                c = Console.ReadKey();
              } while (c.Key != ConsoleKey.Enter);

            Console.Clear();
            DisplayMenu();

      }
  public static void ExitProgram()
        {

            Console.Clear();
            Console.WriteLine("Are you sure you want to exit the Student Program ?");
            Console.Write("Enter in yes or no (Yes or No)");

            bool legitAnswer = false;
            string Answer = Console.ReadLine();
            Answer = Answer.ToLower();


            do
            {
                if (Answer.Any(char.IsPunctuation))
                {
                    Console.Write("No punctuation marks please");
                    Console.ReadKey();
                    ClearLine();

                }
                else if (Answer.Any(char.IsDigit))
                {
                    Console.Write("Please enter in alpha characters only");
                    Console.ReadKey();
                    ClearLine();
                }
                else
                {
                    if (Answer == "no")
                    {
                        Console.Clear();
                        DisplayMenu();
                    }
                    else
                    {

                        legitAnswer = true;
                        Environment.Exit(0);
                    }
                }
            } while (legitAnswer == false);
        }


 static public void InsertStudentsNameFunction()
        {
            int counter2 = 0;
            int incrementer = 1;
            bool isNumeric02;
            bool isNumeric = false;
            int jk = 0;
            int p = 0;


               do
                 {
                    
                    Console.Write("Please enter in Student" + " First Name:");

                    FirstNameArray[p, counter2] = Console.ReadLine();
                    Console.Write("Please enter in Student" + " Last Name:");

                    LastNameArray[p, counter2] = Console.ReadLine();
                    incrementer = incrementer + 1;
                   

                    isNumeric = int.TryParse(FirstNameArray[p, counter2], out jk);
                    isNumeric02 = int.TryParse(LastNameArray[p, counter2], out p);



                    if (isNumeric == true || isNumeric02 == true)
                    {

                        Console.Write("Value you entered is not a string. Press enter to try again");
                        p = p - 1;
                        incrementer = incrementer - 1;
                        Console.ReadKey();
                        Console.Clear();
                    }
                    else if (FirstNameArray[p, counter2].Any(char.IsPunctuation) || LastNameArray[p, counter2].Any(char.IsPunctuation))
                    {
                        Console.Write("Value you entered is not a string. Press enter to try again");
                       
                       
                        Console.ReadKey();
                        Console.Clear();

                    }
                    else
                    {
                        isNumeric=false;
                    }

                  }while(isNumeric==true);
            
               
                SQLInsertName();

        }
 static public void DisplayNames()
        {
            string[] FullName = { "" };
            int FullNameValue = 0;
            bool correctformat=false;
            string colon=",";
            string LastName=" ";
            string FirstName="";
            int trick=0;
            string Pattern = @"[,]";
            ConsoleKeyInfo c;
            do
            {
                Console.Write("Please enter in the last Name\nfollowed by the first name \n of student you wish to  view (e.g Smith,John):");
                FullName[FullNameValue] = Console.ReadLine();


                if (FullName[FullNameValue].Any(char.IsPunctuation))
                {

                    if (FullName[FullNameValue].Contains(colon))
                    {


                        correctformat = true;
                        break;
                    }
                    else
                    {

                        Console.Write("Please enter in alpha characters only");
                        Console.ReadKey();
                        Console.Clear();
                    }
                }

                else if (FullName[FullNameValue].Any(char.IsDigit))
                {
                    Console.Write("Please enter in alph characters");
                    Console.ReadKey();
                    Console.Clear();

                }
                else if (FullName[FullNameValue].Any(char.IsWhiteSpace))
                {
                    Console.Write("Please do not enter in white spaces");
                    Console.ReadKey();
                    Console.Clear();
                }
               

            }while (correctformat == false);

               String[] elements = Regex.Split(FullName[FullNameValue], Pattern);

            foreach (var element in elements)
            {

                if (trick == 0)
                {
                    LastName = element;
                }
                else
                {
                    FirstName = element;
                }
                trick++;
            }


         string sql = "Data Source=SALDAR05-PC;" + "Initial Catalog=TestDaryl;" + "User id=GeoffHise;" + "Password=goldhorse7";
            SqlConnection connection55 = new SqlConnection(sql);
            connection55.Open();   
        var mycommand01 = new SqlCommand("Select StudentID,FirstName,LastName from Student where FirstName=@FirstName and LastName=@LastName",
       connection55);

        mycommand01.Parameters.AddWithValue("@FirstName", FirstName);
        mycommand01.Parameters.AddWithValue("@LastName", LastName);


        using (var reader = mycommand01.ExecuteReader())
        {
            if (reader.Read())
            {

                int GetID = reader.GetInt32(0);
                Console.Write("Record found for");
                Console.Write(" ");
                Console.Write(FirstName);
                Console.Write(" ");
                Console.WriteLine(LastName);
                reader.Close();
                connection55.Close();
            }

            else
            {

                Console.Write("No record found");
                Console.Write(" for ");
                Console.Write(FirstName);
                Console.Write(LastName);
                Console.Write("Press enter to go back to main menu");
                Console.ReadKey();
                Console.Clear();
                DisplayMenu();
                connection55.Close();

            }
        }
            string sql02 = "Data Source=SALDAR05-PC;" + "Initial Catalog=TestDaryl;" + "User id=GeoffHise;" + "Password=goldhorse7";
            SqlConnection connection02 = new SqlConnection(sql02);
            connection02.Open();

            
            var mycommand22 = new SqlCommand("Select FirstName,LastName,CourseName,ExamScore from Student inner join "+
             "Course on Student.StudentID=Course.StudentID inner join Exam on Exam.StudentID=Course.StudentID where (FirstName=@FirstName"
             + " " + "AND LastName=@LastName)",connection02);

            mycommand22.Parameters.AddWithValue("@FirstName", FirstName);
            mycommand22.Parameters.AddWithValue("@LastName", LastName);


            using (var reader22 = mycommand22.ExecuteReader())

            {
             while (reader22.Read())
                {




                    if (reader22.HasRows)
                    {
                        string Name01 = reader22.GetString(0);
                        Console.Write("\n");
                        string Name02 = reader22.GetString(1);
                        String CourseName = reader22.GetString(2);
                        var ExamScore = reader22.GetInt32(3);
                        Console.Write(Name01);
                        Console.Write(" ");
                        Console.Write(Name02);
                        Console.Write("");
                        Console.Write("");
                        Console.Write(CourseName);
                        Console.WriteLine(ExamScore);
                        Console.ReadKey();
                      }
                  
                    }
                   

                  }

            do
            {
                Console.Write("Press enter to go back to the main menu");


                c = Console.ReadKey();
            } while (c.Key != ConsoleKey.Enter);

            Console.Clear();
            DisplayMenu();
         } 

        //    int r = 0;
        //    int m = 0;
        //    ConsoleKeyInfo c;
        //    int runningtotal = 0;


        //    if (StudentArray[r, m] == 0)
        //    {

        //        Console.WriteLine("No Name or grades to display.Press enter to return to main menu");

        //        do
        //        {
        //            c = Console.ReadKey();
        //        } while (c.Key != ConsoleKey.Enter);


        //        Console.Clear();
        //        DisplayMenu();
        //    }
        //    else
        //    {
        //        Console.WriteLine("Student Names are: ");

        //        for (int j = 0; j < MaxValue; j++)
        //        {
        //            int k = 0;
        //            int TempAverage = 0;

        //            Console.WriteLine(FirstNameArray[j, k]);
        //            Console.WriteLine(LastNameArray[j, k]);
        //            Console.WriteLine("Test scores are :");

        //            for (int l = 0; l < NumScores; l++)
        //            {

        //                Console.WriteLine(StudentArray[j, l]);
        //                TempAverage = +StudentArray[j, l];
        //                runningtotal = TempAverage + runningtotal;
        //            }
        //            Average[r, m] = (runningtotal / NumScores);

        //            Console.WriteLine("Average is" + " " + Average[r, m]);
        //            r++;
        //        }

        //        Console.WriteLine("Press enter to return to main menu");

        //        do
        //        {
        //            c = Console.ReadKey();
        //        } while (c.Key != ConsoleKey.Enter);


        //        Console.Clear();
        //        DisplayMenu();
        


 public static void ClearLine()
        {
            Console.SetCursorPosition(0, Console.CursorTop - 1);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, Console.CursorTop - 1);
        }


 static public void SQLInsertName()
        {
            String connection01 = null;
            int ip=0;
            int j = 0;
            ConsoleKeyInfo c;

           
            connection01 = "Data Source=SALDAR05-PC;" + "Initial Catalog=TestDaryl;" + "User id=GeoffHise;" + "Password=goldhorse7";
           
          
            SqlConnection connection02 = new SqlConnection(connection01);
            connection02.Open();
            var mycommand = new SqlCommand("INSERT INTO Student VALUES(@FirstName, @LastName);SELECT CAST(scope_identity() AS int)", connection02);
            mycommand.Parameters.AddWithValue("@FirstName", FirstNameArray[ip, j]);
            mycommand.Parameters.AddWithValue("@LastName", LastNameArray[ip, j]);
            mycommand.ExecuteNonQuery();

                

             if (connection02.State == System.Data.ConnectionState.Open)
                {
                    connection02.Close();
                }


               
                do
                {   
                     Console.WriteLine("Student name(s) added to the system successfully");
                     Console.Write(" Press enter to return to main menu");
                    c = Console.ReadKey();
                } while (c.Key != ConsoleKey.Enter);


                Console.Clear();
                DisplayMenu();
            
        }

   static public void SQLInsertFunction(int GetID,string CourseName)
     {
            String connection01 = null;
            connection01 = "Data Source=SALDAR05-PC;" + "Initial Catalog=TestDaryl;" + "User id=GeoffHise;" + "Password=goldhorse7";
            SqlConnection connection02 = new SqlConnection(connection01);
            connection02.Open();
            int j = 0;
            int k = 0;
               var mycommand = new SqlCommand("INSERT INTO Course(StudentID,CourseName) VALUES(@StudentID, @CourseName);Select CourseID from Course where StudentID=@StudentID", connection02);
                mycommand.Parameters.AddWithValue("@StudentID", GetID);
                mycommand.Parameters.AddWithValue("@CourseName",CourseName );
                mycommand.ExecuteNonQuery();

           int CourseID=0;
          
         using (var reader01 = mycommand.ExecuteReader())
            {
                if (reader01.Read())
                {

                    CourseID = reader01.GetInt32(0);
                    Console.WriteLine("course found");
                    reader01.Close();
                }

                else
                {
                    Console.Write("No record found");
                    Console.Write("Please try again or press enter to go back to the ");
                    Console.Write("main menu");
                    Console.Clear();
                    DisplayMenu();
                }
                 

                       var mycommand01 = new SqlCommand("INSERT INTO Exam(StudentID,ExamScore,CourseID) VALUES(@ID, @ExamScore,@CourseID)", connection02);
                        mycommand01.Parameters.AddWithValue("@ID", GetID);
                        mycommand01.Parameters.AddWithValue("@ExamScore", StudentArray[k, j]);
                        mycommand01.Parameters.AddWithValue("@CourseID", CourseID);
                        mycommand01.ExecuteNonQuery();
                   
                
              


                if (connection02.State == System.Data.ConnectionState.Open)
                {
                    connection02.Close();
                }
            }
           
            ConsoleKeyInfo c;
            Console.WriteLine("Student's score was entered.");
            do
            {
                Console.Write("Insert was a success.Hit enter to go back to the main menu");
                c = Console.ReadKey();
            } while (c.Key != ConsoleKey.Enter);
            DisplayMenu();
        }



   static public void SQLUpdateFunction()
        {
            String FirstName = " ";
            String LastName = " ";
            ConsoleKeyInfo c;
            int p = 0;
            string[] FullName = { " " };
            int FullNameValue = 0;
            string Pattern = @"[,]";
            int trick = 0;
            string colon = ",";
            string Answer = "";
            bool correctformat = false;
            int GetID = 0;
            int ExamScore = 0;
            string dt = "";
            bool ExamFound = false;




           do
           {
                Console.Write("Please enter in the last Name\nfollowed by the first name you wish to update (e.g Smith,John):");
                FullName[FullNameValue] = Console.ReadLine();


                if (FullName[FullNameValue].Any(char.IsPunctuation))
                {

                    if (FullName[FullNameValue].Contains(colon))
                    {


                        correctformat = true;
                        break;
                    }
                    else
                    {

                        Console.Write("Please enter in alpha characters only");
                        Console.ReadKey();
                        Console.Clear();
                    }
                }

                else if (FullName[FullNameValue].Any(char.IsDigit))
                {
                    Console.Write("Please enter in alph characters");
                    Console.ReadKey();
                    Console.Clear();

                }
                else if (FullName[FullNameValue].Any(char.IsWhiteSpace))
                {
                    Console.Write("Please do not enter in white spaces");
                    Console.ReadKey();
                    Console.Clear();
                }

            } while (correctformat == false);

            String[] elements = Regex.Split(FullName[FullNameValue], Pattern);

            foreach (var element in elements)
            {

                if (trick == 0)
                {
                    LastName = element;
                }
                else
                {
                    FirstName = element;
                }
                trick++;
            }



            string sql = "Data Source=SALDAR05-PC;" + "Initial Catalog=TestDaryl;" + "User id=GeoffHise;" + "Password=goldhorse7";
            SqlConnection connection02 = new SqlConnection(sql);
            connection02.Open();
            var mycommand01 = new SqlCommand("Select StudentID,FirstName,LastName from Student where FirstName=@FirstName and LastName=@LastName", 
            connection02);

            mycommand01.Parameters.AddWithValue("@FirstName", FirstName);
            mycommand01.Parameters.AddWithValue("@LastName", LastName);



            using (var reader = mycommand01.ExecuteReader())
            {
                if (reader.Read())
                {

                    GetID = reader.GetInt32(0);
                    Console.Write("Record found for");
                    Console.Write(" ");
                    Console.Write(FirstName);
                    Console.Write(" ");
                    Console.WriteLine(LastName);
                    reader.Close();

                    Console.Write("Please enter in the updated First Name and Last Name(e.g.Smith,John):");
                    FullName[FullNameValue] = Console.ReadLine();

                    bool legitAnswer = false;
                    do
                    {

                        Console.Write("Do you want to update an exam score as well (Yes or No only)?");
                        Answer = Console.ReadLine();
                        Answer = Answer.ToLower();



                        if (Answer.Any(char.IsPunctuation))
                        {
                            Console.Write("No punctuation marks please");
                            Console.ReadKey();
                            ClearLine();

                        }
                        else if (Answer.Any(char.IsDigit))
                        {
                            Console.Write("Please enter in alpha characters only");
                            Console.ReadKey();
                            ClearLine();
                        }
                        else
                        {
                            legitAnswer = true;
                        }
                    } while (legitAnswer == false);





                    if (Answer == "yes")
                    {
                        do
                        {



                            Console.Write("Enter in the Subject(e.g. Math,Science,History or English:");
                            string CourseName = Console.ReadLine();

                            Console.Write("Enter in the exam score you wish to update:");
                            ExamScore = Int32.Parse(Console.ReadLine());
                            
                            var mycommand02 = new SqlCommand("Select ExamScore,CourseName from Course inner join Exam where StudentID=@StudentID and CourseName=@CourseName", connection02);
                            mycommand02.Parameters.AddWithValue("@StudentID", GetID);
                            mycommand02.Parameters.AddWithValue("@CourseName", CourseName);


                            using (var reader01 = mycommand01.ExecuteReader())
                            {
                                if (reader01.Read())
                                {

                                    int Score = reader01.GetInt32(0);
                                    Console.Write(CourseName);
                                    Console.Write("");
                                    Console.Write("Exam found for");
                                    Console.Write(" ");
                                    Console.Write(FirstName);
                                    Console.Write(" ");
                                    Console.WriteLine(LastName);
                                    reader.Close();
                                    ExamFound = true;
                                }
                                else
                                {
                                    Console.Write("No record found");
                                    Console.Write("Please try again or press escape to go back to the ");
                                    Console.Write("main menu");
                                    ClearLine();

                                    c = Console.ReadKey();
                                    if (c.Key == ConsoleKey.Escape)
                                    {
                                        Console.Clear();
                                        DisplayMenu();
                                    }
                                }
                            }
                        } while (ExamFound == false);
                    }


                    do
                    {
                        if (FullName[FullNameValue].Any(char.IsPunctuation))
                        {

                            if (FullName[FullNameValue].Contains(colon))
                            {
                                correctformat = true;
                                break;
                            }
                            else
                            {
                                Console.Write("Please enter in alpha characters only");
                                Console.ReadKey();
                                Console.Clear();
                            }
                        }

                        else if (FullName[FullNameValue].Any(char.IsDigit))
                        {
                            Console.Write("Please enter in alph characters");
                            Console.ReadKey();
                            Console.Clear();
                        }
                        else if (FullName[FullNameValue].Any(char.IsWhiteSpace))
                        {
                            Console.Write("Please do not enter in white spaces");
                            Console.ReadKey();
                            Console.Clear();
                        }

                    } while (correctformat == false);

                    String[] elements01 = Regex.Split(FullName[FullNameValue], Pattern);

                    foreach (var element in elements01)
                    {
                        if (trick == 0)
                        {
                            LastName = element;
                        }
                        else
                        {
                            FirstName = element;
                        }
                        trick++;
                    }
                }
                else
                {
                    Console.Write("No record found for ");
                    Console.Write(FirstName);
                    Console.Write(LastName);
                    Console.ReadKey();
                    reader.Close();
                    Console.Clear();
                    DisplayMenu();
                }




                string querystr;
                if (Answer == "yes" && ExamFound == true)
                {
                    string querystr02 = "UPDATE Exam SET ExamScore=@ExamScore WHERE StudentID=@StudentID";

                    var mycommand03 = new SqlCommand(querystr02, connection02);
                    mycommand03.Parameters.AddWithValue("@ExamScore", ExamScore);
                    mycommand03.Parameters.AddWithValue("@StudentID", GetID);
                    mycommand03.Parameters.AddWithValue("@Date", dt);
                    mycommand03.ExecuteNonQuery();
                }

                querystr = "UPDATE Student SET FirstName=@FirstName,LastName=@LastName WHERE StudentID=@StudentID";
                var mycommand04 = new SqlCommand(querystr, connection02);
                mycommand04.Parameters.AddWithValue("@StudentID", GetID);
                mycommand04.Parameters.AddWithValue("@FirstName", FirstName);
                mycommand04.Parameters.AddWithValue("@LastName", LastName);

                mycommand04.ExecuteNonQuery();
                connection02.Close();

              
                do
                {
                    Console.WriteLine("Update was a success.Hit enter to go back to the main menu");
                    c = Console.ReadKey();
                } while (c.Key != ConsoleKey.Enter);


                Console.Clear();
                DisplayMenu();

            }
        }


   static public void SQLDeleteNameFunction()
   {
       string[] FullName = { "" };
       int FullNameValue = 0;
       bool correctformat = false;
       string Pattern = @"[,]";
       int trick = 0;
       string LastName="";
       string FirstName="";
       string colon = ",";
       int GetID = 0;
       do
       {
           Console.Write("Please enter in the last Name\nfollowed by the first name you wish to delete (e.g Smith,John):");
           FullName[FullNameValue] = Console.ReadLine();


           if (FullName[FullNameValue].Any(char.IsPunctuation))
           {

               if (FullName[FullNameValue].Contains(colon))
               {


                   correctformat = true;
                   break;
               }
               else
               {

                   Console.Write("Please enter in alpha characters only");
                   Console.ReadKey();
                   Console.Clear();
               }
           }

           else if (FullName[FullNameValue].Any(char.IsDigit))
           {
               Console.Write("Please enter in alph characters");
               Console.ReadKey();
               Console.Clear();

           }
           else if (FullName[FullNameValue].Any(char.IsWhiteSpace))
           {
               Console.Write("Please do not enter in white spaces");
               Console.ReadKey();
               Console.Clear();
           }

       } while (correctformat == false);

       String[] elements = Regex.Split(FullName[FullNameValue], Pattern);

       foreach (var element in elements)
       {

           if (trick == 0)
           {
               LastName = element;
           }
           else
           {
               FirstName = element;
           }
           trick++;
       }

       string sql = "Data Source=SALDAR05-PC;" + "Initial Catalog=TestDaryl;" + "User id=GeoffHise;" + "Password=goldhorse7";
       SqlConnection connection02 = new SqlConnection(sql);
       connection02.Open();
       var mycommand01 = new SqlCommand("Select StudentID,FirstName,LastName from Student where FirstName=@FirstName and LastName=@LastName",
       connection02);

       mycommand01.Parameters.AddWithValue("@FirstName", FirstName);
       mycommand01.Parameters.AddWithValue("@LastName", LastName);



       using (var reader = mycommand01.ExecuteReader())
       {
           if (reader.Read())
           {

               GetID = reader.GetInt32(0);
               Console.Write("Record found for");
               Console.Write(" ");
               Console.Write(FirstName);
               Console.Write(" ");
               
               Console.WriteLine(LastName);
               reader.Close();

           }

           var mycommand011 = new SqlCommand("Delete from Student where  StudentID=@ID",
           connection02);
           mycommand011.Parameters.AddWithValue("@ID", GetID);
           mycommand011.ExecuteNonQuery();
       }

        connection02.Close();

        Console.WriteLine("Delete was a success.Hit enter to go back to the main menu");
        ConsoleKeyInfo c;
       do
       {
           c = Console.ReadKey();
       } while (c.Key != ConsoleKey.Enter);


       Console.Clear();
       DisplayMenu();

   }
  static void Main(string[] args)
        {
            DisplayMenu();

        }

    static public void DisplayMenu()
        {


            int incrementer = 1;
            char caseSwitch;
            var indentAmount = 12;
            Console.Clear();

            do
            {
                var indent = new string(' ', indentAmount);
                var Newtext = indent.Replace(Environment.NewLine, Environment.NewLine + indent);

                if (incrementer > 1)
                {

                    Console.Clear();
                }

                for (int i = 0; i < 10; i++)
                {
                    Console.Write("\n");

                }


                Console.Write(Newtext);
                Console.WriteLine("Please select an option below:");
                Console.Write(Newtext);
                Console.WriteLine(" 1. Update Student(s) Grades and Names");
                Console.Write(Newtext);
                Console.WriteLine(" 2. Delete Students Names");
                Console.Write(Newtext);
                Console.WriteLine(" 3. Delete Student grades");
                Console.Write(Newtext);
                Console.WriteLine(" 4. Insert Students Names");
                Console.Write(Newtext);
                Console.WriteLine(" 5. Display Student Names and Grades");
                Console.Write(Newtext);
                Console.WriteLine(" 6. Insert Grades");
                Console.Write(Newtext);
                Console.WriteLine(" 7. Exit the system");
                Console.Write(Newtext);
               
                Console.Write("Select an option (1-7)");
                caseSwitch = Console.ReadKey().KeyChar;



                if ((char.IsNumber(caseSwitch)) && (caseSwitch <= '0' || caseSwitch > '7'))
                {

                    Console.Write("\n");
                    Console.Write("Please select option 1-7 only!");
                    Console.ReadKey();
                    incrementer++;


                }


                else if (char.IsLetter(caseSwitch))
                {
                    Console.Write("\n");
                    Console.Write("Please enter in numeric values only");
                    Console.ReadKey();
                    incrementer++;

                }

                else if (char.IsPunctuation(caseSwitch))
                {
                    Console.Write("\n");
                    Console.Write("Please enter in numeric values only");
                    Console.ReadKey();
                    incrementer++;


                }

                else if (char.IsSymbol(caseSwitch))
                {
                    Console.Write("\n");
                    Console.WriteLine("Please enter in numeric values only");
                    Console.ReadKey();
                    incrementer++;
                }

                else
                {
                    break;
                }

            } while (caseSwitch <= 0 || caseSwitch > 7);



            switch (caseSwitch)
            {
                case '1':
                    Console.Clear();
                    SQLUpdateFunction();
                    break;
                case '2':
                    Console.Clear();
                    SQLDeleteNameFunction();
                    break;
                case '3':
                    Console.Clear();
                    SQLDeleteGradeFunction();
                    break;
                case '4':
                    Console.Clear();
                    InsertStudentsNameFunction();
                    break;
                case '5':
                    Console.Clear();
                    DisplayNames();
                    break;
                case '6':
                    Console.Clear();
                    InsertStudentGrades();
                    break;
                
                case '7':
                    Console.Clear();
                    ExitProgram();
                    break;
            }
        }
    }
}