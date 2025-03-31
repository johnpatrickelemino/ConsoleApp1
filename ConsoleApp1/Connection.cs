using MySql.Data.MySqlClient;
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
    class Connection
    {
        public string connectionString;

        public Connection()
        {
            string server = "localhost";
            string database = "ConsoleApp1";
            string uid = "root";
            string password = "";
            connectionString = $"SERVER={server};DATABASE={database};UID={uid};PASSWORD={password};";
        }

        public void ViewJobPostings()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT `id`, `jobtitle`, `jobdescription` FROM addjobposting";
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            Console.Clear();
                            Console.WriteLine(@"
                          __| |_________________________________________________________________________________________________| |__
                          __   _________________________________________________________________________________________________   __
                            | |                                                                                                 | |  
                            | |                                                                                                 | |  
                            | |       ██╗ ██████╗ ██████╗     ██████╗  ██████╗ ███████╗████████╗██╗███╗   ██╗ ██████╗ ███████╗  | |  
                            | |       ██║██╔═══██╗██╔══██╗    ██╔══██╗██╔═══██╗██╔════╝╚══██╔══╝██║████╗  ██║██╔════╝ ██╔════╝  | |  
                            | |       ██║██║   ██║██████╔╝    ██████╔╝██║   ██║███████╗   ██║   ██║██╔██╗ ██║██║  ███╗███████╗  | |  
                            | |  ██   ██║██║   ██║██╔══██╗    ██╔═══╝ ██║   ██║╚════██║   ██║   ██║██║╚██╗██║██║   ██║╚════██║  | |  
                            | |  ╚█████╔╝╚██████╔╝██████╔╝    ██║     ╚██████╔╝███████║   ██║   ██║██║ ╚████║╚██████╔╝███████║  | |  
                            | |   ╚════╝  ╚═════╝ ╚═════╝     ╚═╝      ╚═════╝ ╚══════╝   ╚═╝   ╚═╝╚═╝  ╚═══╝ ╚═════╝ ╚══════╝  | |  
                            | |                                                                                                 | |  
                          __| |_________________________________________________________________________________________________| |__
                          __   _________________________________________________________________________________________________   __
                            | |                                                                                                 | |  ", Color.Red);
                            while (reader.Read())
                            {
                                Console.WriteLine(@$"             
                                                                  Job ID: {reader["id"]}", Color.YellowGreen);
                                Console.WriteLine(@$"             
                                                                  Job Title: {reader["jobtitle"]}", Color.YellowGreen);
                                Console.WriteLine(@$"             
                                                                  Description: {reader["jobdescription"]}", Color.YellowGreen);
                                Console.WriteLine(@"
                                                                  -------------------------------");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        public void RegisterApplicant(string name, string bday, string address, int contactno, string gmail, string civilstatus, string resume)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO jobapplication (name, bday, address, contactno, gmail, civilstatus, resume) VALUES (@name, @bday, @address, @contactno, @gmail, @civilstatus, @resume)";
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@name", name);
                        cmd.Parameters.AddWithValue("@bday", bday);
                        cmd.Parameters.AddWithValue("@address", address);
                        cmd.Parameters.AddWithValue("@contactno", contactno);
                        cmd.Parameters.AddWithValue("@gmail", gmail);
                        cmd.Parameters.AddWithValue("@civilstatus", civilstatus);
                        cmd.Parameters.AddWithValue("@resume", resume);

                        cmd.ExecuteNonQuery();
                    }
                }
                Console.WriteLine("Data inserted successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        public bool ValidateLogin(string email, string userPassword)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT COUNT(*) FROM users WHERE email = @email AND password = @password";
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@email", email);
                        cmd.Parameters.AddWithValue("@password", userPassword);
                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }

        public bool UserExists(string email)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT COUNT(*) FROM users WHERE email = @email";
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@email", email);
                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }

       

        public void RegisterHR(string admin, string adminPassword)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO HRadmin (username, password) VALUES (@username, @password)";
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@username", admin);
                        cmd.Parameters.AddWithValue("@password", adminPassword);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        public bool LoginHR(string admin, string adminPassword)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT COUNT(*) FROM users WHERE email = @email AND password = @password";
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@email", admin);
                        cmd.Parameters.AddWithValue("@password", adminPassword);
                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }

        public bool Sched(int id, string schedule)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT gmail FROM jobapplication WHERE id = @id";
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        object result = cmd.ExecuteScalar();

                        if (result != null)
                        {
                            string email = result.ToString();
                            string insertQuery = "INSERT INTO job_schedule (email, Schedule) VALUES (@email, @schedule)";
                            using (MySqlCommand insertCmd = new MySqlCommand(insertQuery, connection))
                            {
                                insertCmd.Parameters.AddWithValue("@email", email);
                                insertCmd.Parameters.AddWithValue("@schedule", schedule);
                                insertCmd.ExecuteNonQuery();
                            }
                        }
                        else
                        {
                            Console.WriteLine("No job application found with this ID.");
                        }
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }

        public string GetEmail(int id)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT gmail FROM jobapplication WHERE id = @id";
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        object result = cmd.ExecuteScalar();
                        return result != null ? result.ToString() : null;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return null;
            }
        }

        public void Register(string email, string password)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO users (email, password) VALUES (@email, @password)";
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@email", email);
                        cmd.Parameters.AddWithValue("@password", password);
                        cmd.ExecuteNonQuery();
                    }
                }
                Console.WriteLine("Info inserted successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        public void AddJobPosting(string jobtitle, string jobdescription)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO AddJobposting (jobtitle, jobdescription) VALUES (@jobtitle, @jobdescription)";
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@jobtitle", jobtitle);
                        cmd.Parameters.AddWithValue("@jobdescription", jobdescription);

                        cmd.ExecuteNonQuery();
                    }
                }
                Console.WriteLine("Data inserted successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        public bool ValidateJobid(int id)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT COUNT(*) FROM addjobposting WHERE id = @id";
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }

        public static void All()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection("SERVER=localhost;DATABASE=ConsoleApp1;UID=root;PASSWORD=;"))
                {
                    connection.Open();

                    string query = "SELECT * FROM jobapplication WHERE 1";

                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    int id = reader.GetInt32(0);
                                    string name = reader.GetString(1);
                                    DateTime bday = reader.GetDateTime(2);
                                    string address = reader.GetString(3);
                                    int contactno = reader.GetInt32(4);
                                    string gmail = reader.GetString(5);
                                    string civilstatus = reader.GetString(6);
                                    string resume = reader.GetString(7);

                                    Console.WriteLine($"ID: {id}", Color.Blue);
                                    Console.WriteLine($"Name: {name}", Color.Blue);
                                    Console.WriteLine($"Birthday: {bday.ToString("yyyy-MM-dd")}", Color.Blue);
                                    Console.WriteLine($"Address: {address}", Color.Blue);
                                    Console.WriteLine($"Contact No: {contactno}");
                                    Console.WriteLine($"Gmail: {gmail}");
                                    Console.WriteLine($"Civil Status: {civilstatus}", Color.Blue);
                                    Console.WriteLine($"Resume: {resume}", Color.Blue);
                                    Console.WriteLine("----------------------------");
                                }
                            }
                            else
                            {
                                Console.WriteLine(@"No data found.");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        public void EvaluateCandidate(int id, string evaluationReport)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO candidate_evaluation (id, evaluationReport) VALUES (@id, @evaluationReport)";

                    // Debugging: print the query before executing
                 

                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        // Debugging: Check if parameters are correct
                      

                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.Parameters.AddWithValue("@evaluationReport", evaluationReport);

                        cmd.ExecuteNonQuery();
                    }
                }
                Console.WriteLine("Evaluation report added successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        public void ViewCandidateEvaluation()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = @"
                        SELECT ja.name, ce.evaluationReport
                        FROM candidate_evaluation ce
                        JOIN jobapplication ja ON ce.id = ja.id";
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            Console.Clear();
                            Console.WriteLine(@"
                              █████████████████████████████████████████████████████████████████████████████████████████████████
                              █▌                                                                                             ▐█
                              █▌                                                                                             ▐█
                              █▌           ██████╗ █████╗ ███╗   ██╗██████╗ ██╗██████╗  █████╗ ████████╗███████╗             ▐█
                              █▌          ██╔════╝██╔══██╗████╗  ██║██╔══██╗██║██╔══██╗██╔══██╗╚══██╔══╝██╔════╝             ▐█
                              █▌          ██║     ███████║██╔██╗ ██║██║  ██║██║██║  ██║███████║   ██║   █████╗               ▐█
                              █▌          ██║     ██╔══██║██║╚██╗██║██║  ██║██║██║  ██║██╔══██║   ██║   ██╔══╝               ▐█
                              █▌          ╚██████╗██║  ██║██║ ╚████║██████╔╝██║██████╔╝██║  ██║   ██║   ███████╗             ▐█
                              █▌           ╚═════╝╚═╝  ╚═╝╚═╝  ╚═══╝╚═════╝ ╚═╝╚═════╝ ╚═╝  ╚═╝   ╚═╝   ╚══════╝             ▐█
                              █▌                                                                                             ▐█
                              █▌  ███████╗██╗   ██╗ █████╗ ██╗     ██╗   ██╗ █████╗ ████████╗██╗ ██████╗ ███╗   ██╗███████╗  ▐█
                              █▌  ██╔════╝██║   ██║██╔══██╗██║     ██║   ██║██╔══██╗╚══██╔══╝██║██╔═══██╗████╗  ██║██╔════╝  ▐█
                              █▌  █████╗  ██║   ██║███████║██║     ██║   ██║███████║   ██║   ██║██║   ██║██╔██╗ ██║███████╗  ▐█
                              █▌  ██╔══╝  ╚██╗ ██╔╝██╔══██║██║     ██║   ██║██╔══██║   ██║   ██║██║   ██║██║╚██╗██║╚════██║  ▐█
                              █▌  ███████╗ ╚████╔╝ ██║  ██║███████╗╚██████╔╝██║  ██║   ██║   ██║╚██████╔╝██║ ╚████║███████║  ▐█
                              █▌  ╚══════╝  ╚═══╝  ╚═╝  ╚═╝╚══════╝ ╚═════╝ ╚═╝  ╚═╝   ╚═╝   ╚═╝ ╚═════╝ ╚═╝  ╚═══╝╚══════╝  ▐█
                              █▌                                                                                             ▐█
                              █▌                                                                                             ▐█
                              █████████████████████████████████████████████████████████████████████████████████████████████████", Color.Red);
                            
                            while (reader.Read())
                            {
                                Console.WriteLine(@"
                                                                ----------------------------");
                                Console.WriteLine(@$"
                                                                 Applicant Name: {reader["name"]}");
                                Console.WriteLine(@$"
                                                                 Evaluation Report: {reader["evaluationReport"]}");
                                Console.WriteLine(@"            
                                                                ----------------------------");
                            }
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

    }
}
