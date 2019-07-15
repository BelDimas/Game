using Game.Heros;
using Game.Main_menu;
using Game.Map;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new Menu();
            do
            {
                Console.Clear();
                menu.Info();
                Console.WriteLine("Введите номер");
                int num = int.Parse(Console.ReadLine());
                if (num == 1)
                    menu.Play();
                else if (num == 2)
                    menu.Games();
                else if (num == 3)
                    return;
            }
            while (true);
        }
    }
}
