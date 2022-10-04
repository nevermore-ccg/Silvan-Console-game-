using System;
using Silvan_Wysocki_.Классы;

namespace Silvan_Wysocki_
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Character Player = new Character {};
            Events Events = new Events {};

            Console.WriteLine("Добро пожаловать в игру Silvan");
            Console.WriteLine("\nВведите своё имя: ");
            string Name = Console.ReadLine();
            Console.WriteLine("\nВыберите класс: ");
            Console.WriteLine("1 - Воин");
            Console.WriteLine("2 - Варвар");
            Console.WriteLine("3 - Рыцарь");
            int Input = Convert.ToInt32(Console.ReadLine());
            if (Input == 1)
            {
                string Class = "Воин";
                Player = new Character { HP = 100, DEF = 4, SPD = 24, DMG = 25, Name = Name, Class = Class  };
            }
            else if(Input == 2)
            {
                string Class = "Варвар";
                Player = new Character { HP = 100, DEF = 2, SPD = 40, DMG = 30, Name = Name, Class = Class };
            }
            else if(Input == 3)
            {
                string Class = "Рыцарь";
                Player = new Character { HP = 100, DEF = 6, SPD = 20, DMG = 20, Name = Name, Class = Class };
            }
            else
            {
                Console.WriteLine("\nВы некорректно ввели номер класса");
            }
            Player.Info();

            Console.WriteLine("\nМир Silvan приветствует нового путешественника!");
            Events.City(ref Player);
        }
        
    }
}
