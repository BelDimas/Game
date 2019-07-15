using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Heros
{
    class Warrior : Hero
    {
        int energy = 50;
        int posission = 1;
        public int Energy
        {
            set
            {
                energy = value;
                if (energy > 50)
                    energy = 50;
            }
            get
            {
                return energy;
            }
        }

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

        public int Stoping { private set; get; }

        public int Drop { private set; get; }

        public int DoubleDrop { private set; get; }

        public int Special { private set; get; }

        public string Name { private set; get; }

        public Warrior()
        {
            Name = "Г";
            Stoping = 0;
            Drop = 5;
            DoubleDrop = 15;
            Special = 20;
        }
    }
}
