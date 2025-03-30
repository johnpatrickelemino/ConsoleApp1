using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class email
    {
        public static void SendEmail(string email, string interviewSchedule)
        {
            try
            {

                string senderEmail = "manggaykimcamille@gmail.com";
                string senderPassword = "fnyg odjq snla bpby";

                SmtpClient client = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential(senderEmail, senderPassword),
                    EnableSsl = true
                };


                string htmlBody = @$"
                    <html>
                        <head>
                            <style>
                                body {{
                                    font-family: Arial, sans-serif;
                                    background-color: #f4f4f4;
                                    margin: 0;
                                    padding: 20px;
                                }}
                                .email-container {{
                                    background-color: #ffffff;
                                    padding: 20px;
                                    border-radius: 8px;
                                    border: 1px solid #ddd;
                                    width: 100%;
                                    max-width: 600px;
                                    margin: 0 auto;
                                }}
                                h2 {{
                                    color: #333;
                                    text-align: center;
                                }}
                                .content {{
                                    font-size: 16px;
                                    line-height: 1.5;
                                    color: #555;
                                }}
                                .footer {{
                                    font-size: 12px;
                                    color: #888;
                                    text-align: center;
                                    margin-top: 20px;
                                }}
                            </style>
                        </head>
                        <body>
                            <div class='email-container'>
                                <h2>Interview Scheduled</h2>
                                <p class='content'>Dear Applicant,</p>
                                <p class='content'>Your interview has been scheduled for <strong>{interviewSchedule}</strong>.</p>
                                <p class='content'>Please make sure to attend on time. We look forward to meeting you!</p>
                                <div class='footer'>
                                    <p>Best regards,</p>
                                    <p>Your Company</p>
                                </div>
                            </div>
                        </body>
                    </html>";
                MailMessage mail = new MailMessage
                {
                    From = new MailAddress(senderEmail),
                    Subject = "HTML Email Test",
                    Body = htmlBody,
                    IsBodyHtml = true
                };

                mail.To.Add(email);


                client.Send(mail);

                Console.WriteLine("HTML Email sent successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);

            }
        }
    }
}
