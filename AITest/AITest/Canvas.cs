using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Numerics;

namespace AITest
{

    public partial class Canvas : Form
    {
        Dot dot;
        public Vector2 goal;
        Population pop;
        int flag = 0;
        Random rnd = new Random();
        int temp = 0;

        //DEFINE SIZE
        public const int size = 100;

        public Canvas()
        {
            InitializeComponent();
        }
        public void setup()
        {
            pop = new Population(rnd,size);
            pop.init();
            goal.X = 400;
            goal.Y = 200;

        }
        private void Canvas_Paint(object sender, PaintEventArgs e)
        {
            try { 
            if (flag == 0)
            {
                setup();
            }
            flag = 1;
                e.Graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
            e.Graphics.FillEllipse(Brushes.Green, goal.X, goal.Y, 10, 10);
                
                //e.Graphics.FillRectangle(Brushes.Blue, 320, 300, 500, 20);
                //e.Graphics.FillRectangle(Brushes.Blue, 5, 500, 500, 20);
                e.Graphics.FillRectangle(Brushes.Blue, 150, 400, 500, 20);
                

                // e.Graphics.FillRectangle(Brushes.Black, PosX, PosY, 5, 5);
                // e.Graphics.FillEllipse(Brushes.Black, PosX, PosY, 4, 4);
                // current = new Dot(e.Graphics, Brushes.Black);
                if (pop.allDotsDead())
            {
                string tmp = label2.Text;
                temp = Convert.ToInt32(tmp);
                temp++;
                tmp = Convert.ToString(temp);
                label2.Text = tmp;
                pop.reachedGoal();
                pop.calculateFitness();
                pop.selectDot(rnd);
                pop.MutateDots(rnd);
                pop.init();
            }
            else
            {
                pop.update();
                pop.show(e.Graphics);
            }
        }
        catch(Exception){}
            
        }

        private void tick(object sender, EventArgs e)
        {
          Invalidate();

        }
    }
}
