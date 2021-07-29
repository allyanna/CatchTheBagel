using System;
using System.Drawing;
using System.Windows.Forms;
using CatchTheBagel;

namespace View
{
    public class GamePanel : Panel
    {

        //add all the images needed here for the game
        private Image bagel;
        private Image lifeBooster;
        private Image pointBooster;
        private Image playerImg;
        private Image badBooster;

        private Game game;


        /// <summary>
        /// Draws the world of the CatchTheBagel game for the view form
        /// </summary>
        public GamePanel(Game game, int playerType, int bagelType)
        {
            DoubleBuffered = true; //tells that we need to repaint the panel

            //intialize all the images here
            bagel = Image.FromFile("..\\..\\..\\Resources\\Sprites\\Bagel.png");
            lifeBooster = Image.FromFile("..\\..\\..\\Resources\\Sprites\\life-booster.png");
            pointBooster = Image.FromFile("..\\..\\..\\Resources\\Sprites\\point-booster.png");
            badBooster = Image.FromFile("..\\..\\..\\Resources\\Sprites\\BadBooster.png");
            playerImg = Image.FromFile("..\\..\\..\\Resources\\Sprites\\man-bagel.png");

            if (playerType == 1)
                playerImg = Image.FromFile("..\\..\\..\\Resources\\Sprites\\ghost.png");
            else if (playerType == 2)
                playerImg = Image.FromFile("..\\..\\..\\Resources\\Sprites\\beary-pink.png");
            else if (playerType == 3)
                playerImg = Image.FromFile("..\\..\\..\\Resources\\Sprites\\camper-duck-cap.png");

            if (bagelType == 0)
                bagel = Image.FromFile("..\\..\\..\\Resources\\Sprites\\plain-bagel.png");
            else if (bagelType == 2)
                bagel = Image.FromFile("..\\..\\..\\Resources\\Sprites\\bart-donut.png");
            else if (bagelType == 3)
                bagel = Image.FromFile("..\\..\\..\\Resources\\Sprites\\sugar-donut.png");


            this.game = game;

        }

        // A delegate that helps draw images
        public delegate void DrawComponent(object o, PaintEventArgs e);

        /// <summary>
        /// Draws the player at its current position
        /// </summary>
        /// <param name="o"></param>
        /// <param name="e"></param>
        private void DrawPlayer(object o, PaintEventArgs e)
        {
            Player p = o as Player;
            e.Graphics.DrawImage(playerImg, new PointF(p.GetPointX(), p.GetPointY()));
        }

        /// <summary>
        /// Draws a bagel when it is time to be re-drawn
        /// </summary>
        /// <param name="o"></param>
        /// <param name="e"></param>
        private void DrawBagel(object o, PaintEventArgs e)
        {
            Bagel b = o as Bagel;
            e.Graphics.DrawImage(bagel, new PointF(b.GetPointX(), b.GetPointY()));
        }


        /// <summary>
        /// Draws a life booster when it is time to be re-drawn
        /// </summary>
        /// <param name="o"></param>
        /// <param name="e"></param>
        private void DrawLifeBooster(object o, PaintEventArgs e)
        {
            LifeBooster l = o as LifeBooster;
            e.Graphics.DrawImage(lifeBooster, new PointF(l.GetPointX(), l.GetPointY()));
        }

        /// <summary>
        /// Draws a point booster when it is time to be re-drawn                                                 
        /// </summary>
        /// <param name="o"></param>
        /// <param name="e"></param>
        private void DrawPointBooster(object o, PaintEventArgs e)
        {
            PointBooster p = o as PointBooster;
            e.Graphics.DrawImage(pointBooster, new PointF(p.GetPointX(), p.GetPointY()));
        }

        /// <summary>
        /// Draws a bad booster when it is time to be re-drawn
        /// </summary>
        /// <param name="o"></param>
        /// <param name="e"></param>
        private void DrawBadBooster(object o, PaintEventArgs e)
        {
            BadBooster b = o as BadBooster;
            e.Graphics.DrawImage(badBooster, new PointF(b.GetPointX(), b.GetPointY()));
        }

