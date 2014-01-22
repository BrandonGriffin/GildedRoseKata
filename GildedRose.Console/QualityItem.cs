using System;

namespace GildedRose.Console
{
    public abstract class QualityItem
    {
        protected Item item;

        public QualityItem(Item item)
        {
            this.item = item;
        }

        public abstract void UpdateQuality();        
    }
}
