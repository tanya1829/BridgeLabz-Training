/* STUDENT CLASS- 
PROPERTIES ID NAME AGE MARKS ONE MORE CLASS OF SUBJECTS AND 
MARKS 3 FUNCTIONS ADD STUDENTS SORT USING 
NAME THEN SORT BASED ON MARKS LIKE TOPPER FAIL  */
using System;
class StudentReport {

    // subjectMarks class 
    class SubjectMarks{
    public string subjects;
    public int marks;

    }
    
    // student class  
    class Student{
    public int Id;
    public string Name;
    public int Age;
  
    
    } // for total marks
      public int totalMarks{
        int total=0;
      }

      // for adding students details

        static void Student() {
        student newStudent = new newStudent();

        Console.WriteLine("Enter your emailId");
        newStudent.Id = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter your Name: ");
        newStudent.Name = Console.ReadLine();

        Console.WriteLine("Enter your age");
        newStudent.Age = int.Parse(Console.ReadLine());

        Console.Write("Enter your subjects ");
        int count = int.Parse(Console.ReadLine());

       
    } 
     // sorting using name

       static void  SortByName(){
        
       }
    }
        static void Main(){
        Student();
    
    }