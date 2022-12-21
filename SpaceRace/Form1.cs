using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        int asteriodWidth = 8;
        int asteriodHeight = 2;
        int asteriodSpeed = 6;

        bool wDown = false;
        bool sDown = false;
        bool upDown = false;
        bool dDown = false;

        SolidBrush whiteBrush = new SolidBrush(Color.White);

        Random randGen = new Random();
        int randValue = 0;

        string gameState = "waiting";
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
                player1Score++;
                p1ScoreLabel.Text = $"{player1Score}";
                player1.X = 180;
                player1.Y = 290;
            }

            if (player2.Y <= 0)
            {
                player2Score++;
                p2ScoreLabel.Text = $"{player2Score}";
                player2.X = 320;
                player2.Y = 290;
            }

            // move obstacles
            for (int i = 0; i < asteriods.Count; i++)
            {
                int x = asteriods[i].X + asteriodSpeed;
                asteriods[i] = new Rectangle(x, asteriods[i].Y, asteriodWidth, asteriodHeight);
            }

            //generate a random value
            randValue = randGen.Next(1, 101);

            //generate new asteriod if it is time
            if (randValue < 25)
            {
                asteriods.Add(new Rectangle(0, randGen.Next(0, this.Height - 40), asteriodWidth, asteriodHeight));
            }

            if (randValue < 25)
            {
                asteriods.Add(new Rectangle(0, randGen.Next(0, this.Height - 40), asteriodWidth, asteriodHeight));
            }

            //recomve ball if it goes off the screen (test at y = 400)
            for (int i = 0; i < asteriods.Count; i++)
            {
                if (asteriods[i].Y >= this.Width)
                {
                    asteriods.RemoveAt(i);
                }
            }

            //check for collision between player1 and asteroid
            for (int i = 0; i < asteriods.Count; i++)
            {
                if (player1.IntersectsWith(asteriods[i]))
                {
                    player1.X = 180;
                    player1.Y = 290;
                }
            }

            //check for collision between player2 and asteroid
            for (int i = 0; i < asteriods.Count; i++)
            {
                if (player2.IntersectsWith(asteriods[i]))
                {
                    player2.X = 320;
                    player2.Y = 290;
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

                // draw asteriods
                for (int i = 0; i < asteriods.Count(); i++)
                {
                    e.Graphics.FillRectangle(whiteBrush, asteriods[i]);
                }
            }
            else if (gameState == "p1Winning")
            {
                titleLabel.Text = "Player 1 Won!";
                subtitleLabel.Text = "Press Space to Start or Escape to Exit";
            }
            else if (gameState == "p2Winning")
            {
                titleLabel.Text = "Player 2 Won!";
                subtitleLabel.Text = "Press Space to Start or Escape to Exit";
            }
        }
    }
}
