using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace AITest
{

    class Population
    {
        Dot[] dots;
        float fitnessSum;
        int[] flagarray;
        public Population(Random rnd, int size)
        {
            flagarray = new int[size];
            dots = new Dot[size];
            for (int i = 0; i < size; i++)
            {
                flagarray[i] = 0;
                dots[i] = new Dot(rnd);
            }
            
        }
        public void init()
        {
            for (int i = 0; i < dots.Length; i++)
            {
                dots[i].dead = false;
                dots[i].initX();
                dots[i].initY();
            }
        }
        public void show(Graphics g)
        {
            for (int i = 0; i < dots.Length; i++)
            {
                dots[i].paint(g);
            }
        }
        public void update()
        {
            for (int i = 0; i < dots.Length; i++)
            {
                dots[i].update();
            }
        }
        public Boolean allDotsDead(){
            for (int i = 0; i < dots.Length; i++)
            {
                if (!dots[i].dead && !dots[i].reachedGoal)
                {
                    return false;
                }
            }
            return true;


        }
        public void calculateFitness()
        {
            for (int i = 0; i < dots.Length; i++)
            {
                dots[i].calculateFitness();
            }
        }

        public void selectDot(Random rnd)
        {
            Dot[] newDots = new Dot[dots.Length];
            

                calculateFitnessSum();
                for (int i = 0; i < dots.Length; i++)
                {
                    Dot parent = selectParent(rnd);
                    newDots[i] = parent.cloneBrain();
                }

                for (int i = 0; i < dots.Length; i++)
                {
                    if (!dots[i].reachedGoal)
                    {
                        dots[i] = newDots[i];
                    }
                    else
                    {
                        dots[i] = dots[i].cloneBrain();
                        flagarray[i] = 1;
                    }
                }
            
        }
        public void reachedGoal()
        {
            int k = 0;
            for (int i = 0; i < dots.Length; i++)
            {
                if (dots[i].reachedGoal)
                {
                    k++;
                }
            }
            Console.WriteLine("" + k);
        }
        void calculateFitnessSum()
        {
            fitnessSum = 0;
            for (int i = 0; i < dots.Length; i++)
            {
                fitnessSum += dots[i].fitness;
            }
        }
        Dot selectParent(Random rnd)
        {

            float rand = rnd.Next((int)fitnessSum);


            float runningSum = 0;
            double tmp = 99999;
            int tmpsteps = 0;
            int k = 0;
            for (int i = 0; i < dots.Length; i++)
            {
              /*  runningSum += dots[i].fitness;
                if (runningSum > rand)
                {
                    return dots[i];
                }*/
                if (!dots[i].reachedGoal)
                {
                    if (tmp > dots[i].GetDistance())
                    {
                        tmp = dots[i].GetDistance();
                        tmpsteps = dots[i].brain.step;
                        k = i;
                    }
                }
                else
                {
                    if (tmp > dots[i].GetDistance() && tmpsteps < dots[i].brain.step)
                    {
                        tmp = dots[i].GetDistance();
                        tmpsteps = dots[i].brain.step;
                        k = i;
                    }
                }
            }

            return dots[k];
        }
        public void MutateDots(Random rnd)
        {
            for (int i = 0; i < dots.Length; i++)
            {
                if (flagarray[i]!=1)
                {
                    dots[i].brain.Mutate(rnd);
                }
            }
        }


    }
}
