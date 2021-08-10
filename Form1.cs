using System;
using System.Drawing;
using System.Windows.Forms;

namespace Snowfall
{
    public partial class Form1 : Form
    {
        Graphics graphics;

        Random random = new Random();

        public class Snowflake
        {
            public float X { get; set; }
            public float Y { get; set; }
        }

        private Snowflake[] snowflakes = new Snowflake[6400];

        private float SnowflakeSpeed = 20;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);

            graphics = Graphics.FromImage(pictureBox1.Image);

            for (int i = 0; i < snowflakes.Length; i++)
            {
                snowflakes[i] = new Snowflake()
                {
                    X = random.Next(-pictureBox1.Width, pictureBox1.Width),
                    Y = random.Next(0, pictureBox1.Height)
                };
            }
            timer1.Start();
        }
    
        private void timer1_Tick(object sender, EventArgs e)
        {
            graphics.Clear(Color.Black);

            foreach (var snowflake in snowflakes)
            {
                DrawSnowflake(snowflake);
                MoveSnowflake(snowflake);
            }

            pictureBox1.Refresh();
        }

        private void MoveSnowflake(Snowflake snowflake)
        {
            snowflake.Y += SnowflakeSpeed;

            if(snowflake.Y >= pictureBox1.Height)
            {
                snowflake.X = random.Next(-pictureBox1.Width, pictureBox1.Width);
                snowflake.Y = random.Next(0, pictureBox1.Height);
            }
        }

        private void DrawSnowflake(Snowflake snowflake)
        {
            float SizeSnowflake = random.Next(2, 7);

            float x = snowflake.X;
            float y = snowflake.Y;

            graphics.FillEllipse(Brushes.White, x, y, SizeSnowflake, SizeSnowflake);
        }
    }
}
