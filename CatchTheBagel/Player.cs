using System;
using System.Collections.Generic;
using System.Text;

namespace CatchTheBagel
{
    /// <summary>
    /// Represents a player
    /// </summary>
    public class Player : BaseClass
    {
        public Player() { }

        public Player(int ID, int pointX, int pointY)
        {
            this.ID = ID;
            this.pointX = pointX;
            this.pointY = pointY;
        }

        //does the player need to keep track of anything or should it just be an object component 
        //that stores its location etc...?? hmmmmmm
    }
}
