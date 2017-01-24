using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student
{
    class Program
    {
        //creat a class
        class Student
        {
            //added data
            public string FirstName;
            public string LastName;
            public int id;
            public double GPA;
            
            //creat a constructor with the same name as the class to initialize the data members of the new object
           public Student (string FirstName, string LastName,int id)
            {
                //"this." to qualify members hidden by similar names
                this.FirstName = FirstName;
                this.LastName = LastName;
                this.id = id;
            }
            //creat a constructor for two data members
            public Student (string FirstName, double GPA)
            {
                this.FirstName = FirstName;
                this.GPA = GPA;
            }
            //this method use to return a string representation of object
            public override string ToString()
            {
                //return as a string
                return FirstName + " " + LastName + " " + id + " " + GPA;
            }
        }

        static void Main(string[] args)
        {
            //creat a new variables
            Student a = new Student("Marzhan", "Okasyva", 1452);
            a.GPA = 3.82; 
            Student b = new Student("Aliya", 4.0);
            b.LastName = "Kyran";
            b.id = 5245;
           
            //display it with method ToString()
            Console.WriteLine(a);
            Console.WriteLine(b);
          
            //window will not close until we won't press any key
            Console.ReadKey();
        }
    }
}
