using LawnMower.Domain.Model;
using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawnMower.Domain
{
    public class LawnMower
    {
        public static new List<LawnMowerModel> Lawnmowers = new List<LawnMowerModel>();

        public static void AddLawnMower(double latitude, double longitude, Directions directions)
        {
            Lawnmowers.Add(new LawnMowerModel()
            {
                Position = new GeoCoordinate(latitude, longitude),
                Direction = Directions.North
            }
            );
        }

        public static LawnMowerModel MoveForward(LawnMowerModel lawnmower)
        {
            var aaa = new Dictionary<Directions, Action>();
            aaa.Add(Directions.North, () => { lawnmower.Position.Longitude += 1; });
            aaa.Add(Directions.West, () => { lawnmower.Position.Latitude -= 1; });
            aaa.Add(Directions.South, () => { lawnmower.Position.Longitude -= 1; });
            aaa.Add(Directions.East, () => { lawnmower.Position.Latitude += 1; });

            var action = aaa.ContainsKey(lawnmower.Direction) ? aaa[lawnmower.Direction] : null;
            if(action != null)
            {
                action.Invoke();
            }

            return lawnmower;
        }

        public static Directions ChangeDirection(string direction, Directions currentDirection)
        {
            const string moveLeft = "L";
            const string moveRight = "R";

            var directions = new Dictionary<Directions, Action>();
            directions.Add(Directions.East, () =>
            {
                if (direction == moveRight)
                {
                    currentDirection = Directions.South;
                }
                if (direction == moveLeft)
                {
                    currentDirection = Directions.North;
                }
            });
            directions.Add(Directions.North, () =>
            {
                if (direction == moveRight)
                {
                    currentDirection = Directions.South;
                }
                if (direction == moveLeft)
                {
                    currentDirection = Directions.West;
                }
            });
            directions.Add(Directions.South, () =>
            {
                if (direction == moveRight)
                {
                    currentDirection = Directions.West;
                }
                if (direction == moveLeft)
                {
                    currentDirection = Directions.East;
                }
            });
            directions.Add(Directions.West, () =>
            {
                if (direction == moveRight)
                {
                    currentDirection = Directions.North;
                }
                if (direction == moveLeft)
                {
                    currentDirection = Directions.South;
                }
            });

            var action = directions.ContainsKey(currentDirection) ? directions[currentDirection] : null;
            if (action != null)
            {
                action.Invoke();
            }

            return currentDirection;
        }

        public static void ChangeDirection(LawnMower lawnMower)
        {
            throw new NotImplementedException();
        }
    }
}
