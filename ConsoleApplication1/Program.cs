using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {

            //Simple Query
            IEnumerable<Student> studentQuery =
                from student in students
                where student.Scores[0] > 90
                orderby student.Last ascending
                select student;

            //Execute Query
            foreach (Student student in studentQuery)
            {
                Console.WriteLine("{0}, {1} {2}", student.Last, student.First, student.Scores[0]);
            }

            Console.WriteLine("--------------"); //Separator

            //Second Query
            //IEnumerable<IGrouping<char,Student>>
            var studentQuery2 =
                from student in students
                group student by student.Last[0]; //Group the students by the first letter of their lastname

           


            //Execute the second query, each result in the iteration is a group of students matched to a key
            foreach (var studentGroup in studentQuery2)
            {
                //Present key, initial of lastname
                Console.WriteLine(studentGroup.Key);
                //Present all students in the group owned by this key
                foreach (Student student in studentGroup)
                {
                    Console.WriteLine("   {0}, {1}",
                              student.Last, student.First);
                }
            }
            Console.WriteLine("--------------"); //Separator

            //Third Query
            var studentQuery3 =
              from student in students
              group student by student.Last[0];

            foreach (var groupOfStudents in studentQuery3)
            {
                Console.WriteLine(groupOfStudents.Key);
                foreach (var student in groupOfStudents)
                {
                    Console.WriteLine("   {0}, {1}",
                        student.Last, student.First);
                }
            }
            Console.WriteLine("--------------"); //Separator
            //Fourth Query

            var studentQuery4 =
             from student in students
             group student by student.Last[0] into studentGroup
             orderby studentGroup.Key //Add in sorting condition
             select studentGroup;

            foreach (var groupOfStudents in studentQuery4)
            {
                Console.WriteLine(groupOfStudents.Key);
                foreach (var student in groupOfStudents)
                {
                    Console.WriteLine("   {0}, {1}",
                        student.Last, student.First);
                }
            }

            Console.WriteLine("--------------"); //Separator

            //Fifth Query - Let Statement

            var studentQuery5 =
                from student in students
                //let statement - assign a value totalScore, use it in the where condition
                let totalScore = student.Scores[0] + student.Scores[1] +
                    student.Scores[2] + student.Scores[3]
                where totalScore / 4 < student.Scores[0]
                select student.Last + " " + student.First;

            foreach (string s in studentQuery5)
            {
                Console.WriteLine(s);
            }

            Console.WriteLine("--------------"); //Separator
            //Sixth Query

            var studentQuery6 =
                from student in students
                let totalScore = student.Scores[0] + student.Scores[1] +
                    student.Scores[2] + student.Scores[3]
                select totalScore;

            double averageScore = studentQuery6.Average(); //Average of all query results
            Console.WriteLine("Class average score = {0}", averageScore);

           

            Console.WriteLine("--------------"); //Separator
            //Seventh Query

            IEnumerable<string> studentQuery7 =
               from student in students
               where student.Last == "Garcia"
               select student.First;

            Console.WriteLine("The Garcias in the class are:"); //Project the results of last name Garcia
            foreach (string s in studentQuery7)
            {
                Console.WriteLine(s);
            }

            Console.WriteLine("--------------"); //Separator
            //Eighth Query

            var studentQuery8 =
                from student in students
                let x = student.Scores[0] + student.Scores[1] +
                    student.Scores[2] + student.Scores[3]
                where x > averageScore
                select new { id = student.ID, score = x }; //Anonymously typed select statement, provides an output object type, including the variable score

            foreach (var item in studentQuery8)
            {
                Console.WriteLine("Student ID: {0}, Score: {1}", item.id, item.score); //Retrieve fields from anonymous type
            }

        }


        //Define nested class Student
        public class Student
        {
            public string First { get; set; }
            public string Last { get; set; }
            public int ID { get; set; }
            public List<int> Scores;

        }

        // Data Structure with which to test LINQ Queries
        static List<Student> students = new List<Student>
        {
           new Student {First="Svetlana", Last="Omelchenko", ID=111, Scores= new List<int> {97, 92, 81, 60}},
           new Student {First="Claire", Last="O'Donnell", ID=112, Scores= new List<int> {75, 84, 91, 39}},
           new Student {First="Sven", Last="Mortensen", ID=113, Scores= new List<int> {88, 94, 65, 91}},
           new Student {First="Cesar", Last="Garcia", ID=114, Scores= new List<int> {97, 89, 85, 82}},
           new Student {First="Debra", Last="Garcia", ID=115, Scores= new List<int> {35, 72, 91, 70}},
           new Student {First="Fadi", Last="Fakhouri", ID=116, Scores= new List<int> {99, 86, 90, 94}},
           new Student {First="Hanying", Last="Feng", ID=117, Scores= new List<int> {93, 92, 80, 87}},
           new Student {First="Hugo", Last="Garcia", ID=118, Scores= new List<int> {92, 90, 83, 78}},
           new Student {First="Lance", Last="Tucker", ID=119, Scores= new List<int> {68, 79, 88, 92}},
           new Student {First="Terry", Last="Adams", ID=120, Scores= new List<int> {99, 82, 81, 79}},
           new Student {First="Eugene", Last="Zabokritski", ID=121, Scores= new List<int> {96, 85, 91, 60}},
           new Student {First="Michael", Last="Tucker", ID=122, Scores= new List<int> {94, 92, 91, 91} },
           new Student {First="Steve", Last= "Sullivan", ID=123, Scores= new List<int> { 52, 68, 97, 71} }
        };

    }

   



}
