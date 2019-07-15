using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Heros
{
    class Elf : Hero
    {
        int energy = 40;
        int posission = 1;
        public int Energy
        {
            set
            {
                energy = value;
                if (energy > 40)
                    energy = 40;
            }
            get
            {
                return energy;
            }
        }

        public int Stoping { private set; get; }

        public int Drop { private set; get; }

        public int DoubleDrop { private set; get; }

        public int Special { private set; get; }

        public string Name { private set; get; }

        public int Posission
        {
            set
            {
                posission = value;
                if (posission >= 20)
                    posission = 20;
            }
            get
            {
                return posission;
            }
        }

        public Elf()
        {
            Name = "Э";
            Stoping = 0;
            Drop = 5;
            DoubleDrop = 12;
            Special = 24;
        }
    }
}
