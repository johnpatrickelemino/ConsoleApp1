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
                    (_____)                                                                                                       (_____)", Color.Yellow);
            
            
            Console.WriteLine("\nenter applicant's name: ", Color.Blue);
            string name = Console.ReadLine();
            Console.WriteLine("enter applicant's bday yy-mm-dd : ", Color.Blue);
            string bday = Console.ReadLine();
            Console.WriteLine("enter address: ", Color.Blue);
            string address = Console.ReadLine();
            Console.WriteLine("enter contactno : ", Color.Blue);
            int contactno = int.Parse(Console.ReadLine());
            Console.WriteLine("enter gmail: ", Color.Blue);
            string gmail = Console.ReadLine();
            Console.WriteLine("enter civilstatus: ", Color.Blue);
            string civilstatus = Console.ReadLine();
            Console.WriteLine("enter resume: ", Color.Blue);
            string resume = Console.ReadLine();
                
            conn.RegisterApplicant(name, bday, address, contactno, gmail, civilstatus, resume);
            

        }
    }
}