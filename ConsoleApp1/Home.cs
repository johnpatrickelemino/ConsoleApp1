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
                Console.WriteLine("Welcome");  // need d2 ng design po para maganda ty. kung sino ka man mag design  
                Console.WriteLine("1. View Job Posting"); // asa ito 
                Console.WriteLine("2. Apply for Job"); 
                Console.WriteLine("3. HR ADMIN");
                Console.WriteLine("4. Exit");// ano next?? HAHAHHA 
                Console.WriteLine("Enter your choice: ");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        ConsoleApp1.view.ViewJobPostings(); // iba na toh huh 
                        break;
                    case 2:
                        ConsoleApp1.main.jobapplication(); 
                        break;
                        break;
                    case 3:
                        ConsoleApp1.admin.Adminpage();
                        return;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            }
        }
    }
}
