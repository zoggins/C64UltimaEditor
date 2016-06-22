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
        public U4Location()
        {
            Lat1 = 'A';
            Lat2 = 'A';
            Long1 = 'A';
            Long2 = 'A';
        }

        public char Lat1;
        public char Lat2;
        public char Long1;
        public char Long2;
    }

    class Ultima4Data
    {
        public Ultima4Data()
        {
            Characters = new Ultima4CharacterData[8];
            for (int i = 0; i < 8; ++i)
                Characters[i] = new Ultima4CharacterData();
            NumberOfCharactersInParty = 0;

            Spells = new int[26];
            Reagents = new int[8];
            Armor = new int[8];
            Weapons = new int[16];

            Food = 0;
            Gold = 0;
            Torches = 0;
            Gems = 0;
            Keys = 0;
            Sextants = 0;

            Skull = false;
            Horn = false;
            Wheel = false;

            Candle = false;
            Book = false;
            Bell = false;

            KeyOfLove = false;
            KeyOfTruth = false;
            KeyOfCourage = false;

            Moves = 0;
            Location = new U4Location();

            Stones = new bool[8];
            Runes = new bool[8];
            Virtues = new int[8];

            RawFile = null;
        }

        public Ultima4CharacterData[] Characters;
        public int NumberOfCharactersInParty;

        public int[] Spells;
        public int[] Reagents;
        public int[] Armor;
        public int[] Weapons;

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

        public bool[] Stones;
        public bool[] Runes;
        public int[] Virtues;

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
