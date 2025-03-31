using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class main
    {

        public static void jobapplication()
        {
            Console.Clear();
            Connection conn = new Connection();
            Console.WriteLine(@"
                     _____                                                                                                         _____ 
                    ( ___ )                                                                                                       ( ___ )
                     |   |~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~|   | 
                     |   |                                                                                                         |   | 
                     |   |    █████╗ ██████╗ ██████╗ ██╗     ██╗   ██╗    ███████╗ ██████╗ ██████╗          ██╗ ██████╗ ██████╗    |   | 
                     |   |   ██╔══██╗██╔══██╗██╔══██╗██║     ╚██╗ ██╔╝    ██╔════╝██╔═══██╗██╔══██╗         ██║██╔═══██╗██╔══██╗   |   | 
                     |   |   ███████║██████╔╝██████╔╝██║      ╚████╔╝     █████╗  ██║   ██║██████╔╝         ██║██║   ██║██████╔╝   |   | 
                     |   |   ██╔══██║██╔═══╝ ██╔═══╝ ██║       ╚██╔╝      ██╔══╝  ██║   ██║██╔══██╗    ██   ██║██║   ██║██╔══██╗   |   | 
                     |   |   ██║  ██║██║     ██║     ███████╗   ██║       ██║     ╚██████╔╝██║  ██║    ╚█████╔╝╚██████╔╝██████╔╝   |   | 
                     |   |   ╚═╝  ╚═╝╚═╝     ╚═╝     ╚══════╝   ╚═╝       ╚═╝      ╚═════╝ ╚═╝  ╚═╝     ╚════╝  ╚═════╝ ╚═════╝    |   | 
                     |   |                                                                                                         |   | 
                     |___|~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~|___| 
                    (_____)                                                                                                       (_____)");
            Console.WriteLine("\nenter applicant's name: ");
            string name = Console.ReadLine();
            Console.WriteLine("enter applicant's bday yy-mm-dd : ");
            string bday = Console.ReadLine();
            Console.WriteLine("enter address: ");
            string address = Console.ReadLine();
            Console.WriteLine("enter contactno : ");
            int contactno = int.Parse(Console.ReadLine());
            Console.WriteLine("enter gmail: ");
            string gmail = Console.ReadLine();
            Console.WriteLine("enter civilstatus: ");
            string civilstatus = Console.ReadLine();
            Console.WriteLine("enter resume: ");
            string resume = Console.ReadLine();
                
            conn.registerApplicant(name, bday, address, contactno, gmail, civilstatus, resume);
            

        }
    }
}