
namespace GildedRose.Console
{
    public static class ItemQualityExtensions
    {
        public static void IncreaseQuality(this Item item)
        {
            if (item.Quality < 50)
                item.Quality++;
        }

        public static void DecreaseQuality(this Item item)
        {
            if (item.Quality > 0)
                item.Quality--;
        }

        public static void SetQualityToZero(this Item item)
        {
            item.Quality = 0;
        }
    }
}
