using System;
using System.Collections.Generic;
using GildedRose.Console;
using NUnit.Framework;

namespace GildedRose.Tests
{
    [TestFixture]
    public class UpdaterTests
    {
        private List<Item> Items;
        private Updater updater;

        [SetUp]
        public void SetUp()
        {
            updater = new Updater();

            Items = new List<Item>
            {
                new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                new Item {Name = "Aged Brie", SellIn = 2, Quality = 0},
                new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
                new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                new Item
                    {
                        Name = "Backstage passes to a TAFKAL80ETC concert",
                        SellIn = 15,
                        Quality = 20
                    },
                new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
            };
        }

        [Test]
        public void SellInGoesDownByOneEachDay()
        {
            updater.UpdateQuality(Items);
            Assert.That(Items[0].SellIn, Is.EqualTo(9));
        }
        
        [Test]
        public void QualityDegreadesAtTheEndOfEachDay()
        {
            updater.UpdateQuality(Items);
            Assert.That(Items[0].Quality, Is.EqualTo(19));
        }

        [Test]
        public void OnceSellInIsAt0QualityDegradesTwiceAsFast()
        {
            PassDays(11);
            Assert.That(Items[0].Quality, Is.EqualTo(8));
        }

        [Test]
        public void QualityIsNeverNegative()
        {
            PassDays(20);
            Assert.That(Items[0].Quality, Is.EqualTo(0));
        }

        [Test]
        public void AgedBrieIncreasesInQualityAsTimePasses()
        {
            var agedBrie = Items[1];
            updater.UpdateQuality(Items);

            Assert.That(agedBrie.Quality, Is.EqualTo(1));
        }

        [Test]
        public void QualityIsNeverGreaterThan50()
        {
            var agedBrie = Items[1];
            PassDays(101);

            Assert.That(agedBrie.Quality, Is.EqualTo(50));
        }

        [Test]
        public void SulfurasAlwaysHasAQualityOf80()
        {
            var sulfuras = Items[3];
            PassDays(11);

            Assert.That(sulfuras.Quality, Is.EqualTo(80));
        }

        [Test]
        public void BackstagePassesIncreaseDoublyWhenSellInIs10OrLess()
        {
            var backstagePass = Items[4];
            PassDays(6);

            Assert.That(backstagePass.Quality, Is.EqualTo(27));
        }

        [Test]
        public void BackstagePassesIncreaseBy3IfThereIsFiveOrLessDaysToTheShow()
        {
            var backstagePass = Items[4];
            PassDays(11);

            Assert.That(backstagePass.Quality, Is.EqualTo(38));
        }

        [Test]
        public void ConjuredGoodsShouldDecreaseTwiceAsFast()
        {
            var conjuredGood = Items[5];
            PassDays(1);

            Assert.That(conjuredGood.Quality, Is.EqualTo(4));
        }

        private void PassDays(Int32 daysToPass)
        {
            for (var i = daysToPass; i > 0; i--)
                updater.UpdateQuality(Items);
        }
    }
}