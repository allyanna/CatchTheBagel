// Implemented by Allyanna Boo
// Last updated: May 22, 2021
using System;

namespace CatchTheBagel
{
    /// <summary>
    /// The controller handles the logic for the CatchTheBagel game, storing all the needed lives, powerups, 
    /// points to be displayed for the view
    /// </summary>
    public class Controller
    {

        // TODO:: ADD needed variables here
        private int livesLeft;
        private int PointBooster;


        public Controller()
        {
            livesLeft = 3;
            PointBooster = 0;
        }

        /// <summary>
        /// Sets the life of the player
        /// </summary>
        /// <param name="currentLife"></param>
        public void SetLife(int currentLife)
        {
            livesLeft = currentLife;
        }

        /// <summary>
        /// Gets the life of the player
        /// </summary>
        /// <returns></returns>
        public int GetLife()
        {
            return livesLeft;
        }

        /// <summary>
        /// Adds a point booster powerup the player can use
        /// </summary>
        public void AddPointBooster()
        {
            PointBooster = PointBooster + 1;
        }


    }
}
