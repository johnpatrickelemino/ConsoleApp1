using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection.PortableExecutable;
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
        public void registerApplicant(string name, string bday, string address, int contactno, string gmail, string civilstatus,  string resume)

        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString)) // wait pa check ako 
                {
                    connection.Open();
                    string query = "INSERT INTO jobapplication (name, bday, address, contactno, gmail, civilstatus, resume ) VALUES (@name, @bday, @address, @contactno, @gmail, @civilstatus, @resume )";
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
                Console.WriteLine(@"
                                                                Data inserted successfully!");
            }// wala kayong jop posting? job title yung nakapangalan ano? wai ano ulit 
            catch (Exception ex) // parang pwedeng palitan yung contact as resume na agad tas jobpsting as documents s
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        public void EvaluateCandidate(int applicantId, string evaluationReport)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO candidate_evaluation (applicantId, evaluationReport) VALUES (@applicantId, @evaluationReport)";
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@applicantId", applicantId);
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
                        JOIN jobapplication ja ON ce.applicantId = ja.id";
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            Console.WriteLine("Candidate Evaluations:");
                            while (reader.Read())
                            {
                                Console.WriteLine($"Applicant Name: {reader["name"]}");
                                Console.WriteLine($"Evaluation Report: {reader["evaluationReport"]}");
                                Console.WriteLine("----------------------------");
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


        public bool LoginHR(string admin, string adminPassword) //register pero select WBAHAHAHA view ba dapat?0
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

                    // Step 1: Retrieve email based on jobapplication ID
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
                            Console.WriteLine(@"
                                                              No job application found with this ID.");
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
                Console.WriteLine(@"
                                                                Info inserted successfully!"); // ahh sa program ko ilalagay yung Main??

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
        public void addjobposting(string jobtitle, string jobdescription)

        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString)) // wait pa check ako 
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
                Console.WriteLine(@"
                                                                   Data inserted successfully!");
            }// wala kayong jop posting? job title yung nakapangalan ano? wai ano ulit 
            catch (Exception ex) // parang pwedeng palitan yung contact as resume na agad tas jobpsting as documents s
            {
                Console.WriteLine("Error: " + ex.Message);
            }
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

        public static void all()
        {
            try
            {
                // Establish a connection to the database
                using (MySqlConnection connection = new MySqlConnection())
                {
                    connection.Open();

                    // SQL query to select all data from the jobapplication table
                    string query = "SELECT * FROM jobapplication WHERE 1";

                    // Execute the query and fetch the data using MySqlCommand and MySqlDataReader
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            // Check if the reader has rows (data)
                            if (reader.HasRows)
                            {
                                // Read and display the data row by row
                                while (reader.Read())
                                {
                                    // You can access columns by index or by column name
                                    int id = reader.GetInt32(0); // Assuming the first column is 'id'
                                    string name = reader.GetString(1); // Assuming the second column is 'name'
                                    string bday = reader.GetString(2); // Assuming the third column is 'bday'
                                    string address = reader.GetString(3); // Assuming the fourth column is 'address'
                                    int contactno = reader.GetInt32(4); // Assuming the fifth column is 'contactno'
                                    string gmail = reader.GetString(5); // Assuming the sixth column is 'gmail'
                                    string civilstatus = reader.GetString(6); // Assuming the seventh column is 'civilstatus'
                                    string resume = reader.GetString(7); // Assuming the eighth column is 'resume'

                                    // Output the data to the console
                                    Console.WriteLine($"ID: {id}", Color.Blue);
                                    Console.WriteLine($"Name: {name}", Color.Blue);
                                    Console.WriteLine($"Birthday: {bday}", Color.Blue);
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
                                Console.WriteLine(@"
                                                                                 No data found.");
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
