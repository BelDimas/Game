using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Heros
{
    class Mage : Hero
    {
        int energy = 30;
        int posission = 1;
        public int Energy
        {
            set
            {
                energy = value;
                if (energy > 30)
                    energy = 30;
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

        public Mage()
        {
            Name = "Ч";
            Stoping = 0;
            Drop = 5;
            DoubleDrop = 13;
            Special = 15;
        }
    }
}
