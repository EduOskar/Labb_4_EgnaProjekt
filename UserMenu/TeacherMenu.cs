using Labb_4_EgnaProjekt.Data;
using Labb_4_EgnaProjekt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb_4_EgnaProjekt.UserMenu
{
    public class TeacherMenu
    {
        public static AhlingsSchoolDbContext context = new AhlingsSchoolDbContext();
        public static List<LoginUsers> userList = new List<LoginUsers>();
        public static void Run() 
        {
            Console.WriteLine("Hello and welcome to studentMenu");


            Console.WriteLine("1: StudentInformation");
            Console.WriteLine("2: ClassInformation");
            Console.WriteLine("3: Loggout");
            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    StudentInfo();
                    break;
                case 2:
                    ClassInfo();
                    break;
                case 3:
                    AhlingSchool.Run();
                    break;
            }


        }
        internal static void StudentInfo()
        {

            var Join = from q in context.Students
                       join w in context.PersonalInformations on q.FkPersonIdStudent equals w.PersonId
                       orderby w.Fname ascending
                       select new
                       {
                           PersonalInformation = w.Fname,
                           PersonalInformation1 = w.Lname,
                           PersonalInformation2 = w.Type,
                           PersonalInformation3 = w.PersonId,
                           Students = q.StudentId,

                       };
            Console.WriteLine("Name:   LastName:     Type:     StudentId: ");
            foreach (var x in Join)
            {

                Console.WriteLine(x.PersonalInformation + " \t " + x.PersonalInformation1 + " \t " + x.PersonalInformation2 + "\t" + x.Students + "\t ");
            }
            Console.WriteLine("Which student would you like to see ?");
            Console.WriteLine("First name: ");
            var studentChoice = Console.ReadLine();
            Console.WriteLine("Last Name");
            var studentChoiceLname = Console.ReadLine();

            var Student = from q in context.Students
                       join w in context.PersonalInformations on q.FkPersonIdStudent equals w.PersonId
                       join e in context.Classes on q.FkClassId equals e.ClassId
                       join t in context.GradingTables on e.FkGradingTable equals t.GradingId
                       where w.Fname == studentChoice && w.Lname == studentChoiceLname
                       select new
                       {
                           PersonalInformation = w.Fname,
                           PersonalInformation1 = w.Lname,
                           PersonalInformation3 = w.PersonId,
                           Students = q.StudentId,
                           Class = e.ClassName,
                           ClassId = e.ClassId
                       };
            foreach (var item in Student)
            {
                Console.WriteLine($"name: {item.PersonalInformation} {item.PersonalInformation1} StudentId: {item.Students}");
                
            }
            Console.WriteLine($"{studentChoice} attends these classes");
          
            foreach (var item in Student)
            {
                Console.WriteLine($"{item.Class}, {item.ClassId}");
            }
            Console.WriteLine("Do you want to set grade?");
            Console.WriteLine("Y/N");
            string choice = Console.ReadLine().ToUpper();
            switch (choice)
            {
                case "Y":
                    SetGrade();
                    break;
                case "N":
                    Console.Clear();
                    Run();
                    break;
            }
            void SetGrade()
            {
                GradingTable gradeStudent = new GradingTable();
                Console.WriteLine("What is the student id?");
                string studId = Console.ReadLine();
                gradeStudent.FkStudentId = Convert.ToInt32(studId);
                Console.WriteLine("what is the class id?");
                string classId = Console.ReadLine();
                gradeStudent.FkClassId = Convert.ToInt32(classId);
                Console.WriteLine("what grade? 1-5");
                int grade = Convert.ToInt32(Console.ReadLine());
                if (grade == 1 || grade == 2 || grade == 3 || grade == 4 || grade == 5)
                {
                }
                else
                {
                    Console.WriteLine("you need to choose between 1 and 5");
                    Console.WriteLine("restarting process");
                    Console.WriteLine("Press a key to continue");
                    Console.ReadKey();
                    SetGrade();
                }
                
                gradeStudent.Grade = Convert.ToInt32(grade);
                gradeStudent.GradeSet = DateTime.Today;
                context.GradingTables.Add(gradeStudent);
                context.SaveChanges();
                Console.WriteLine("grade set sucessfully \nPress Key to continue");
                Console.ReadKey();
                Run();

            }
            Console.ReadKey();

        


        }

        internal static void ClassInfo()
        {


            var Class = from q in context.Classes
                        select new
                        {
                            Classes = q.ClassName,
                            Classes1 = q.ClassId
                        };
            foreach (var x in Class)
            {
                Console.WriteLine($"{x.Classes} {x.Classes1}");
            }
            Console.WriteLine("Do you want to see the students in a specific class?");
            Console.WriteLine("Y/N");
            string choice = Console.ReadLine().ToUpper();
            switch (choice)
            {
                case "Y":
                    Console.Clear();
                    StudentInfo();
                    break;
                case "N":
                    Console.Clear();
                    Run();
                    break;
            }
        }
    }
}