        /// <summary>
        /// Draws the label when it is time to be re-drawn
        /// </summary>
        /// <param name="o"></param>
        /// <param name="e"></param>
        private void DrawLabel(object o, PaintEventArgs e)
        {
            Game g = o as Game;
            using (System.Drawing.SolidBrush blackBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black))
            {
                Font font = new Font("Cambria", 15, FontStyle.Bold);
                String labels = "Level: " + g.GetCurrentLevel() + "\n" + "Points: " + g.GetPoints() + "\n" + "Lives Left: " + g.GetLivesLeft() + "\n" + "Bagel count: " + g.getBagelCount();
                e.Graphics.DrawString(labels, font, blackBrush, 3, 3);
            }
        }

        /// <summary>
        /// Draws the ground when it is time to be re-drawn
        /// </summary>
        /// <param name="o"></param>
        /// <param name="e"></param>
        private void DrawGround(object o, PaintEventArgs e)
        {
            using (System.Drawing.SolidBrush greenBrush = new System.Drawing.SolidBrush(Color.FromArgb(91, 140, 69)))
            {
                Rectangle r = new Rectangle(0, 750, Constants.SCREENSIZE, 50);
                e.Graphics.FillRectangle(greenBrush, r);
            }

        }

        /// <summary>
        /// Draws the game over screen 
        /// </summary>
        /// <param name="e"></param>
        private void DrawGameOverLabel(Object o, PaintEventArgs e)
        {
            Game g = o as Game;
            using (System.Drawing.SolidBrush blackBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black))
            {
                Font font = new Font("Cambria", 30, FontStyle.Bold);
                Font font2 = new Font("Cambria", 20, FontStyle.Bold);
                e.Graphics.DrawString("GAME OVER", font, blackBrush, 315, 350);
                e.Graphics.DrawString("You collected: " + game.getBagelCount(), font2, blackBrush, 325, 400);
                e.Graphics.DrawString("You Scored: " + game.GetPoints(), font2, blackBrush, 325, 450);
            }
        }

        /// <summary>
        /// Draws the you won screen
        /// </summary>
        /// <param name="e"></param>
        private void DrawYouWonLabel(Object o, PaintEventArgs e)
        {
            Game g = o as Game;
            using (System.Drawing.SolidBrush blackBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black))
            {
                Font font = new Font("Cambria", 30, FontStyle.Bold);
                Font font2 = new Font("Cambria", 20, FontStyle.Bold);
                e.Graphics.DrawString("YOU WON!", font, blackBrush, 315, 350);
                e.Graphics.DrawString("You collected: " + game.getBagelCount(), font2, blackBrush, 325, 400);
                e.Graphics.DrawString("You Scored: " + game.GetPoints(), font2, blackBrush, 325, 450);
            }
        }

        /// <summary>
        /// This method invokes when the GamePanel needs to be re-drawn
        /// </summary>
        /// <param name="e">The PaintEventArgs to access the graphics</param>
        protected override void OnPaint(PaintEventArgs e)
        {

            if (!game.CheckGameOver())
            {

                lock (game.AllBagels)
                {
                    foreach (Bagel b in game.AllBagels.Values)
                        DrawBagel(b, e);
                }

                lock (game.AllPBoosters)
                {
                    foreach (PointBooster p in game.AllPBoosters.Values)
                        DrawPointBooster(p, e);
                }

                lock (game.AllLBoosters) //in the works
                {
                    foreach (LifeBooster l in game.AllLBoosters.Values)
                        DrawLifeBooster(l, e);
                }

                lock (game.AllBBoosters) //in the works
                {
                    foreach (BadBooster b in game.AllBBoosters.Values)
                        DrawBadBooster(b, e);
                }

                if (game.GetWonGame()) {
                    DrawYouWonLabel(game, e);
                }
                else
                {
                    DrawLabel(game, e);
                    DrawGround(new object(), e);
                    lock (game.GetPlayer())
                        DrawPlayer(game.GetPlayer(), e);
                }
            }
            else
            {
                lock (game.AllBagels)
                {
                    foreach (Bagel b in game.AllBagels.Values)
                        DrawBagel(b, e);
                }

                //draw Game over
                DrawGameOverLabel(game, e);
            }

            // call on paint again to redraw
            base.OnPaint(e);
        }

    }
}
