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
                    Console.WriteLine("invalid");
                    break;
            }//okay 


        }
        public static void Sched()
        { 
            Console.WriteLine("enter applicant's id:"); // tulog na tayo // or gawin mo db mg addd posting at yung sa schedule ng applicant.... antok na me maaga pa bukasmaana me byeby punta kayo diba? si rommel bukas ulit HAHAHAH thankyou so much sa help wc <3
            int applicantid = int.Parse(Console.ReadLine());
            Console.WriteLine("enter interview schedule: ");
            int sched = int.Parse(Console.ReadLine());
            Console.WriteLine("applicant's interview" + sched);
        }

       
        
        // gawa ng switchcasee ng mag add sya ng add jobposting tapos mag sched din mga applicant
    }
}
