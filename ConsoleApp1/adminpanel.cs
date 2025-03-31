using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class adminpanel
    {
        public static void choice()
        {
            Console.WriteLine(@"enter choices: 
                                1. interview schedule
                                2. addjobposting");
            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    adminpanel.Sched();
                    break;
                case 2:
                    ConsoleApp1.jobposting.AddJobposting();
                    break;
                default:
                    Console.WriteLine("Invalid!");
                    break;
            }//okay 


        }
        public static void Sched()
        {
            ConsoleApp1.Connection.all();
            Console.WriteLine("Enter applicant's id:");
            int applicantid = int.Parse(Console.ReadLine());
            Console.WriteLine("enter interview schedule yyyy-mm-dd 00:00: ");
            string sched = Console.ReadLine();
            Connection conn = new Connection();
            conn.Sched(applicantid, sched);
            
            ConsoleApp1.email.SendEmail(conn.GetEmail(applicantid), sched);

        }
    }
}
