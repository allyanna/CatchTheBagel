using System;
using System.Collections.Generic;
using System.Text;

namespace CatchTheBagel
{
    // <summary>
    /// Represents a bagel in the game where the player can earn points from
    /// </summary>
    public class BaseClass
    {

        protected int ID;
        protected int pointX;
        protected int pointY;

        public BaseClass()
        {
            //defaults?
        }

        public BaseClass(int ID, int pointX, int pointY)
        {
            this.ID = ID;
            this.pointX = pointX;
            this.pointY = pointY;
        }

        /// <summary>
        /// Gets the ID of the bagel
        /// </summary>
        /// <returns></returns>
        public int GetID()
        {
            return ID;
        }

        /// <summary>
        /// Gets the x position of the bagel
        /// </summary>
        /// <returns></returns>
        public int GetPointX()
        {
            return pointX;
        }

        /// <summary>
        /// Sets the new position of X
        /// </summary>
        /// <param name="x"></param>
        public void SetPointX(int x)
        {
            pointX = x;
        }

        /// <summary>
        /// Gets the y position of the bagel
        /// </summary>
        /// <returns></returns>
        public int GetPointY()
        {
            return pointY;
        }

        /// <summary>
        /// Sets the new position of y
        /// </summary>
        /// <param name="y"></param>
        public void SetPointY(int y)
        {
            pointY = y;
        }
    }
}
