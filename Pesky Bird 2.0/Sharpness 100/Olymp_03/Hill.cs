using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharpness_100.Olymp_03
{
    public record Hill
    {
        public Pole StartPole { get; init; }
        public Pole EndPole { get; init; }
        public int Lenght => EndPole.PoleNumber - StartPole.PoleNumber + 1;
    }
}
