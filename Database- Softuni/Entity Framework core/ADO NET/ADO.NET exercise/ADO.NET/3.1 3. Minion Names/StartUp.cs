using System;
using System.Data.SqlClient;
using System.Text;

namespace _3._1_3._Minion_Names
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string connectionString = @"Server=.; Database=MinionsDB;Integrated Security=true;";

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                var sb = new StringBuilder();
                string id = Console.ReadLine();

                string commandVillain = @"SELECT TOP(1) * FROM MinionsVillains AS mv JOIN Villains AS v ON v.Id = mv.VillainId WHERE mv.VillainId = @Id";          
                var sqlCommand1 = new SqlCommand(commandVillain, sqlConnection);
                sqlCommand1.Parameters.AddWithValue("@Id", id);

                using (SqlDataReader reader = sqlCommand1.ExecuteReader())
                {                    
                    while (reader.Read())
                    {
                        string name = (string)reader["Name"];
                        sb.AppendLine(name);
                    }
                }

                string command = "SELECT [Name],Age FROM MinionsVillains AS mv JOIN Minions AS m ON mv.MinionId = m.id WHERE mv.VillainId = @Id ORDER BY Name";
                var sqlCommand2 = new SqlCommand(command, sqlConnection);
                sqlCommand2.Parameters.AddWithValue("@Id", id);

                using (SqlDataReader reader = sqlCommand2.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string name = (string)reader["Name"];
                        int age =(int) reader["Age"];
                        sb.AppendLine(name + " - " + age);
                    }
                }

                Console.WriteLine(sb.ToString().Trim());
            }
        }
    }
}
