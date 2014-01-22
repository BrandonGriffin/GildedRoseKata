using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GildedRose.Console
{
    public static class SellInItemExtensions
    {
        public static void DecreaseSellIn(this Item item)
        {
            item.SellIn--;
        }

        public static Boolean ItemIsBeyondSellByDate(this Item item)
        {
            return item.SellIn < 0;
        }
    }
}
