using Dealership.Controllers;
using Dealership.Models;
using System;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace Dealership
{
    public partial class Form1 : Form
    {
        private static readonly GridController gridController = new GridController();
        private static readonly DatabaseController databaseController = new DatabaseController();
        private static readonly StockController stockController = new StockController();
        private static readonly CarController carController = new CarController();
        private static MySqlConnection databaseConnection = new MySqlConnection();
        private static List<Car> carsList = new List<Car>();
        private static List<Stock> stocksList = new List<Stock>();
        private static CarFilterModel carFilters = new CarFilterModel();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Database database = new Database
            {
                Server = "localhost",
                User = "root",
                Password = "",
                DatabaseName = "dealershipapp"
            };

            databaseConnection = databaseController.MakeConnection(database);

            carFilters = new CarFilterModel
            {
                Brand = "none",
                Model = "none",
                DateFrom = "none",
                DateTo = "none"
            };

            SetupDataGridView();

            UpdateData();
        }

        private void UpdateData()
        {
            carFilters = new CarFilterModel
            {
                Brand = "none",
                Model = "none",
                DateFrom = "none",
                DateTo = "none"
            };

            carsList = carController.UpdateCarsList(databaseConnection, carFilters);
            stocksList = stockController.UpdateStocksList(databaseConnection);
            gridController.UpdateGrid(dataGridView1, carsList, stocksList);
        }

        private void SetupDataGridView()
        {
            dataGridView1.ColumnCount = 16;

            dataGridView1.Columns[0].Name = "id";
            dataGridView1.Columns[1].Name = "Brand";
            dataGridView1.Columns[2].Name = "Model";
            dataGridView1.Columns[3].Name = "Production Year";
            dataGridView1.Columns[4].Name = "Fuel Type";
            dataGridView1.Columns[5].Name = "Body Type";
            dataGridView1.Columns[6].Name = "Weight";
            dataGridView1.Columns[7].Name = "Steering Wheel Position";
            dataGridView1.Columns[8].Name = "Horse Power";
            dataGridView1.Columns[9].Name = "Torque";
            dataGridView1.Columns[10].Name = "Seats";
            dataGridView1.Columns[11].Name = "Doors";
            dataGridView1.Columns[12].Name = "Fuel Capacity";
            dataGridView1.Columns[13].Name = "Range";
            dataGridView1.Columns[14].Name = "Price (USD)";
            dataGridView1.Columns[15].Name = "Stock";

            dataGridView1.ReadOnly = true;
        }

        private void ButtonMakeSearch_Click(object sender, EventArgs e)
        {
            var brand = (!string.IsNullOrWhiteSpace(textBoxBrand.Text) ? textBoxBrand.Text : "none");
            var model = (!string.IsNullOrWhiteSpace(textBoxModel.Text) ? textBoxModel.Text : "none");
            var dateFrom = Convert.ToString(numericUpDownFrom.Value);
            var dateTo = Convert.ToString(numericUpDownTo.Value);

            carFilters = new CarFilterModel
            {
                Brand = brand,
                Model = model,
                DateFrom = dateFrom,
                DateTo = dateTo
            };

            carsList = carController.UpdateCarsList(databaseConnection, carFilters);
            stocksList = stockController.UpdateStocksList(databaseConnection);
            gridController.UpdateGrid(dataGridView1, carsList, stocksList);
        }

        private void ButtonEdit_Click(object sender, EventArgs e)
        {
            int selectedRowCount = dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 0)
            {
                int id = Convert.ToInt32(dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells["id"].Value);
                Car car = carsList.Find(v => v.Id == id);
                Stock stock = stocksList.Find(s => s.CarId == id);
                ModifyCar(car, stock, "edit");
            }
            else
            {
                MessageBox.Show("Please select a row first.", "Error!", MessageBoxButtons.OK);
            }
        }

        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            int selectedRowCount = dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 0)
            {
                int id = Convert.ToInt32(dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells["id"].Value);

                string message = "You are sure that you want to delete car with id #" + id;
                string title = "Sure about that?";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;

                result = MessageBox.Show(message, title, buttons);

                if (result == DialogResult.Yes)
                {
                    string[] response = carController.Delete(databaseConnection, id).Split(',');
                    var stock_id = stocksList.Find(s => s.CarId == id).Id;
                    stockController.Delete(databaseConnection, stock_id);
                    stockController.DeleteSell(databaseConnection, id);

                    message = response[1];
                    title = response[0];
                    buttons = MessageBoxButtons.OK;

                    MessageBox.Show(message, title, buttons);

                    if (response[0] == "Success!") UpdateData();
                }
            }
            else
            {
                MessageBox.Show("Please select a row first.", "Error!", MessageBoxButtons.OK);
            }
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            Car car = new Car
            {
                Id = -1,
                Brand = "none",
                Model = "none",
                ProductionYear = Convert.ToInt32("1970"),
                FuelType = "none",
                BodyType = "none",
                Weight = Convert.ToInt32("0"),
                SteeringWheelPos = "",
                HorsePower = Convert.ToInt32("0"),
                Torque = Convert.ToInt32("0"),
                Seats = Convert.ToInt32("0"),
                Doors = Convert.ToInt32("0"),
                FuelCapacity = Convert.ToInt32("0"),
                RangeVal = Convert.ToInt32("0"),
                PriceUSD = Convert.ToDouble("0")
            };

            Stock stock = new Stock
            {
                Id = -1,
                CarId = Convert.ToInt32("0"),
                StockV = Convert.ToInt32("0")
            };

            ModifyCar(car, stock, "add");
        }

        private void ModifyCar(Car car, Stock stock, string action)
        {
            string caption = (action == "add" ? "Add new car" : "Edit car with id #" + car.Id);
            Form prompt = new Form()
            {
                Width = 580,
                Height = 600,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = caption,
                StartPosition = FormStartPosition.CenterScreen,
                MaximizeBox = false,
                AutoSize = false
            };

            Label labelBrand = new Label() { Left = 40, Top = 20, Text = "Brand:", Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))) };
            TextBox textBoxBrand = new TextBox() { Left = 40, Top = 50, Width = 200, Text = car.Brand };

            Label labelModel = new Label() { Left = 310, Top = 20, Text = "Model:", Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))) };
            TextBox textBoxModel = new TextBox() { Left = 310, Top = 50, Width = 200, Text = car.Model };

            Label labelProductionYear = new Label() { Left = 40, Top = 80, Text = "Production Year:", Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))) };
            NumericUpDown numericUpDownProductionYear = new NumericUpDown() { Left = 40, Top = 110, Width = 200, Maximum = new decimal(new int[] { 2022, 0, 0, 0 }), Minimum = new decimal(new int[] { 1970, 0, 0, 0 }), Value = car.ProductionYear };

            Label labelFuelType = new Label() { Left = 310, Top = 80, Text = "Fuel Type:", Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))) };
            TextBox textBoxFuelType = new TextBox() { Text = car.FuelType, Left = 310, Top = 110, Width = 200 };

            Label labelBodyType = new Label() { Left = 310, Top = 140, Text = "Body Type:", Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))) };
            TextBox textBoxBodyType = new TextBox() { Text = car.BodyType, Left = 310, Top = 170, Width = 200 };

            Label labelWeight = new Label() { Left = 40, Top = 200, Text = "Weight:", Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))) };
            NumericUpDown numericUpDownWeight = new NumericUpDown() { Left = 40, Top = 230, Width = 200, Maximum = new decimal(new int[] { 99999, 0, 0, 0 }), Minimum = new decimal(new int[] { 0, 0, 0, 0 }), Value = car.Weight };

            Label labelSteeringWheelPos = new Label() { Left = 310, Top = 200, Text = "Steering wheel pos:", Font = new Font("Microsoft Sans Serif", 8F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))) };
            TextBox textBoxSteeringWheelPos = new TextBox() { Text = car.SteeringWheelPos, Left = 310, Top = 230, Width = 200 };

            Label labelHorsePower = new Label() { Left = 40, Top = 140, Text = "Horse Power:", Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))) };
            NumericUpDown numericUpDownHorsePower = new NumericUpDown() { Left = 40, Top = 170, Width = 200, Maximum = new decimal(new int[] { 99999, 0, 0, 0 }), Minimum = new decimal(new int[] { 0, 0, 0, 0 }), Value = car.HorsePower };

            Label labelTorque = new Label() { Left = 40, Top = 260, Text = "Torque:", Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))) };
            NumericUpDown numericUpDownTorque = new NumericUpDown() { Left = 40, Top = 290, Width = 200, Maximum = new decimal(new int[] { 99999, 0, 0, 0 }), Minimum = new decimal(new int[] { 0, 0, 0, 0 }), Value = car.Torque };

            Label labelSeats = new Label() { Left = 310, Top = 260, Text = "Seats:", Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))) };
            NumericUpDown numericUpDownSeats = new NumericUpDown() { Left = 310, Top = 290, Width = 200, Maximum = new decimal(new int[] { 99999, 0, 0, 0 }), Minimum = new decimal(new int[] { 0, 0, 0, 0 }), Value = car.Seats };

            Label labelDoors = new Label() { Left = 40, Top = 320, Text = "Doors:", Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))) };
            NumericUpDown numericUpDownDoors = new NumericUpDown() { Left = 40, Top = 350, Width = 200, Maximum = new decimal(new int[] { 99999, 0, 0, 0 }), Minimum = new decimal(new int[] { 0, 0, 0, 0 }), Value = car.Doors };

            Label labelFuelCapacity = new Label() { Left = 310, Top = 320, Text = "Fuel Capcity:", Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))) };
            NumericUpDown numericUpDownFuelCapacity = new NumericUpDown() { Left = 310, Top = 350, Width = 200, Maximum = new decimal(new int[] { 99999, 0, 0, 0 }), Minimum = new decimal(new int[] { 0, 0, 0, 0 }), Value = car.FuelCapacity };

            Label labelRangeVal = new Label() { Left = 40, Top = 380, Text = "Range Value:", Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))) };
            NumericUpDown numericUpDownRangeVal = new NumericUpDown() { Left = 40, Top = 410, Width = 200, Maximum = new decimal(new int[] { 99999, 0, 0, 0 }), Minimum = new decimal(new int[] { 0, 0, 0, 0 }), Value = car.RangeVal };

            Label labelPriceUSD = new Label() { Left = 310, Top = 380, Text = "Price USD:", Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))) };
            TextBox textBoxPriceUSD = new TextBox() { Text = Convert.ToString(car.PriceUSD), Left = 310, Top = 410, Width = 200 };

            Label labelStock = new Label() { Left = 40, Top = 440, Text = "On stock:", Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))) };
            NumericUpDown numericUpDownStock = new NumericUpDown() { Left = 40, Top = 470, Width = 200, Maximum = new decimal(new int[] { 99999, 0, 0, 0 }), Minimum = new decimal(new int[] { 0, 0, 0, 0 }), Value = stock.StockV };

            Button confirmation = new Button() { Text = (action == "add" ? "Add" : "Edit"), Left = 440, Width = 100, Top = 510, Size = new Size(100, 35), Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))), DialogResult = DialogResult.OK };
            confirmation.Click += (senderr, ee) => { prompt.Close(); };

            prompt.Controls.Add(labelBrand);
            prompt.Controls.Add(textBoxBrand);
            prompt.Controls.Add(labelModel);
            prompt.Controls.Add(textBoxModel);
            prompt.Controls.Add(labelProductionYear);
            prompt.Controls.Add(numericUpDownProductionYear);
            prompt.Controls.Add(labelFuelType);
            prompt.Controls.Add(textBoxFuelType);
            prompt.Controls.Add(labelBodyType);
            prompt.Controls.Add(textBoxBodyType);
            prompt.Controls.Add(labelWeight);
            prompt.Controls.Add(numericUpDownWeight);
            prompt.Controls.Add(labelSteeringWheelPos);
            prompt.Controls.Add(textBoxSteeringWheelPos);
            prompt.Controls.Add(labelHorsePower);
            prompt.Controls.Add(numericUpDownHorsePower);
            prompt.Controls.Add(labelTorque);
            prompt.Controls.Add(numericUpDownTorque);
            prompt.Controls.Add(labelSeats);
            prompt.Controls.Add(numericUpDownSeats);
            prompt.Controls.Add(labelDoors);
            prompt.Controls.Add(numericUpDownDoors);
            prompt.Controls.Add(labelFuelCapacity);
            prompt.Controls.Add(numericUpDownFuelCapacity);
            prompt.Controls.Add(labelRangeVal);
            prompt.Controls.Add(numericUpDownRangeVal);
            prompt.Controls.Add(labelPriceUSD);
            prompt.Controls.Add(textBoxPriceUSD);
            prompt.Controls.Add(labelStock);
            prompt.Controls.Add(numericUpDownStock);

            prompt.Controls.Add(confirmation);
            prompt.AcceptButton = confirmation;

            if (prompt.ShowDialog() == DialogResult.OK)
            {
                car.Id = car.Id;
                car.Brand = textBoxBrand.Text;
                car.Model = textBoxModel.Text;
                car.ProductionYear = Convert.ToInt32(numericUpDownProductionYear.Value);
                car.FuelType = textBoxFuelType.Text;
                car.BodyType = textBoxBodyType.Text;
                car.Weight = Convert.ToInt32(numericUpDownWeight.Value);
                car.SteeringWheelPos = textBoxSteeringWheelPos.Text;
                car.HorsePower = Convert.ToInt32(numericUpDownHorsePower.Value);
                car.Torque = Convert.ToInt32(numericUpDownTorque.Value);
                car.Seats = Convert.ToInt32(numericUpDownSeats.Value);
                car.Doors = Convert.ToInt32(numericUpDownDoors.Value);
                car.FuelCapacity = Convert.ToInt32(numericUpDownFuelCapacity.Value);
                car.RangeVal = Convert.ToInt32(numericUpDownRangeVal.Value);
                car.PriceUSD = Convert.ToDouble(textBoxPriceUSD.Text);

                stock.StockV = Convert.ToInt32(numericUpDownStock.Value);

                string[] response = (action == "add" ? carController.Add(databaseConnection, car).Split(',') : carController.Edit(databaseConnection, car).Split(','));

                if (response[0] == "Success!")
                {
                    carFilters = new CarFilterModel
                    {
                        Brand = "none",
                        Model = "none",
                        DateFrom = "none",
                        DateTo = "none"
                    };

                    carsList = carController.UpdateCarsList(databaseConnection, carFilters);

                    if (action == "add")
                    {
                        stock.CarId = carsList[carsList.Count - 1].Id;
                        stockController.Add(databaseConnection, stock);
                    }
                    else if (action == "edit")
                    {
                        stock.CarId = car.Id;
                        stockController.Edit(databaseConnection, stock);
                    }

                    string message = response[1];
                    string title = response[0];
                    MessageBoxButtons buttons = MessageBoxButtons.OK;
                    DialogResult result;

                    result = MessageBox.Show(message, title, buttons);

                    UpdateData();
                }
                else
                {
                    string message = response[1];
                    string title = response[0];
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    DialogResult result;

                    result = MessageBox.Show(message, title, buttons);
                    if (result == DialogResult.Yes)
                    {
                        this.Close();
                        ModifyCar(car, stock, action);
                    }
                }
            }

        }

        private void ButtonSellcar_Click(object sender, EventArgs e)
        {
            int selectedRowCount = dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 0)
            {
                int id = Convert.ToInt32(dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells["id"].Value);
                Stock stock = stocksList.Find(s => s.CarId == id);

                if (stock.StockV > 0)
                {
                    string message = "You are sure that you want to sell car with id #" + id + ", there are " + stock.StockV + " available at the moment.";
                    string title = "Sure about that?";
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    DialogResult result;

                    result = MessageBox.Show(message, title, buttons);

                    if (result == DialogResult.Yes)
                    {
                        string caption = "Sell car #" + id;
                        Form prompt = new Form()
                        {
                            Width = 300,
                            Height = 150,
                            FormBorderStyle = FormBorderStyle.FixedDialog,
                            Text = caption,
                            StartPosition = FormStartPosition.CenterScreen,
                            MaximizeBox = false,
                            AutoSize = false
                        };

                        Label labelAddress = new Label() { Left = 40, Top = 20, Text = "Address:", Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))) };
                        TextBox textBoxAddress = new TextBox() { Left = 40, Top = 50, Width = 200 };

                        Button confirmation = new Button() { Text = "Sell", Left = 180, Width = 100, Top = 80, Size = new Size(80, 25), Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))), DialogResult = DialogResult.OK };
                        confirmation.Click += (senderr, ee) => { prompt.Close(); };

                        prompt.Controls.Add(labelAddress);
                        prompt.Controls.Add(textBoxAddress);

                        prompt.Controls.Add(confirmation);
                        prompt.AcceptButton = confirmation;

                        if (prompt.ShowDialog() == DialogResult.OK)
                        {
                            string address = textBoxAddress.Text;

                            stockController.Sell(databaseConnection, stock, address);

                            UpdateData();

                            MessageBox.Show("Car sold successfully!", "Sold!", MessageBoxButtons.OK);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Car out of stock.", "Out of stock!", MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show("Please select a row first.", "Error!", MessageBoxButtons.OK);
            }
        }
    }
}
