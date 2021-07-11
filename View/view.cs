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
    public partial class View : Form
    {
        Game game;
        GamePanel gamePanel;

        // Tracks when to move positions and repaint items
        Timer BagelTime = new Timer();
        // Creates a smoother transition to updating
        Timer UpdateTime = new Timer();

        public View()
        {
            InitializeComponent();

            game = new Game();

            // Set the window size
            ClientSize = new Size(Constants.SCREENSIZE, Constants.SCREENSIZE);

            // set the back color of the game
            BackColor = Color.Black;

            //Place and add the game panel components
            gamePanel = new GamePanel(game);
            gamePanel.Location = new Point(0, 22); //TO mess with later
            gamePanel.Size = new Size(Constants.SCREENSIZE, Constants.SCREENSIZE);
            gamePanel.BackColor = Color.FromArgb(242, 197, 61);
            this.Controls.Add(gamePanel);
            this.Text = "Catch the Bagel";

            //handle key presses and mouse presses
            KeyDown += KeyDownPressed;
            gamePanel.MouseClick += MouseClickedHandler;

            //handles the intervals of movements needed
            BagelTime.Interval = 3000;
            BagelTime.Start();
            BagelTime.Tick += BagelTick;


            //update the page
            UpdateTime.Interval = 10;
            UpdateTime.Start();
            UpdateTime.Tick += TimerUpdate;

        }

        /// <summary>
        /// Updates everything
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TimerUpdate(object sender, EventArgs e)
        {

            //keep moving the items
            game.MoveBagels();
           
            //life booster and pointbooster


            gamePanel.Invalidate(); //redraws the panel

            game.CheckBagels();

        }

        /// <summary>
        /// Times when more powerups, bagels, etc should be added
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BagelTick(object sender, EventArgs e)
        {
            Console.WriteLine("timer was triggered");
            BagelTime.Stop();
            BagelTime.Start();

            // decides whether to add a bagel
            game.AddBagel();

        }

        /// <summary>
        /// Checks which key was pressed and decides where the player should move next
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void KeyDownPressed(object sender, KeyEventArgs e)
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

        private void MouseClickedHandler(object sender, MouseEventArgs e)
        {
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
            MessageBox.Show(controlText.ToString(), "Controls", MessageBoxButtons.OK);
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

            MessageBox.Show(aboutText.ToString(), "About Catch the Bagel", MessageBoxButtons.OK);
        }
    }
}
