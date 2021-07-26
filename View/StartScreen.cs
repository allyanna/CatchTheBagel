using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace View
{
    public partial class StartScreen : Form
    {
        public StartScreen()
        {
            InitializeComponent();

            this.CenterToScreen();
            this.comboBox_players.SelectedIndex = 0;

        }

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
        /// Opens the game once it has started
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Start_Click(object sender, EventArgs e)
        {
            //Player options
            //Man Bagel = 0
            //Ghostly Bagel = 1
            //Beary Pink = 2
            //Camper Duck = 3
     
            //TODO:: See what player has been selected and draw that in the view
            GameScreen view = new GameScreen(this.comboBox_players.SelectedIndex);
            view.Show();
            view.Focus();
        }

        private void exit_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
