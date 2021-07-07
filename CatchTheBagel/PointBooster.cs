using System;
using System.Collections.Generic;
using System.Text;

namespace CatchTheBagel
{
    /// <summary>
    /// Represents a point booster where a player has the ability to earn more points 
    /// when they catch bagels for a certain amount of time
    /// </summary>
    public class PointBooster : BaseClass
    {
        public PointBooster() { 
            //defaults?
        }

        public PointBooster(int ID, int pointX, int pointY)
        {
            this.ID = ID;
            this.pointX = pointX;
            this.pointY = pointY;
        }


        //what else does the point booster need besides 
        //the base class?
    }
}
