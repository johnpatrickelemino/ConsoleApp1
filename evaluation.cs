using System;
using namespace ConsoleApp1;

{
    class evaluate;
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

            Console.WriteLine("Evaluation report added successfully!");
        }
    }
}
