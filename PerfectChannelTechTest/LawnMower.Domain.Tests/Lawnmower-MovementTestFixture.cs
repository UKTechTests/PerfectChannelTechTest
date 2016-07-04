using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LawnMower.Domain.Model;
using System.Device.Location;

namespace LawnMower.Domain.Tests
{
    /// <summary>
    /// Summary description for Lawnmower_MovementTestFixture
    /// </summary>
    [TestClass]
    public class Lawnmower_MovementTestFixture
    {
        [TestMethod]
        public void Ensure_Longitude_Increments_By_One_When_Moving_North()
        {
            var longitude = 5;
            var lawnMower = new LawnMowerModel()
            {
                Direction = Directions.North,
                Position = new GeoCoordinate(2, longitude)
            };

            lawnMower = new LawnMower().MoveForward(lawnMower);

            Assert.AreEqual(lawnMower.Position.Longitude, longitude+=1);
        }

        [TestMethod]
        public void Ensure_Longitude_Decrements_By_One_When_Moving_South()
        {
            var longitude = 5;
            var lawnMower = new LawnMowerModel()
            {
                Direction = Directions.South,
                Position = new GeoCoordinate(2, longitude)
            };

            lawnMower = new LawnMower().MoveForward(lawnMower);

            Assert.AreEqual(lawnMower.Position.Longitude, longitude-=1);
        }

        [TestMethod]
        public void Ensure_Latitude_Increments_By_One_When_Moving_East()
        {
            var latitude = 5;
            var lawnMower = new LawnMowerModel()
            {
                Direction = Directions.East,
                Position = new GeoCoordinate(latitude, 5)
            };

            lawnMower = new LawnMower().MoveForward(lawnMower);

            Assert.AreEqual(lawnMower.Position.Latitude, latitude+=1);
        }

        [TestMethod]
        public void Ensure_Latitude_Decrements_By_One_When_Moving_West()
        {
            var latitude = 5;
            var lawnMower = new LawnMowerModel()
            {
                Direction = Directions.West,
                Position = new GeoCoordinate(latitude, 5)
            };

            lawnMower = new LawnMower().MoveForward(lawnMower);

            Assert.AreEqual(lawnMower.Position.Latitude, latitude-=1);
        }
    }
}
