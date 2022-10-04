using System;
using System.Collections.Generic;
using System.Text;
using Silvan_Wysocki_.Классы;

namespace Silvan_Wysocki_.Классы
{
    public class Goods
    {
        public string Name { get; set; }
        public int HP { get; set; }
        public int DMG { get; set; }
        public int SPD { get; set; }
        public int DEF { get; set; }
        public int Quantity { get; set; }
        public int Cost { get; set; }

        public void Purchase(ref Character Player, Goods Item)
        {
            Player.HP = Player.HP + Item.HP;
            Player.DMG = Player.DMG + Item.DMG;
            Player.SPD = Player.SPD + Item.SPD;
            Player.DEF = Player.DEF + Item.DEF;
            Player.Money = Player.Money - Item.Cost;
        }
    }
}
