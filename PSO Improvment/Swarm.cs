using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSO_Improvment
{
    struct Cell
    {
        public int profit;
        public int weight;
    }
    class Swarm
    {
        int capacity;
        double globalBest;
        Particle[] particles;
        int swarmSize;
        int demintion;
        int[] profitArray;
        int[] weightArray;
        Cell[] swarmFitness;
        double w;
        double c1;
        double c2;
        int iterations;
        
        public Swarm(int _swarmSize, int _demintion, int[] _profitArray, int[] _weightArray, int _capacity, int _iterations)
        {
            swarmSize = _swarmSize;
            demintion = _demintion;
            particles = new Particle[_swarmSize];
            globalBest = 0;
            profitArray = _profitArray;
            weightArray = _weightArray;
            capacity = _capacity;
            swarmFitness = new Cell[_swarmSize];
            for (int i = 0; i < _swarmSize; i++)
            {
                particles[i] = new Particle(_demintion, profitArray);
            }
            w = 0.75;
            c1 = 1.8;
            c2 = 2;
            iterations = _iterations;
        }
        private void CreateRandomSolution()
        {
            Random getRandom = new Random();
            
            for (int i = 0; i < swarmSize; i++)
            {
                for (int k = 0; k < demintion; k++)
                {
                    particles[i].Position[k] = getRandom.NextDouble();
                    particles[i].Velocity[k] = getRandom.NextDouble();
                }
                while ((CapacityChecker(particles[i].Position)) == false)
                {
                    for (int k = 0; k < demintion; k++)
                    {
                        particles[i].Position[k] = getRandom.NextDouble();
                    }
                }
            }
        }
        private bool CapacityChecker(double[] arr)
        {
            int weight = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if(arr[i] >= 0.5)
                {
                    weight += weightArray[i];
                }
            }
            if (weight <= capacity)
                return true;
            else return false;
        }
        private void Swap_Mutation(ref Particle part)
        {
            double temp = 0;
            Random getRandom = new Random();
            int x = getRandom.Next(0, part.Position.Length - 1);
            int y = getRandom.Next(0, part.Position.Length - 1);
            temp = part.Position[x];
            part.Position[x] = part.Position[y];
            part.Position[y] = temp;
        }
        private void FitnessFunction(ref Cell cell, double[] arr)
        {
            cell.profit = 0;
            cell.weight = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] >= 0.5)
                {
                    cell.profit += profitArray[i];
                    cell.weight += weightArray[i];
                }
                else { }
            }
        }
        private void ChangeVelocity(ref Particle part)
        {
            Random getRandom = new Random();
            for (int i = 0; i < part.Velocity.Length; i++)
            {
                part.Velocity[i] = w * part.Velocity[i] + c1 * getRandom.NextDouble() * (part.PersonalBest - part.PositionProfit()) + c2 * getRandom.NextDouble() * (globalBest - part.PositionProfit());
            }
        }
        private void ChangePosition(ref Particle part)
        {
            for (int i = 0; i < part.Position.Length; i++)
            {
                part.Position[i] = part.Position[i] + part.Velocity[i];
            }
        }

        public void RunPSO()
        {
            CreateRandomSolution();
            for (int K = 0; K < iterations; K++)
            {
                for (int i = 0; i < swarmSize; i++)
                {
                    FitnessFunction(ref swarmFitness[i], particles[i].Position);
                    if (swarmFitness[i].profit >= particles[i].PersonalBest && swarmFitness[i].weight <= capacity)
                    {
                        particles[i].PersonalBest = swarmFitness[i].profit;
                        for (int k = 0; k < demintion; k++)
                        {
                            particles[i].BestPosition[k] = particles[i].Position[k];
                        }
                        if (particles[i].PersonalBest >= globalBest)
                        {
                            globalBest = particles[i].PersonalBest;
                        }
                    }
                    ChangeVelocity(ref particles[i]);
                    ChangePosition(ref particles[i]);
                    Swap_Mutation(ref particles[i]);
                }
            }
            Console.WriteLine("The best Profit is : {0}", globalBest);
        }
    }
}
