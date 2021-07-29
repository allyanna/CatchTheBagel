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

        // ADD needed variables here
        private int LivesLeft;
        private int CurrentPoints;
        private int CurrentLevel;
        private int BagelCount;
        private int LevelPoints;
        private int PlayerSpeed;

        private int SpriteSpeed;
        private int BagelAddSpeed;
        private int SpriteUpdateSpeed;

        // keeps track of how many boosts a level can have
        // and how many are left that will spawn
        private int PBoostCounts;
        private int LBoostCounts;
        private int BBoostCounts;

        //declare id's here so they can be used
        private int IDPBooster;
        private int IDLBooster;
        private int IDBagel;
        private int IDBBooster;

        // checks
        public bool PauseGame;
        public bool WonGame;

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
            PBoostCounts = 0;
            LBoostCounts = 0;
            BBoostCounts = 0;

            CurrentPoints = 0;
            CurrentLevel = 1;
            BagelCount = 0;

            LevelPoints = Constants.POINTSL1;
            PlayerSpeed = Constants.INITIAL_P_SPEED;

            SpriteSpeed = Constants.SPRITE_SPEED1;
            BagelAddSpeed = Constants.BAG_ADD_S1;
            SpriteUpdateSpeed = Constants.BAG_UPDATE1;

            //initialize id's so they can be used
            IDPBooster = 0;
            IDLBooster = 0;
            IDBagel = 0;
            IDBBooster = 0;

            AllPBoosters = new Dictionary<int, PointBooster>();
            AllBagels = new Dictionary<int, Bagel>();
            AllLBoosters = new Dictionary<int, LifeBooster>();
            AllBBoosters = new Dictionary<int, BadBooster>();

            PauseGame = false;
            WonGame = false;

            player = new Player(0, 0, 680); //start player on the left TODO
        }

        /// <summary>
        /// Returns whether you won the game
        /// </summary>
        /// <returns></returns>
        public bool GetWonGame()
        {
            return WonGame;
        }

        /// <summary>
        /// Sets whether a game is paused currently
        /// </summary>
        /// <param name="set"></param>
        public void SetPauseGame(bool set)
        {
            PauseGame = set;
        }

        /// <summary>
        /// Returns whether a game is paused
        /// </summary>
        /// <returns></returns>
        public bool GetPauseGame()
        {
            return PauseGame;
        }

        /// <summary>
        /// Returns the speed that bagels are being added
        /// </summary>
        /// <returns></returns>
        public int GetBagelAddSpeed()
        {
            return BagelAddSpeed;
        }

        /// <summary>
        /// Returns the speed that boosts and bagels are being updated
        /// </summary>
        /// <returns></returns>
        public int GetSpriteUpdateSpeed()
        {
            return SpriteUpdateSpeed;
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
            switch (CurrentLevel)
            {
                case 2:
                    UpdateFields(Constants.POINTSL2, Constants.SPRITE_SPEED2, Constants.BAG_ADD_S2, Constants.BAG_UPDATE2, 0, 0, 0);
                    break;
                case 3:
                    UpdateFields(Constants.POINTSL3, Constants.SPRITE_SPEED3, Constants.BAG_ADD_S3, Constants.BAG_UPDATE3, 0, 0, 0);
                    break;
                case 4:
                    UpdateFields(Constants.POINTSL4, Constants.SPRITE_SPEED4, Constants.BAG_ADD_S4, Constants.BAG_UPDATE4, 0, 0, 0);
                    break;
                case 5:
                    UpdateFields(Constants.POINTSL5, Constants.SPRITE_SPEED5, Constants.BAG_ADD_S5, Constants.BAG_UPDATE5, Constants.P_BOOST5, Constants.L_BOOST5, Constants.B_BOOST5);
                    break;
                case 6:
                    UpdateFields(Constants.POINTSL6, Constants.SPRITE_SPEED6, Constants.BAG_ADD_S6, Constants.BAG_UPDATE6, Constants.P_BOOST6, Constants.L_BOOST6, Constants.B_BOOST6);
                    break;
                case 7:
                    UpdateFields(Constants.POINTSL7, Constants.SPRITE_SPEED7, Constants.BAG_ADD_S7, Constants.BAG_UPDATE7, Constants.P_BOOST7, Constants.L_BOOST7, Constants.B_BOOST7);
                    break;
                case 8:
                    UpdateFields(Constants.POINTSL8, Constants.SPRITE_SPEED8, Constants.BAG_ADD_S8, Constants.BAG_UPDATE5, Constants.P_BOOST8, Constants.L_BOOST8, Constants.B_BOOST8);

                    break;
                case 9:
                    UpdateFields(Constants.POINTSL9, Constants.SPRITE_SPEED9, Constants.BAG_ADD_S9, Constants.BAG_UPDATE9, Constants.P_BOOST9, Constants.L_BOOST9, Constants.B_BOOST9);
                    break;
                case 10:
                    UpdateFields(Constants.POINTSL10, Constants.SPRITE_SPEED10, Constants.BAG_ADD_S10, Constants.BAG_UPDATE10, Constants.P_BOOST10, Constants.L_BOOST10, Constants.B_BOOST10);
                    break;
            }
        }

        /// <summary>
        /// Updates the fields wyhen a level changes
        /// </summary>
        /// <param name="LevelPoints"></param>
        /// <param name="SpriteSpeed"></param>
        /// <param name="BagelAddSpeed"></param>
        /// <param name="SpriteUpdateSpeed"></param>
        /// <param name="PBoostCounts"></param>
        /// <param name="LBoostCounts"></param>
        /// <param name="BBoostCount"></param>
        public void UpdateFields(int LevelPoints, int SpriteSpeed, int BagelAddSpeed, int SpriteUpdateSpeed, int PBoostCounts, int LBoostCounts, int BBoostCount)
        {
            lock (AllBagels)
                AllBagels.Clear();

            lock (AllPBoosters)
                AllPBoosters.Clear();

            lock (AllLBoosters)
                AllLBoosters.Clear();

            lock (AllBBoosters)
                AllBBoosters.Clear();

            this.LevelPoints = LevelPoints;
            this.SpriteSpeed = SpriteSpeed;
            this.BagelAddSpeed = BagelAddSpeed;
            this.SpriteUpdateSpeed = SpriteUpdateSpeed;
            // boosts
            this.PBoostCounts = PBoostCounts;
            this.LBoostCounts = LBoostCounts;
            this.BBoostCounts = BBoostCount;

            PlayerSpeed = PlayerSpeed + 1;

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
            CurrentPoints = CurrentPoints + (pAmount);
        }

        //**********************************making changes to the dictionaries*******************************//

        /*SECTION THAT DEALS WITH BAGELS*/

        /// <summary>
        /// Adds bagels in the bagel when needed
        /// </summary>
        public void AddBagel()
        {
            int randX = rng.Next(Constants.MINX, Constants.MAXX);

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
                {
                    b.SetPointY(b.GetPointY() + SpriteSpeed); //TODO: do i need to put this in the game?

                    if (CurrentLevel == 10)
                    {
                        if (b.GetPointX() % 2 == 0)
                            b.SetPointX(b.GetPointX() + 1);
                        else
                            b.SetPointX(b.GetPointX() - 1);
                    }

                }
            }
        }


        /// <summary>
        /// Checks whether bagels need to be removed because they hit the ground, or hit a player. updates in life and points
        /// </summary>
        public void CheckBagels()
        {
            int playerX = player.GetPointX();
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
                        if(!CheckGameOver() && !GetWonGame())
                        SetLife(-1);
                    }
                    else if ((playerX - Constants.PLAYERSIZE <= bagelX && playerX + Constants.PLAYERSIZE >= bagelX) && bagelY + (Constants.PLAYERSIZE - 2) >= 690)
                    {
                        itemsToRemove.Add(b.GetID());
                        if (!CheckGameOver() && !GetWonGame())
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
            int randX = rng.Next(Constants.MINX, Constants.MAXX);

            //TODO: check level, whether if it has a point boost or not
            if (LevelPoints >= 4 && PBoostCounts > 0 && CanBoost())
            {
                AllPBoosters.Add(IDPBooster, new PointBooster(IDPBooster, randX, 0));
                this.IDPBooster++;
                PBoostCounts--;
            }
        }

        /// <summary>
        /// Moves a point booster throughout the game
        /// </summary>
        public void MovePointBoost()
        {
            lock (AllPBoosters)
            {
                foreach (PointBooster p in AllPBoosters.Values)
                    p.SetPointY(p.GetPointY() + SpriteSpeed);
            }
        }

        /// <summary>
        /// Checks which point booster needs to be removed and have points added
        /// </summary>
        public void CheckPointBoost()
        {
            int playerX = player.GetPointX();
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
                    else if ((playerX - Constants.PLAYERSIZE <= pointBX && playerX + Constants.PLAYERSIZE >= pointBX) && pointBY + (Constants.PLAYERSIZE - 2) >= 690)
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
            int randX = rng.Next(Constants.MINX, Constants.MAXX);

            if (CurrentLevel >= 4 && LBoostCounts > 0 && CanBoost())
            {
                AllLBoosters.Add(IDLBooster, new LifeBooster(IDLBooster, randX, 0));
                this.IDLBooster++;
                LBoostCounts--;
            }
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
            int playerX = player.GetPointX();
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
                    else if ((playerX - Constants.PLAYERSIZE <= pointLX && playerX + Constants.PLAYERSIZE >= pointLX) && pointLY + (Constants.PLAYERSIZE - 2) >= 690)
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
        public void AddBadBoost()
        {
            int randX = rng.Next(Constants.MINX, Constants.MAXX);

            if (CurrentLevel >= 4 && BBoostCounts > 0 && CanBoost())
            {
                AllBBoosters.Add(IDBBooster, new BadBooster(IDBBooster, randX, 0));
                this.IDBBooster++;
                BBoostCounts--;
            }
        }

        /// <summary>
        /// Moves the bad booster
        /// </summary>
        public void MoveBadBoost()
        {
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
        public void CheckBadBoost()
        {
            int playerX = player.GetPointX();
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
                    else if ((playerX - Constants.PLAYERSIZE <= pointBX && playerX + Constants.PLAYERSIZE >= pointBX) && pointBY + (Constants.PLAYERSIZE - 2) >= 690)
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
                CurrentLevel++;
                BagelAddSpeed = 800;
                WonGame = true;
            }

            //TO TEST
            /*     if (BagelCount >= 135)
                 {
                     CurrentLevel = 9;
                     ChangeLevel();
                 }*/
        }

        /// <summary>
        /// Checks if there are no remaining lives and clears all dictionaries
        /// </summary>
        public bool CheckGameOver()
        {
            if (LivesLeft <= 0)
            {
                // TODO: clear all dictionaries
                BagelAddSpeed = 800;
                return true;
            }

            CheckLevelUp(); //TODO: not sure where to put this for now
            return false;
        }

        ////////////////////////////////////HELPERS/////////////////////////////////////////////
        ///
        /// <summary>
        /// Decides whether a boost can be added into the game
        /// </summary>
        /// <returns></returns>
        public bool CanBoost()
        {
            int rand = rng.Next(11);
            return rand % 5 == 0;
        }

    }
}
