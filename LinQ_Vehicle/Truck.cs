using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinQ_Vehicle
{
    internal class Truck: Vehicle
    {
        public string owner { get; set; }

        public Truck(): base()
        {
        }

        public Truck(string name, string brand, int price, int year, string owner) : base(name, brand, price, year)
        {
            this.owner = owner;
        }

        public override void enterVehicle()
        {
            base.enterVehicle();
            Console.WriteLine("Enter owner:");
            this.owner = Console.ReadLine();
        }

        public override void showVehicles()
        {
            base.showVehicles();
            Console.WriteLine($"Owner: {this.owner}");
        }
    }
}
