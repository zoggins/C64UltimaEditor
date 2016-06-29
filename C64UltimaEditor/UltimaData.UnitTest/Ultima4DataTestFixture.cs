using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltimaData.UnitTest
{
    [TestClass]
    public class Ultima4DataTestFixture
    {
        [TestMethod]
        public void Ctor()
        {
            Ultima4Data data = new Ultima4Data();

            Assert.AreEqual(0, data.NumberOfCharactersInParty);
            Assert.AreEqual(8, data.Characters.Length);

            Assert.AreEqual(26, data.Spells.Length);
            foreach (var spell in data.Spells)
                Assert.AreEqual(0, spell);

            Assert.AreEqual(8, data.Reagents.Length);
            foreach (var reagent in data.Reagents)
                Assert.AreEqual(0, reagent);

            Assert.AreEqual(8, data.Armor.Length);
            foreach (var armor in data.Armor)
                Assert.AreEqual(0, armor);

            Assert.AreEqual(16, data.Weapons.Length);
            foreach (var weapon in data.Weapons)
                Assert.AreEqual(0, weapon);

            Assert.AreEqual(0, data.Food);
            Assert.AreEqual(0, data.Gold);
            Assert.AreEqual(0, data.Torches);
            Assert.AreEqual(0, data.Gems);
            Assert.AreEqual(0, data.Keys);
            Assert.AreEqual(0, data.Sextants);
            Assert.AreEqual(false, data.Skull);
            Assert.AreEqual(false, data.Horn);
            Assert.AreEqual(false, data.Wheel);
            Assert.AreEqual(false, data.Candle);
            Assert.AreEqual(false, data.Book);
            Assert.AreEqual(false, data.Bell);
            Assert.AreEqual(false, data.KeyOfTruth);
            Assert.AreEqual(false, data.KeyOfLove);
            Assert.AreEqual(false, data.KeyOfCourage);
            Assert.AreEqual(0, data.Moves);

            Assert.AreEqual('A', data.Location.Lat1);
            Assert.AreEqual('A', data.Location.Lat2);
            Assert.AreEqual('A', data.Location.Long1);
            Assert.AreEqual('A', data.Location.Long2);

            Assert.AreEqual(8, data.Stones.Length);
            foreach (var stone in data.Stones)
                Assert.AreEqual(false, stone);

            Assert.AreEqual(8, data.Runes.Length);
            foreach (var rune in data.Runes)
                Assert.AreEqual(false, rune);

            Assert.AreEqual(8, data.Virtues.Length);
            foreach (var virtue in data.Virtues)
                Assert.AreEqual(0, virtue);

            Assert.AreEqual(U4Transportation.Foot, data.CurrentTransportation);
        }

        [TestMethod]
        public void Load()
        {

        }
    }
}
