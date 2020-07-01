using System;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;

namespace _4._Add_Minion
{
    class StartUp
    {
        private static string connectionStr= @"Server=.; Database=MinionsDB;Integrated Security=true;";
        static void Main()
        {
            var minionInfo = Console.ReadLine().Split();
            var villainInfo = Console.ReadLine().Split();

            addMinionToTheDatabase()

        }

        private static void addMinionToTheDatabase(SqlConnection sqlConnection,string[] minionInfo,string[] villainInfo)
        {
            var sb = new StringBuilder();

            string minionName = minionInfo[1];
            string minionAge = minionInfo[2];
            string minionTown = minionInfo[3];
            
            string villainName = villainInfo[1];

            string townId = EnsureExists(sqlConnection, minionTown,sb);

            string villains = EnsureVillain(sqlConnection, villainName, sb);
        }

        private static string EnsureVillain(SqlConnection sqlConnection, string villainName, StringBuilder sb)
        {
            string getvillaginIdQueryText = "SELECT Id FROM Villains WHERE Name=@Name";
            using SqlCommand getVillainId = new SqlCommand(getvillaginIdQueryText, sqlConnection);

            getVillainId.Parameters.AddWithValue("@name", villainName);

            string villainId = getVillainId.ExecuteScalar()?.ToString();

            if (villainId == null)
            {
                string getFactorIdQueryText = @"SELECT Id FROM EvilnessFactors WHERE Name='Evil'";
                using var getFactorId = new SqlCommand(getFactorIdQueryText, sqlConnection);

                string factorId = getFactorId.ExecuteScalar()?.ToString();
                using var insertVillain = new SqlCommand(insertVillain, sqlConnection);
            }
        }

        private static string EnsureExists(SqlConnection sqlConnection, string minionTown,StringBuilder sb)
        {
            string getTownIdQuerryText = @"SELECT Id FROM Towns WHERE [Name] = @townName";
            using SqlCommand getTownId = new SqlCommand(getTownIdQuerryText, sqlConnection);
            getTownId.Parameters.AddWithValue("@townName", minionTown);

            string townId = getTownId.ExecuteScalar()?.ToString();

            if (townId == null)
            {
                string insertTownQueryText = "INSERT NTO Towns([Name],CountryCode) VALUES (@townName,1)";
                using SqlCommand insertTown = new SqlCommand(insertTownQueryText, sqlConnection);
                insertTown.Parameters.AddWithValue("@townName", minionTown);

                townId = getTownId.ExecuteScalar().ToString();
            }

            return townId;
        }
    }
}
