using Game.Heros;
using Game.Map;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using LiteDB;
using Game.Data;

namespace Game.Main_menu
{
    class Menu
    {
        List<Hero> heroes;
        Hero Player1, Player2;
        List<int> Posission1, Posission2;
        List<string[]> GameArea;
        List<int> Energy1, Energy2;
        public Menu()
        {
            heroes = new List<Hero>();
            Posission1 = new List<int>();
            Posission2 = new List<int>();
            GameArea = new List<string[]>();
            Energy1 = new List<int>();
            Energy2 = new List<int>();
            heroes.Add(new Mage());
            heroes.Add(new Warrior());
            heroes.Add(new Elf());
        }

        public void Info()
        {
            Console.WriteLine("Подземелья");
            Console.WriteLine("Выбор действий");
            Console.WriteLine("Отдых клавиша O");
            Console.WriteLine("Спуск клавиша S");
            Console.WriteLine("Быстрый спуск клавиша X");
            Console.WriteLine("Особое действие клавиша Y");
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine("1 Начать игру");
            Console.WriteLine("2 Посмотреть прошлые игры");
            Console.WriteLine("3 Выход");
        }

        void Go()
        {
            Render render = new Render(Player1, Player2);
            render.Start();
            render.Show();
            Posission1.Add(Player1.Posission);
            Posission2.Add(Player2.Posission);
            Energy1.Add(Player1.Energy);
            Energy2.Add(Player2.Energy);
            while (true)
            {
                do
                {
                    render.Show();
                    render.Move(Console.ReadKey(), Player1);
                }
                while (render.Step1 != true);
                Posission1.Add(Player1.Posission);
                Posission2.Add(Player2.Posission);
                Energy1.Add(Player1.Energy);
                Energy2.Add(Player2.Energy);
                if (render.Win() == true)
                    break;
                do
                {
                    render.Show();
                    render.Move(Console.ReadKey(), Player2);
                }
                while (render.Step2 != true);
                Posission1.Add(Player1.Posission);
                Posission2.Add(Player2.Posission);
                Energy1.Add(Player1.Energy);
                Energy2.Add(Player2.Energy);
                if (render.Win() == true)
                    break;
            }
            Posission1.Add(Player1.Posission);
            Posission2.Add(Player2.Posission);
            Energy1.Add(Player1.Energy);
            Energy2.Add(Player2.Energy);
            Console.Clear();
            Console.WriteLine("Выграл " + render.Winer.Name);
            Thread.Sleep(1000);
        }

        void Ramd(Hero hero1, Hero hero2)
        {
            Random random = new Random();
            if (random.Next(1,3) == 1)
            {
                Player1 = hero1;
                Player2 = hero2;
            }
            else
            {
                Player1 = hero2;
                Player2 = hero1;
            }
            Console.WriteLine("Игрок " + Player1.Name + " ходит первый");
            Thread.Sleep(1000);
        }

        public void Play()
        {
            Hero hero1, hero2;
            Console.WriteLine("Первый игрок выберает персонажа");
            for(int i=0;i<heroes.Count;i++)
            {
                Console.WriteLine((i + 1).ToString() + " " + heroes[i].Name);
            }
            Console.WriteLine("Введите номер персонажа");
            int index1 = int.Parse(Console.ReadLine());
            hero1 = heroes[--index1];
            heroes.RemoveAt(index1);
            Console.Clear();
            Console.WriteLine("Второй игрок выберает персонажа");
            for (int i = 0; i < heroes.Count; i++)
            {
                Console.WriteLine((i + 1).ToString() + " " + heroes[i].Name);
            }
            Console.WriteLine("Введите номер персонажа");
            int index2 = int.Parse(Console.ReadLine());
            hero2 = heroes[--index2];
            heroes.RemoveAt(index2);
            Ramd(hero1, hero2);
            Console.Clear();
            Go();
            while (true)
            {
                Console.Clear();
                Console.WriteLine("1 Посмотреть запись игры");
                Console.WriteLine("2 Сохранить запись игры и выйти");
                Console.WriteLine("Введите номер");
                int key = int.Parse(Console.ReadLine());
                if (key == 1)
                    Recording();
                else if (key == 2)
                    Save();
            }
        }

