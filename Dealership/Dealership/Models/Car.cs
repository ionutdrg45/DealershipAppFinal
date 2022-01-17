namespace Dealership.Models
{
    public class Car
    {
        public int Id { get; set; }

        public string Brand { get; set; }

        public string Model { get; set; }

        public int ProductionYear { get; set; }

        public string FuelType { get; set; }

        public string BodyType { get; set; }

        public int Weight { get; set; }

        public string SteeringWheelPos { get; set; }

        public int HorsePower { get; set; }

        public int Torque { get; set; }

        public int Seats { get; set; }

        public int Doors { get; set; }

        public int FuelCapacity { get; set; }

        public int RangeVal { get; set; }

        public double PriceUSD { get; set; }
    }
}
