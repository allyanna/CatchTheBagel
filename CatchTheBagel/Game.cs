using System;
using System.Collections.Generic;
using System.Text;

namespace CatchTheBagel
{
    /// <summary>
    /// Represents the whole game such as the player, life boosters, point boosters, 
    /// and items detrimental to the player
    /// </summary>
    public class Game
    {

        // TODO:: ADD needed variables here
        private int LivesLeft;
        private int PointBooster;
        private int CurrentPoints;
        private int CurrentLevel;

        //TODO: declare id's here so they can be used
        private int IDPBooster;
        private int IDLBooster;
        private int IDBagel;

        Random rng = new Random();

        //keeps track of the various things that need to be drawn
        public Dictionary<int, PointBooster> AllPBoosters { get; set; }
        public Dictionary<int, Bagel> AllBagels { get; set; }
        public Dictionary<int, LifeBooster> AllLBoosters { get; set; }
        //TODO: bad boost


        private Player player;

        public Game()
        {
            LivesLeft = Constants.STARTLIVES;
            PointBooster = 0;
            CurrentPoints = 0;
            CurrentLevel = 1;

            //initialize id's so they can be used
            IDPBooster = 0;
            IDLBooster = 0;
            IDBagel = 0;

            AllPBoosters = new Dictionary<int, PointBooster>();
            AllBagels = new Dictionary<int, Bagel>();
            AllLBoosters = new Dictionary<int, LifeBooster>();



            player = new Player(0, 0, 700); //TODO: need to move it

        }

        /// <summary>
        /// Returns the player
        /// </summary>
        /// <returns></returns>
        public Player GetPlayer()
        {
            return player;
        }
        //TODO:: what components does a game have?
        //it must keep track of everything just like how we did in the 
        //tankwars controller?? hmm we'll have to sketch this out or something

        /// <summary>
        /// Gets the number of lives the player has left
        /// </summary>
        /// <returns>the players life count</returns>
        public int GetLivesLeft()
        {
            return LivesLeft;
        }

        /// <summary>
        /// Changes whether the player earns a life or loses a life
        /// </summary>
        /// <returns></returns>
        public void SetLife(int life)
        {
            LivesLeft = LivesLeft + (life);
            //TODO::do i check if the player reached zero here or somewhere else
        }

        /// <summary>
        /// Get the current level of the game
        /// </summary>
        /// <returns></returns>
        public int GetCurrentLevel()
        {
            return CurrentLevel;
        }

        /// <summary>
        /// Increase the level of the game
        /// </summary>
        public void IncreaseLevel()
        {
            //TODO:: decide what we need to do when it hits level 11
            //do we end it here or the view???
            CurrentLevel = CurrentLevel + 1;
        }

        /// <summary>
        /// Gets the current amount of points a player has
        /// </summary>
        /// <returns></returns>
        public int GetPoints()
        {
            return CurrentPoints;
        }

        /// <summary>
        /// Changes the amount of points a player has by increasing
        /// or decreasing it
        /// </summary>
        /// <param name="pAmount"></param>
        public void ChangePoints(int pAmount)
        {
            CurrentPoints = CurrentPoints + (pAmount); //TODO:: do we check here or something ugh
        }

        //**********************************making changes to the dictionaries*******************************//
        /// <summary>
        /// Adds bagels in the bagel when needed
        /// </summary>
        public void AddBagel()
        {
            int randX = rng.Next(20, 840);
            int check = rng.Next(10);

            if (check % 2 == 0)
            {
                AllBagels.Add(IDBagel, new Bagel(IDBagel, randX, 0));
                this.IDBagel++;
            }
        }

        /// <summary>
        /// Moves the player when the arrow keys are moving it
        /// </summary>
        public void MovePlayer(string movement)
        {
            int x = player.GetPointX();

            lock (player)
            {
                if (movement == "left" && x > 0)
                    player.SetPointX(x - 1);
                else if (movement == "right" && x < 825)
                    player.SetPointX(x + 1); ;
            }
        }


    }
}
