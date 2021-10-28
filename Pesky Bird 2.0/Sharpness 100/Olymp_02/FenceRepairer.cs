using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharpness_100.Olymp_02
{
    public class FenceRepairer
    {
        int ReadInt() => int.Parse(Console.ReadLine()!);

        private bool ReadBool()
        {
            var x = int.Parse(Console.ReadLine());
            return x == 1;
        }

        private bool[] CreateFence(int k)
        {
            var x = new bool[k];
            for (var i = 0; i < k; i++)
            {
                x[i] = ReadBool();
            }

            return x;
        }

        int FindFirstBroken(bool[] f, int current)
        {
            if (current >= f.Length)
            {
                return f.Length;
            }
            //else
            for (var i = current; i <= f.Length - 1; i++)
            {
                if (f[i])
                {
                    return i;
                }
            }

            return f.Length;
        }

        int Repair(int n, int current) => current + n;

        int ReapairAll(bool[] f, int n)
        {
            var i = 0;

            for (var current = 0; current <= f.Length - 1; )
            {
                current = FindFirstBroken(f, current);
                if (current < f.Length)
                {
                    current = Repair(n, current);
                    i++;
                }
            }

            return i;
        }

        public void RunFence()
        {
            var n = ReadInt();
            var k = ReadInt();
            var fence = CreateFence(k);
            var answer = ReapairAll(fence, n);
            Console.WriteLine(answer);
        }
    }
}
