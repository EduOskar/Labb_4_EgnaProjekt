using Labb_4_EgnaProjekt.Data;
using Labb_4_EgnaProjekt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb_4_EgnaProjekt.UserMenu
{
    public class StundetMenu
    {
        public static AhlingsSchoolDbContext context = new AhlingsSchoolDbContext();
        public static List<LoginUsers> userList = new List<LoginUsers>();
        public static void Run()
        {
            Console.WriteLine("Hello and welcome to studentMenu");
            Console.WriteLine("To look at your personal information press 1: ");
            Console.WriteLine("To logg out press 2: ");
            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    PersonalInfo();
                    break;
                case 2:
                    AhlingSchool.Run();
                    break;
            }

        }
        internal static void PersonalInfo()
        {
            var Join = from q in context.Students
                       join w in context.PersonalInformations on q.FkPersonIdStudent equals w.PersonId
                       where w.Fname == AhlingSchool._FirstName && w.Lname == AhlingSchool._LastName
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

            string studentChoice = AhlingSchool._FirstName;
            string studentLname = AhlingSchool._LastName;
            var Student = from q in context.Schools
                          join b in context.Students on q.FkStudentId equals b.StudentId
                          join w in context.PersonalInformations on b.StudentId equals w.PersonId
                          join e in context.Classes on q.FkClassId equals e.ClassId
                          join t in context.GradingTables on e.FkGradingTable equals t.GradingId
                          where w.Fname == AhlingSchool._FirstName && w.Lname == AhlingSchool._LastName
                          select new
                          {
                              PersonalInformation = w.Fname,
                              PersonalInformation1 = w.Lname,
                              PersonalInformation3 = w.PersonId,
                              Students = q.FkStudentId,
                              Class = e.ClassName,
                              ClassId = e.ClassId,
                              grades = t.Grade
                          };
            Console.WriteLine($"Student: {studentChoice} {studentLname}");
            foreach (var item in Student)
            {
                Console.WriteLine($"StudentId: {item.Students}\nGrade: {item.grades} \nClass: {item.Class}");

            }
            Console.WriteLine("Press Key to Continue");
            Console.ReadKey();
            Console.Clear();
            Run();
        }
    }
}
