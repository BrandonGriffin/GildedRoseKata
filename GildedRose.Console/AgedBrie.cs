namespace GildedRose.Console
{
    public class AgedBrie : QualityItem
    {
        public AgedBrie(Item item)
            : base(item)
        { }

        public override void UpdateQuality()
        {
            item.DecreaseSellIn();
            item.IncreaseQuality();
        }
    }
}
