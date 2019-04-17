using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace BallBrickBreaker
{
    public partial class Form1 : Form
    {
        Boolean move = false;

        List<Boxes> boxList = new List<Boxes>();
        List<Balls> ballList = new List<Balls>();
        SolidBrush ballBrush = new SolidBrush(Color.Maroon);
        SolidBrush boxBrush = new SolidBrush(Color.White);
        SolidBrush HUDBrush = new SolidBrush(Color.Black);
        int counter = 0;
        int maxBall = 1;
        int ballAngle = 90;

        public Form1()
        {
            InitializeComponent();
            ballCreation();
        }

        public void ballCreation()
        {
            counter = 0;
            int x = this.Width / 2 - 20;
            int y = this.Height - 230;
            int size = 20;
            double xStep = Math.Cos(ballAngle * Math.PI / 180.0) * 9;
            double yStep = Math.Sin(ballAngle * Math.PI / 180.0) * 9;
            Balls ball = new Balls(x, y, size, (float)-xStep, (float)-yStep);
            ballList.Add(ball);
        }

        public void BoxCreation()
        {
            int m = 10;
            int n = 10;
            int size = this.Width / 5 - 2;
            Boxes box = new Boxes(m, n, size);
            boxList.Add(box);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    if (move == false)
                    {
                        move = true;
                        counter = 0;

                        double xStep = Math.Cos(ballAngle * Math.PI / 180.0) * 9;
                        double yStep = Math.Sin(ballAngle * Math.PI / 180.0) * 9;

                        ballList[0].xStep = (float)-xStep;
                        ballList[0].yStep = (float)-yStep;
                    }
                        break;
                case Keys.Right:
                    if (move == false)
                    {
                        if (ballAngle < 165)
                        {
                            ballAngle++;
                        }
                    }
                    break;
                case Keys.Left:
                    if (move == false)
                    {
                        if (ballAngle > 15)
                        {
                            ballAngle--;
                        }
                    }
                    break;
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            label1.Text = "" + ballAngle;
            label4.Text = "" + maxBall;

            if (move)
            {
                foreach (Balls b in ballList)
                {
                    b.Move();
                    b.Collision(this);
                }

                counter++;

                if (counter == 4 && ballList.Count() < maxBall)
                {
                    ballCreation();
                }

                if (ballList.Count > 0)
                {
                    if (ballList[0].y > this.Height - 225)
                    {
                        ballList.RemoveAt(0);
                    }
                }
                else
                {
                    move = false;
                    maxBall++;
                    ballCreation();
                }
            }

            Refresh();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            foreach (Balls b in ballList)
            {
                e.Graphics.FillEllipse(ballBrush, b.x, b.y, b.size, b.size);
            }
            e.Graphics.FillRectangle(HUDBrush, 0, 550, 400, 200);

            foreach (Boxes k in boxList)
            {
                e.Graphics.FillRectangle(boxBrush, k.x2, k.y2, k.size2, k.size2);
            }
        }


    }
}
