using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinQ_Vehicle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char k = 'y';
            while (k == 'y' || k == 'Y')
            {
                menu();
                Console.WriteLine("Enter (Y) to go back Menu or any key to stop:");
                k = Console.ReadLine()[0];
            }

            Console.ReadKey();
        }

        static void menu()
        {
            Console.WriteLine("----- VEHICLE MANAGE -----");
            Console.WriteLine("1. Manage Cars");
            Console.WriteLine("2. Manage Trucks");
            Console.Write("Enter your option: ");
            int option = int.Parse(Console.ReadLine());

            switch (option)
            {
                case 1:
                    manageCars();
                    break;
                case 2:
                    manageTrucks();
                    break;
            }
        }

        static void manageCars()
        {
            IList<Car> cars = new List<Car>();
            char isContinue = 'y';

            Console.WriteLine("\n-- Enter list cars --");
            while (isContinue == 'y' || isContinue == 'Y')
            {
                var car = new Car();
                car.enterVehicle();
                cars.Add(car);

                Console.WriteLine("Do you want continue: ");
                isContinue = Console.ReadLine()[0];
            }

            Console.WriteLine("\n-- The list of cars has prices ranging from 100,000 to 250,000 --");
            filterCarByPrice(cars);

            Console.WriteLine("\n-- The list of vehicles with production year from 1990 --");
            filterCarByYear(cars);

            Console.WriteLine("\n-- Total price by brand --");
            sumPriceByBrand(cars);
        }

        static void filterCarByPrice(IList<Car> cars)
        {
            var listCar = from item in cars where (item.price >+ 100000 && item.price <= 250000) select item;

            foreach (var item in listCar)
            {
                item.showVehicles();
            }
        }

        static void filterCarByYear(IList<Car> cars)
        {
            var listCar = from item in cars where item.year > 1990 select item;

            foreach(var item in listCar)
            {
                item.showVehicles();
            }
        }

        static void sumPriceByBrand(IList<Car> cars)
        {
            var groupBrands = from car in cars group car by car.brand;
            foreach (var brand in groupBrands)
            {
                var totalPrice = 0f;
                Console.WriteLine("Brand {0}:", brand.Key);
                foreach (var car in brand)
                {
                    totalPrice += car.price;
                    Console.WriteLine(" - {0}", car.name);
                }
                Console.WriteLine($" => Total price: {totalPrice}");
            }
        }

        static void manageTrucks()
        {
            IList<Truck> trucks = new List<Truck>();
            char isContinue = 'y';

            Console.WriteLine("\n-- Enter list trucks --");
            while (isContinue == 'y' || isContinue == 'Y')
            {
                var truck = new Truck();
                truck.enterVehicle();
                trucks.Add(truck);

                Console.WriteLine("Do you want continue: ");
                isContinue = Console.ReadLine()[0];
            }

            Console.WriteLine("\n-- List of trucks in order of most recent year of manufacture --");
            orderTruckByYear(trucks);

            Console.WriteLine("\n-- List of managing companies --");
            truckByOwner(trucks);
        }

        static void orderTruckByYear(IList<Truck> trucks)
        {
            var listTrucks = trucks.OrderByDescending(truck => truck.year);
            foreach (var truck in listTrucks)
            {
                truck.showVehicles();
            }
        }

        static void truckByOwner(IList<Truck> trucks)
        {
            var distinctOwner = trucks.Select(truck => truck.owner).Distinct();
            foreach (var item in distinctOwner)
            {
                Console.WriteLine(item);
            }
        }
    }
}
