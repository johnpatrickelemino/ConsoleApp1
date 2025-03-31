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
    class adminpanel
    {
        public static void choice()
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
                                                                        Enter choices: 

                                                                    1. Interview schedule
                                                                    2. Add job posting
                                                                    3. Evaluate candidate", Color.YellowGreen);
            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    adminpanel.Sched();
                    break;
                case 2:
                    ConsoleApp1.jobposting.AddJobposting();
                    break;
                case 3:
                    Evaluate();
                    break;
                default:
                    Console.WriteLine("Invalid!");
                    break;
            }

        }

        public static void Sched()
        {
            ConsoleApp1.Connection.All();
            Console.WriteLine("Enter applicant's id:");
            int applicantid = int.Parse(Console.ReadLine());
            Console.WriteLine("enter interview schedule yyyy-mm-dd 00:00: ");
            string sched = Console.ReadLine();
            Connection conn = new Connection();
            conn.Sched(applicantid, sched);
            Console.WriteLine("Interview scheduled successfully!");

            ConsoleApp1.email.SendEmail(conn.GetEmail(applicantid), sched);
        }
        public static void Evaluate()
        {
            ConsoleApp1.Connection.All();
            Console.WriteLine("Enter applicant's id:");
            int applicantid = int.Parse(Console.ReadLine());
            Console.WriteLine("enter Evaluation Report: ");
            string evaluation = Console.ReadLine();
            Connection conn = new Connection();
            conn.EvaluateCandidate(applicantid, evaluation);
            Console.WriteLine("Evaluation successfully!");

            ConsoleApp1.email.SendEvaluationReport(conn.GetEmail(applicantid), evaluation);
        }

       
    }
}


