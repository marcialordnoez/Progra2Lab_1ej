using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PingpongGAME
{
    public partial class Form1 : Form
    {
        public int speed_left = 4;//speed of the ball
        public int speed_top = 4;
        public int point = 0;

        public Form1()
        {
            InitializeComponent();
            timer1.Enabled = true;
            Cursor.Hide();
            this.FormBorderStyle = FormBorderStyle.None; //remove any border
            this.TopMost = true;    //bring the form to the front 
            this.Bounds = Screen.PrimaryScreen.Bounds;  //make it fullscreen
            racket.Top = Playground.Bottom - (Playground.Bottom / 10);      //set the position of the racket
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            racket.Left = Cursor.Position.X - (racket.Width / 2);
            ball.Left += speed_left;
            ball.Top += speed_top;

            if (ball.Bottom >= racket.Top && ball.Bottom <= racket.Bottom && ball.Left >= racket.Left && ball.Right <= racket.Right) 
            {
                speed_top += 2;
                speed_left += 2;
                speed_top = -speed_top;
                point += 1;
                lbpuntos.Text = point.ToString();
            }

            if (ball.Left <= Playground.Left) 
            {
                speed_left = -speed_left;
            }

            if (ball.Right >= Playground.Right)
            {
                speed_left = -speed_left;
            }
            if (ball.Top <= Playground.Top)
            {
                speed_top = -speed_top;
            }
            if (ball.Bottom >= Playground.Bottom)
            {
                timer1.Enabled = false;
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) 
            {
                this.Close();//press escape to quit
            }
        }

    }
}
