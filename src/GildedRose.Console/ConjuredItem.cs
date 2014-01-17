namespace GildedRose.Console
{
    public class ConjuredItem : QualityItem
    {
        public ConjuredItem(Item item)
            : base(item)
        { }

        public override void UpdateQuality()
        {
            item.DecreaseSellIn();
            item.DecreaseQuality();
            item.DecreaseQuality();
        }
    }
}
