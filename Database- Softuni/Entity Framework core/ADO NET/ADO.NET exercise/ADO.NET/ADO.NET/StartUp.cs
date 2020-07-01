namespace ADO.NET
{
    using System;
    using System.Data.SqlClient;
    class StartUp
    {
        static void Main()
        {
            string connectionString = @"Server=.; Database=MinionsDB;Integrated Security=true;";
            
            using(SqlConnection sqlConnection=new SqlConnection(connectionString))
            {
                sqlConnection.Open();

                string command = "SELECT v.Name, COUNT(mv.VillainId) AS MinionsCount FROM Villains AS v JOIN MinionsVillains AS mv ON v.Id = mv.VillainId GROUP BY v.Id, v.Name HAVING COUNT(mv.VillainId) > 3 ORDER BY COUNT(mv.VillainId)";

                var sqlCommand = new SqlCommand(command, sqlConnection);

                using (SqlDataReader reader=sqlCommand.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        string name =(string) reader["Name"];
                        int count = (int)reader["MinionsCount"];
                        Console.WriteLine(name+" - "+count);
                    }
                }
            }    
        }
    }
}
