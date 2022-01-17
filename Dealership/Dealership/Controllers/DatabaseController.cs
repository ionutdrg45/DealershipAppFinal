using System;
using MySql.Data.MySqlClient;

namespace Dealership.Controllers
{
    public class DatabaseController
    {
        public MySqlConnection MakeConnection(Models.Database database)
        {
            MySqlConnection connection = new MySqlConnection();

            try
            {
                connection.ConnectionString = "server=" + database.Server + ";uid=" + database.User + ";pwd=" + database.Password + ";database=" + database.DatabaseName;
                connection.Open();
                Console.WriteLine("Successful connection to database " + database.DatabaseName + " with user " + database.User + ". MySQL version: " + connection.ServerVersion);
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error occured on connection to database " + database.DatabaseName + " with user " + database.User + ":");
                Console.WriteLine(ex.Message);
            }

            return connection;
        }

        public string ExecuteCommand(MySqlConnection connection, string mysqlSyntax, string action)
        {
            var response = "Error!,There was an error trying to " + action + ".";

            try
            {
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = mysqlSyntax;
                cmd.Prepare();
                cmd.ExecuteNonQuery();
                response = "Success!,Data inserted successfully.";
                switch (action)
                {
                    case "update":
                        response = "Success!,Data updated successfully.";
                        break;
                    case "insert":
                        response = "Success!,Data inserted successfully.";
                        break;
                    case "delete":
                        response = "Success!,Data deleted successfully.";
                        break;
                    default:
                        response = "Success!,Command executed successfully.";
                        break;
                }
                return response;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(action + " error:");
                Console.WriteLine(ex.Message);
            }

            return response;
        }

        public MySqlDataReader Select(MySqlConnection connection, string mysqlSyntax)
        {

            try
            {
                MySqlCommand cmd = new MySqlCommand(mysqlSyntax, connection);

                MySqlDataReader rdr = cmd.ExecuteReader();

                return rdr;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error occured on database select.");
                Console.WriteLine(ex.Message);
            }

            return null;
        }
    }
}
