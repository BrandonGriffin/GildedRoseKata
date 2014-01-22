using System.Collections.Generic;
using System.Linq;

namespace GildedRose.Console
{
    public class Updater
    {
        private QualityItemFactory qualityItemFactory;

        public Updater(QualityItemFactory qualityItemFactory)
        {
            this.qualityItemFactory = qualityItemFactory;
        }

        public void UpdateQuality(IList<Item> items)
        {
            var qualityItems = items.Select(x => qualityItemFactory.CreateQualityItem(x));

            foreach (var i in qualityItems)
                i.UpdateQuality();
        }
    }
}
