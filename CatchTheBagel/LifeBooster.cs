using System;
using System.Collections.Generic;
using System.Text;

namespace CatchTheBagel
{
    /// <summary>
    /// Represents a life booster where a player can increase its life count with
    /// </summary>
    public class LifeBooster : BaseClass
    {


        public LifeBooster()
        {
            //defautls?
        }
        public LifeBooster(int ID, int pointX, int pointY)
        {
            this.ID = ID;
            this.pointX = pointX;
            this.pointY = pointY;
        }

    }
}
