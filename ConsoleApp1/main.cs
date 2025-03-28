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
            List<string> jobtitle = new List<string>() { "manager", "supervisor", "staff" };
            List<string> applicant = new List<string>() { "name", "resume", "documents" };
            for (int i = 0; i < jobtitle.Count; i++)
                Console.WriteLine(jobtitle[i]);
            Console.WriteLine("Enter Job Id:");
            int idko = int.Parse(Console.ReadLine());
            Connection conn = new Connection();
            if (conn.ValidateJobid(idko)){
                Console.WriteLine("enter applicant's name: ");
                string name = Console.ReadLine();
                Console.WriteLine("enter applicant's bday yy-mm-dd: ");
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
            else
            {
                Console.WriteLine("ayoko na po");
            }
        }
    }
}