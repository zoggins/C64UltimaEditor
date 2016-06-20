using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltimaEditor
{
    enum U4Virtues
    {
        Honesty = 0,
        Compassion = 1,
        Valor = 2,
        Justice = 3,
        Sacrifice = 4,
        Honor = 5,
        Spirituality = 6,
        Humility = 7
    }

    class U4Location
    {
        public char Lat1 = 'A';
        public char Lat2 = 'A';
        public char Long1 = 'A';
        public char Long2 = 'A';
    }

    class Ultima4Data
    {
        public Ultima4CharacterData[] Characters = new Ultima4CharacterData[8];
        public int NumberOfCharactersInParty;

        public int[] Spells = new int[26];
        public int[] Reagents = new int[8];
        public int[] Armor = new int[8];
        public int[] Weapons = new int[16];

        public int Food;
        public int Gold;
        public int Torches;
        public int Gems;
        public int Keys;
        public int Sextants;

        public bool Skull;
        public bool Horn;
        public bool Wheel;

        public bool Candle;
        public bool Book;
        public bool Bell;

        public bool KeyOfLove;
        public bool KeyOfTruth;
        public bool KeyOfCourage;

        public int Moves;
        public U4Location Location;

        public bool[] Stones = new bool[8];
        public bool[] Runes = new bool[8];
        public int[] Virtues = new int[8];

        private byte[] RawFile;

        public bool Load(string file)
        {
            return false;
        }

        public void Save(string file)
        {

        }

        private const int SaveFileStartOffset = 0x11100;  // 8 records
        private const int CharacterRecordSize = 0x20;

        private const int VirtuesOffset = 0x11200;  // 8 bytes

        private const int TorchesOffset = 0x11208;
        private const int GemsOffset = 0x11209;
        private const int KeysOffset = 0x1120A;
        private const int SextantsOffset = 0x1120B;

        private const int StonesOffset = 0x1120C;
        private const int RunesOffset = 0x1120D;
        private const int BellBookCandleOffset = 0x1120E;
        private const int ThreePartKeyOffset = 0x1120F;

        private const int FoodOffset = 0x11210;  // 2 bytes
        private const int GoldOffset = 0x11213;  // 2 bytes
        private const int HornOffset = 0x11215;
        private const int WheelOffset = 0x11216;
        private const int SkullOffset = 0x11217;

        private const int ArmorOffset = 0x11218;  // 8 bytes
        private const int WeaponOffset = 0x11220;  // 16 bytes

        private const int ReagentsOffset = 0x11238;  // 8 bytes
        private const int SpellsOffset = 0x11240; // 26 bytes

        private const int LocationOffset = 0x11300; // 2 bytes
        private const int NumInPartyOffset = 0x1130F;
        private const int MovesOffset = 0x1131C;  // 4 bytes
    }
}
