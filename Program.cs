using System;
using System.Text;
using System.Data.SqlClient;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
          while (true)
          {
            try
            {
              SqlConnectionStringBuilder connbuilder = new SqlConnectionStringBuilder();
              connbuilder.DataSource = "10.0.0.20";
              connbuilder.UserID = "sa";
              connbuilder.Password = "Yukon900";
              connbuilder.InitialCatalog = "master";

              using (SqlConnection connection = new SqlConnection(connbuilder.ConnectionString))
              {
                Console.WriteLine("Connecting");
                connection.Open();
                Console.WriteLine("Connected");
                String sql = "SELECT CONVERT(sysname,SERVERPROPERTY('ServerName'))";
                using (SqlCommand command = new SqlCommand(sql,connection))
                {
                  using (SqlDataReader reader = command.ExecuteReader())
                  {
                    while (reader.Read())
                    {
                      Console.WriteLine(reader.GetString(0));
                    }
                  }
                }
              }
            }
            catch (Exception e)
            {
              Console.WriteLine("Lost connection");
            }
          }
        }
    }
}
