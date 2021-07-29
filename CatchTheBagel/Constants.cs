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
        public const int PLAYERSIZE = 70;

        public const int SCREENSIZE = 900 - 25; //875
        public const int STARTLIVES = 3;

        public const int MINX = 1;
        public const int MAXX = 824;


        // points players earn at each level (can just increment in the game)
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

        // player speeds (incremented)
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
        public const int P_BOOST5 = 1;
        public const int P_BOOST6 = 2;
        public const int P_BOOST7 = 3;
        public const int P_BOOST8 = 4;
        public const int P_BOOST9 = 4;
        public const int P_BOOST10 = 4;


        // number of life boosters (level 5 and up)
        public const int L_BOOST5 = 1;
        public const int L_BOOST6 = 2;
        public const int L_BOOST7 = 2;
        public const int L_BOOST8 = 3;
        public const int L_BOOST9 = 4;
        public const int L_BOOST10 = 4;

        // numhber of bad boosters (level 5 and up)
        public const int B_BOOST5 = 1;
        public const int B_BOOST6 = 2;
        public const int B_BOOST7 = 2;
        public const int B_BOOST8 = 3;
        public const int B_BOOST9 = 3;
        public const int B_BOOST10 = 4;

        // number of clear bagel boosters (level 5 and up) NOT SURE IF WANT TO DO

        // speed of bagels being added 
        public const int BAG_ADD_S1 = 2800;
        public const int BAG_ADD_S2 = 2600;
        public const int BAG_ADD_S3 = 2400;
        public const int BAG_ADD_S4 = 2200;
        public const int BAG_ADD_S5 = 2000;
        public const int BAG_ADD_S6 = 1800;
        public const int BAG_ADD_S7 = 1600;
        public const int BAG_ADD_S8 = 1400;
        public const int BAG_ADD_S9 = 1200;
        public const int BAG_ADD_S10 = 1000;


        // speed of bagel movement update
        public const int BAG_UPDATE1 = 30;
        public const int BAG_UPDATE2 = 29;
        public const int BAG_UPDATE3 = 28;
        public const int BAG_UPDATE4 = 27;
        public const int BAG_UPDATE5 = 26;
        public const int BAG_UPDATE6 = 25;
        public const int BAG_UPDATE7 = 24;
        public const int BAG_UPDATE8 = 23;
        public const int BAG_UPDATE9 = 22;
        public const int BAG_UPDATE10 = 21;
    }
}