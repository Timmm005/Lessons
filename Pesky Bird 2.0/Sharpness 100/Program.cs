using System;
using Sharpness_100.Olymp_01;
using Sharpness_100.Olymp_02;
using Sharpness_100.Olymp_03;
using Sharpness_100.Olymp_04;
using Sharpness_100.Olymp_05;

namespace Sharpness_100
{
    class Program
    {
        static void Main(string[] args)
        {
            //Solver.RunBarge();
            //new FenceRepairer().RunFence();
            //new RollerCoaster().RunRollerCoaster();
            //new Numbers().RunNumbers();
            CubicRootSolver.Create().Run();
        }
    }
}
