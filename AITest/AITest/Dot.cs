using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows;
using System.Numerics;
using System.Windows.Forms;


namespace AITest
{

    class Dot : Canvas
    {
        public Vector2 pos;
        public Vector2 vel;
        static public Vector2 acc;
        public Brain brain;
        public Boolean dead = false;
        public Boolean reachedGoal = false;
        public float fitness = 0;
        public Vector2 goal;

        public Dot(Random rnd)
        {
            brain = new Brain(400,rnd);
            pos = new Vector2(pos.X, pos.Y);
            vel = new Vector2(vel.X, vel.Y);
            acc = new Vector2(acc.X, acc.Y);


        }
        public double GetDistance()
        {
            double a = (double)(pos.X - goal.X);
            double b = (double)(pos.Y - goal.Y);

            return Math.Sqrt(a * a + b * b);
        }
        public void paint(Graphics g)
        {

            g.FillEllipse(Brushes.Black, pos.X, pos.Y, 5, 5);
        }
        public void initX()
        {
            pos.X = 400;
            vel.X = 0;
            acc.X = 0;
            goal.X = 400;
        }
        public void initY()
        {
            pos.Y = 600;
            vel.Y = 0;
            acc.Y = 0;
            goal.Y = 200;
        }
        public void MoveDot()
        {

                if (brain.directions.Length > brain.step)
              {
             vel += brain.directions[brain.step];
             brain.step++;

             }
                //vel += acc;
                pos += vel;
 
                


        }
        //-------------------------------------------------------------------------------------------
        //-------------------------------------------------------------------------------------------
        public void update()
        {
        if (!dead && !reachedGoal)
        {
                MoveDot();
                if (pos.X < 2 || pos.Y < 2 || pos.X > 810  || pos.Y > 820 )
                {
                    vel.X = 0;
                    vel.Y = 0;
                    dead = true;
                }
                 /*else if (pos.X>320 && pos.X<820 && pos.Y>300 && pos.Y<320)
                 {
                     vel.X = 0;
                     vel.Y = 0;
                     dead = true;
                 }
                 else if(pos.X > 5 && pos.X < 505 && pos.Y > 500 && pos.Y < 520){
                     vel.X = 0;
                     vel.Y = 0;
                     dead = true;
                 }*/
                else if (pos.X > 150 && pos.X < 650 && pos.Y > 400 && pos.Y < 420)
                {
                    vel.X = 0;
                    vel.Y = 0;
                    dead = true;
                }
     
            else if (Vector2.Distance(goal, pos) < 10)
            {
                    reachedGoal = true;

                }
            
            }


        }
        public void calculateFitness()
        {
            float distanceToGoal = Vector2.Distance(goal, pos);
            fitness =1/(distanceToGoal*distanceToGoal);
            
        }
       public Dot cloneBrain()
        {
            Random rnd = new Random();
            Dot baby = new Dot(rnd);
            baby.brain = brain.Clone();//babies have the same brain as their parents
            return baby;
        }
















    }
}
