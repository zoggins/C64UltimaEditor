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
        [TestInitialize]
        public void LoadFromDisk()
        {
            File = new MockFile();
            File.Files["u4Data.dat"] = System.IO.File.ReadAllBytes("Data\\u4Data.dat");
            SaveFile = new Ultima4Data(File);
        }

        [TestMethod]
        public void Ctor()
        {
            Assert.AreEqual(0, SaveFile.NumberOfCharactersInParty);
            Assert.AreEqual(8, SaveFile.Characters.Length);

            Assert.AreEqual(26, SaveFile.Spells.Length);
            foreach (var spell in SaveFile.Spells)
                Assert.AreEqual(0, spell);

            Assert.AreEqual(8, SaveFile.Reagents.Length);
            foreach (var reagent in SaveFile.Reagents)
                Assert.AreEqual(0, reagent);

            Assert.AreEqual(8, SaveFile.Armor.Length);
            foreach (var armor in SaveFile.Armor)
                Assert.AreEqual(0, armor);

            Assert.AreEqual(16, SaveFile.Weapons.Length);
            foreach (var weapon in SaveFile.Weapons)
                Assert.AreEqual(0, weapon);

            Assert.AreEqual(0, SaveFile.Food);
            Assert.AreEqual(0, SaveFile.Gold);
            Assert.AreEqual(0, SaveFile.Torches);
            Assert.AreEqual(0, SaveFile.Gems);
            Assert.AreEqual(0, SaveFile.Keys);
            Assert.AreEqual(0, SaveFile.Sextants);
            Assert.AreEqual(false, SaveFile.Skull);
            Assert.AreEqual(false, SaveFile.Horn);
            Assert.AreEqual(false, SaveFile.Wheel);
            Assert.AreEqual(false, SaveFile.Candle);
            Assert.AreEqual(false, SaveFile.Book);
            Assert.AreEqual(false, SaveFile.Bell);
            Assert.AreEqual(false, SaveFile.KeyOfTruth);
            Assert.AreEqual(false, SaveFile.KeyOfLove);
            Assert.AreEqual(false, SaveFile.KeyOfCourage);
            Assert.AreEqual(0, SaveFile.Moves);

            Assert.AreEqual('A', SaveFile.Location.Lat1);
            Assert.AreEqual('A', SaveFile.Location.Lat2);
            Assert.AreEqual('A', SaveFile.Location.Long1);
            Assert.AreEqual('A', SaveFile.Location.Long2);

            Assert.AreEqual(8, SaveFile.Stones.Length);
            foreach (var stone in SaveFile.Stones)
                Assert.AreEqual(false, stone);

            Assert.AreEqual(8, SaveFile.Runes.Length);
            foreach (var rune in SaveFile.Runes)
                Assert.AreEqual(false, rune);

            Assert.AreEqual(8, SaveFile.Virtues.Length);
            foreach (var virtue in SaveFile.Virtues)
                Assert.AreEqual(0, virtue);

            Assert.AreEqual(U4Transportation.Foot, SaveFile.CurrentTransportation);
        }

        [TestMethod]
        public void LoadSimpleSaveFromDisk()
        {
            Assert.AreEqual(true, SaveFile.Load("u4Data.dat"));

            Assert.AreEqual(1, SaveFile.NumberOfCharactersInParty);
            Assert.AreEqual(8, SaveFile.Characters.Length);

            SaveFile.Characters[0].Name = "Ike";
            SaveFile.Characters[0].Sex = U4Sex.Male;
            SaveFile.Characters[0].Health = U4Health.Good;
            SaveFile.Characters[0].Class = U4Class.Shepherd;
            SaveFile.Characters[0].HitPoints = 300;
            SaveFile.Characters[0].MaxHitPoints = 300;
            SaveFile.Characters[0].Strength = 19;
            SaveFile.Characters[0].Dexterity = 19;
            SaveFile.Characters[0].Intelligence = 19;
            SaveFile.Characters[0].Weapon = U4EquipedWeapon.Staff;
            SaveFile.Characters[0].Armor = U4EquipedArmor.Cloth;

            Assert.AreEqual(26, SaveFile.Spells.Length);
            foreach (var spell in SaveFile.Spells)
                Assert.AreEqual(0, spell);

            Assert.AreEqual(8, SaveFile.Reagents.Length);
            Assert.AreEqual(0, SaveFile.Reagents[0]);
            Assert.AreEqual(3, SaveFile.Reagents[1]);
            Assert.AreEqual(4, SaveFile.Reagents[2]);
            for (int i = 3; i < 8; ++i)
                Assert.AreEqual(0, SaveFile.Reagents[i]);

            Assert.AreEqual(8, SaveFile.Armor.Length);
            foreach (var armor in SaveFile.Armor)
                Assert.AreEqual(0, armor);

            Assert.AreEqual(16, SaveFile.Weapons.Length);
            foreach (var weapon in SaveFile.Weapons)
                Assert.AreEqual(0, weapon);

            Assert.AreEqual(299, SaveFile.Food);
            Assert.AreEqual(200, SaveFile.Gold);
            Assert.AreEqual(2, SaveFile.Torches);
            Assert.AreEqual(0, SaveFile.Gems);
            Assert.AreEqual(0, SaveFile.Keys);
            Assert.AreEqual(0, SaveFile.Sextants);
            Assert.AreEqual(false, SaveFile.Skull);
            Assert.AreEqual(false, SaveFile.Horn);
            Assert.AreEqual(false, SaveFile.Wheel);
            Assert.AreEqual(false, SaveFile.Candle);
            Assert.AreEqual(false, SaveFile.Book);
            Assert.AreEqual(false, SaveFile.Bell);
            Assert.AreEqual(false, SaveFile.KeyOfTruth);
            Assert.AreEqual(false, SaveFile.KeyOfLove);
            Assert.AreEqual(false, SaveFile.KeyOfCourage);
            Assert.AreEqual(6, SaveFile.Moves);

            Assert.AreEqual('K', SaveFile.Location.Lat1);
            Assert.AreEqual('K', SaveFile.Location.Lat2);
            Assert.AreEqual('L', SaveFile.Location.Long1);
            Assert.AreEqual('K', SaveFile.Location.Long2);

            Assert.AreEqual(8, SaveFile.Stones.Length);
            foreach (var stone in SaveFile.Stones)
                Assert.AreEqual(false, stone);

            Assert.AreEqual(8, SaveFile.Runes.Length);
            foreach (var rune in SaveFile.Runes)
                Assert.AreEqual(false, rune);

            Assert.AreEqual(8, SaveFile.Virtues.Length);
            Assert.AreEqual(55, SaveFile.Virtues[0]);
            Assert.AreEqual(60, SaveFile.Virtues[1]);
            Assert.AreEqual(50, SaveFile.Virtues[2]);
            Assert.AreEqual(50, SaveFile.Virtues[3]);
            Assert.AreEqual(50, SaveFile.Virtues[4]);
            Assert.AreEqual(50, SaveFile.Virtues[5]);
            Assert.AreEqual(55, SaveFile.Virtues[6]);
            Assert.AreEqual(65, SaveFile.Virtues[7]);

            Assert.AreEqual(U4Transportation.Foot, SaveFile.CurrentTransportation);
        }

        [TestMethod]
        public void SimpleSaveAndReload()
        {
            Assert.AreEqual(true, SaveFile.Load("u4Data.dat"));

            Assert.AreEqual(true, SaveFile.Save("SimpleSave.d64"));

            Ultima4Data newSave = new Ultima4Data(File);

            Assert.AreEqual(true, newSave.Load("SimpleSave.d64"));

            Assert.AreEqual(1, newSave.NumberOfCharactersInParty);
            Assert.AreEqual(8, newSave.Characters.Length);

            Assert.AreEqual("Ike", newSave.Characters[0].Name);
            Assert.AreEqual(U4Sex.Male, newSave.Characters[0].Sex);
            Assert.AreEqual(U4Health.Good, newSave.Characters[0].Health);
            Assert.AreEqual(U4Class.Shepherd, newSave.Characters[0].Class);
            Assert.AreEqual(100, newSave.Characters[0].HitPoints);
            Assert.AreEqual(100, newSave.Characters[0].MaxHitPoints);
            Assert.AreEqual(16, newSave.Characters[0].Strength);
            Assert.AreEqual(22, newSave.Characters[0].Dexterity);
            Assert.AreEqual(19, newSave.Characters[0].Intelligence);
            Assert.AreEqual(U4EquipedWeapon.Staff, newSave.Characters[0].Weapon);
            Assert.AreEqual(U4EquipedArmor.Cloth, newSave.Characters[0].Armor);

            Assert.AreEqual(26, newSave.Spells.Length);
            foreach (var spell in newSave.Spells)
                Assert.AreEqual(0, spell);

            Assert.AreEqual(8, newSave.Reagents.Length);
            Assert.AreEqual(0, newSave.Reagents[0]);
            Assert.AreEqual(3, newSave.Reagents[1]);
            Assert.AreEqual(4, newSave.Reagents[2]);
            for (int i = 3; i < 8; ++i)
                Assert.AreEqual(0, newSave.Reagents[i]);

            Assert.AreEqual(8, newSave.Armor.Length);
            foreach (var armor in newSave.Armor)
                Assert.AreEqual(0, armor);

            Assert.AreEqual(16, newSave.Weapons.Length);
            foreach (var weapon in newSave.Weapons)
                Assert.AreEqual(0, weapon);

            Assert.AreEqual(299, newSave.Food);
            Assert.AreEqual(200, newSave.Gold);
            Assert.AreEqual(2, newSave.Torches);
            Assert.AreEqual(0, newSave.Gems);
            Assert.AreEqual(0, newSave.Keys);
            Assert.AreEqual(0, newSave.Sextants);
            Assert.AreEqual(false, newSave.Skull);
            Assert.AreEqual(false, newSave.Horn);
            Assert.AreEqual(false, newSave.Wheel);
            Assert.AreEqual(false, newSave.Candle);
            Assert.AreEqual(false, newSave.Book);
            Assert.AreEqual(false, newSave.Bell);
            Assert.AreEqual(false, newSave.KeyOfTruth);
            Assert.AreEqual(false, newSave.KeyOfLove);
            Assert.AreEqual(false, newSave.KeyOfCourage);
            Assert.AreEqual(6, newSave.Moves);

            Assert.AreEqual('K', newSave.Location.Lat1);
            Assert.AreEqual('K', newSave.Location.Lat2);
            Assert.AreEqual('L', newSave.Location.Long1);
            Assert.AreEqual('K', newSave.Location.Long2);

            Assert.AreEqual(8, newSave.Stones.Length);
            foreach (var stone in newSave.Stones)
                Assert.AreEqual(false, stone);

            Assert.AreEqual(8, newSave.Runes.Length);
            foreach (var rune in newSave.Runes)
                Assert.AreEqual(false, rune);

            Assert.AreEqual(8, newSave.Virtues.Length);
            Assert.AreEqual(55, newSave.Virtues[0]);
            Assert.AreEqual(60, newSave.Virtues[1]);
            Assert.AreEqual(50, newSave.Virtues[2]);
            Assert.AreEqual(50, newSave.Virtues[3]);
            Assert.AreEqual(50, newSave.Virtues[4]);
            Assert.AreEqual(50, newSave.Virtues[5]);
            Assert.AreEqual(55, newSave.Virtues[6]);
            Assert.AreEqual(65, newSave.Virtues[7]);

            Assert.AreEqual(U4Transportation.Foot, newSave.CurrentTransportation);
        }

        [TestMethod]
        public void SaveLoadMultipleCharacters()
        {
            Assert.AreEqual(true, SaveFile.Load("u4Data.dat"));

            SaveFile.NumberOfCharactersInParty = 2;

            SaveFile.Characters[1].Sex = U4Sex.Female;
            SaveFile.Characters[1].Health = U4Health.Asleep;
            SaveFile.Characters[1].Class = U4Class.Bard;
            SaveFile.Characters[1].HitPoints = 250;
            SaveFile.Characters[1].MaxHitPoints = 301;
            SaveFile.Characters[1].Strength = 17;
            SaveFile.Characters[1].Dexterity = 12;
            SaveFile.Characters[1].Intelligence = 25;
            SaveFile.Characters[1].Weapon = U4EquipedWeapon.Crossbow;
            SaveFile.Characters[1].Armor = U4EquipedArmor.MagicPlate;

            Assert.AreEqual(true, SaveFile.Save("MultipleCharacters.d64"));

            Ultima4Data newSave = new Ultima4Data(File);

            Assert.AreEqual(true, newSave.Load("MultipleCharacters.d64"));

            Assert.AreEqual(2, newSave.NumberOfCharactersInParty);

            Assert.AreEqual("Ike", newSave.Characters[0].Name);
            Assert.AreEqual(U4Sex.Male, newSave.Characters[0].Sex);
            Assert.AreEqual(U4Health.Good, newSave.Characters[0].Health);
            Assert.AreEqual(U4Class.Shepherd, newSave.Characters[0].Class);
            Assert.AreEqual(100, newSave.Characters[0].HitPoints);
            Assert.AreEqual(100, newSave.Characters[0].MaxHitPoints);
            Assert.AreEqual(16, newSave.Characters[0].Strength);
            Assert.AreEqual(22, newSave.Characters[0].Dexterity);
            Assert.AreEqual(19, newSave.Characters[0].Intelligence);
            Assert.AreEqual(U4EquipedWeapon.Staff, newSave.Characters[0].Weapon);
            Assert.AreEqual(U4EquipedArmor.Cloth, newSave.Characters[0].Armor);

            Assert.AreEqual("Iolo", newSave.Characters[1].Name);
            Assert.AreEqual(U4Sex.Female, newSave.Characters[1].Sex);
            Assert.AreEqual(U4Health.Asleep, newSave.Characters[1].Health);
            Assert.AreEqual(U4Class.Bard, newSave.Characters[1].Class);
            Assert.AreEqual(250, newSave.Characters[1].HitPoints);
            Assert.AreEqual(301, newSave.Characters[1].MaxHitPoints);
            Assert.AreEqual(17, newSave.Characters[1].Strength);
            Assert.AreEqual(12, newSave.Characters[1].Dexterity);
            Assert.AreEqual(25, newSave.Characters[1].Intelligence);
            Assert.AreEqual(U4EquipedWeapon.Crossbow, newSave.Characters[1].Weapon);
            Assert.AreEqual(U4EquipedArmor.MagicPlate, newSave.Characters[1].Armor);

        }

        [TestMethod]
        public void SaveAndLoadSpells()
        {
            Assert.AreEqual(true, SaveFile.Load("u4Data.dat"));

            for (int i = 0; i < 26; ++i)
                SaveFile.Spells[i] = i * 2;

            Assert.AreEqual(true, SaveFile.Save("Spells.d64"));

            Ultima4Data newSave = new Ultima4Data(File);

            Assert.AreEqual(true, newSave.Load("Spells.d64"));

            for (int i = 0; i < 26; ++i)
                Assert.AreEqual(i * 2, newSave.Spells[i]);
        }

        [TestMethod]
        public void SaveAndLoadReagents()
        {
            Assert.AreEqual(true, SaveFile.Load("u4Data.dat"));

            for (int i = 0; i < 8; ++i)
                SaveFile.Reagents[i] = i * 4;

            Assert.AreEqual(true, SaveFile.Save("Reagents.d64"));

            Ultima4Data newSave = new Ultima4Data(File);

            Assert.AreEqual(true, newSave.Load("Reagents.d64"));

            for (int i = 0; i < 8; ++i)
                Assert.AreEqual(i * 4, newSave.Reagents[i]);
        }

        [TestMethod]
        public void SaveAndLoadArmor()
        {
            Assert.AreEqual(true, SaveFile.Load("u4Data.dat"));

            for (int i = 0; i < 8; ++i)
                SaveFile.Armor[i] = i * 4;

            Assert.AreEqual(true, SaveFile.Save("Armor.d64"));

            Ultima4Data newSave = new Ultima4Data(File);

            Assert.AreEqual(true, newSave.Load("Armor.d64"));

            for (int i = 0; i < 8; ++i)
                Assert.AreEqual(i * 4, newSave.Armor[i]);
        }

        [TestMethod]
        public void SaveAndLoadWeapons()
        {
            Assert.AreEqual(true, SaveFile.Load("u4Data.dat"));

            for (int i = 0; i < 16; ++i)
                SaveFile.Weapons[i] = i * 4;

            Assert.AreEqual(true, SaveFile.Save("Weapons.d64"));

            Ultima4Data newSave = new Ultima4Data(File);

            Assert.AreEqual(true, newSave.Load("Weapons.d64"));

            for (int i = 0; i < 16; ++i)
                Assert.AreEqual(i * 4, newSave.Weapons[i]);
        }

        [TestMethod]
        public void SaveAndLoadPartyInventory()
        {
            Assert.AreEqual(true, SaveFile.Load("u4Data.dat"));

            SaveFile.Food = 8192;
            SaveFile.Gold = 6709;
            SaveFile.Torches = 65;
            SaveFile.Gems = 56;
            SaveFile.Keys = 78;
            SaveFile.Sextants = 3;

            Assert.AreEqual(true, SaveFile.Save("Inventory.d64"));

            Ultima4Data newSave = new Ultima4Data(File);

            Assert.AreEqual(true, newSave.Load("Inventory.d64"));

            Assert.AreEqual(8192, newSave.Food);
            Assert.AreEqual(6709, newSave.Gold);
            Assert.AreEqual(65, newSave.Torches);
            Assert.AreEqual(56, newSave.Gems);
            Assert.AreEqual(78, newSave.Keys);
            Assert.AreEqual(3, newSave.Sextants);
        }

        [TestMethod]
        public void SaveAndLoadBookBellCandleSkullWheelHorn()
        {
            Assert.AreEqual(true, SaveFile.Load("u4Data.dat"));

            SaveFile.Skull = true;
            SaveFile.Bell = true;
            SaveFile.Book = true;
            SaveFile.Candle = true;
            SaveFile.Wheel = true;
            SaveFile.Horn = true;

            Assert.AreEqual(true, SaveFile.Save("Items.d64"));

            Ultima4Data newSave = new Ultima4Data(File);

            Assert.AreEqual(true, newSave.Load("Items.d64"));

            Assert.AreEqual(true, newSave.Skull);
            Assert.AreEqual(true, newSave.Bell);
            Assert.AreEqual(true, newSave.Book);
            Assert.AreEqual(true, newSave.Candle);
            Assert.AreEqual(true, newSave.Wheel);
            Assert.AreEqual(true, newSave.Horn);
        }

        [TestMethod]
        public void SaveAndLoadThreePartKey()
        {
            Assert.AreEqual(true, SaveFile.Load("u4Data.dat"));

            SaveFile.KeyOfTruth = true;
            SaveFile.KeyOfLove = true;
            SaveFile.KeyOfCourage = true;

            Assert.AreEqual(true, SaveFile.Save("ThreePartKey.d64"));

            Ultima4Data newSave = new Ultima4Data(File);

            Assert.AreEqual(true, newSave.Load("ThreePartKey.d64"));

            Assert.AreEqual(true, newSave.KeyOfTruth);
            Assert.AreEqual(true, newSave.KeyOfLove);
            Assert.AreEqual(true, newSave.KeyOfCourage);
        }

        [TestMethod]
        public void SaveAndLoadMoves()
        {
            Assert.AreEqual(true, SaveFile.Load("u4Data.dat"));

            SaveFile.Moves = 87654321;

            Assert.AreEqual(true, SaveFile.Save("Moves.d64"));

            Ultima4Data newSave = new Ultima4Data(File);

            Assert.AreEqual(true, newSave.Load("Moves.d64"));

            Assert.AreEqual(87654321, newSave.Moves);
        }

        [TestMethod]
        public void LocationDefaultCtor()
        {
            U4Location location = new U4Location();

            Assert.AreEqual('A', location.Lat1);
            Assert.AreEqual('A', location.Lat2);
            Assert.AreEqual('A', location.Long1);
            Assert.AreEqual('A', location.Long2);
        }

        [TestMethod]
        public void LocationCtor()
        {
            U4Location location = new U4Location('D', 'E', 'A', 'K');

            Assert.AreEqual('D', location.Lat1);
            Assert.AreEqual('E', location.Lat2);
            Assert.AreEqual('A', location.Long1);
            Assert.AreEqual('K', location.Long2);
        }

        [TestMethod]
        public void SaveAndLoadLocation()
        {
            Assert.AreEqual(true, SaveFile.Load("u4Data.dat"));

            SaveFile.Location.Lat1 = 'B';
            SaveFile.Location.Lat2 = 'G';
            SaveFile.Location.Long1 = 'D';
            SaveFile.Location.Long2 = 'H';

            Assert.AreEqual(true, SaveFile.Save("Location.d64"));

            Ultima4Data newSave = new Ultima4Data(File);

            Assert.AreEqual(true, newSave.Load("Location.d64"));

            Assert.AreEqual('B', newSave.Location.Lat1);
            Assert.AreEqual('G', newSave.Location.Lat2);
            Assert.AreEqual('D', newSave.Location.Long1);
            Assert.AreEqual('H', newSave.Location.Long2);
        }

        [TestMethod]
        public void SaveAndLoadCurrentTransportation()
        {
            Assert.AreEqual(true, SaveFile.Load("u4Data.dat"));

            SaveFile.CurrentTransportation = U4Transportation.HorseEast;

            Assert.AreEqual(true, SaveFile.Save("Transportation.d64"));

            Ultima4Data newSave = new Ultima4Data(File);

            Assert.AreEqual(true, newSave.Load("Transportation.d64"));

            Assert.AreEqual(U4Transportation.HorseEast, newSave.CurrentTransportation);
        }

        [TestMethod]
        public void SaveAndLoadRunes()
        {
            Assert.AreEqual(true, SaveFile.Load("u4Data.dat"));

            for(int i = 0; i < 8; ++i)
                SaveFile.Runes[i] = i % 2 == 0;

            Assert.AreEqual(true, SaveFile.Save("Runes.d64"));

            Ultima4Data newSave = new Ultima4Data(File);

            Assert.AreEqual(true, newSave.Load("Runes.d64"));

            for (int i = 0; i < 8; ++i)
                Assert.AreEqual(i % 2 == 0, newSave.Runes[i]);
        }

        [TestMethod]
        public void SaveAndLoadStones()
        {
            Assert.AreEqual(true, SaveFile.Load("u4Data.dat"));

            for (int i = 0; i < 8; ++i)
                SaveFile.Stones[i] = i % 2 != 0;

            Assert.AreEqual(true, SaveFile.Save("Stones.d64"));

            Ultima4Data newSave = new Ultima4Data(File);

            Assert.AreEqual(true, newSave.Load("Stones.d64"));

            for (int i = 0; i < 8; ++i)
                Assert.AreEqual(i % 2 != 0, newSave.Stones[i]);
        }

        [TestMethod]
        public void SaveAndLoadVirtues()
        {
            Assert.AreEqual(true, SaveFile.Load("u4Data.dat"));

            for (int i = 0; i < 8; ++i)
                SaveFile.Virtues[i] = i * 4;

            Assert.AreEqual(true, SaveFile.Save("Virtues.d64"));

            Ultima4Data newSave = new Ultima4Data(File);

            Assert.AreEqual(true, newSave.Load("Virtues.d64"));

            for (int i = 0; i < 8; ++i)
                Assert.AreEqual(i * 4, newSave.Virtues[i]);
        }

        [TestMethod]
        public void DiskImageIsTooSmall()
        {
            File.Files["u4Data.dat"] = new byte[256];

            Assert.AreEqual(false, SaveFile.Load("u4Data.dat"));
        }

        [TestMethod]
        public void DiskImageWrongDiskLabel()
        {
            File.Files["u4Data.dat"][0x16590] = (byte)'X';

            Assert.AreEqual(false, SaveFile.Load("u4Data.dat"));
        }

        [TestMethod]
        public void FileNotFoundOnLoad()
        {
            Assert.AreEqual(false, SaveFile.Load("NotThere.dat"));
        }

        [TestMethod]
        public void SaveFails()
        {
            Assert.AreEqual(true, SaveFile.Load("u4Data.dat"));

            File.WriteAllBytesException = new System.IO.FileNotFoundException("File Not Found!");

            Assert.AreEqual(false, SaveFile.Save("u4NewData.dat"));
        }

        [TestMethod]
        public void InstantiateAndLoadRealFile()
        {
            Ultima4Data data = new Ultima4Data();

            Assert.AreEqual(true, data.Load("data\\u4data.dat"));

            Assert.AreEqual("Ike", data.Characters[0].Name);
        }

        [TestMethod]
        public void LongCharacterName()
        {
            for (int i = 0; i < 16; ++i)
                File.Files["u4Data.dat"][0x11100+i] = 0xC1;

            Assert.AreEqual(true, SaveFile.Load("u4Data.dat"));

            Assert.AreEqual("Aaaaaaaaaaaaaaaa", SaveFile.Characters[0].Name);
        }

        private MockFile File;
        private Ultima4Data SaveFile;
    }
}
