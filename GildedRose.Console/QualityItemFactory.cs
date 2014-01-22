using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GildedRose.Console
{
    public class QualityItemFactory
    {
        public QualityItem CreateQualityItem(Item item)
        {
            if (item.Name == "Aged Brie")
                return new AgedBrie(item);
            else if (item.Name == "Sulfuras, Hand of Ragnaros")
                return new Sulfuras(item);
            else if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
                return new BackstagePass(item);
            else if (item.Name == "Conjured Mana Cake")
                return new ConjuredItem(item);
            else
                return new RegularItem(item);
        }
    }
}
