using LawnMower.Domain.Model;
using System.Device.Location;

namespace LawnMower.Client
{
    public class Instructions
    {
        //private LawnModel lawn = new LawnModel(new GeoCoordinate(0, 0));
        //private IList<LawnMowerModel> lawnMowers = new List<LawnModel>;

       

        public void SetLawnDimensions(GeoCoordinate rightCorner)
        {
            //lawn.Dimensions.UpperRightCorner = rightCorner;
        }

        public void SetNumberOfLawnMowers(int numberOfMowers)
        {
            for(int mower = 1; mower <= numberOfMowers; mower++)
            {
                //lawnMowers.Add(new LawnMowerModel());
            }
        }
    }
}
