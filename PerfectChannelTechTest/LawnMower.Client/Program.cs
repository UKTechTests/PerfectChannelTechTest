using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawnMower.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = new Domain.Lawn();

            Console.WriteLine("Please enter the top right coordinates of the lawn.");
            var x = Console.ReadLine();

            a.CalculateLawnArea(new GeoCoordinate(5, 5));

            var b = a.LawnArea;

            Console.Write("Please enter the lawn mower coordinates");
            var direction = Console.Read();

            Domain.LawnMower.AddLawnMower(1, 2, Domain.Model.Directions.North);


        }
    }
}
