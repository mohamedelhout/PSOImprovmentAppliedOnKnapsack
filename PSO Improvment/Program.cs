using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSO_Improvment
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] profitArr = new int[] { 55, 10, 47, 5, 4, 50, 8, 61, 85, 87 };
            int[] weightArr = new int[] { 95, 4, 60, 32, 23, 72, 80, 62, 65, 46 };
            Swarm sm = new Swarm(50, 10, profitArr, weightArr, 269, 20);
            sm.RunPSO();
            Console.ReadLine();
        }
    }
}
