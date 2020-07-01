using System;
using System.Data.SqlClient;
using System.Text;

namespace _3._Minion_Names
{
    class StartUp
    {
        static void Main()
        {
            string connectionString = @"Server=.; Database=MinionsDB;Integrated Security=true;";

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();

                int Id = int.Parse(Console.ReadLine());
                string result = GetMinionsInfoAboutMinion(sqlConnection, Id);

                Console.WriteLine(result);
            }
        }

        private static string GetMinionsInfoAboutMinion(SqlConnection sqlConnection, int id)
        {
            string villainNameCommand = @"SELECT Name FROM Villains WHERE Id = @Id;";
            using SqlCommand sqlVillainName = new SqlCommand(villainNameCommand, sqlConnection);
            sqlVillainName.Parameters.AddWithValue("@Id", id);

            string villainName = sqlVillainName.ExecuteScalar()?.ToString();

            StringBuilder sb = new StringBuilder();

            if(villainName==null)
            {
                sb.Append($"No villain with ID {id} exists in the database.");
            }else
            {
                sb.Append($"Villain: {villainName}");

                string minionsInfo = @"SELECT Name FROM Villains WHERE Id = @Id SELECT ROW_NUMBER() OVER(ORDER BY m.Name) as RowNum, m.Name, m.Age  FROM MinionsVillains AS mv JOIN Minions As m ON mv.MinionId = m.Id WHERE mv.VillainId = @Id ORDER BY m.Name";

                using SqlDataReader reader = minionsInfo.ExecuteReader();

                if(reader.HasRows)
                {
                    int rowNum = 1;
                    while (reader.Read())
                    {
                        string minionName = reader["Name"]?.ToString();
                        string minionsAge = reader["Age"]?.ToString();

                        sb.AppendLine($"{rowNum}. {minionName} ");
                    }
                }else
                {
                    sb.AppendLine("(no minions)");
                }
            }

            return sb.ToString().Trim();
        }
    }
}
