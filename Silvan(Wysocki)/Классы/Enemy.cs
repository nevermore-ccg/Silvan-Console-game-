using System;
using System.Collections.Generic;
using System.Text;
using Silvan_Wysocki_.Классы;

namespace Silvan_Wysocki_.Классы
{
    public class Enemy
    {
        public string Name { get; set; }
        public int HP { get; set; }
        public int DMG { get; set; }
        public int SPD { get; set; }
        public int DEF { get; set; }
        public int Money { get; set; }
        public void Attack(ref Character Player, ref Enemy enemy)
        {
            Player.HP = Player.HP - (enemy.DMG - Player.DEF);
        }
    }
}
