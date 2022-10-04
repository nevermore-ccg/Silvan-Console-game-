using System;
using System.Collections.Generic;
using System.Text;
using Silvan_Wysocki_.Классы;

namespace Silvan_Wysocki_.Классы
{
    public class Events
    {
        public void City(ref Character Player)
        {
            int GoodsIndex1= 0;
            int GoodsIndex2= 0;
            int GoodsIndex3= 0;
            Goods_Generation(ref GoodsIndex1,ref GoodsIndex2, ref GoodsIndex3, out Dictionary<int, Goods> goods);
            Random rnd = new Random();
            string[] Cities = { "Ольцбург", "Фердоро", "Мариенсбург", "Липеце", "Дурсвиль", "Зорково", "Щерч", "Берчер", "Цекюр", "Вейленс" };
            int CityIndex = rnd.Next(Cities.Length);

            Console.WriteLine("\nВы сейчас находитесь в городе {0}", Cities[CityIndex] +
                   "\nПеред отправкой в путешествие вы можете посетить магазин и закупиться всем необходимым" +
                   "\n1 - Отправиться в путешествие" +
                   "\n2 - Посетить магазин" +
                   "\n3 - Посмотреть свои характеристики" +
                   "\n4 - Выйти из игры");
            int Input = Convert.ToInt32(Console.ReadLine());
            if (Input == 1)
            {
                Road(ref Player);
            }
            else if (Input == 2)
            {
                Shop(ref Player,ref GoodsIndex1,ref GoodsIndex2,ref GoodsIndex3, goods);
            }
            else if (Input == 3)
            {
                Player.Info();
                Console.ReadKey();
                City(ref Player);
            }
            else if (Input == 4)
            {
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("\nНекорректный ввод данных");
                City(ref Player);
            }
        }
        public void Goods_Generation(ref int GoodsIndex1, ref int GoodsIndex2, ref int GoodsIndex3, out Dictionary<int, Goods> goods)
        {
            Goods Зачарованный_наперсток = new Goods { Name = "Зачарованный наперсток(Защита + 2, Атака + 1)", DEF = 2, DMG = 1, Cost = 200 };
            Goods Зелье_здоровья_2 = new Goods { Name = "Зелье восстановления(Здоровье +20)", HP = 20, Cost = 200 };
            Goods Зелье_здоровья_3 = new Goods { Name = "Зелье восстановления(Здоровье +30)", HP = 30, Cost = 300 };
            Goods Травы_берсерка = new Goods { Name = "Травы берсерка(Здоровье -10, Урон +6)", HP = -10, DMG = 6, Cost = 600 };
            Goods Зелье_скорости_1 = new Goods { Name = "Зелье скорости(Скорость +1)", SPD = 1, Cost = 100 };
            Goods Зелье_скорости_2 = new Goods { Name = "Зелье скорости(Скорость +4)", SPD = 4, Cost = 300 };
            Goods Зелье_здоровья_1 = new Goods { Name = "Зелье восстановления(Здоровье +10)", HP = 10, Cost = 100 };
            Random rnd = new Random();
            goods = new Dictionary<int, Goods>()
            {
                {0, Зачарованный_наперсток },
                {1, Зелье_здоровья_2 },
                {2, Зелье_здоровья_3 },
                {3, Травы_берсерка },
                {4, Зелье_скорости_1 },
                {5, Зелье_скорости_2 },
                {6, Зелье_здоровья_1 },

            };
            GoodsIndex1 = rnd.Next(goods.Count);
            GoodsIndex2 = rnd.Next(goods.Count);
            GoodsIndex3 = rnd.Next(goods.Count);
            goods[GoodsIndex1].Quantity = rnd.Next( 1 ,4);
            goods[GoodsIndex2].Quantity = rnd.Next( 1, 4);
            goods[GoodsIndex3].Quantity = rnd.Next( 1, 4);
        }
        public void Shop(ref Character Player,ref int GoodsIndex1,ref int GoodsIndex2, ref int GoodsIndex3, Dictionary<int, Goods> goods)
        {
            Console.WriteLine($"\nВы видите перед собой полку с товарами:" +
           $"\n1 - {goods[GoodsIndex1].Name} Цена: {goods[GoodsIndex1].Cost} Количество: {goods[GoodsIndex1].Quantity}" +
           $"\n2 - {goods[GoodsIndex2].Name} Цена: {goods[GoodsIndex2].Cost} Количество: {goods[GoodsIndex2].Quantity}" +
           $"\n3 - {goods[GoodsIndex3].Name} Цена: {goods[GoodsIndex3].Cost} Количество: {goods[GoodsIndex3].Quantity}" +
           $"\n4 - Посмотреть свои характеристики" +
           $"\n5 - Отправиться в путешествие");
            int Input = Convert.ToInt32(Console.ReadLine());

            if (Input == 1)
            {
                if (goods[GoodsIndex1].Quantity > 0)
                {
                    if (Player.Money >= goods[GoodsIndex1].Cost)
                    {
                        goods[GoodsIndex1].Purchase(ref Player, goods[GoodsIndex1]);
                        Console.WriteLine($"\nТовар куплен. У вас осталось {Player.Money} монет");
                        goods[GoodsIndex1].Quantity = goods[GoodsIndex1].Quantity - 1;
                        if (goods[GoodsIndex1].Quantity == 0)
                            goods[GoodsIndex1] = new Goods { Name = "Пустя полка", Cost = 0 };

                    }
                    else
                        Console.WriteLine($"\nУ вас недостаточно средств. Вам не хватает  {goods[GoodsIndex1].Cost - Player.Money} монет");
                }

            else if (goods[GoodsIndex1].Quantity == 0)
                {
                    Console.WriteLine($"\nТовар распродан");
                }
                Shop(ref Player, ref GoodsIndex1, ref GoodsIndex2, ref GoodsIndex3, goods);
            }
            else if (Input == 2)
            {
                if (goods[GoodsIndex2].Quantity > 0)
                {
                    if (Player.Money >= goods[GoodsIndex2].Cost)
                    {
                        goods[GoodsIndex2].Purchase(ref Player, goods[GoodsIndex2]);
                        Console.WriteLine($"\nТовар куплен. У вас осталось {Player.Money} монет");
                        goods[GoodsIndex2].Quantity = goods[GoodsIndex2].Quantity - 1;
                        if (goods[GoodsIndex2].Quantity == 0)
                            goods[GoodsIndex2] = new Goods { Name = "Пустя полка", Cost = 0 };

                    }
                    else
                        Console.WriteLine($"\nУ вас недостаточно средств. Вам не хватает  {goods[GoodsIndex2].Cost - Player.Money} монет");
                }

                else if (goods[GoodsIndex2].Quantity == 0)
                {
                    Console.WriteLine($"\nТовар распродан");
                }
                Shop(ref Player, ref GoodsIndex1, ref GoodsIndex2, ref GoodsIndex3, goods);
            }
            else if (Input == 3)
            {
                if (goods[GoodsIndex3].Quantity > 0)
                {
                    if (Player.Money >= goods[GoodsIndex3].Cost)
                    {
                        goods[GoodsIndex3].Purchase(ref Player, goods[GoodsIndex3]);
                        Console.WriteLine($"\nТовар куплен. У вас осталось {Player.Money} монет");
                        goods[GoodsIndex3].Quantity = goods[GoodsIndex3].Quantity - 1;
                        if (goods[GoodsIndex3].Quantity == 0)
                            goods[GoodsIndex3] = new Goods { Name = "Пустя полка", Cost = 0 };

                    }
                    else
                        Console.WriteLine($"\nУ вас недостаточно средств. Вам не хватает  {goods[GoodsIndex3].Cost - Player.Money} монет");
                }

                else if (goods[GoodsIndex3].Quantity == 0)
                {
                    Console.WriteLine($"\nТовар распродан");
                }
                Shop(ref Player, ref GoodsIndex1, ref GoodsIndex2, ref GoodsIndex3, goods);
            }
            else if (Input == 4)
            {
                Player.Info();
                Shop(ref Player, ref GoodsIndex1, ref GoodsIndex2, ref GoodsIndex3, goods);
            }
            else if (Input == 5)
            {
                Road(ref Player);
            }
            else
            {
                Console.WriteLine("\nНекорректный ввод данных");
                Shop(ref Player, ref GoodsIndex1, ref GoodsIndex2, ref GoodsIndex3, goods);
            }

        }