        void Save()
        {
            using (var db = new LiteDatabase(@"Data.db"))
            {
                var c = db.GetCollection<Play>("Playes");
                var result = c.FindAll();
                int count = 0;
                foreach(Play play1 in result)
                {
                    Console.WriteLine(play1.Name);
                    count++;
                }
                string name = "";
                Play result2 = null;
                do
                {
                    Console.Write("Введите уникальное имя ");
                    name = Console.ReadLine();
                    result2 = c.FindOne(x => x.Name == name);
                    if (count == 0)
                        break;
                }
                while (result2 != null);
                Play play = new Play();
                play.Name = name;
                play.NamePlaer1 = Player1.Name;
                play.NamePlaer2 = Player2.Name;
                play.Posission1 = Posission1;
                play.Posission2 = Posission2;
                play.Energy1 = Energy1;
                play.Energy2 = Energy2;
                var res = c.Insert(play);
            }
            Environment.Exit(0);
        }

        public void Show(int k1, int k2)
        {
            Console.Clear();
            Console.WriteLine(k1 + " " + k2);
            for (int i = 0; i < GameArea.Count; i++)
            {
                Console.WriteLine(string.Join("", GameArea[i]));
            }
        }

        public void Games()
        {
            using (var db = new LiteDatabase(@"Data.db"))
            {
                var c = db.GetCollection<Play>("Playes");
                var result = c.FindAll();
                int count = 0;
                foreach (Play play1 in result)
                {
                    Console.WriteLine(play1.Name);
                    count++;
                }
                string name = "";
                if (count == 0)
                    return;
                Play result2 = null;
                do
                {
                    Console.Write("Введите уникальное имя ");
                    name = Console.ReadLine();
                    result2 = c.FindOne(x => x.Name == name);
                }
                while (result2 == null);
                Energy1 = result2.Energy1;
                Energy2 = result2.Energy2;
                Posission1 = result2.Posission1;
                Posission2 = result2.Posission2;
                GameArea.Add(new string[] { "#", "#", "#", "#" });
                GameArea.Add(new string[] { "#", result2.NamePlaer1, result2.NamePlaer2, "#" });
                for (int i = 1; i < 20; i++)
                {
                    GameArea.Add(new string[] { "#", " ", " ", "#" });
                }
                GameArea.Add(new string[] { "#", "#", "#", "#" });
                Show(Energy1[0], Energy2[0]);
                Thread.Sleep(1000);
                for (int i = 1; i < Posission1.Count; i++)
                {
                    GameArea[Posission1[i - 1]][1] = " ";
                    GameArea[Posission1[i]][1] = result2.NamePlaer1;
                    GameArea[Posission2[i - 1]][2] = " ";
                    GameArea[Posission2[i]][2] = result2.NamePlaer2;
                    Show(Energy1[i], Energy2[i]);
                    Thread.Sleep(1000);
                }
                GameArea.Clear();
            }
        }

        void Recording()
        {
            GameArea.Add(new string[] { "#", "#", "#", "#" });
            GameArea.Add(new string[] { "#", Player1.Name, Player2.Name, "#" });
            for (int i = 1; i < 20; i++)
            {
                GameArea.Add(new string[] { "#", " ", " ", "#" });
            }
            GameArea.Add(new string[] { "#", "#", "#", "#" });
            Show(Energy1[0], Energy2[0]);
            Thread.Sleep(1000);
            for (int i=1;i<Posission1.Count;i++)
            {
                GameArea[Posission1[i - 1]][1] = " ";
                GameArea[Posission1[i]][1] = Player1.Name;
                GameArea[Posission2[i - 1]][2] = " ";
                GameArea[Posission2[i]][2] = Player2.Name;
                Show(Energy1[i], Energy2[i]);
                Thread.Sleep(1000);
            }
            GameArea.Clear();
        }
    }
}
