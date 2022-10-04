using System;
using System.Collections.Generic;
using System.Text;
using Silvan_Wysocki_.Классы;

namespace Silvan_Wysocki_
{
    public class Character
    {
        public string Name { get; set; }
        public string Class { get; set; }
        public int HP { get; set; }
        public int DMG { get; set; }
        public int SPD { get; set; }
        public int DEF { get; set; }

        public int Money = 600;
        public void Info()
        {
            Console.WriteLine("\nВаш персонаж: ");
            Console.WriteLine($"{Class} {Name}");
            Console.WriteLine($"\nЗдоровье = {HP} \nУрон = {DMG} \nСкорость = {SPD} \nЗащита = {DEF} \nДеньги = {Money}");
        }
        public void Attack(ref Character Player, ref Enemy enemy)
        {
            enemy.HP = enemy.HP - (Player.DMG - enemy.DEF);
        }
    }

}
