using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Home
    {
        public static void Homepage()
        {
            while (true)
            {
                Console.Clear();
                Console.SetCursorPosition(0, 0);
                Console.WriteLine(@"
                                     █████████████████████████████████████████████████████████████████████████████████
                                     █▌                                                                             ▐█
                                     █▌                                                                             ▐█
                                     █▌                                                                             ▐█
                                     █▌  ██╗  ██╗██████╗     ███████╗██╗   ██╗███████╗████████╗███████╗███╗   ███╗  ▐█
                                     █▌  ██║  ██║██╔══██╗    ██╔════╝╚██╗ ██╔╝██╔════╝╚══██╔══╝██╔════╝████╗ ████║  ▐█
                                     █▌  ███████║██████╔╝    ███████╗ ╚████╔╝ ███████╗   ██║   █████╗  ██╔████╔██║  ▐█
                                     █▌  ██╔══██║██╔══██╗    ╚════██║  ╚██╔╝  ╚════██║   ██║   ██╔══╝  ██║╚██╔╝██║  ▐█
                                     █▌  ██║  ██║██║  ██║    ███████║   ██║   ███████║   ██║   ███████╗██║ ╚═╝ ██║  ▐█
                                     █▌  ╚═╝  ╚═╝╚═╝  ╚═╝    ╚══════╝   ╚═╝   ╚══════╝   ╚═╝   ╚══════╝╚═╝     ╚═╝  ▐█
                                     █▌                                                                             ▐█
                                     █▌                                                                             ▐█
                                     █▌                                                                             ▐█
                                     █████████████████████████████████████████████████████████████████████████████████");

                                      Console.WriteLine(@"
                                                                    1. View Job Posting"); 
                                      Console.WriteLine(@"
                                                                    2. Apply for Job"); 
                                      Console.WriteLine(@"
                                                                    3. HR ADMIN");
                                      Console.WriteLine(@"          
                                                                    4. Exit");
                
                Console.WriteLine("Enter your choice: ");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        ConsoleApp1.view.ViewJobPostings(); 
                        break;
                    case 2:
                        ConsoleApp1.main.jobapplication(); 
                        break;
                        break;
                    case 3:
                        ConsoleApp1.admin.Adminpage();
                        break;
                    case 4:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
                Console.WriteLine("presss any key to go back to main menu");
                Console.ReadKey();
                Console.Clear();
            }
          
        }
        
    }
}
