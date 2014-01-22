namespace GildedRose.Console
{
    public class BackstagePass : QualityItem
    {
        public BackstagePass(Item item)
            : base(item)
        { }

        public override void UpdateQuality()
        {
            if (item.SellIn > 0)
                item.IncreaseQuality();
            else
                item.SetQualityToZero();
            if (item.SellIn < 11)
                item.IncreaseQuality();
            if (item.SellIn < 6)
                item.IncreaseQuality();

            item.DecreaseSellIn();
        }
    }
}
