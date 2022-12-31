using Labb_4_EgnaProjekt.Data;
using Labb_4_EgnaProjekt.Models;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb_4_EgnaProjekt.UserMenu
{
    public class AdminMenu
    {
        public static AhlingsSchoolDbContext context = new AhlingsSchoolDbContext();
        public static void Run()
        {

            Console.WriteLine("Hello and welcome to AdminMenu");
            Console.WriteLine("1 for add users: ");
            Console.WriteLine("2 for Employee Information");
            Console.WriteLine("3 department info");
            Console.WriteLine("4 Logout");
            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    AddUsers();
                    break;
                case 2:
                    EmployeeInfo();
                    break;
                case 3:
                    DepartmentInfo();
                    break;
                case 4:
                    AhlingSchool.Run();
                    break;
            }

        }
        public static void AddUsers()
        {
            AhlingsSchoolDbContext context = new AhlingsSchoolDbContext();
            int choice = 0;
            try
            {
                PersonalInformation p1 = new PersonalInformation();
                Console.WriteLine("Type the name of the person");
                p1.Fname = Console.ReadLine();
                Console.WriteLine("Last Name");
                p1.Lname = Console.ReadLine();
                Console.WriteLine("Birthdate");
                Console.WriteLine("Input Format need to be \n:0000,00,00");
                string birthdate = Console.ReadLine();
                p1.Birthdate = Convert.ToDateTime(birthdate);
                Console.WriteLine("Write your email");
                p1.Mail = Console.ReadLine();
                Console.WriteLine("Write your social security number as: 00000000-0000");
                p1.Ssnumber = Console.ReadLine();
                Console.WriteLine("type 1 for  student and type 2 for employee");
                string type = Console.ReadLine();
                p1.Type = Convert.ToInt32(type);
                Console.WriteLine("What gender? F for female and M for Male");
                p1.Gender = Console.ReadLine().ToUpper();
                context.PersonalInformations.Add(p1);
                context.SaveChanges();
                Console.WriteLine("Add this person as a student press 1:\nAdd this person as employee press 2");
            
               choice = int.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("You have to enter the information correcly, otherwise a error occurs.");
                Console.ReadKey();
                Console.Clear();
                AdminMenu.Run();

            }
            
            switch (choice)
            {
                case 1:
                    addStudent();
                    break;
                case 2:
                    addEmployee();
                    break;
            }

            static void addStudent()
            {
                AhlingsSchoolDbContext context = new AhlingsSchoolDbContext();
                Student stud1 = new Student();

                stud1.Title = "Student";
                context.Add(stud1);
                context.SaveChanges();
                Console.WriteLine("Student added");
                Console.WriteLine("Press key to continue");
                Console.ReadKey();
                AdminMenu.Run();
            }
            static void addEmployee()
            {
                AhlingsSchoolDbContext context = new AhlingsSchoolDbContext();
                
                Employee emp1 = new Employee();
                string choice = null;

                Console.WriteLine("Which titel do the employee have?");
                Console.WriteLine("1: Teacher \n2: Admin\n3:Janitor");
                choice = Console.ReadLine();
                if (choice == "1")
                {
                    emp1.Title = "Teacher";
                    Console.WriteLine("What is their salary?");
                    decimal salary = decimal.Parse(Console.ReadLine());
                    emp1.Salary = salary;
                }
                else if (choice == "2")
                {
                    emp1.Title = "Administrator";
                    Console.WriteLine("What is their salary?");
                    decimal salary = decimal.Parse(Console.ReadLine());
                    emp1.Salary = salary;
                }
                else if (choice == "3")
                {
                    emp1.Title = "Janitor";
                    Console.WriteLine("What is their salary?");
                    decimal salary = decimal.Parse(Console.ReadLine());
                    emp1.Salary = salary;
                }
                context.Add(emp1);
                context.SaveChanges();
                Console.WriteLine("employee added");
                Console.WriteLine("Press key to continue");
                Console.ReadKey();
                AdminMenu.Run();
            }
        }
        static void EmployeeInfo()
        {
            var Employees = from q in context.Employees
                            join w in context.PersonalInformations on q.FkPersonIdEmployee equals w.PersonId

                            select new
                            {
                                PersonalInformation = w.Fname,
                                PersonalInformation1 = w.Lname,
                                PersonalInformation2 = w.Type,
                                PersonalInformation3 = w.PersonId,
                                Employees = q.EmployeeId,
                                Employees1 = q.Title,
                                Employees2 = q.Salary,
                                Emplyee3 = q.HireDate
                            };
            Console.WriteLine("Title:           Name:              LastName:  Type:   EmployeeId:   Salary:   DateSinceStart");
            foreach (var x in Employees)
            {
                Console.WriteLine(x.Employees1 + "\t        " + x.PersonalInformation + "  \t   " + x.PersonalInformation1 + "  \t" + x.PersonalInformation2 + "\t" + x.Employees + "\t" + x.Employees2 + "\t" + x.Emplyee3);
            }
            Console.ReadKey();
            Console.Clear();
            AdminMenu.Run();
        }
       
        static void DepartmentInfo()
        {
            Console.WriteLine("which department would you like to see total salary on?");
            Console.WriteLine("Type the department: \nTeacher \nAdministrator \nJanitor \nBoss ");


            string departmentSalary = Console.ReadLine();
            var totsalary = (from q in context.Employees
                             where q.Title == departmentSalary
                             select q.Salary).Max();
            var minSalary = (from q in context.Employees
                             where q.Title == departmentSalary
                             select q.Salary).Min();
            var averageSalary = (from q in context.Employees
                             where q.Title == departmentSalary
                             select q.Salary).Average();
            Console.WriteLine($"Highest salary:{totsalary}\nLowest salary: {minSalary}\nAverage Salary: {averageSalary}");

            Console.WriteLine("which department would you like to see the total cost of?");
            Console.WriteLine("Type the department: \nTeacher \nAdministrator \nJanitor \nBoss ");

            departmentSalary = Console.ReadLine();
            var TotalCost = ((from q in context.Employees
                              where q.Title == departmentSalary
                              select q.Salary).Sum());
            Console.WriteLine($"{TotalCost}");
            Console.ReadKey();
            AdminMenu.Run();

        }


    }
}
