using LawnMower.Domain.Model;
using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawnMower.Domain
{
    public class LawnmowerInstructions
    {
        private IDictionary<Directions, Action> LawnmowerMovementStratergy;

        private IDictionary<Directions, Func<Directions>> LawnmowerDirectionStratergy;

        public IList<LawnMowerModel> lawnmowers = new List<LawnMowerModel>();
                
        public LawnMowerModel MoveForward(LawnMowerModel lawnmower)
        {
            CreateLawnmowerMovementStratergy(lawnmower);

            var action = LawnmowerMovementStratergy.ContainsKey(lawnmower.Direction) ? LawnmowerMovementStratergy[lawnmower.Direction] : null;
            if (action != null)
            {
                action.Invoke();
            }

            return lawnmower;
        }

        public Directions ChangeDirection(string direction, Directions currentDirection)
        {
            CreateLawnmowerDirectionStratergy(direction, currentDirection);

            var action = LawnmowerDirectionStratergy.ContainsKey(currentDirection) ? LawnmowerDirectionStratergy[currentDirection] : null;
            if (action != null)
            {
                currentDirection = action.Invoke();
            }

            return currentDirection;
        }

        private  Directions CreateLawnmowerDirectionStratergy(string direction, Directions currentDirection)
        {
            const string moveLeft = "L";
            const string moveRight = "R";

            LawnmowerDirectionStratergy = new Dictionary<Directions, Func<Directions>>();
            LawnmowerDirectionStratergy.Add(Directions.East, () =>
            {
                if (direction == moveRight)
                {
                    currentDirection = Directions.South;
                }
                if (direction == moveLeft)
                {
                    currentDirection = Directions.North;
                }

                return currentDirection;
            });
            LawnmowerDirectionStratergy.Add(Directions.North, () =>
            {
                if (direction == moveRight)
                {
                    currentDirection = Directions.South;
                }
                if (direction == moveLeft)
                {
                    currentDirection = Directions.West;
                }

                return currentDirection;
            });
            LawnmowerDirectionStratergy.Add(Directions.South, () =>
            {
                if (direction == moveRight)
                {
                    currentDirection = Directions.West;
                }
                if (direction == moveLeft)
                {
                    currentDirection = Directions.East;
                }

                return currentDirection;
            });
            LawnmowerDirectionStratergy.Add(Directions.West, () =>
            {
                if (direction == moveRight)
                {
                    currentDirection = Directions.North;
                }
                if (direction == moveLeft)
                {
                    currentDirection = Directions.South;
                }

                return currentDirection;
            });
            return currentDirection;
        }

        public GeoCoordinate ExecuteInstructions(LawnMowerModel lawnmower)
        {
            foreach(var movement in lawnmower.Instructions)
            {
                switch (movement)
                {
                    case 'L':
                        {
                            lawnmower.Direction = ChangeDirection("L", lawnmower.Direction);
                            break;
                        }
                    case 'R':
                        {
                            lawnmower.Direction = ChangeDirection("R", lawnmower.Direction);
                            break;
                        }
                    default:
                        {
                            MoveForward(lawnmower);
                            break;
                        }
                }

                return lawnmower.Position;

            }

            return lawnmower.Position;
        }

        public void AddLawnmowerToGrid(string lawnMowerPosition, string lawnmowerMovements)
        {
            //TODO: validate input.for both arguments.
            var positions = lawnMowerPosition.Split(' ');
            var latitude = int.Parse(positions[0]);  //Fragile with more time would do differently
            var longitude = int.Parse(positions[1]); //Fragile with more time would do differently
            var direction = positions[2]; //Fragile with more time would do differently

            var lawnmower = new LawnMowerModel()
            {
                Position = new GeoCoordinate(latitude, longitude),
                Direction = GetDirection(direction),
                Instructions = lawnmowerMovements.ToCharArray()
            };

            lawnmowers.Add(lawnmower);
        }
    

        private Directions GetDirection(string direction)
        {
            var result = Directions.North;

            switch (direction.ToUpper())
            {
                case "E":
                    {
                        result = Directions.East;
                        break;
                    }
                case "S":
                    {
                        result = Directions.South;
                        break;
                    }
                case "W":
                    {
                        result = Directions.West;
                        break;
                    }
                default:
                    {
                        result = Directions.North;
                        break;
                    }
            }

            return result;
        }
    

        private void CreateLawnmowerMovementStratergy(LawnMowerModel lawnmower)
        {
            LawnmowerMovementStratergy = new Dictionary<Directions, Action>();
            LawnmowerMovementStratergy.Add(Directions.North, () => { lawnmower.Position.Longitude += 1; });
            LawnmowerMovementStratergy.Add(Directions.West, () => { lawnmower.Position.Latitude -= 1; });
            LawnmowerMovementStratergy.Add(Directions.South, () => { lawnmower.Position.Longitude -= 1; });
            LawnmowerMovementStratergy.Add(Directions.East, () => { lawnmower.Position.Latitude += 1; });
        }

    }
}
