using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics.CodeAnalysis;

namespace UltimaData.UnitTest
{
    [TestClass]
    public class Ultima4CharacterDataTestFixture
    {
        [TestMethod]
        public void Ctor()
        {
            Ultima4CharacterData character = new Ultima4CharacterData();

            Assert.AreEqual("", character.Name);
            Assert.AreEqual(U4Sex.Female, character.Sex);
            Assert.AreEqual(U4Class.Mage, character.Class);
            Assert.AreEqual(U4Health.Good, character.Health);
            Assert.AreEqual(0, character.HitPoints);
            Assert.AreEqual(100, character.MaxHitPoints);
            Assert.AreEqual(0, character.Experience);
            Assert.AreEqual(0, character.Strength);
            Assert.AreEqual(0, character.Dexterity);
            Assert.AreEqual(0, character.Intelligence);
            Assert.AreEqual(0, character.MagicPoints);
            Assert.AreEqual(U4Weapons.Hands, character.Weapon);
            Assert.AreEqual(U4Armor.Skin, character.Armor);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        [ExcludeFromCodeCoverage]
        public void HitPointsCappedByMaxHitPoints()
        {
            Ultima4CharacterData character = new Ultima4CharacterData();

            character.HitPoints = 200;
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        [ExcludeFromCodeCoverage]
        public void MaxHitPointsFlooredByHitPoints()
        {
            Ultima4CharacterData character = new Ultima4CharacterData();

            character.HitPoints = 100;
            character.MaxHitPoints = 50;
        }
    }
}
