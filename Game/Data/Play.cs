using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Data
{
    class Play
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public string NamePlaer1 { set; get; }
        public string NamePlaer2 { set; get; }
        public List<int> Posission1 { set; get; }
        public List<int> Posission2 { set; get; }
        public List<int> Energy1 { set; get; }
        public List<int> Energy2 { set; get; }
    }
}
