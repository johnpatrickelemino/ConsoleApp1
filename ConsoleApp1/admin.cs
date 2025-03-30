using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace ConsoleApp1
{
    class admin
    {
        static bool Islogin = false; // falase kasi wala palogin eh  sorry na bobo lang
        public static void Adminpage()
        {
            Console.Clear();
            Console.WriteLine(@"Welcome to HR Admin
                             1. Login
                             2. Register
                             3. exit");
            Console.WriteLine("Enter your choice: ");
            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    Login(); 
                    break;
                case 2:
                    Register(); // mali kasi diskaarte mo dapat kung ano nakita mo doon sa may dropdown yung lang may ct ka sa pag cod  like ganto 
                    break;
                case 3:
                    Console.WriteLine("Goodbye");
                    return;
                default:
                    Console.WriteLine("Invalid choice");
                    break;
            } // after yan nag message ako here sa anydesk basahin mo na lang 

        }
        public static void Login()
        {
            
            
            Console.Clear();
            




            if (!Islogin)
            {
                Connection conn = new Connection();

                Console.WriteLine("Enter Email: ");
                string email = Console.ReadLine();
                Console.WriteLine("Enter Password: "); 
                string password = Console.ReadLine();
                
               

                if (conn.ValidateLogin(email, password)) 
                {
                    Console.WriteLine("Congrats");
                    Islogin = true;
                    ConsoleApp1.adminpanel.choice();
                }
                else
                {
                    Console.WriteLine("Invalid Username and Password");
                }

               
                
      
            }
            else
            {
                Console.WriteLine("you already logged in");
            }

        }
        public static void Register()
        {
         
            if (!Islogin)
            {
                Console.WriteLine("register ");
                Console.WriteLine("Enter Email: ");
                string email = Console.ReadLine();
                Console.WriteLine("Enter Password: ");
                string password = Console.ReadLine();
               

                Connection conn = new Connection();

                if (conn.UserExists(email))
                {
                    Console.WriteLine("Email is already Exist");
                }
                else
                {
                    conn.Register(email, password);
                    Console.WriteLine("Enter any key to return in menu");
                    Console.ReadKey();
                    ConsoleApp1.Home.Homepage();
                }
                
            }
            else
            {
                Console.WriteLine("you already logged in");
            }

        }


    }
}
