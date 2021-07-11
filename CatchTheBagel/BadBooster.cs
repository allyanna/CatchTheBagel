using System;
using System.Collections.Generic;
using System.Text;

namespace CatchTheBagel
{
    /// <summary>
    /// Represents a bad boost that brings down a players points (along with its life maybe)
    /// </summary>
    public class BadBooster : BaseClass
    {
        public BadBooster()
        {
            //defaults?
        }

        public BadBooster(int ID, int pointX, int pointY)
        {
            this.ID = ID;
            this.pointX = pointX;
            this.pointY = pointY;
        }
    }
}