        public void Road(ref Character Player)
        {
            Random rnd = new Random();
            int Probability = rnd.Next(1, 4);
            int Fight = 1;
            int Treasure = 2;
            int Town = 3;
            int Crossroads = 4;
            Enemy Current_Enemy = null;
            if (Probability == Fight)
                Encounter(ref Player,ref Current_Enemy);
            else if (Probability == Treasure)
                Findings(ref Player);
            else if (Probability == Town)
                City(ref Player);
            else if (Probability == Crossroads)
                Crossroad(ref Player);

        }
        public void Enemy_Generation(out Dictionary<int, Enemy> Enemies, out int EnemyIndex)
        {
            Enemy Бандит = new Enemy {Name= "Бандит", HP = 100, DEF = 3, SPD = 23, DMG = 10, Money = 300 };
            Enemy Волк = new Enemy { Name = "Волк", HP = 100, DEF = 1, SPD = 40, DMG = 15, Money = 450 };
            Enemy Медведь = new Enemy { Name = "Медведь", HP = 100, DEF = 4, SPD = 23, DMG = 20, Money = 700 };
            Enemy Зомби = new Enemy { Name = "Зомби", HP = 100, DEF = 0, SPD = 10, DMG = 8, Money = 150 };
            Enemy Дикарь = new Enemy { Name = "Дикарь", HP = 100, DEF = 2, SPD = 30, DMG = 15, Money = 350 };
            Enemy Бандитствующий_рыцарь = new Enemy { Name = "Бандитствующий_рыцарь", HP = 100, DEF = 6, SPD = 23, DMG = 15, Money = 650 };
            Enemies = new Dictionary<int, Enemy>
            {
            { 0, Бандит },
            { 1, Волк },
            { 2, Медведь },
            { 3, Зомби },
            { 4, Дикарь },
            { 5, Бандитствующий_рыцарь }
            };
            Random rnd = new Random();
            EnemyIndex = rnd.Next(Enemies.Count);

        }

