using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSO_Improvment
{
    class Particle
    {
        private double[] position;
        int[] profitArray;
        private double[] bestPosition;

        public double[] BestPosition
        {
            get { return bestPosition; }
            set { bestPosition = value; }
        }

        public double[] Position
        {
            get { return position; }
            set { position = value; }
        }

        private double[] velocity;

        public double[] Velocity
        {
            get { return velocity; }
            set { velocity = value; }
        }

        // double[] arr0_1;
        private int personalBest;

        public int PersonalBest
        {
            get { return personalBest; }
            set { personalBest = value; }
        }


        public Particle(int _demintion, int[] _profitArray)
        {
            position = new double[_demintion];
            velocity = new double[_demintion];
            //arr0_1 = new double[_demintion];
            personalBest = 0;
            bestPosition = new double[_demintion];
            profitArray = _profitArray;
        }
        public double PositionProfit()
        {
            double result = 0;
            for (int i = 0; i < position.Length; i++)
            {
                if (position[i] >= 0.5)
                    result += profitArray[i];
            }
            return result;
        }
    }
}
