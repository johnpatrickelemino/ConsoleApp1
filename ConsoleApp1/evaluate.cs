using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Evaluate
    {
        public static void CandidateEvaluation()
        {
            Console.Clear();
            Console.WriteLine("Enter Applicant ID: ");
            int applicantId = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Evaluation Report: ");
            string evaluationReport = Console.ReadLine();

            Connection conn = new Connection();
            conn.EvaluateCandidate(applicantId, evaluationReport);

            // Get the applicant's email
            string applicantEmail = conn.GetEmail(applicantId);

            // Send the evaluation report via email
            email.SendEvaluationReport(applicantEmail, evaluationReport); //POTA HELP AHUDHUDHASHISJCAOSJ

            Console.WriteLine("Evaluation report added and email sent successfully!");
        }
    }
}


