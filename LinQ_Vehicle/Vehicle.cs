using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinQ_Vehicle
{
    public class Vehicle
    {
        public string name { get; set; }
        public string brand { get; set; }
        public float price { get; set; }
        public int year { get; set; }

        public Vehicle()
        {
        }

        public Vehicle(string name, string brand, int price, int year)
        {
            this.name = name;
            this.brand = brand;
            this.price = price;
            this.year = year;
        }

        public virtual void enterVehicle()
        {
            Console.WriteLine("Enter name:");
            this.name = Console.ReadLine();
            Console.WriteLine("Enter brand:");
            this.brand = Console.ReadLine();
            Console.WriteLine("Enter price: ");
            this.price = float.Parse(Console.ReadLine());
            Console.WriteLine("Enter year:");
            this.year = int.Parse(Console.ReadLine());
        }

        public virtual void showVehicles()
        {
            Console.WriteLine($"\nName: {this.name}");
            Console.WriteLine($"Brand: {this.brand}");
            Console.WriteLine($"Price: {this.price}");
            Console.WriteLine($"Year: {this.year}");
        }
    }
}
