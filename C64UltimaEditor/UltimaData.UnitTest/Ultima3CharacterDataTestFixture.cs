using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UltimaData.UnitTest
{
    [TestClass]
    public class Ultima3CharacterDataTestFixture
    {
        [TestMethod]
        public void Ctor()
        {
            Ultima3CharacterData character = new Ultima3CharacterData();

            Assert.AreEqual("", character.Name);
            
            Assert.AreEqual(false, character.CardOfDeath);
            Assert.AreEqual(false, character.CardOfSol);
            Assert.AreEqual(false, character.CardOfMoon);
            Assert.AreEqual(false, character.CardOfLove);

            Assert.AreEqual(false, character.MarkOfFire);
            Assert.AreEqual(false, character.MarkOfSnake);
            Assert.AreEqual(false, character.MarkOfForce);
            Assert.AreEqual(false, character.MarkOfKings);

            Assert.AreEqual(0, character.Torches);

            Assert.AreEqual(U3Sex.Male, character.Sex);
            Assert.AreEqual(U3Class.Fighter, character.Class);
            Assert.AreEqual(U3Health.Good, character.Health);
            Assert.AreEqual(150, character.HitPoints);
            Assert.AreEqual(150, character.MaxHitPoints);
            Assert.AreEqual(0, character.MagicPoints);
            Assert.AreEqual(0, character.Experience);
            Assert.AreEqual(0, character.Strength);
            Assert.AreEqual(0, character.Agility);
            Assert.AreEqual(0, character.Intelligence);
            Assert.AreEqual(0, character.Wisdom);
            Assert.AreEqual(0, character.Food);
            Assert.AreEqual(0, character.Gems);
            Assert.AreEqual(0, character.Keys);
            Assert.AreEqual(0, character.Powder);
            Assert.AreEqual(0, character.Food);
            Assert.AreEqual(U3Weapons.Hands, character.EquippedWeapon);
            Assert.AreEqual(U3Armor.Skin, character.EquippedArmor);

            Assert.AreEqual(8, character.Armor.Length);
            foreach (var armor in character.Armor)
                Assert.AreEqual(0, armor);

            Assert.AreEqual(16, character.Weapons.Length);
            foreach (var weapon in character.Weapons)
                Assert.AreEqual(0, weapon);
        }
    }
}
