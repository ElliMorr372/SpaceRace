using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// Elliana Morrison: December 21st, 2022
// A simple space race game with
// two players and asteriods

namespace SpaceRace
{
    public partial class Form1 : Form
    {
        Rectangle player1 = new Rectangle(8, 150, 15, 15);
        Rectangle player2 = new Rectangle(8, 150, 15, 15);

        int player1Speed = 8;
        int player2Speed = 8;

        int player1Score = 0;
        int player2Score = 0;

        List<Rectangle> asteriods = new List<Rectangle>();
        List<Rectangle> asteriods2 = new List<Rectangle>();
        List<int> asteriodsSpeed = new List<int>();
        List<int> asteriods2Speed = new List<int>();

        int asteriodWidth = 8;
        int asteriodHeight = 2;
        //int asteriodSpeed = 6;
        //int asteriod2Speed = -6;

        bool wDown = false;
        bool sDown = false;
        bool upDown = false;
        bool dDown = false;

        SolidBrush whiteBrush = new SolidBrush(Color.White);

        Random randGen = new Random();
        int randValue = 0;

        string gameState = "waiting";

        SoundPlayer collision = new SoundPlayer(Properties.Resources.collision);
        SoundPlayer gainedPoint = new SoundPlayer(Properties.Resources.gainedPoint);
        public Form1()
        {
            InitializeComponent();
        }

        public void GameSetup()
        {
            gameState = "running";
            titleLabel.Text = "";
            subtitleLabel.Text = "";
            player1Score = 0;
            player2Score = 0;
            p1ScoreLabel.Text = "0";
            p2ScoreLabel.Text = "0";
            gameLoop.Enabled = true;

            player1.X = 180;
            player2.X = 320;
            player1.Y = 280;
            player2.Y = 280;
            asteriods.Clear();
            asteriods2.Clear();
            asteriodsSpeed.Clear();
            asteriods2Speed.Clear();
        }

        private void Form1_KeyDown_1(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    wDown = true;
                    break;
                case Keys.S:
                    sDown = true;
                    break;
                case Keys.Up:
                    upDown = true;
                    break;
                case Keys.Down:
                    dDown = true;
                    break;
                case Keys.Space:
                    if (gameState == "waiting" || gameState == "p1Winning" || gameState == "p2Winning")
                    {
                        GameSetup();
                    }
                    break;
                case Keys.Escape:
                    if (gameState == "waiting" || gameState == "p1Winning" || gameState == "p2Winning")
                    {
                        this.Close();
                    }
                    break;
            }
        }

