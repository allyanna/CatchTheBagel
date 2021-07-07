using System;

namespace CatchTheBagel
{
    /// <summary>
    /// Represents a bagel in the game where the player can earn points from
    /// </summary>
    public class Bagel : BaseClass
    {

        public Bagel()
        {
            //defaults?
        }

        public Bagel(int ID, int pointX, int pointY)
        {
            this.ID = ID;
            this.pointX = pointX;
            this.pointY = pointY;
        }
    }
}
