using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Connection
    {
        public string connectionString;

        public Connection()
        {
            string server = "localhost";
            string database = "midterm";
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
                Console.WriteLine("Data inserted successfully!");
            }// wala kayong jop posting? job title yung nakapangalan ano? wai ano ulit 
            catch (Exception ex) // parang pwedeng palitan yung contact as resume na agad tas jobpsting as documents s
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
                    string query = "INSERT INTO HRadmun (username, password) VALUES (@username, @password)";
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
        public bool UserExists(string username)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT COUNT(*) FROM hradmun WHERE username = @username";
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
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
        public bool ValidateLogin(string username, string userPassword)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT COUNT(*) FROM hradmun WHERE username = @username AND password = @password";
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
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
                    string query = "SELECT COUNT(*) FROM hradmun WHERE username = @username AND password = @password";
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@username", admin);
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







        public void InsertInfo(string resume, string documents)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO user (resume, password) VALUES (@resume, @documents)";
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@resume", resume);
                        cmd.Parameters.AddWithValue("@documents", documents);
                        cmd.ExecuteNonQuery();
                    }
                }
                Console.WriteLine("Info inserted successfully!"); // ahh sa program ko ilalagay yung Main??

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
                    string query = "INSERT INTO addjobposting (jobtitle, jobdescription) VALUES (@jobtitle, @jobdescription)";
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@jobtitle", jobtitle);
                        cmd.Parameters.AddWithValue("@jobdescription", jobdescription);

                        cmd.ExecuteNonQuery();
                    }
                }
                Console.WriteLine("Data inserted successfully!");
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
                            Console.WriteLine("\n--- Job Postings ---");
                            while (reader.Read())
                            {
                                Console.WriteLine($"Job ID: {reader["id"]}");
                                Console.WriteLine($"Job Title: {reader["jobtitle"]}");
                                Console.WriteLine($"Description: {reader["jobdescription"]}");
                                Console.WriteLine("---------------------");
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

    }
}
