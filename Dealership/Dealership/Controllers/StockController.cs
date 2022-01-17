using MySql.Data.MySqlClient;
using Dealership.Models;
using System.Collections.Generic;

namespace Dealership.Controllers
{
    public class StockController
    {
        private static readonly DatabaseController databaseController = new DatabaseController();

        public string Edit(MySqlConnection connection, Stock stockObj)
        {
            var response = databaseController.ExecuteCommand(connection,
                "UPDATE stock SET stock = '" + stockObj.StockV + "' WHERE `car_id` = " + stockObj.CarId
            , "update");

            return response;
        }

        public string Delete(MySqlConnection connection, int id)
        {
            var response = databaseController.ExecuteCommand(connection, "DELETE FROM stock WHERE `id` = " + id, "delete");

            return response;
        }

        public string Add(MySqlConnection connection, Stock stockObj)
        {
            var response = databaseController.ExecuteCommand(connection,
               "INSERT INTO stock (car_id, stock) VALUES " +
               "('" + stockObj.CarId + "', '" + stockObj.StockV + "')"
           , "insert");

            return response;
        }

        public string Decrease(MySqlConnection connection, Stock stockObj, int value)
        {
            var response = databaseController.ExecuteCommand(connection,
                "UPDATE stock SET stock = stock - " + value + " WHERE `car_id` = " + stockObj.CarId
            , "update");

            return response;
        }

        public List<Stock> UpdateStocksList(MySqlConnection connection)
        {
            List<Stock> stocks = new List<Stock>();
            var mysqlSyntax = "SELECT * FROM stock";

            MySqlDataReader rdr = databaseController.Select(connection, mysqlSyntax);

            while (rdr.Read())
            {
                stocks.Add(
                    new Stock
                    {
                        Id = rdr.GetInt32(0),
                        CarId = rdr.GetInt32(1),
                        StockV = rdr.GetInt32(2)
                    }
                );
            }

            rdr.Close();

            return stocks;
        }

        public void Sell(MySqlConnection connection, Stock stockObj, string address)
        {
            databaseController.ExecuteCommand(connection,
               "INSERT INTO sells (car_id, address) VALUES " +
               "('" + stockObj.CarId + "', '" + address + "')"
           , "insert");

            Decrease(connection, stockObj, 1);
        }

        public void DeleteSell(MySqlConnection connection, int id)
        {
            databaseController.ExecuteCommand(connection, "DELETE FROM sells WHERE `car_id` = " + id, "delete");
        }
    }
}