        private void Form1_KeyUp_1(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    wDown = false;
                    break;
                case Keys.S:
                    sDown = false;
                    break;
                case Keys.Up:
                    upDown = false;
                    break;
                case Keys.Down:
                    dDown = false;
                    break;

            }
        }
        private void gameLoop_Tick_1(object sender, EventArgs e)
        {
            // move player1

            if (wDown == true && player1.Y > 0)
            {
                player1.Y -= player1Speed;
            }

            if (sDown == true && player1.Y < this.Height - player1.Height)
            {
                player1.Y += player1Speed;
            }

            // move player2

            if (upDown == true && player2.Y > 0)
            {
                player2.Y -= player2Speed;
            }

            if (dDown == true && player2.Y < this.Height - player2.Height)
            {
                player2.Y += player2Speed;
            }

            // Add a point and reset player position on the bottom if players 
            if (player1.Y <= 0)
            {
                gainedPoint.Play();
                player1Score++;
                p1ScoreLabel.Text = $"{player1Score}";
                player1.X = 180;
                player1.Y = 280;
            }

            if (player2.Y <= 0)
            {
                gainedPoint.Play();
                player2Score++;
                p2ScoreLabel.Text = $"{player2Score}";
                player2.X = 320;
                player2.Y = 280;
            }

            // move obstacles from the left
            for (int i = 0; i < asteriods.Count; i++)
            {
                int x = asteriods[i].X + asteriodsSpeed[i];
                asteriods[i] = new Rectangle(x, asteriods[i].Y, asteriodWidth, asteriodHeight);
            }

            //move obstacles from the right
            for (int i = 0; i < asteriods2.Count; i++)
            {
                int x = asteriods2[i].X + asteriods2Speed[i];
                asteriods2[i] = new Rectangle(x, asteriods2[i].Y, asteriodWidth, asteriodHeight);
            }

            //generate a random value
            randValue = randGen.Next(1, 101);

            //generate new asteriod if it is time
            if (randValue < 21)
            {
                asteriods.Add(new Rectangle(0, randGen.Next(0, this.Height - 40), asteriodWidth, asteriodHeight));
                asteriodsSpeed.Add(randGen.Next(1, 11));
            }

            //generate a random value
            randValue = randGen.Next(1, 101);

            if (randValue < 21)
            {
                asteriods2.Add(new Rectangle(this.Width, randGen.Next(0, this.Height - 40), asteriodWidth, asteriodHeight));
                asteriods2Speed.Add(randGen.Next(-11, -1));
            }

            //recomve ball if it goes off the right of the screen
            for (int i = 0; i < asteriods.Count; i++)
            {
                if (asteriods[i].Y >= this.Width)
                {
                    asteriods.RemoveAt(i);
                    asteriodsSpeed.RemoveAt(i);
                }
            }

            //recomve ball if it goes off the left of the screen
            for (int i = 0; i < asteriods2.Count; i++)
            {
                if (asteriods2[i].Y <= 0)
                {
                    asteriods2.RemoveAt(i);
                    asteriods2Speed.RemoveAt(i);
                }
            }

            //check for collision between player1 and asteroid
            for (int i = 0; i < asteriods.Count; i++)
            {
                if (player1.IntersectsWith(asteriods[i]))
                {
                    player1.X = 180;
                    player1.Y = 280;
                    collision.Play();
                }
                else if (player2.IntersectsWith(asteriods[i]))
                {
                    player2.X = 320;
                    player2.Y = 280;
                    collision.Play();
                }
            }

            //check for collision between player2 and asteroid
            for (int i = 0; i < asteriods2.Count; i++)
            {
                if (player1.IntersectsWith(asteriods2[i]))
                {
                    player1.X = 180;
                    player1.Y = 280;
                    collision.Play();
                }
                else if (player2.IntersectsWith(asteriods2[i]))
                {
                    player2.X = 320;
                    player2.Y = 280;
                    collision.Play();
                }
            }

            if (player1Score == 3)
            {
                gameState = "p1Winning";
            }
            else if (player2Score == 3)
            {
                gameState = "p2Winning";
            }

            Refresh();
        }

        private void Form1_Paint_1(object sender, PaintEventArgs e)
        {
            if (gameState == "waiting")
            {
                p1ScoreLabel.Text = "";
                p2ScoreLabel.Text = "";
                titleLabel.Text = "Space Race";
                subtitleLabel.Text = "Press Space to Start or Escape to Exit";
            }
            else if (gameState == "running")
            {
                titleLabel.Text = "";
                subtitleLabel.Text = "";

                //draw player 1 and 2
                e.Graphics.FillRectangle(whiteBrush, player1);
                e.Graphics.FillRectangle(whiteBrush, player2);

                // draw asteriods coming from the left
                for (int i = 0; i < asteriods.Count(); i++)
                {
                    e.Graphics.FillRectangle(whiteBrush, asteriods[i]);
                }

                // draw asteriods coming from the right
                for (int i = 0; i < asteriods2.Count(); i++)
                {
                    e.Graphics.FillRectangle(whiteBrush, asteriods2[i]);
                }
            }
            else if (gameState == "p1Winning")
            {
                gameLoop.Enabled = false;
                titleLabel.Text = "Player 1 Won!";
                subtitleLabel.Text = "Press Space to Start or Escape to Exit";
            }
            else if (gameState == "p2Winning")
            {
                gameLoop.Enabled = false;
                titleLabel.Text = "Player 2 Won!";
                subtitleLabel.Text = "Press Space to Start or Escape to Exit";
            }
        }
    }
}
