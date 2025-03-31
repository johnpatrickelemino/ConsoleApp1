using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Colorful;
using Console = Colorful.Console;

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
                                     █████████████████████████████████████████████████████████████████████████████████", Color.Red);

                                      Console.WriteLine(@"
                                                                    1. View Job Posting", Color.Salmon); 
                                      Console.WriteLine(@"
                                                                    2. Apply for Job", Color.Salmon); 
                                      Console.WriteLine(@"
                                                                    3. HR ADMIN", Color.Salmon);
                                      Console.WriteLine(@"
                                                                    4. Candidate Evaluation", Color.Salmon);
                                      Console.WriteLine(@"
                                                                    5. Exit", Color.Salmon);

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
                        ConsoleApp1.evaluation.CandidateEvaluation();
                        break;
                    case 5:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine(@"
                                                                    Invalid choice!");
                        break;
                }
                Console.WriteLine("Press any key to go back to main menu.");
                Console.ReadKey();
                Console.Clear();
            }
          
        }
        
    }
}
