using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CatchTheBagel;



namespace View
{
    public partial class GameScreen : Form
    {
        Game game;
        GamePanel gamePanel;

        /* Tracks whent to add things */
        Timer BagelTime = new Timer();
        Timer PointTime = new Timer();
        Timer LifeTime = new Timer();
        Timer BadTime = new Timer();

        /* Updates */
        Timer UpdatePlayers = new Timer();
        Timer UpdateBoosts = new Timer();

        public GameScreen(int playerType, int bagelType)
        {
            InitializeComponent();

            game = new Game();

            // Set the window size
            ClientSize = new Size(Constants.SCREENSIZE, Constants.SCREENSIZE);
            this.CenterToScreen();
            BackColor = Color.Black;

            // Place and add the game panel components
            gamePanel = new GamePanel(game, playerType, bagelType);
            gamePanel.Location = new Point(0, 22); //TO mess with later
            gamePanel.Size = new Size(Constants.SCREENSIZE, Constants.SCREENSIZE);
            gamePanel.BackColor = Color.LightBlue;
            this.Controls.Add(gamePanel);
            this.Text = "Catch the Bagel";

            // Handles key presses and mouse presses
            KeyDown += KeyDownPressed;
            gamePanel.MouseClick += MouseClickedHandler;

            // Handles the intervals of movements needed
            BagelTime.Interval = Constants.BAG_ADD_S1;
            BagelTime.Start();
            BagelTime.Tick += BagelTick;

            PointTime.Interval = 5000;
            PointTime.Start();
            PointTime.Tick += PointTick;

            LifeTime.Interval = 7000;
            LifeTime.Start();
            LifeTime.Tick += LifeTick;

            BadTime.Interval = 8000;
            BadTime.Start();
            BadTime.Tick += BadTick;

            // Update the player and things unrelated to boosts
            UpdatePlayers.Interval = 10;
            UpdatePlayers.Start();
            UpdatePlayers.Tick += NonBoostUpdate;

            // Update all boosts
            UpdateBoosts.Interval = 30;
            UpdateBoosts.Start();
            UpdateBoosts.Tick += BoostsUpdate;

        }




        private void BadTick(object sender, EventArgs e)
        {
            if (!game.GetPauseGame() && !game.CheckGameOver())
                game.AddBadBoost();
        }

        private void LifeTick(object sender, EventArgs e)
        {
            if (!game.GetPauseGame() && !game.CheckGameOver())
                game.AddLifeBoost();
        }

        private void PointTick(object sender, EventArgs e)
        {
            if (!game.GetPauseGame() && !game.CheckGameOver())
                game.AddPointBoost();
        }

        /// <summary>
        /// Moves all boosts
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BoostsUpdate(object sender, EventArgs e)
        {
            UpdateBoosts.Stop();
            UpdateBoosts.Interval = game.GetSpriteUpdateSpeed();
            UpdateBoosts.Start();

            if (!game.GetPauseGame())
            {
                //keep moving the items
                game.MoveBagels();
                game.MovePointBoost();
                game.MoveLifeBoost();
                game.MoveBadBoost();
                game.CheckBagels();

                //life booster and pointbooster
                if (!game.CheckGameOver() && !game.GetWonGame())
                {
                    game.CheckPointBoost();
                    game.CheckLifeBoost();
                    game.CheckBadBoost();
                }
            }
        }

        /// <summary>
        /// Updates everything
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NonBoostUpdate(object sender, EventArgs e)
        {
            if (!game.GetPauseGame())
                gamePanel.Invalidate(); 
        }

        /// <summary>
        /// Times when more powerups, bagels, etc should be added
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BagelTick(object sender, EventArgs e)
        {
            BagelTime.Stop();
            BagelTime.Interval = game.GetBagelAddSpeed();
            BagelTime.Start();

            if (!game.GetPauseGame())
            {
                game.AddBagel();
            }
        }

        /// <summary>
        /// Checks which key was pressed and decides where the player should move next
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void KeyDownPressed(object sender, KeyEventArgs e)
        {
            if (!game.GetPauseGame())
            {
                if (e.KeyCode == Keys.Left)
                    game.MovePlayer("left");

                if (e.KeyCode == Keys.Right)
                    game.MovePlayer("right");

                if (e.KeyCode == Keys.Q)
                    this.Close();

                if (e.KeyCode == Keys.A)
                    game.MovePlayer("left");

                if (e.KeyCode == Keys.D)
                    game.MovePlayer("right");
            }

            if (e.KeyCode == Keys.Space)
            {
                if (game.GetPauseGame())
                    game.SetPauseGame(false);
                else
                    game.SetPauseGame(true);
            }
        }

        private void MouseClickedHandler(object sender, MouseEventArgs e)
        {
            // handle left click
       /*     if (e.Button == MouseButtons.Left)
                Console.WriteLine("Left button was clicked");*/

            // handle right click
      /*      if (e.Button == MouseButtons.Right)
                Console.WriteLine("Right button was clicked");*/
        }


        /// <summary>
        /// Handle's when the view should update
        /// </summary>
        private void OnFrame()
        {
        }

        private void view_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Displays what controls can be used in this game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void controlsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StringBuilder controlText = new StringBuilder();
            controlText.Append("Controls\n");
            controlText.Append("A:\t\tMove Left\n");
            controlText.Append("Left:\t\tMove Left\n");
            controlText.Append("D:\t\tMove Right\n");
            controlText.Append("Right:\t\tMove Right\n");
            controlText.Append("Space:\t\tPause\n");
       /*     controlText.Append("Left Click:\tPoint Booster\n");
            controlText.Append("Right Click:\tclear bagels\n");*/
            controlText.Append("Q:\t\tQuit\n\n");

            game.SetPauseGame(true);
            DialogResult result = MessageBox.Show(controlText.ToString(), "Controls", MessageBoxButtons.OK);
            if (result == DialogResult.OK)
                game.SetPauseGame(false);

        }

        /// <summary>
        /// Displays what additional information is needed for this game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StringBuilder aboutText = new StringBuilder();
            aboutText.Append("About\n\n");
            aboutText.Append("How does this Catch the Bagel game work??\n");
            aboutText.Append("A player has the ability to move from left to right to collect bagels, point boosters (cat), life boosters (fairy), " +
                "as well as items (squiggly emote) that are deemed detrimental to the player.\n\n");
            aboutText.Append("The game has 10 levels, for every increasing level, the bagels fall increasingly faster " +
                "and the amount of points earned increases.\n\n");
            aboutText.Append("Additionally, all bagels must be caught in order to maintain the amount of lives you start with. " +
                "Otherwise, your lives get increasingly lower until the game is over.\n\n");
            aboutText.Append("Created by: Allyanna Boo\n");
            aboutText.Append("First Modified: May 22, 2021\n");
            aboutText.Append("Last Modified: July 28, 2021\n\n");

            game.SetPauseGame(true);
            DialogResult result = MessageBox.Show(aboutText.ToString(), "About Catch the Bagel", MessageBoxButtons.OK);
            if (result == DialogResult.OK)
                game.SetPauseGame(false);
        }

        private void pauseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (game.GetPauseGame())
                game.SetPauseGame(false);
            else
                game.SetPauseGame(true);
        }
    }
}
