using System;
namespace ConsoleApp1
{
    class jobposting
    {
        public static void AddJobposting()
        {
            Console.WriteLine("Job Posting");
            List<string> jobtitle = new List<string>() { "manager", "supervisor", "staff" };
            List<string> jobdescription = new List<string>() { "manager", "supervisor", "staff" };
            for (int i = 0; i < jobtitle.Count; i++)
                Console.WriteLine(jobtitle[i]);
            Console.WriteLine("enter job title: ");
            string title = Console.ReadLine();
            Console.WriteLine("enter job description: ");
            string description = Console.ReadLine();
            Console.WriteLine($"job title: {title}\njob description: {description}");
            Connection conn = new Connection();
           conn.addjobposting(title, description);
        }
    }  /// ahh  AHHAHAHHA 
}
