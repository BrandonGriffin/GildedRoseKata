namespace GildedRose.Console
{
    public class RegularItem : QualityItem
    {
        public RegularItem(Item item)
            : base(item)
        { }

        public override void UpdateQuality()
        {
            item.DecreaseQuality();
            item.DecreaseSellIn();

            if (item.ItemIsBeyondSellByDate())
            {
                if (item.Quality > 0)
                    item.DecreaseQuality();
                else
                    item.SetQualityToZero();
            }
        }
    }
}
