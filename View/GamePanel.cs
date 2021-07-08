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

        private Game game;


        /// <summary>
        /// Draws the world of the CatchTheBagel game for the view form
        /// </summary>
        public GamePanel(Game game)
        {
            DoubleBuffered = true; //tells that we need to repaint the panel

            //intialize all the images here
            bagel = Image.FromFile("..\\..\\..\\Resources\\Sprites\\Bagel.png");
            lifeBooster = Image.FromFile("..\\..\\..\\Resources\\Sprites\\LifeBooster.png");
            pointBooster = Image.FromFile("..\\..\\..\\Resources\\Sprites\\PointBooster.png");
            playerImg = Image.FromFile("..\\..\\..\\Resources\\Sprites\\bagel-ghost-bg-sq.png");

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
            /* e.Graphics.DrawImage(playerImg, new PointF(p.GetPointX(), p.GetPointY()));*/
            // TODO: some work needed
            using (System.Drawing.SolidBrush white = new System.Drawing.SolidBrush(Color.White))
            {
                Rectangle r = new Rectangle(p.GetPointX(), p.GetPointY(), 50, 50);
                e.Graphics.FillRectangle(white, r);
            }
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
            LifeBooster l = o as LifeBooster; //TODO
            e.Graphics.DrawImage(lifeBooster, new PointF(150, 150));
        }

        /// <summary>
        /// Draws a point booster when it is time to be re-drawn                                                 
        /// </summary>
        /// <param name="o"></param>
        /// <param name="e"></param>
        private void DrawPointBooster(object o, PaintEventArgs e)
        {
            PointBooster p = o as PointBooster; //TODO
            e.Graphics.DrawImage(pointBooster, new PointF(200, 200));
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
                Font font = new Font("Cambria", 10, FontStyle.Bold);
                String labels = "Level: " + g.GetCurrentLevel() + "\n" + "Points: " + g.GetPoints() + "\n" + "Lives Left: " + g.GetLivesLeft();
                e.Graphics.DrawString(labels, font, blackBrush, 0, 0);
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
        private void  DrawGameOverLabel(Object o, PaintEventArgs e)
        {
            Game g = o as Game;
            using (System.Drawing.SolidBrush blackBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black))
            {
                Font font = new Font("Cambria", 30, FontStyle.Bold);
                Font font2 = new Font("Cambria", 20, FontStyle.Bold);
                e.Graphics.DrawString("GAME OVER", font, blackBrush, 315, 350);
           /*     e.Graphics.DrawString("You collected: " + game.getBagelCount(), font2, blackBrush, 315, 400);
                e.Graphics.DrawString("You Scored: " + game.GetPoints(), font2, blackBrush, 315, 450);*/
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
                lock (game.GetPlayer())
                    DrawPlayer(game.GetPlayer(), e);

                lock (game.AllBagels)
                {
                    foreach (Bagel b in game.AllBagels.Values)
                        DrawBagel(b, e);
                }
                /*DrawLifeBooster(new object(), e);
                  DrawPointBooster(new object(), e);*/
                DrawLabel(game, e);
                DrawGround(new object(), e);
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
