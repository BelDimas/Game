using Game.Heros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Game.Map
{
    class Render
    {
        public List<string[]> GameArea { private set; get; }
        Hero hero1, hero2;
        public bool Step1 { private set; get; }
        public bool Step2 { private set; get; }
        private bool UltaGnom = false;
        public List<int> Posission1 { private set; get; }
        public List<int> Posission2 { private set; get; }
        public Hero Winer { private set; get; }

        public Render(Hero hero1, Hero hero2)
        {
            this.hero1 = hero1;
            this.hero2 = hero2;
            GameArea = new List<string[]>();
            Posission1 = new List<int>();
            Posission2 = new List<int>();
        }

        public void Start()
        {
            Console.WriteLine(hero1.Energy + " " + hero2.Energy);
            string[] str = new string[4];
            GameArea.Add(new string[] { "#", "#", "#", "#" });
            GameArea.Add(new string[] { "#", hero1.Name, hero2.Name, "#" });
            for (int i = 1; i < 20; i++)
            {
                GameArea.Add(new string[] { "#", " ", " ", "#" });
            }
            GameArea.Add(new string[] { "#", "#", "#", "#" });
            Posission1.Add(hero1.Posission);
            Posission2.Add(hero2.Posission);
        }

        public void Show()
        {
            Console.Clear();
            Console.WriteLine(hero1.Energy + " " + hero2.Energy);
            for (int i=0;i<GameArea.Count;i++)
            {
                Console.WriteLine(string.Join("", GameArea[i]));
            }
        }

        void HeroDrop(int index, Hero hero)
        {
            if (UltaGnom == true)
            {
                UltaGnom = false;
                return;
            }
            Posission1.Add(hero1.Posission);
            Posission2.Add(hero2.Posission);
            if (hero.Posission + 1 < GameArea.Count - 1)
            {
                GameArea[hero.Posission][index] = " ";
                GameArea[hero.Posission + 1][index] = hero.Name;
                hero.Posission++;
            }
            Posission1.Add(hero1.Posission);
            Posission2.Add(hero2.Posission);
        }

        void HeroDoubleDrop(int index, Hero hero)
        {
            if (UltaGnom == true)
            {
                UltaGnom = false;
                return;
            }
            Posission1.Add(hero1.Posission);
            Posission2.Add(hero2.Posission);
            if (hero.Posission + 2 < GameArea.Count - 1)
            {
                GameArea[hero.Posission][index] = " ";
                GameArea[hero.Posission + 2][index] = hero.Name;
                hero.Posission += 2;
            }
            else if (hero.Posission + 1 < GameArea.Count - 1)
            {
                GameArea[hero.Posission][index] = " ";
                GameArea[hero.Posission + 1][index] = hero.Name;
                hero.Posission += 2;
            }
            Posission1.Add(hero1.Posission);
            Posission2.Add(hero2.Posission);
        }

        bool LimitEnergy(int energy, Hero hero)
        {
            if (energy < 0)
            {
                Console.Clear();
                Console.WriteLine("Нехватает маны");
                Thread.Sleep(3000);
                Show();
                return false;
            }
            else
            {
                hero.Energy = energy;
                return true;
            }
        }

        void Ulta(Hero hero)
        {
            if (hero.Name == "Ч")
            {
                if (UltaGnom == true)
                {
                    UltaGnom = false;
                    return;
                }
                Posission1.Add(hero1.Posission);
                Posission2.Add(hero2.Posission);
                if (hero1.Name == "Ч")
                {
                    if (hero2.Posission > hero1.Posission)
                    {
                        string[] temp = GameArea[hero1.Posission];
                        GameArea[hero1.Posission] = GameArea[hero2.Posission];
                        GameArea[hero2.Posission] = temp;
                        int t = hero1.Posission;
                        hero1.Posission = hero2.Posission;
                        hero2.Posission = t;
                    }
                    else
                    {
                        GameArea[hero1.Posission][1] = " ";
                        GameArea[hero1.Posission + 1][1] = "Ч";
                        hero1.Posission++;
                    }
                }
                else if (hero2.Name == "Ч")
                {
                    if (hero1.Posission > hero2.Posission)
                    {
                        string[] temp = GameArea[hero1.Posission];
                        GameArea[hero1.Posission] = GameArea[hero2.Posission];
                        GameArea[hero2.Posission] = temp;
                        int t = hero1.Posission;
                        hero1.Posission = hero2.Posission;
                        hero2.Posission = t;
                    }
                    else
                    {
                        GameArea[hero2.Posission][2] = " ";
                        GameArea[hero2.Posission + 1][2] = "Ч";
                        hero2.Posission++;
                    }
                }
                Posission1.Add(hero1.Posission);
                Posission2.Add(hero2.Posission);
            }
            else if (hero.Name == "Э")
            {
                if (UltaGnom == true)
                {
                    UltaGnom = false;
                    return;
                }
                Posission1.Add(hero1.Posission);
                Posission2.Add(hero2.Posission);
                if (hero1.Name == "Э")
                {
                    if (hero1.Posission + 3 < GameArea.Count - 1)
                    {
                        GameArea[hero1.Posission][1] = " ";
                        GameArea[hero1.Posission + 3][1] = hero1.Name;
                        hero1.Posission += 3;
                    }
                    else if (hero1.Posission + 2 < GameArea.Count - 1)
                    {
                        GameArea[hero1.Posission][1] = " ";
                        GameArea[hero1.Posission + 2][1] = hero1.Name;
                        hero1.Posission += 3;
                    }
                    else if (hero1.Posission + 1 < GameArea.Count - 1)
                    {
                        GameArea[hero1.Posission][1] = " ";
                        GameArea[hero1.Posission + 1][1] = hero1.Name;
                        hero1.Posission += 3;
                    }
                }
                else if (hero2.Name == "Э")
                {
                    if (hero2.Posission + 3 < GameArea.Count - 1)
                    {
                        GameArea[hero2.Posission][2] = " ";
                        GameArea[hero2.Posission + 3][2] = hero2.Name;
                        hero2.Posission += 3;
                    }
                    else if (hero2.Posission + 2 < GameArea.Count - 1)
                    {
                        GameArea[hero2.Posission][1] = " ";
                        GameArea[hero2.Posission + 2][1] = hero2.Name;
                        hero2.Posission += 3;
                    }
                    else if (hero2.Posission + 1 < GameArea.Count - 1)
                    {
                        GameArea[hero2.Posission][1] = " ";
                        GameArea[hero2.Posission + 1][1] = hero2.Name;
                        hero2.Posission += 3;;
                    }
                }
                Posission1.Add(hero1.Posission);
                Posission2.Add(hero2.Posission);
            }
            else if (hero.Name == "Г")
            {
                Posission1.Add(hero1.Posission);
                Posission2.Add(hero2.Posission);
                if (hero1.Name == "Г")
                {
                    GameArea[hero1.Posission][1] = " ";
                    GameArea[hero2.Posission + 1][1] = "Г";
                    hero1.Posission = hero2.Posission + 1;
                    UltaGnom = true;
                }
                else if (hero2.Name == "Г")
                {
                    GameArea[hero2.Posission][2] = " ";
                    GameArea[hero1.Posission + 1][2] = "Г";
                    hero2.Posission = hero1.Posission + 1;
                    UltaGnom = true;
                }
                Posission1.Add(hero1.Posission);
                Posission2.Add(hero2.Posission);
            }
        }

        public void Move(ConsoleKeyInfo keyInfo, Hero hero)
        {
            if (hero == hero1)
            {
                if (keyInfo.Key == ConsoleKey.S)
                {
                    if (LimitEnergy(hero1.Energy - hero1.Drop, hero1) == false)
                    {
                        Console.Clear();
                        Step1 = false;
                        Console.WriteLine("Выберете другую способность");
                        Thread.Sleep(2000);
                        return;
                    }
                    Step1 = true;
                    HeroDrop(1, hero1);
                    hero1.Energy += 2;
                }
                else if (keyInfo.Key == ConsoleKey.O)
                {
                    hero1.Energy += 5;
                    Step1 = true;
                }
                else if (keyInfo.Key == ConsoleKey.X)
                {
                    if (LimitEnergy(hero1.Energy - hero1.DoubleDrop, hero1) == false)
                    {
                        Console.Clear();
                        Step1 = false;
                        Console.WriteLine("Выберете другую способность");
                        Thread.Sleep(2000);
                        return;
                    }
                    Step1 = true;
                    HeroDoubleDrop(1, hero1);
                    hero1.Energy += 2;
                }
                else if (keyInfo.Key == ConsoleKey.Y)
                {
                    if (LimitEnergy(hero1.Energy - hero1.Special, hero1) == false)
                    {
                        Console.Clear();
                        Step1 = false;
                        Console.WriteLine("Выберете другую способность");
                        Thread.Sleep(2000);
                        return;
                    }
                    Step1 = true;
                    Ulta(hero1);
                    hero1.Energy += 2;
                }
                else
                {
                    Console.Clear();
                    Step1 = false;
                    Console.WriteLine("Такой команды нет");
                    Thread.Sleep(2000);
                    return;
                }
            }
            else if (hero == hero2)
            {
                if (keyInfo.Key == ConsoleKey.S)
                {
                    if (LimitEnergy(hero2.Energy - hero2.Drop, hero2) == false)
                    {
                        Console.Clear();
                        Step2 = false;
                        Console.WriteLine("Выберете другую способность");
                        Thread.Sleep(2000);
                        return;
                    }
                    Step2 = true;
                    HeroDrop(2, hero2);
                    hero2.Energy += 2;
                }
                else if (keyInfo.Key == ConsoleKey.O)
                {
                    hero2.Energy += 5;
                    Step2 = true;
                }
                else if (keyInfo.Key == ConsoleKey.X)
                {
                    if (LimitEnergy(hero2.Energy - hero2.DoubleDrop, hero2) == false)
                    {
                        Console.Clear();
                        Step2 = false;
                        Console.WriteLine("Выберете другую способность");
                        Thread.Sleep(2000);
                        return;
                    }
                    Step2 = true;
                    HeroDoubleDrop(2, hero2);
                    hero2.Energy += 2;
                }
                else if (keyInfo.Key == ConsoleKey.Y)
                {
                    if (LimitEnergy(hero2.Energy - hero2.Special, hero2) == false)
                    {
                        Console.Clear();
                        Step2 = false;
                        Console.WriteLine("Выберете другую способность");
                        Thread.Sleep(2000);
                        return;
                    }
                    Step2 = true;
                    Ulta(hero2);
                    hero2.Energy += 2;
                }
                else
                {
                    Console.Clear();
                    Step1 = false;
                    Console.WriteLine("Такой команды нет");
                    Thread.Sleep(2000);
                    return;
                }
            }
        }

        public bool Win()
        {
            if (hero1.Posission >= 20)
            {
                Winer = hero1;
                return true;
            }
            else if (hero2.Posission >= 20)
            {
                Winer = hero2;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
