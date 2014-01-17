using System;
using System.Collections.Generic;

namespace GildedRose.Console
{
    public class Updater
    {
        public void UpdateQuality(IList<Item> Items)
        {
            foreach (var item in Items)
            {
                if (ItemIsDegradable(item))
                {
                    DecreaseQuality(item);
                }
                else
                {
                    IncreaseQuality(item);

                    if (ItemIsTimeSensitive(item))
                    {
                        if (item.SellIn < 11)
                            IncreaseQuality(item);

                        if (item.SellIn < 6)
                            IncreaseQuality(item);
                    }
                }

                if (ItemHasASellByDate(item))
                    DecreaseSellIn(item);

                if (ItemIsBeyondSellByDate(item))
                {
                    if (ItemIsDegradable(item))
                    {
                        if (item.Quality > 0)
                            DecreaseQuality(item);
                        else
                            SetQualityToZero(item);
                    }
                    else
                    {
                        IncreaseQuality(item);
                    }
                }
            }
        }

        private static Boolean ItemIsTimeSensitive(Item item)
        {
            return item.Name == "Backstage passes to a TAFKAL80ETC concert";
        }

        private static void SetQualityToZero(Item item)
        {
            item.Quality = 0;
        }

        private static Boolean ItemIsBeyondSellByDate(Item item)
        {
            return item.SellIn < 0;
        }

        private static void DecreaseSellIn(Item item)
        {
            item.SellIn--;
        }

        private static Boolean ItemHasASellByDate(Item item)
        {
            return item.Name != "Sulfuras, Hand of Ragnaros";
        }

        private static void IncreaseQuality(Item item)
        {
            if (item.Quality < 50)
            {
                item.Quality++;
            }
        }

        private static Boolean ItemIsDegradable(Item Item)
        {
            return Item.Name != "Aged Brie" && Item.Name != "Backstage passes to a TAFKAL80ETC concert" && Item.Name != "Sulfuras, Hand of Ragnaros";
        }

        private static void DecreaseQuality(Item Item)
        {
            if (Item.Quality > 0)
            {
                if (Item.Name != "Sulfuras, Hand of Ragnaros")
                {
                    Item.Quality = Item.Quality - 1;
                }
            }
        }
    }
}
