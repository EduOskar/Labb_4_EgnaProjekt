using Labb_4_EgnaProjekt.UserMenu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Labb_4_EgnaProjekt
{
    public  class AhlingSchool
    {
        public static List<LoginUsers> userList = new List<LoginUsers>();
        public static void Run() 
        {
            Console.WriteLine("1: loggin");
            Console.WriteLine("2: create loggin");
            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    Login();
                    break;
                case 2:
                    CreateAccount();
                    break;
            }

        }
        internal static void Login()
        {
            string enteredUsername = null;
            string enteredPassword = null;
            int userType = 0;
            LoginUsers existingUsers = null;
            LoginUsers existingPassword = null;
            LoginUsers role = null;

            Console.WriteLine("Please enter your username");
            enteredUsername = Console.ReadLine();
            Console.WriteLine("Please enter your password");
            enteredPassword = Console.ReadLine();
            
            existingUsers = userList.Find(x => x.Username.Contains(enteredUsername));
            existingPassword = userList.Find(x => x.Password.Contains(enteredPassword));
            role = userList.Find(x => x.Role.Equals(existingUsers.Role));
 

            if (existingUsers.Username != enteredUsername || existingUsers.Password != enteredPassword)
            {
                Console.WriteLine("wrong username or password, try again");
                Login();
            }
            else
            {
                if (role.Role == 1)
                {
                    StundetMenu.Run();
                }
                else if (role.Role == 2)
                {
                    TeacherMenu.Run();
                }
                else if (role.Role == 3)
                {
                    AdminMenu.Run();
                }
            }
            
        }
        internal static void CreateAccount()
        {
            string userName = null;
            string passWord = null;
            string firstName = null;
            string lastName = null;
            int role = 0;
            

            Console.WriteLine("Please Enter your Username");
            userName = Console.ReadLine();
            Console.WriteLine("Please Enter your Password");
            passWord = Console.ReadLine();
            Console.WriteLine("Please enter your firstname");
            firstName = Console.ReadLine();
            Console.WriteLine("Please enter your lastname");
            lastName = Console.ReadLine();

            Console.WriteLine("What role do you got?");
            Console.WriteLine("1 for student: \n2 for Teacher:\n3 for Admin");
            role = int.Parse(Console.ReadLine());
            if (role == 1)
            {
                Console.WriteLine("Your account is submitted as student");
            }
            else if (role == 2)
            {
                Console.WriteLine("Your account is submitted as teacher");
            }
            else if (role == 3)
            {
                Console.WriteLine("Your account is submitted as admin");
            }
            else
            {
                Console.WriteLine("you choose a role that did not exist, please try again");
                Console.ReadKey();
                Console.Clear();
                Run();
            }  
            userList.Add(new LoginUsers(userName, passWord, firstName, lastName, role));
            Console.WriteLine("New user added");
            Console.WriteLine("Press key to continue");
            Console.ReadKey();
            Console.Clear();
            Run();

        }
        
    }
}
