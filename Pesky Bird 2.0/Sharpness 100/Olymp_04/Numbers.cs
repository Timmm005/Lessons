using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharpness_100.Olymp_04
{
    public class Numbers
    {
        int ReadInt() => int.Parse(Console.ReadLine()!);
        public int A { get; }
        public int B { get; }
        public Numbers()
        {
            A = ReadInt();
            B = ReadInt();
        }

        public int A1 => (A % 10) == 0 ? A : ((A / 10) + 1) * 10;
        public int B1 => (B % 10) == 9 ? B : ((B / 10) - 1) * 10 + 9;

        private int SumOfDigits(int x)
        {
            var answer = 0;
            while (x != 0)
            {
                answer += (x % 10);
                x /= 10;
            }
            return answer;
        }
        /// <summary>
        /// x is included y is NOT
        /// </summary>
        private int Calculate(int x, int y)
        {
            return (y - x) / 2 + ((y - x) % 2 == 0 ? 0 : SumOfDigits(x) % 2);
        }
        private int CalculateA1() => Calculate(A, A1);
        private int CalculateB1() => Calculate(B1 + 1, B + 1);

        private int CalculateAll()
        {
            return ((B1 - A1 + 1) / 2) + CalculateA1() + CalculateB1();
        }
        public void RunNumbers()
        {
            Console.WriteLine(CalculateAll());
        }
    }
}
