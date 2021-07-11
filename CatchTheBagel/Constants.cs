using System;
using System.Collections.Generic;
using System.Text;

namespace CatchTheBagel
{
    /// <summary>
    /// Stores all the necessary constants used for the Catch the Bagel game
    /// </summary>
    public static class Constants
    {
        public const int SCREENSIZE = 900 - 25; //875
        public const int STARTLIVES = 3;

        // points players earn at each level //can just increment in the game
        public const int POINTSL1 = 5;
        public const int POINTSL2 = 10;
        public const int POINTSL3 = 15;
        public const int POINTSL4 = 20;
        public const int POINTSL5 = 25;
        public const int POINTSL6 = 30;
        public const int POINTSL7 = 35;
        public const int POINTSL8 = 40;
        public const int POINTSL9 = 45;
        public const int POINTSL10 = 50;

        // player speeds **********maybe leave these as incremental in game
        public const int INITIAL_P_SPEED = 10;

        // sprite speeds
        public const int SPRITE_SPEED1 = 1;
        public const int SPRITE_SPEED2 = 2;
        public const int SPRITE_SPEED3 = 3;
        public const int SPRITE_SPEED4 = 4;
        public const int SPRITE_SPEED5 = 5;
        public const int SPRITE_SPEED6 = 6;
        public const int SPRITE_SPEED7 = 7;
        public const int SPRITE_SPEED8 = 8;
        public const int SPRITE_SPEED9 = 9;
        public const int SPRITE_SPEED10 = 10;


        // number of point boosters (level 5 and up)

        // number of life boosters (level 5 and up)

        // number of clear bagel boosters (level 5 and up)
    }
}