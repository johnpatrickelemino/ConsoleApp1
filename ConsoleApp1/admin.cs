using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;
using Mysqlx.Session;
using Colorful;
using Console = Colorful.Console;

namespace ConsoleApp1
{
    class admin
    {
        static bool Islogin = false; // falase kasi wala palogin eh  sorry na bobo lang
        public static void Adminpage()
        {
            while (true)
            {
                Console.Clear();
                Console.SetCursorPosition(0, 0);
                Console.WriteLine(@"
                          ████████████████████████████████████████████████████████████████████████████████████████████████████████
                          █▌                                                                                                    ▐█
                          █▌        ██╗    ██╗███████╗██╗      ██████╗ ██████╗ ███╗   ███╗███████╗    ████████╗ ██████╗         ▐█
                          █▌        ██║    ██║██╔════╝██║     ██╔════╝██╔═══██╗████╗ ████║██╔════╝    ╚══██╔══╝██╔═══██╗        ▐█
                          █▌        ██║ █╗ ██║█████╗  ██║     ██║     ██║   ██║██╔████╔██║█████╗         ██║   ██║   ██║        ▐█
                          █▌        ██║███╗██║██╔══╝  ██║     ██║     ██║   ██║██║╚██╔╝██║██╔══╝         ██║   ██║   ██║        ▐█
                          █▌        ╚███╔███╔╝███████╗███████╗╚██████╗╚██████╔╝██║ ╚═╝ ██║███████╗       ██║   ╚██████╔╝        ▐█
                          █▌         ╚══╝╚══╝ ╚══════╝╚══════╝ ╚═════╝ ╚═════╝ ╚═╝     ╚═╝╚══════╝       ╚═╝    ╚═════╝         ▐█
                          █▌                                                                                                    ▐█
                          █▌                    ██╗  ██╗██████╗      █████╗ ██████╗ ███╗   ███╗██╗███╗   ██╗                    ▐█
                          █▌                    ██║  ██║██╔══██╗    ██╔══██╗██╔══██╗████╗ ████║██║████╗  ██║                    ▐█
                          █▌                    ███████║██████╔╝    ███████║██║  ██║██╔████╔██║██║██╔██╗ ██║                    ▐█
                          █▌                    ██╔══██║██╔══██╗    ██╔══██║██║  ██║██║╚██╔╝██║██║██║╚██╗██║                    ▐█
                          █▌                    ██║  ██║██║  ██║    ██║  ██║██████╔╝██║ ╚═╝ ██║██║██║ ╚████║                    ▐█
                          █▌                    ╚═╝  ╚═╝╚═╝  ╚═╝    ╚═╝  ╚═╝╚═════╝ ╚═╝     ╚═╝╚═╝╚═╝  ╚═══╝                    ▐█
                          █▌                                                                                                    ▐█
                          ████████████████████████████████████████████████████████████████████████████████████████████████████████", Color.Violet);

                Console.WriteLine(@"                                                   
                                                                         1. Login

                                                                         2. Register", Color.Blue);

                if (Islogin)
                {
                    Console.WriteLine(@"
                                                                         3. Logout", Color.Blue);
                }

                Console.WriteLine(@"
                                                                         4. Exit", Color.Blue);

                Console.WriteLine("Enter your choice: ");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Login();
                        break;
                    case 2:
                        Register();
                        break;
                    case 3:
                        if (Islogin)
                        {
                            Logout();
                        }
                        else
                        {
                            Console.WriteLine("Invalid choice");
                        }
                        break;
                    case 4:
                        Console.WriteLine(@" 
                                                                          Goodbye!");
                        return;
                    default:
                        Console.WriteLine(@"
                                                                       Invalid choice");
                        break;
                }
            }
        }

        public static void Login()
        {
            if (!Islogin)
            {
                Connection conn = new Connection();
                Console.Clear();
                Console.WriteLine(@"
                                                      ▐▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▌
                                                      ▐                                           ▌
                                                      ▐  ██╗      ██████╗  ██████╗ ██╗███╗   ██╗  ▌
                                                      ▐  ██║     ██╔═══██╗██╔════╝ ██║████╗  ██║  ▌
                                                      ▐  ██║     ██║   ██║██║  ███╗██║██╔██╗ ██║  ▌
                                                      ▐  ██║     ██║   ██║██║   ██║██║██║╚██╗██║  ▌
                                                      ▐  ███████╗╚██████╔╝╚██████╔╝██║██║ ╚████║  ▌
                                                      ▐  ╚══════╝ ╚═════╝  ╚═════╝ ╚═╝╚═╝  ╚═══╝  ▌
                                                      ▐                                           ▌
                                                      ▐▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▌", Color.Purple);
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
                Console.WriteLine("You are already logged in");
            }
        }

        public static void Register()
        {
            if (!Islogin)
            {
                Console.Clear();
                Console.WriteLine(@"
                                             ▐▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▌
                                             ▐                                                                 ▌
                                             ▐  ██████╗ ███████╗ ██████╗ ██╗███████╗████████╗███████╗██████╗   ▌
                                             ▐  ██╔══██╗██╔════╝██╔════╝ ██║██╔════╝╚══██╔══╝██╔════╝██╔══██╗  ▌
                                             ▐  ██████╔╝█████╗  ██║  ███╗██║███████╗   ██║   █████╗  ██████╔╝  ▌
                                             ▐  ██╔══██╗██╔══╝  ██║   ██║██║╚════██║   ██║   ██╔══╝  ██╔══██╗  ▌
                                             ▐  ██║  ██║███████╗╚██████╔╝██║███████║   ██║   ███████╗██║  ██║  ▌
                                             ▐  ╚═╝  ╚═╝╚══════╝ ╚═════╝ ╚═╝╚══════╝   ╚═╝   ╚══════╝╚═╝  ╚═╝  ▌
                                             ▐                                                                 ▌
                                             ▐▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▌", Color.YellowGreen);
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
                    Adminpage();
                }
            }
            else
            {
                Console.WriteLine("You are already logged in");
                return;
            }
        }

        public static void Logout()
        {
            if (Islogin)
            {
                Console.Clear();
                Console.WriteLine(@"
                                         _      _      _      _      _      _      _      _      _      _      _   
                                       _( )_  _( )_  _( )_  _( )_  _( )_  _( )_  _( )_  _( )_  _( )_  _( )_  _( )_ 
                                      (_ o _)(_ o _)(_ o _)(_ o _)(_ o _)(_ o _)(_ o _)(_ o _)(_ o _)(_ o _)(_ o _)
                                       (_,_)  (_,_)  (_,_)  (_,_)  (_,_)  (_,_)  (_,_)  (_,_)  (_,_)  (_,_)  (_,_) 
                                         _                                                                     _   
                                       _( )_                                                                 _( )_ 
                                      (_ o _)                                                               (_ o _)
                                       (_,_)      ██╗      ██████╗  ██████╗  ██████╗ ██╗   ██╗████████╗      (_,_) 
                                         _        ██║     ██╔═══██╗██╔════╝ ██╔═══██╗██║   ██║╚══██╔══╝        _   
                                       _( )_      ██║     ██║   ██║██║  ███╗██║   ██║██║   ██║   ██║         _( )_ 
                                      (_ o _)     ██║     ██║   ██║██║   ██║██║   ██║██║   ██║   ██║        (_ o _)
                                       (_,_)      ███████╗╚██████╔╝╚██████╔╝╚██████╔╝╚██████╔╝   ██║         (_,_) 
                                         _        ╚══════╝ ╚═════╝  ╚═════╝  ╚═════╝  ╚═════╝    ╚═╝           _   
                                       _( )_                                                                 _( )_ 
                                      (_ o _)                                                               (_ o _)
                                       (_,_)                                                                 (_,_) 
                                         _      _      _      _      _      _      _      _      _      _      _   
                                       _( )_  _( )_  _( )_  _( )_  _( )_  _( )_  _( )_  _( )_  _( )_  _( )_  _( )_ 
                                      (_ o _)(_ o _)(_ o _)(_ o _)(_ o _)(_ o _)(_ o _)(_ o _)(_ o _)(_ o _)(_ o _)
                                       (_,_)  (_,_)  (_,_)  (_,_)  (_,_)  (_,_)  (_,_)  (_,_)  (_,_)  (_,_)  (_,_) ", Color.Aqua);
                Islogin = false;
                Console.WriteLine(@"
                                                                      Logging out...");
                Thread.Sleep(2000);
                Console.WriteLine(@"
                                                               You have been logged out!");
                Console.WriteLine("Enter any key to return to the menu");
                Console.ReadKey();
                Adminpage();
            }
            else
            {
                Console.WriteLine("You are not logged in");
                Adminpage();
            }
        }
    }
}
