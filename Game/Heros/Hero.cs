using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Heros
{
    interface Hero
    {
        int Energy { set; get; }
        int Stoping { get; }
        int Drop { get; }
        int DoubleDrop { get; }
        int Special { get; }
        string Name { get; }
        int Posission { set; get; }
    }
}
