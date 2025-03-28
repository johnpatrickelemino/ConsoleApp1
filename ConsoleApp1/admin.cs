using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class admin
    {
        static bool Islogin = false; // falase kasi wala palogin eh  sorry na bobo lang
        public static void Adminpage()
        { 
            Console.WriteLine(@"Welcome to HR Admin
                             1. Login
                             2. Register
                             3. exit");
            Console.WriteLine("Enter your choice: ");
            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    Login(); // ito kasi iba pa nakalagay BWAHAHHAA // ayan na ako tawag sa job posting 
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
            //pagawa ng register at login apara sa hr sige wait 
            // dapat sa loob toh tanga
            if (!Islogin)
            {
                //pagawa ng register at login apara sa hr sige wait 
                Console.WriteLine("enter username: ");
                string username = Console.ReadLine();
                Console.WriteLine("enter password: "); // puro daldal sa gc e eto naaa HAHahahah ang lt kase eh
                string password = Console.ReadLine();// gawin muna ulit sigeee
                
                Connection conn = new Connection();

                if (conn.ValidateLogin(username, password)) 
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
            //pagawa ng register at login apara sa hr sige wait 
            // dapat sa loob toh tanga
            if (!Islogin)
            {
                Console.WriteLine("register ");
                Console.WriteLine("enter username: ");
                string username = Console.ReadLine();
                Console.WriteLine("enter password: "); // puro daldal sa gc e eto naaa HAHahahah ang lt kase eh
                string password = Console.ReadLine();// gawin muna ulit sigeee
                //islogin padin ba? ikaw ba bahala ikaw mag debug mamaya ge pausukin na naten utak ko HAHAHAh 
                // feel ko tama to pakilag yan na rin ng database ito 

                Connection conn = new Connection();

                if (conn.UserExists(username))
                {
                    Console.WriteLine("username is already Exist");
                }
                else
                {
                    conn.RegisterHR(username, password);
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