        public void Encounter(ref Character Player,ref Enemy Current_Enemy)
        {
            if (Current_Enemy == null)
            {
                Dictionary<int, Enemy> Enemies;
                int EnemyIndex;
                Enemy_Generation(out Enemies, out EnemyIndex);
                Current_Enemy = Enemies[EnemyIndex];
            }
            Console.WriteLine($"\nПо дороге вы встретили противника: {Current_Enemy.Name}" +
                $"\nЗдоровье: {Current_Enemy.HP}" +
                $"\nАтака: {Current_Enemy.DMG}" +
                $"\nЗащита: {Current_Enemy.DEF}" +
                $"\nСкорость: {Current_Enemy.SPD}");
            Player.Info();
            Console.WriteLine("\n1 - Атаковать" +
                "\n2 - Попытаться убежать");
            int Input = Convert.ToInt32(Console.ReadLine());
            if (Input == 1)
            {
                Player.Attack(ref Player, ref Current_Enemy);
                Current_Enemy.Attack(ref Player, ref Current_Enemy);
                if (Player.HP <= 0)
                {
                    Console.WriteLine($"\nВаш персонаж {Player.Class} {Player.Name} погиб. Игра окончена");
                    Console.ReadLine();

                }
                else if (Current_Enemy.HP <= 0)
                {
                    Player.Money = Player.Money + Current_Enemy.Money;
                    Console.WriteLine($"\nВы смогли победить противника {Current_Enemy.Name}!" +
                        $"\nВаша награда {Current_Enemy.Money} монет" +
                        $"\nТеперь вы имеете {Player.Money} монет");
                    Road(ref Player);
                }
                Encounter(ref Player, ref Current_Enemy);
            }
            if (Input == 2)
                Flee(ref Player,ref Current_Enemy);
                
        }

        public void Findings(ref Character Player)
        {
            int[] treasure = { 100, 200, 300, 400, 500 };
            Random rnd = new Random();
            int Finding = rnd.Next(treasure.Length);
            Player.Money = Player.Money + Finding;
            Console.WriteLine($"\nВы нашли сокровище!" +
                $"\nПолучено {Finding} монет" +
                $"\nВсего {Player.Money} монет");
            Console.ReadLine();
            Road(ref Player);

        }

        public void Crossroad(ref Character Player)
        {
            Random rnd = new Random();
            string[] locations = { "Лес", "Холмы", "Берег реки", "Мост", "Побережье моря", "Развалины", "" };
            Console.WriteLine($"\n{Player.Name} дошёл до перекрёстка, вы можете отправиться: " +
                $"\n1 - Вправо - {locations[rnd.Next(locations.Length)]}" +
                $"\n2 - Влево - {locations[rnd.Next(locations.Length)]}" +
                $"\n3 - Вправо - {locations[rnd.Next(locations.Length)]}");
            Console.ReadLine();

            Road(ref Player);

        }
        public void Flee(ref Character Player, ref Enemy Current_Enemy)
        {
            double probability = Player.SPD / Current_Enemy.SPD;
            Random rnd = new Random();
            double random = rnd.NextDouble();
            if (random < probability)
            {
                Console.WriteLine("\nВам удалось сбежать!");
                Road(ref Player);
            }
            else
            {
                Console.WriteLine("\nВам не удалось сбежать");
                Current_Enemy.Attack(ref Player, ref Current_Enemy);
                if (Player.HP <= 0)
                {
                    Console.WriteLine($"\nВаш персонаж {Player.Class} {Player.Name} погиб. Игра окончена");
                    Console.ReadLine();

                }
                Encounter(ref  Player, ref Current_Enemy);

            }



        }
    }
}
