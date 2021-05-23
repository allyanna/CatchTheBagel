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
        private int powerups;


        public Controller()
        {
            livesLeft = 3;
            powerups = 0;
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
        public int getLife()
        {
            return livesLeft;
        }

        /// <summary>
        /// Adds a powerup the player can use
        /// </summary>
        public void addPower()
        {
            powerups = powerups + 1;
        }


    }
}
