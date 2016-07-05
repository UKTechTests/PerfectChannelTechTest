using LawnMower.Domain;
using LawnMower.Domain.Model;
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
            var lawnmowerInstructions = new Domain.LawnmowerInstructions();
            var lawnConfiguration = new LawnConfiguration();

            Console.WriteLine("Enter the top right lawn coordinates separated by a space (5 5): ");
            var topRightCoordinates = Console.ReadLine();
            //TODO: Validate input respond with warning if necessary.

            var lawnDimensions = topRightCoordinates.Split(' ');
            var topRightLat = int.Parse(lawnDimensions[0]);
            var topRightLong = int.Parse(lawnDimensions[1]);

            lawnConfiguration.CalculateLawnArea(new GeoCoordinate(topRightLat, topRightLong)); 

            var response = string.Empty;

            do
            {
                Console.Write("Enter lawnmower starting position separated by spaces (2 2 N: ");
                var lawnMowerPosition = Console.ReadLine();
                //TODO: Validate input respond with warning if necessary.


                Console.Write("Instruct the lawnmower to move by using L R M: ");
                var lawnmowerMovements = Console.ReadLine();
                //TODO: Validate input respond with warning if necessary.

                lawnmowerInstructions.AddLawnmowerToGrid(lawnMowerPosition, lawnmowerMovements);

                //TODO: create and configureLawnmower.
                Console.WriteLine("Type FINISHED to print out results or press any key to configure another lawnmower");
                response = Console.ReadLine();

            }
            while (response.ToUpper() != "FINISHED");

            Console.WriteLine("Output");

            foreach(var lawnmower in lawnmowerInstructions.lawnmowers)
            {
                lawnmowerInstructions.ExecuteInstructions(lawnmower);
                Console.WriteLine("{0} {1} {2}", lawnmower.Position.Latitude, lawnmower.Position.Longitude, lawnmower.Direction.ToString());
            }
            
                //TODO: Iterate through lawnmowers and print out positions.

            Console.WriteLine("Press any key to exit.");
        }
    }
}
