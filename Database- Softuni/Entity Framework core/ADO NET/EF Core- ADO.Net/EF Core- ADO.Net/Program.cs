using Microsoft.Data.SqlClient;
using System;

namespace EF_Core__ADO.Net
{
    class Program
    {
        static void Main()
        {
            string connectionString = "Server=.;Database=SoftUni; Integrated Security=true";
            //string connectionString2 = "Server=.;Database=SoftUni; User Id=myUser; Password=123456";
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                string command = "SELECT COUNT(*) FROM Employees";
                var sqlCommand = new SqlCommand(command, sqlConnection);

                //scalar result
                int result = (int)sqlCommand.ExecuteScalar(); //returns only 1 - 1

                //table read line by line
                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {               //read all lines
                    while (reader.Read())
                    {
                        string firstName = (string)reader[0];
                        //or string firstName =(string) reader["FirstName"];
                        string lastName = (string)reader[1];

                        Console.WriteLine(firstName + " " + lastName);
                    }
                }
                Console.WriteLine(result);

                //update query
                string command2 = "UPDATE Employees SER Salary=Salary*1.10";
                SqlCommand updateSalary = new SqlCommand(command2, sqlConnection);

                var updatedRows = updateSalary.ExecuteNonQuery();
                Console.WriteLine($"Salary is updated for {updatedRows} employees");
            }

            
        }
    }
}
