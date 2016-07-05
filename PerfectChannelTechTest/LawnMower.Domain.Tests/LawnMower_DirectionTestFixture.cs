using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Device.Location;
using LawnMower.Domain.Model;

namespace LawnMower.Domain.Tests
{
    [TestClass]
    public class LawnMower_DirectionTestFixture
    {
        [TestMethod]
        public void Ensure_Lawnmower_ChangeDirection_L_Returns_West_For_Current_Direction_North()
        {
            var lawnMower = new LawnMowerModel()
            {
                Position = new GeoCoordinate(1, 2),
                Direction = Directions.North
            };

            lawnMower.Direction = new LawnmowerInstructions().ChangeDirection("L", lawnMower.Direction);

            Assert.AreEqual(lawnMower.Direction, Directions.West);
        }

        [TestMethod]
        public void Ensure_Lawnmower_ChangeDirection_L_Returns_South_For_Current_Direction_West()
        {
            var lawnMower = new LawnMowerModel()
            {
                Position = new GeoCoordinate(1, 2),
                Direction = Directions.West
            };

            lawnMower.Direction = new LawnmowerInstructions().ChangeDirection("L", lawnMower.Direction);

            Assert.AreEqual(lawnMower.Direction, Directions.South);
        }

        [TestMethod]
        public void Ensure_Lawnmower_ChangeDirection_L_Returns_East_For_Current_Direction_South()
        {
            var lawnMower = new LawnMowerModel()
            {
                Position = new GeoCoordinate(1, 2),
                Direction = Directions.South
            };

            lawnMower.Direction = new LawnmowerInstructions().ChangeDirection("L", lawnMower.Direction);

            Assert.AreEqual(lawnMower.Direction, Directions.East);
        }

        [TestMethod]
        public void Ensure_Lawnmower_ChangeDirection_L_Returns_North_For_Current_Direction_East()
        {
            var lawnMower = new LawnMowerModel()
            {
                Position = new GeoCoordinate(1, 2),
                Direction = Directions.East
            };

            lawnMower.Direction = new LawnmowerInstructions().ChangeDirection("L", lawnMower.Direction);

            Assert.AreEqual(lawnMower.Direction, Directions.North);
        }

        [TestMethod]
        public void Ensure_Lawnmower_ChangeDirection_R_Returns_East_For_Current_Direction_North()
        {
            var lawnMower = new LawnMowerModel()
            {
                Position = new GeoCoordinate(1, 2),
                Direction = Directions.North
            };

            lawnMower.Direction = new LawnmowerInstructions().ChangeDirection("L", lawnMower.Direction);

            Assert.AreEqual(lawnMower.Direction, Directions.West);
        }

        [TestMethod]
        public void Ensure_Lawnmower_ChangeDirection_R_Returns_North_For_Current_Direction_West()
        {
            var lawnMower = new LawnMowerModel()
            {
                Position = new GeoCoordinate(1, 2),
                Direction = Directions.West
            };

            lawnMower.Direction = new LawnmowerInstructions().ChangeDirection("R", lawnMower.Direction);

            Assert.AreEqual(lawnMower.Direction, Directions.North);
        }

        [TestMethod]
        public void Ensure_Lawnmower_ChangeDirection_R_Returns_West_For_Current_Direction_South()
        {
            var lawnMower = new LawnMowerModel()
            {
                Position = new GeoCoordinate(1, 2),
                Direction = Directions.South
            };

            lawnMower.Direction = new LawnmowerInstructions().ChangeDirection("R", lawnMower.Direction);

            Assert.AreEqual(lawnMower.Direction, Directions.West);
        }

        [TestMethod]
        public void Ensure_Lawnmower_ChangeDirection_R_Returns_South_For_Current_Direction_East()
        {
            var lawnMower = new LawnMowerModel()
            {
                Position = new GeoCoordinate(1, 2),
                Direction = Directions.East
            };

            lawnMower.Direction = new LawnmowerInstructions().ChangeDirection("R", lawnMower.Direction);

            Assert.AreEqual(lawnMower.Direction, Directions.South);
        }
    }
}
