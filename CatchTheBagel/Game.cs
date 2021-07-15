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
        private int CurrentPoints;
        private int CurrentLevel;
        private int BagelCount;
        private int LevelPoints;
        private int PlayerSpeed;

        private int SpriteSpeed;

        // keeps track of how many boosts a level can have
        // and how many are left that will spawn
        private int PointBoosts;
        private int LifeBoosts;
        private int BadBoosts;
        //TODO: bad boost


        //TODO: declare id's here so they can be used
        private int IDPBooster;
        private int IDLBooster;
        private int IDBagel;
        private int IDBBooster;

        Random rng = new Random();

        //keeps track of the various things that need to be drawn
        public Dictionary<int, PointBooster> AllPBoosters { get; set; }
        public Dictionary<int, Bagel> AllBagels { get; set; }
        public Dictionary<int, LifeBooster> AllLBoosters { get; set; }
        public Dictionary<int, BadBooster> AllBBoosters { get; set; }


        private Player player;

        public Game()
        {
            LivesLeft = Constants.STARTLIVES;
            PointBoosts = 0;
            LifeBoosts = 0;
            BadBoosts = 0;

            CurrentPoints = 0;
            CurrentLevel = 1;
            BagelCount = 0;

            LevelPoints = Constants.POINTSL1;
            PlayerSpeed = Constants.INITIAL_P_SPEED;

            SpriteSpeed = Constants.SPRITE_SPEED1;

            //initialize id's so they can be used
            IDPBooster = 0;
            IDLBooster = 0;
            IDBagel = 0;
            IDBBooster = 0;

            AllPBoosters = new Dictionary<int, PointBooster>();
            AllBagels = new Dictionary<int, Bagel>();
            AllLBoosters = new Dictionary<int, LifeBooster>();
            AllBBoosters = new Dictionary<int, BadBooster>();

            player = new Player(0, 0, 700); //start player on the left
        }

        /// <summary>
        /// Gets the count of how many bagels the player has collected
        /// </summary>
        /// <returns></returns>
        public int getBagelCount()
        {
            return BagelCount;
        }

        /// <summary>
        /// Returns the player
        /// </summary>
        /// <returns></returns>
        public Player GetPlayer()
        {
            return player;
        }

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
            LivesLeft += (life);
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
        /// Increase the level of the game and make additional changes to points, boosts, and perks to a new level
        /// </summary>
        public void ChangeLevel()
        {
            CurrentLevel += 1;
            PlayerSpeed += 2; //TODO: how fast you want to increase the speed

            switch (CurrentLevel)
            {
                case 2:
                    LevelPoints = Constants.POINTSL2;
                    SpriteSpeed = Constants.SPRITE_SPEED2;
                    break;
                case 3:
                    LevelPoints = Constants.POINTSL3;
                    SpriteSpeed = Constants.SPRITE_SPEED3;
                    break;
                case 4:
                    LevelPoints = Constants.POINTSL4;
                    SpriteSpeed = Constants.SPRITE_SPEED4;
                    break;
                case 5:
                    LevelPoints = Constants.POINTSL5;
                    SpriteSpeed = Constants.SPRITE_SPEED5;
                    break;
                case 6:
                    LevelPoints = Constants.POINTSL6;
                    SpriteSpeed = Constants.SPRITE_SPEED6;
                    break;
                case 7:
                    LevelPoints = Constants.POINTSL7;
                    SpriteSpeed = Constants.SPRITE_SPEED7;
                    break;
                case 8:
                    LevelPoints = Constants.POINTSL8;
                    SpriteSpeed = Constants.SPRITE_SPEED8;
                    break;
                case 9:
                    LevelPoints = Constants.POINTSL9;
                    SpriteSpeed = Constants.SPRITE_SPEED9;
                    break;
                case 10:
                    LevelPoints = Constants.POINTSL10;
                    SpriteSpeed = Constants.SPRITE_SPEED10;
                    break;
            }
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

        /*SECTION THAT DEALS WITH BAGELS*/

        /// <summary>
        /// Adds bagels in the bagel when needed
        /// </summary>
        public void AddBagel()
        {
            int randX = rng.Next(30, 795);

            AllBagels.Add(IDBagel, new Bagel(IDBagel, randX, 0));
            this.IDBagel++;

        }

        /// <summary>
        /// Moves bagels to its new position
        /// </summary>
        public void MoveBagels()
        {
            lock (AllBagels)
            {
                foreach (Bagel b in AllBagels.Values)
                    b.SetPointY(b.GetPointY() + SpriteSpeed); //TODO: do i need to put this in the game?
            }
        }


        /// <summary>
        /// Checks whether bagels need to be removed because they hit the ground, or hit a player. updates in life and points
        /// </summary>
        public void CheckBagels()
        {
            //+50 here length
            int playerX = player.GetPointX();
            //+50 here for the width
            int playerY = player.GetPointY();

            List<int> itemsToRemove = new List<int>();

            lock (AllBagels)
            {
                foreach (Bagel b in AllBagels.Values)
                {
                    int bagelX = b.GetPointX();
                    int bagelY = b.GetPointY();

                    if (bagelY >= 690)
                    {
                        itemsToRemove.Add(b.GetID());
                        SetLife(-1);
                    }
                    else if ((playerX - 50 <= bagelX && playerX + 50 >= bagelX) && bagelY + 48 >= 690)
                    {
                        itemsToRemove.Add(b.GetID());
                        ChangePoints(+LevelPoints);
                        // helps with leveling up
                        BagelCount++;
                    }
                }
            }

            lock (AllBagels)
            {
                for (int i = 0; i < itemsToRemove.Count; i++)
                    AllBagels.Remove(itemsToRemove[i]);
            }
        }

        /*SECTION THAT DEALS WITH POINT BOOSTS*/

        /// <summary>
        /// Adds a point booster into the game
        /// </summary>
        public void AddPointBoost()
        {
            int randX = rng.Next(30, 795);

            //TODO: check level, whether if it has a point boost or not
            AllPBoosters.Add(IDPBooster, new PointBooster(IDPBooster, randX, 0));
            this.IDPBooster++;
        }

        /// <summary>
        /// Moves a point booster throughout the game
        /// </summary>
        public void MovePointBoost()
        {
            lock (AllPBoosters)
            {
                foreach (PointBooster p in AllPBoosters.Values)
                    p.SetPointY(p.GetPointY() + SpriteSpeed); //TODO: do i need to put this in the game?
            }
        }

        /// <summary>
        /// Checks which point booster needs to be removed and have points added
        /// </summary>
        public void CheckPointBoost()
        {
            //+50 here length
            int playerX = player.GetPointX();
            //+50 here for the width
            int playerY = player.GetPointY();

            List<int> itemsToRemove = new List<int>();

            lock (AllPBoosters)
            {
                foreach (PointBooster p in AllPBoosters.Values)
                {
                    int pointBX = p.GetPointX();
                    int pointBY = p.GetPointY();

                    if (pointBY >= 690)
                        itemsToRemove.Add(p.GetID());
                    else if ((playerX - 50 <= pointBX && playerX + 50 >= pointBX) && pointBY + 48 >= 690)
                    {
                        itemsToRemove.Add(p.GetID());
                        ChangePoints(+LevelPoints * CurrentLevel * 10);
                    }
                }
            }

            lock (AllPBoosters)
            {
                for (int i = 0; i < itemsToRemove.Count; i++)
                    AllPBoosters.Remove(itemsToRemove[i]);
            }
        }

        /*SECTION THAT DEALS WITH LIFE BOOSTS*/
        /// <summary>
        /// Adds a life boost in the game
        /// </summary>
        public void AddLifeBoost()
        {
            int randX = rng.Next(30, 795);

            //TODO: level, and amount of life boosts
            AllLBoosters.Add(IDLBooster, new LifeBooster(IDLBooster, randX, 0));
            this.IDLBooster++;
        }

        /// <summary>
        /// Moves a lifeboost in the game
        /// </summary>
        public void MoveLifeBoost()
        {
            lock (AllLBoosters)
            {
                foreach (LifeBooster l in AllLBoosters.Values)
                    l.SetPointY(l.GetPointY() + SpriteSpeed);
            }
        }

        /// <summary>
        /// Checks which life booster needs to be removed, and whether a life needs
        /// to be added
        /// </summary>
        public void CheckLifeBoost()
        {
            //+50 here length
            int playerX = player.GetPointX();
            //+50 here for the width
            int playerY = player.GetPointY();

            List<int> itemsToRemove = new List<int>();

            lock (AllLBoosters)
            {
                foreach (LifeBooster l in AllLBoosters.Values)
                {
                    int pointLX = l.GetPointX();
                    int pointLY = l.GetPointY();

                    if (pointLY >= 690)
                        itemsToRemove.Add(l.GetID());
                    else if ((playerX - 50 <= pointLX && playerX + 50 >= pointLX) && pointLY + 48 >= 690)
                    {
                        itemsToRemove.Add(l.GetID());
                        LivesLeft += 1;
                    }
                }
            }

            lock (AllLBoosters)
            {
                for (int i = 0; i < itemsToRemove.Count; i++)
                    AllLBoosters.Remove(itemsToRemove[i]);
            }
        }



        /*SECTION THAT DEALS WITH BAD BOOSTS*/

        /// <summary>
        /// Adds a bad booster to the game
        /// </summary>
        public void AddBadBoost() {
            int randX = rng.Next(30, 795);

            //TODO: level, and amount of bad boosts
            AllBBoosters.Add(IDBBooster, new BadBooster(IDBBooster, randX, 0));
            this.IDBBooster++;
        }

        /// <summary>
        /// Moves the bad booster
        /// </summary>
        public void MoveBadBoost() {
            lock (AllBBoosters)
            {
                foreach (BadBooster b in AllBBoosters.Values)
                    b.SetPointY(b.GetPointY() + SpriteSpeed);
            }
        }

        /// <summary>
        /// Checks whether the bad booster needs to be moved and deduct a life from 
        /// the player if it is caught
        /// </summary>
        public void CheckBadBoost() {
            //+50 here length
            int playerX = player.GetPointX();
            //+50 here for the width
            int playerY = player.GetPointY();

            List<int> itemsToRemove = new List<int>();

            lock (AllBBoosters)
            {
                foreach (BadBooster b in AllBBoosters.Values)
                {
                    int pointBX = b.GetPointX();
                    int pointBY = b.GetPointY();

                    if (pointBY >= 690)
                        itemsToRemove.Add(b.GetID());
                    else if ((playerX - 50 <= pointBX && playerX + 50 >= pointBX) && pointBY + 48 >= 690)
                    {
                        itemsToRemove.Add(b.GetID());
                        LivesLeft -= 1;
                    }
                }
            }

            lock (AllBBoosters)
            {
                for (int i = 0; i < itemsToRemove.Count; i++)
                    AllBBoosters.Remove(itemsToRemove[i]);
            }
        }

        /*SECTION THAT DEALS WITH THE PLAYER*/

        /// <summary>
        /// Moves the player when the arrow keys are moving it
        /// </summary>
        public void MovePlayer(string movement)
        {
            int x = player.GetPointX();

            lock (player)
            {
                if (movement == "left" && x > 0)
                    player.SetPointX(x - PlayerSpeed);
                else if (movement == "right" && x < 825)
                    player.SetPointX(x + PlayerSpeed);
                else if (x <= 0)
                    player.SetPointX(825);
                else if (x >= 825)
                    player.SetPointX(0);
            }
        }


        /// <summary>
        /// Checks whether a player can level up based on the bagels they have caught
        /// </summary>
        public void CheckLevelUp()
        {

            if (BagelCount == 15 && CurrentLevel == 1)
            {
                ChangeLevel();
            }
            else if (BagelCount == 30 && CurrentLevel == 2)
            {
                ChangeLevel();
            }
            else if (BagelCount == 45 && CurrentLevel == 3)
            {
                ChangeLevel();
            }
            else if (BagelCount == 60 && CurrentLevel == 4)
            {
                ChangeLevel();
            }
            else if (BagelCount == 75 && CurrentLevel == 5)
            {
                ChangeLevel();
            }
            else if (BagelCount == 90 && CurrentLevel == 6)
            {
                ChangeLevel();
            }
            else if (BagelCount == 105 && CurrentLevel == 7)
            {
                ChangeLevel();
            }
            else if (BagelCount == 120 && CurrentLevel == 8)
            {
                ChangeLevel();
            }
            else if (BagelCount == 135 && CurrentLevel == 9)
            {
                ChangeLevel();
            }
            else if (BagelCount >= 150)
            {
                //TODO say you won or something, idk
            }

        }

        /// <summary>
        /// Checks if there are no remaining lives and clears all dictionaries
        /// </summary>
        public bool CheckGameOver()
        {
            if (LivesLeft <= 0)
            {
                //clear all dictionaries
                return true;
            }

            CheckLevelUp(); //TODO: not sure where to put this for now
            return false;
        }

    }
}
