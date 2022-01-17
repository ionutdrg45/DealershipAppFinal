using Dealership.Models;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace Dealership.Controllers
{
    public class CarController
    {
        private static readonly DatabaseController databaseController = new DatabaseController();

        public string Edit(MySqlConnection connection, Car carObj)
        {
            var response = databaseController.ExecuteCommand(connection,
                "UPDATE cars SET " +
                "brand = '" + carObj.Brand + "', model = '" + carObj.Model + "', production_year = '" + carObj.ProductionYear + "', fuel_type = '" + carObj.FuelType + "', body_type = '" + carObj.BodyType + 
                "', weight = '" + carObj.Weight + "', steering_wheel_pos = '" + carObj.SteeringWheelPos + "', horse_power = '" + carObj.HorsePower + "', torque = '" + carObj.Torque + "', seats = '" + carObj.Seats + 
                "', doors = '" + carObj.Doors + "', fuel_capacity = '" + carObj.FuelCapacity + "', range_val = '" + carObj.RangeVal + "', price_usd = '" + carObj.PriceUSD + "' WHERE `id` = " + carObj.Id
            , "update");

            return response;
        }

        public string Delete(MySqlConnection connection, int id)
        {
            var response = databaseController.ExecuteCommand(connection,
                "DELETE FROM cars WHERE `id` = " + id
            , "delete");

            return response;
        }

        public string Add(MySqlConnection connection, Car carObj)
        {
            var response = databaseController.ExecuteCommand(connection, 
                "INSERT INTO cars (brand,model,production_year,fuel_type,body_type,weight,steering_wheel_pos,horse_power,torque,seats,doors,fuel_capacity,range_val,price_usd) VALUES " +
                "(" + "'" + carObj.Brand + "'," + "'" + carObj.Model + "'," + "'" + carObj.ProductionYear + "'," + "'" + carObj.FuelType + "'," + "'" + carObj.BodyType + "'," + "'" + carObj.Weight + "',"
                 + "'" + carObj.SteeringWheelPos + "'," + "'" + carObj.HorsePower + "'," + "'" + carObj.Torque + "'," + "'" + carObj.Seats + "'," + "'" + carObj.Doors + "'," + "'" + carObj.FuelCapacity + "',"
                  + "'" + carObj.RangeVal + "'," + "'" + carObj.PriceUSD + "')"
            , "insert");

            return response;
        }

        public List<Car> UpdateCarsList(MySqlConnection connection, CarFilterModel carFilters)
        {
            List<Car> cars = new List<Car>();
            var mysqlSyntax = "SELECT * FROM cars";
            var updatedSyntax = false;

            if (carFilters.Brand != "none")
            {
                mysqlSyntax += " WHERE `brand` LIKE '%" + carFilters.Brand + "%'";
                updatedSyntax = true;
            }
            if (carFilters.Model != "none")
            {
                if (updatedSyntax == false) mysqlSyntax += " WHERE `model` LIKE '%" + carFilters.Model + "%'";
                else mysqlSyntax += " AND `model` LIKE '%" + carFilters.Model + "%'";
                updatedSyntax = true;
            }
            if (carFilters.DateFrom != "none" && carFilters.DateTo != "none")
            {
                if (updatedSyntax == false) mysqlSyntax += " WHERE `production_year` >= '" + carFilters.DateFrom + "' AND `production_year` <= '" + carFilters.DateTo + "'";
                else mysqlSyntax += " AND `production_year` >= '" + carFilters.DateFrom + "' AND `production_year` <= '" + carFilters.DateTo + "'";
            }

            MySqlDataReader rdr = databaseController.Select(connection, mysqlSyntax);

            while (rdr.Read())
            {
                cars.Add(
                    new Car
                    {
                        Id = rdr.GetInt32(0),
                        Brand = rdr.GetString(1),
                        Model = rdr.GetString(2),
                        ProductionYear = rdr.GetInt32(3),
                        FuelType = rdr.GetString(4),
                        BodyType = rdr.GetString(5),
                        Weight = rdr.GetInt32(6),
                        SteeringWheelPos = rdr.GetString(7),
                        HorsePower = rdr.GetInt32(8),
                        Torque = rdr.GetInt32(9),
                        Seats = rdr.GetInt32(10),
                        Doors = rdr.GetInt32(11),
                        FuelCapacity = rdr.GetInt32(12),
                        RangeVal = rdr.GetInt32(13),
                        PriceUSD = rdr.GetDouble(14)
                    }
                );
            }

            rdr.Close();

            return cars;
        }
    }
}
