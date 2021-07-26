using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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

        /* Tracks when to move positions and repaint items */
        Timer BagelTime = new Timer();
        /* Creates a smoother transition to updating */
        Timer UpdatePlayers = new Timer();
        /* Updates all forms of boost*/
        Timer UpdateBoosts = new Timer();

        public GameScreen(int playerType)
        {
            InitializeComponent();

            game = new Game();

            // Set the window size
            ClientSize = new Size(Constants.SCREENSIZE, Constants.SCREENSIZE);
            this.CenterToScreen();

            // set the back color of the game
            BackColor = Color.Black;

            // Place and add the game panel components
            gamePanel = new GamePanel(game, playerType);
            gamePanel.Location = new Point(0, 22); //TO mess with later
            gamePanel.Size = new Size(Constants.SCREENSIZE, Constants.SCREENSIZE);
            gamePanel.BackColor = Color.FromArgb(242, 197, 61);
            this.Controls.Add(gamePanel);
            this.Text = "Catch the Bagel";

            // Handles key presses and mouse presses
            KeyDown += KeyDownPressed;
            gamePanel.MouseClick += MouseClickedHandler;

            // Handles the intervals of movements needed
            BagelTime.Interval = 3000;
            BagelTime.Start();
            BagelTime.Tick += BagelTick;


            // Update the player and things unrelated to boosts
            UpdatePlayers.Interval = 10;
            UpdatePlayers.Start();
            UpdatePlayers.Tick += NonBoostUpdate;

            // Update all boosts
            UpdateBoosts.Interval = 30;
            UpdateBoosts.Start();
            UpdateBoosts.Tick += BoostsUpdate;


        }

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

                //life booster and pointbooster
                game.CheckBagels();
                game.CheckPointBoost();
                game.CheckLifeBoost();
                game.CheckBadBoost();
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
                gamePanel.Invalidate(); //redraws the panel
            // Player is called in game panel hmm
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

            // decides whether to add a bagel

            if (!game.GetPauseGame())
            {
                game.AddBagel();

                //******************************
                game.AddPointBoost();
                game.AddLifeBoost();
                game.AddBadBoost();
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
        }

        private void MouseClickedHandler(object sender, MouseEventArgs e)
        {
            //TODO: if more features here (and pause game)

            // handle left click
            if (e.Button == MouseButtons.Left)
                Console.WriteLine("Left button was clicked");

            // handle right click
            if (e.Button == MouseButtons.Right)
                Console.WriteLine("Right button was clicked");
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
            controlText.Append("D:\t\tMove Right\n");
            controlText.Append("Left Click:\tPoint Booster\n");
            controlText.Append("Right Click:\tclear bagels\n");
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
            aboutText.Append("A player has the ability to move from left to right to collect bagels, point boosters, life boosters, " +
                "as well as items that are deemed detrimental to the player.\n\n");
            aboutText.Append("The game has 10 levels, for every increasing level, the bagels fall increasingly faster " +
                "and the amount of points earned increases.\n\n");
            aboutText.Append("Additionally, all bagels must be caught in order to maintain the amount of lives you start with. " +
                "Otherwise, your lives get increasingly lower until the game is over.\n\n");
            aboutText.Append("Created by: Allyanna Boo\n");
            aboutText.Append("Last Modified: May 22, 2021\n\n");

            game.SetPauseGame(true);
            DialogResult result = MessageBox.Show(aboutText.ToString(), "About Catch the Bagel", MessageBoxButtons.OK);
            if (result == DialogResult.OK)
                game.SetPauseGame(false);
        }

    }
}
