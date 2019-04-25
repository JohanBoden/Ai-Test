using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Drawing;
using System.Windows.Forms;

namespace AITest
{
    class Brain
    {
        public Vector2[] directions;
        public int step = 0;
        public Brain(int size,Random rnd)
        {
            directions = new Vector2[size];
            randomize(rnd);
        }


        void randomize(Random rnd)
        {
            for(int i=0; i < directions.Length; i++)
            {
                double randomAngle = rnd.NextDouble();
                randomAngle = 2 * randomAngle * Math.PI;
                directions[i] = FromAngle(randomAngle);
            }
        }
        public Vector2 FromAngle(double angle)
        {
            Vector2 vec = new Vector2((float)Math.Cos(angle), (float)Math.Sin(angle));
            return vec;
        }
        public Brain Clone()
        {
            Random rnd = new Random();
            Brain clone = new Brain(directions.Length,rnd);

            for (int i = 0; i < directions.Length; i++)
            {
                clone.directions[i] = directions[i];
            }
            

            return clone;
        }
        public void Mutate(Random rnd)
        {
            double mutationrate = 0.01;

            for (int i = 0; i < directions.Length; i++)
            {
                double rand = rnd.NextDouble();
                if (rand < mutationrate)
                {
                    double randomAngle = rnd.NextDouble();
                    randomAngle = randomAngle * 2 * Math.PI;
                    directions[i] = FromAngle(randomAngle);

                }
            }
        }

    }
}
