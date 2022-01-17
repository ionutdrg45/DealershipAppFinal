using System;
using System.Windows.Forms;
using Dealership.Models;
using System.Collections.Generic;

namespace Dealership.Controllers
{
    public class GridController
    {
        public void UpdateGrid(DataGridView grid, List<Car> carsList, List<Stock> stockList)
        {
            while (grid.Rows.Count > 0)
            {
                grid.Rows.Remove(grid.Rows[0]);
            }

            foreach (Car c in carsList)
            {
                var stock_value = stockList.Find(s => s.CarId == c.Id).StockV;

                string[] row =
                {
                    Convert.ToString(c.Id),
                    c.Brand,
                    c.Model,
                    Convert.ToString(c.ProductionYear),
                    c.FuelType,
                    c.BodyType,
                    Convert.ToString(c.Weight) + " kg",
                    c.SteeringWheelPos,
                    Convert.ToString(c.HorsePower),
                    Convert.ToString(c.Torque) + " Nm",
                    Convert.ToString(c.Seats),
                    Convert.ToString(c.Doors),
                    Convert.ToString(c.FuelCapacity) + (c.FuelType == "Electricity" ? " Kw" : " L"),
                    Convert.ToString(c.RangeVal) + " km",
                    "$" + String.Format("{0:n}", c.PriceUSD),
                    Convert.ToString(stock_value)
                };

                grid.Rows.Add(row);
            }
        }
    }
}
