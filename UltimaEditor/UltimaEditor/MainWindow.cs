using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UltimaEditor
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();

            this.Text = "Ultima Savegame Editor for C64 (Version " + Application.ProductVersion + ") ";

            // Ultima 1
            //m_u1Data = new Ultima1Data();
            //m_u1Data.Load("C:\\users\\Chris\\Desktop\\Ultima I - The First Age of Darkness (U).d64");



            // Ultima 4
            PopulateU4GoToLocations();
            m_u4Data = new Ultima4Data();
            PopulateU4Data();
        }

        private void ValidateInteger(TextBox textBox, int low, int high, CancelEventArgs e)
        {
            bool succeeded = true;
            try
            {
                int strength = Int32.Parse(textBox.Text);
                if (strength < low || strength > high)
                {
                    succeeded = false;
                }
            }
            catch (Exception)
            {
                succeeded = false;
            }

            if (!succeeded)
            {
                MessageBox.Show("Enter an integer between " + low + " and " + high);
                e.Cancel = true;
            }
        }

        private void ValidateLocation(TextBox textBox, CancelEventArgs e)
        {
            if (textBox.Text.Length != 1 || textBox.Text[0] < 'A' || textBox.Text[0] > 'P')
            {
                MessageBox.Show("Enter an letter between 'A' and 'P'");
                e.Cancel = true;
            }

        }

        private void PopulateU4Character(int index)
        {
            var character = m_u4Data.Characters[index];

            U4SexDropDown.SelectedItem = Enum.GetName(typeof(U4Sex), character.Sex);
            U4ClassDropDown.SelectedItem = Enum.GetName(typeof(U4Class), character.Class);
            U4HealthDropDown.SelectedItem = Enum.GetName(typeof(U4Health), character.Health);
            U4HitTextBox.Text = character.HitPoints.ToString();
            U4MaxHitTextBox.Text = character.MaxHitPoints.ToString();
            U4ExperienceTextBox.Text = character.Experience.ToString();
            U4StrengthTextBox.Text = character.Strength.ToString();
            U4DexterityTextBox.Text = character.Dexterity.ToString();
            U4IntelligenceTextBox.Text = character.Intelligence.ToString();
            U4MagicTextBox.Text = character.MagicPoints.ToString();
            U4WeaponDropDown.SelectedIndex = (int)character.Weapon;
            U4ArmorDropDown.SelectedIndex = (int)character.Armor;
        }

        private void PopulateLocation(char lat1, char lat2, char long1, char long2)
        {
            U4LocLat1.Text = lat1.ToString();
            U4LocLat2.Text = lat2.ToString();
            U4LocLong1.Text = long1.ToString();
            U4LocLong2.Text = long2.ToString();

        }

        private void PopulateU4Data()
        {
            U4NameDropDown.Items.Clear();
            for(int i = 0; i < m_u4Data.NumberOfCharactersInParty; ++i)
            {
                U4NameDropDown.Items.Add(m_u4Data.Characters[i].Name);
            }

            if (m_u4Data.NumberOfCharactersInParty != 0)
            {
                U4NameDropDown.SelectedIndex = 0;
            }

            PopulateU4Character(0);

            U4BlueStoneCheckBox.Checked = m_u4Data.Stones[0];
            U4YellowCheckBox.Checked = m_u4Data.Stones[1];
            U4RedCheckBox.Checked = m_u4Data.Stones[2];
            U4GreenCheckBox.Checked = m_u4Data.Stones[3];
            U4OrangeCheckBox.Checked = m_u4Data.Stones[4];
            U4PurpleCheckBox.Checked = m_u4Data.Stones[5];
            U4WhiteCheckBox.Checked = m_u4Data.Stones[6];
            U4BlackCheckBox.Checked = m_u4Data.Stones[7];

            U4RuneDropDown.SelectedIndex = 0;
            U4RuneCheckBox.Checked = m_u4Data.Runes[0];

            U4VirtueDropDown.SelectedIndex = 0;
            U4VirtueTextBox.Text = m_u4Data.Virtues[0].ToString();

            U4SkullCheckBox.Checked = m_u4Data.Skull;
            U4HornCheckBox.Checked = m_u4Data.Horn;
            U4WheelCheckBox.Checked = m_u4Data.Wheel;
            U4CandleCheckBox.Checked = m_u4Data.Candle;
            U4BookCheckBox.Checked = m_u4Data.Book;
            U4BellCheckBox.Checked = m_u4Data.Bell;
            U4LoveCheckBox.Checked = m_u4Data.KeyOfLove;
            U4TruthCheckBox.Checked = m_u4Data.KeyOfTruth;
            U4CourageCheckBox.Checked = m_u4Data.KeyOfCourage;

            U4SpellsDropDown.SelectedIndex = 0;
            U4SpellsTextBox.Text = m_u4Data.Spells[0].ToString();
            U4ReagentsDropDown.SelectedIndex = 0;
            U4ReagentsTextBox.Text = m_u4Data.Reagents[0].ToString();

            U4PartyArmorDropDown.SelectedIndex = 0;
            U4PartyArmorTextBox.Text = m_u4Data.Armor[0].ToString();
            U4PartyWeaponsDropDown.SelectedIndex = 0;
            U4PartyWeaponsTextBox.Text = m_u4Data.Weapons[0].ToString();

            U4FoodTextBox.Text = m_u4Data.Food.ToString();
            U4GoldTextBox.Text = m_u4Data.Gold.ToString();
            U4TorchesTextBox.Text = m_u4Data.Torches.ToString();
            U4GemsTextBox.Text = m_u4Data.Gems.ToString();
            U4KeysTextBox.Text = m_u4Data.Keys.ToString();
            U4SextantsTextBox.Text = m_u4Data.Sextants.ToString();

            U4MovesTextBox.Text = m_u4Data.Moves.ToString();
            PopulateLocation(m_u4Data.Location.Lat1, m_u4Data.Location.Lat2, m_u4Data.Location.Long1, m_u4Data.Location.Long2);

            U4GoToDropDownBox.SelectedIndex = 0;
        }

        private void PopulateU4GoToLocations()
        {
            m_u4GoToLocations = new List<U4GoToLocation>();

            m_u4GoToLocations.Add(new U4GoToLocation("Not Specified", new U4Location(), false, false));
            m_u4GoToLocations.Add(new U4GoToLocation("", new U4Location(), false, false));

            m_u4GoToLocations.Add(new U4GoToLocation("---- TOWNES ----", new U4Location(), false, false));
            m_u4GoToLocations.Add(new U4GoToLocation("Britain", new U4Location('G', 'K', 'F', 'C'), false, true));
            m_u4GoToLocations.Add(new U4GoToLocation("Buccaneers Den", new U4Location('J', 'O', 'I', 'I'), false, true));
            m_u4GoToLocations.Add(new U4GoToLocation("Cove", new U4Location('F', 'K', 'I', 'I'), false, true));
            m_u4GoToLocations.Add(new U4GoToLocation("Empath Abbey", new U4Location('D', 'C', 'B', 'M'), false, true));
            m_u4GoToLocations.Add(new U4GoToLocation("Jhelom", new U4Location('N', 'O', 'C', 'E'), false, true));
            m_u4GoToLocations.Add(new U4GoToLocation("LB's Castle", new U4Location('G', 'L', 'F', 'G'), false, true));
            m_u4GoToLocations.Add(new U4GoToLocation("Magincia", new U4Location('K', 'J', 'L', 'L'), false, true));
            m_u4GoToLocations.Add(new U4GoToLocation("Minoc", new U4Location('B', 'E', 'J', 'P'), false, true));
            m_u4GoToLocations.Add(new U4GoToLocation("Moonglow", new U4Location('I', 'H', 'O', 'I'), false, true));
            m_u4GoToLocations.Add(new U4GoToLocation("Paws", new U4Location('J', 'B', 'G', 'C'), false, true));
            m_u4GoToLocations.Add(new U4GoToLocation("Serpent's Hold", new U4Location('P', 'B', 'J', 'C'), false, true));
            m_u4GoToLocations.Add(new U4GoToLocation("Skara Brae", new U4Location('I', 'A', 'B', 'G'), false, true));
            m_u4GoToLocations.Add(new U4GoToLocation("The Lycaeum", new U4Location('G', 'L', 'N', 'K'), false, true));
            m_u4GoToLocations.Add(new U4GoToLocation("Trinsic", new U4Location('L', 'I', 'G', 'K'), false, true));
            m_u4GoToLocations.Add(new U4GoToLocation("Vesper", new U4Location('D', 'L', 'M', 'J'), false, true));
            m_u4GoToLocations.Add(new U4GoToLocation("Yew", new U4Location('C', 'L', 'D', 'K'), false, true));

            m_u4GoToLocations.Add(new U4GoToLocation("", new U4Location(), false, false));

            m_u4GoToLocations.Add(new U4GoToLocation("---- DUNGEONS ----", new U4Location(), false, false));
            m_u4GoToLocations.Add(new U4GoToLocation("Deceit", new U4Location('E', 'J', 'P', 'A'), false, true));
            m_u4GoToLocations.Add(new U4GoToLocation("Despise", new U4Location('E', 'D', 'F', 'L'), false, true));
            m_u4GoToLocations.Add(new U4GoToLocation("Destard", new U4Location('K', 'I', 'E', 'I'), false, true));
            m_u4GoToLocations.Add(new U4GoToLocation("Wrong", new U4Location('B', 'E', 'H', 'O'), false, true));
            m_u4GoToLocations.Add(new U4GoToLocation("Covetous", new U4Location('B', 'L', 'J', 'M'), false, true));
            m_u4GoToLocations.Add(new U4GoToLocation("Shame", new U4Location('G', 'G', 'D', 'K'), false, true));
            m_u4GoToLocations.Add(new U4GoToLocation("Hythloth", new U4Location('P', 'A', 'O', 'P'), false, true));

            m_u4GoToLocations.Add(new U4GoToLocation("", new U4Location(), false, false));

            m_u4GoToLocations.Add(new U4GoToLocation("---- SHRINES ----", new U4Location(), false, false));
            m_u4GoToLocations.Add(new U4GoToLocation("Compassion", new U4Location('F', 'M', 'I', 'A'), false, true));
            m_u4GoToLocations.Add(new U4GoToLocation("Honesty", new U4Location('E', 'C', 'O', 'J'), false, true));
            m_u4GoToLocations.Add(new U4GoToLocation("Honor", new U4Location('M', 'P', 'F', 'B'), false, true));
            m_u4GoToLocations.Add(new U4GoToLocation("Humility", new U4Location('N', 'I', 'O', 'H'), false, true));
            m_u4GoToLocations.Add(new U4GoToLocation("Justice", new U4Location('A', 'L', 'E', 'J'), false, true));
            m_u4GoToLocations.Add(new U4GoToLocation("Sacrifice", new U4Location('C', 'N', 'M', 'N'), false, true));
            m_u4GoToLocations.Add(new U4GoToLocation("Spirituality", new U4Location('B', 'D', 'K', 'G'), false, true));
            m_u4GoToLocations.Add(new U4GoToLocation("Valor", new U4Location('O', 'F', 'C', 'E'), false, true));

            m_u4GoToLocations.Add(new U4GoToLocation("", new U4Location(), false, false));

            m_u4GoToLocations.Add(new U4GoToLocation("---- SPOILERS ----", new U4Location(), false, false));
            m_u4GoToLocations.Add(new U4GoToLocation("Bell of Courage", new U4Location('N', 'A', 'L', 'A'), true, true));
            m_u4GoToLocations.Add(new U4GoToLocation("Book of Truth", new U4Location('G', 'L', 'N', 'K'), false, true));
            m_u4GoToLocations.Add(new U4GoToLocation("Candle of Love", new U4Location('F', 'K', 'I', 'I'), false, true));
            m_u4GoToLocations.Add(new U4GoToLocation("Mondain's Skull", new U4Location('P', 'F', 'M', 'F'), true, true));
            m_u4GoToLocations.Add(new U4GoToLocation("Balloon", new U4Location('P', 'C', 'O', 'J'), false, true));
            m_u4GoToLocations.Add(new U4GoToLocation("Wheel", new U4Location('N', 'H', 'G', 'A'), true, true));
            m_u4GoToLocations.Add(new U4GoToLocation("Silver Horn", new U4Location('K', 'N', 'C', 'N'), false, true));
            m_u4GoToLocations.Add(new U4GoToLocation("Black Stone", new U4Location('I', 'F', 'O', 'A'), false, true));
            m_u4GoToLocations.Add(new U4GoToLocation("White Stone", new U4Location('F', 'A', 'E', 'A'), false, true));
            m_u4GoToLocations.Add(new U4GoToLocation("Mystic Armour", new U4Location('D', 'C', 'B', 'M'), false, true));
            m_u4GoToLocations.Add(new U4GoToLocation("Mystic Weapons", new U4Location('P', 'B', 'J', 'C'), false, true));
            m_u4GoToLocations.Add(new U4GoToLocation("Nightshade", new U4Location('J', 'F', 'C', 'O'), false, true));
            m_u4GoToLocations.Add(new U4GoToLocation("Mandrake Root", new U4Location('D', 'G', 'L', 'G'), false, true));

            U4GoToDropDownBox.Items.Clear();

            foreach(var location in m_u4GoToLocations)
            {
                U4GoToDropDownBox.Items.Add(location.Name);
            }

            U4GoToDropDownBox.SelectedIndex = 0;

        }

        // Ultima 1
        private Ultima1Data m_u1Data;

        // Ultima 4
        private List<U4GoToLocation> m_u4GoToLocations;
        private Ultima4Data m_u4Data;

        private void U4StrengthTextBox_Validating(object sender, CancelEventArgs e)
        {
            ValidateInteger(U4StrengthTextBox, 0, 50, e);
        }

        private void U4MaxHitTextBox_Validating(object sender, CancelEventArgs e)
        {
            ValidateInteger(U4MaxHitTextBox, 100, 800, e);
        }

        private void U4HitTextBox_Validating(object sender, CancelEventArgs e)
        {
            ValidateInteger(U4HitTextBox, 0, 800, e);

            // TODO: Should probably check that this isn't bigger than Max Hits
        }

        private void U4ExperienceTextBox_Validating(object sender, CancelEventArgs e)
        {
            ValidateInteger(U4ExperienceTextBox, 0, 9999, e);
        }

        private void U4DexterityTextBox_Validating(object sender, CancelEventArgs e)
        {
            ValidateInteger(U4DexterityTextBox, 0, 50, e);
        }

        private void U4IntelligenceTextBox_Validating(object sender, CancelEventArgs e)
        {
            ValidateInteger(U4IntelligenceTextBox, 0, 50, e);
        }

        private void U4FoodTextBox_Validating(object sender, CancelEventArgs e)
        {
            ValidateInteger(U4FoodTextBox, 0, 9999, e);
        }

        private void U4TorchesTextBox_Validating(object sender, CancelEventArgs e)
        {
            ValidateInteger(U4TorchesTextBox, 0, 99, e);
        }

        private void U4KeysTextBox_Validating(object sender, CancelEventArgs e)
        {
            ValidateInteger(U4KeysTextBox, 0, 99, e);
        }

        private void U4GoldTextBox_Validating(object sender, CancelEventArgs e)
        {
            ValidateInteger(U4GoldTextBox, 0, 9999, e);
        }

        private void U4GemsTextBox_Validating(object sender, CancelEventArgs e)
        {
            ValidateInteger(U4GemsTextBox, 0, 99, e);
        }

        private void U4SextantsTextBox_Validating(object sender, CancelEventArgs e)
        {
            ValidateInteger(U4SextantsTextBox, 0, 99, e);
        }

        private void U4SpellsTextBox_Validating(object sender, CancelEventArgs e)
        {
            ValidateInteger(U4SpellsTextBox, 0, 99, e);
        }

        private void U4ReagentsTextBox_Validating(object sender, CancelEventArgs e)
        {
            ValidateInteger(U4ReagentsTextBox, 0, 99, e);
        }

        private void U4PartyArmorTextBox_Validating(object sender, CancelEventArgs e)
        {
            ValidateInteger(U4PartyArmorTextBox, 0, 99, e);
        }

        private void U4PartyWeaponsTextBox_Validating(object sender, CancelEventArgs e)
        {
            ValidateInteger(U4PartyWeaponsTextBox, 0, 99, e);
        }

        private void U4MovesTextBox_Validating(object sender, CancelEventArgs e)
        {
            ValidateInteger(U4MovesTextBox, 0, 99999999, e);
        }

        private void U4VirtueTextBox_Validating(object sender, CancelEventArgs e)
        {
            ValidateInteger(U4VirtueTextBox, 0, 99, e);
        }

        private void U4LocLat1_Validating(object sender, CancelEventArgs e)
        {
            ValidateLocation(U4LocLat1, e);
        }

        private void U4LocLat2_Validating(object sender, CancelEventArgs e)
        {
            ValidateLocation(U4LocLat2, e);
        }

        private void U4LocLong1_Validating(object sender, CancelEventArgs e)
        {
            ValidateLocation(U4LocLong1, e);
        }

        private void U4LocLong2_Validating(object sender, CancelEventArgs e)
        {
            ValidateLocation(U4LocLong2, e);
        }

        private void U4MagicTextBox_Validating(object sender, CancelEventArgs e)
        {
            ValidateInteger(U4MagicTextBox, 0, 99, e);
            
            // TODO: Should probably validate this value, but that is a complicated check.
        }

        private void U4NameDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateU4Character(U4NameDropDown.SelectedIndex);
        }

        private void U4SexDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            var characterIndex = U4NameDropDown.SelectedIndex == -1 ? 0 : U4NameDropDown.SelectedIndex;
     
            m_u4Data.Characters[characterIndex].Sex = (U4Sex)Enum.Parse(typeof(U4Sex), U4SexDropDown.SelectedItem.ToString());
        }

        private void U4ClassDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            var characterIndex = U4NameDropDown.SelectedIndex == -1 ? 0 : U4NameDropDown.SelectedIndex;

            m_u4Data.Characters[characterIndex].Class = (U4Class)Enum.Parse(typeof(U4Class), U4ClassDropDown.SelectedItem.ToString());
        }

        private void U4HealthDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            var characterIndex = U4NameDropDown.SelectedIndex == -1 ? 0 : U4NameDropDown.SelectedIndex;

            m_u4Data.Characters[characterIndex].Health = (U4Health)Enum.Parse(typeof(U4Health), U4HealthDropDown.SelectedItem.ToString());
        }

        private void U4HitTextBox_Validated(object sender, EventArgs e)
        {
            var characterIndex = U4NameDropDown.SelectedIndex == -1 ? 0 : U4NameDropDown.SelectedIndex;

            m_u4Data.Characters[characterIndex].HitPoints = Int32.Parse(U4HitTextBox.Text);
        }

        private void U4MaxHitTextBox_Validated(object sender, EventArgs e)
        {
            var characterIndex = U4NameDropDown.SelectedIndex == -1 ? 0 : U4NameDropDown.SelectedIndex;

            m_u4Data.Characters[characterIndex].MaxHitPoints = Int32.Parse(U4MaxHitTextBox.Text);
        }

        private void U4ExperienceTextBox_Validated(object sender, EventArgs e)
        {
            var characterIndex = U4NameDropDown.SelectedIndex == -1 ? 0 : U4NameDropDown.SelectedIndex;

            m_u4Data.Characters[characterIndex].Experience = Int32.Parse(U4ExperienceTextBox.Text);
        }

        private void U4StrengthTextBox_Validated(object sender, EventArgs e)
        {
            var characterIndex = U4NameDropDown.SelectedIndex == -1 ? 0 : U4NameDropDown.SelectedIndex;

            m_u4Data.Characters[characterIndex].Strength = Int32.Parse(U4StrengthTextBox.Text);
        }

        private void U4DexterityTextBox_Validated(object sender, EventArgs e)
        {
            var characterIndex = U4NameDropDown.SelectedIndex == -1 ? 0 : U4NameDropDown.SelectedIndex;

            m_u4Data.Characters[characterIndex].Dexterity = Int32.Parse(U4DexterityTextBox.Text);
        }

        private void U4IntelligenceTextBox_Validated(object sender, EventArgs e)
        {
            var characterIndex = U4NameDropDown.SelectedIndex == -1 ? 0 : U4NameDropDown.SelectedIndex;

            m_u4Data.Characters[characterIndex].Intelligence = Int32.Parse(U4IntelligenceTextBox.Text);
        }

        private void U4MagicTextBox_Validated(object sender, EventArgs e)
        {
            var characterIndex = U4NameDropDown.SelectedIndex == -1 ? 0 : U4NameDropDown.SelectedIndex;

            m_u4Data.Characters[characterIndex].MagicPoints = Int32.Parse(U4MagicTextBox.Text);
        }

        private void U4WeaponDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            var characterIndex = U4NameDropDown.SelectedIndex == -1 ? 0 : U4NameDropDown.SelectedIndex;

            m_u4Data.Characters[characterIndex].Weapon = (U4EquipedWeapon)U4WeaponDropDown.SelectedIndex;
        }

        private void U4ArmorDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            var characterIndex = U4NameDropDown.SelectedIndex == -1 ? 0 : U4NameDropDown.SelectedIndex;

            m_u4Data.Characters[characterIndex].Armor = (U4EquipedArmor)U4ArmorDropDown.SelectedIndex;
        }

        private void U4BlueStoneCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            m_u4Data.Stones[0] = U4BlueStoneCheckBox.Checked;
        }

        private void U4YellowCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            m_u4Data.Stones[1] = U4YellowCheckBox.Checked;
        }

        private void U4RedCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            m_u4Data.Stones[2] = U4RedCheckBox.Checked;
        }

        private void U4GreenCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            m_u4Data.Stones[3] = U4GreenCheckBox.Checked;
        }

        private void U4OrangeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            m_u4Data.Stones[4] = U4OrangeCheckBox.Checked;
        }

        private void U4PurpleCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            m_u4Data.Stones[5] = U4PurpleCheckBox.Checked;
        }

        private void U4WhiteCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            m_u4Data.Stones[6] = U4WhiteCheckBox.Checked;
        }

        private void U4BlackCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            m_u4Data.Stones[7] = U4BlackCheckBox.Checked;
        }

        private void U4RuneCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            m_u4Data.Runes[U4RuneDropDown.SelectedIndex] = U4RuneCheckBox.Checked;
        }

        private void U4RuneDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            U4RuneCheckBox.Checked = m_u4Data.Runes[U4RuneDropDown.SelectedIndex];
        }

        private void U4VirtueTextBox_Validated(object sender, EventArgs e)
        {
            m_u4Data.Virtues[U4VirtueDropDown.SelectedIndex] = Int32.Parse(U4VirtueTextBox.Text);
        }

        private void U4VirtueDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            U4VirtueTextBox.Text = m_u4Data.Virtues[U4VirtueDropDown.SelectedIndex].ToString();
        }

        private void U4SkullCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            m_u4Data.Skull = U4SkullCheckBox.Checked;
        }

        private void U4HornCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            m_u4Data.Horn = U4HornCheckBox.Checked;
        }

        private void U4WheelCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            m_u4Data.Wheel = U4WheelCheckBox.Checked;
        }

        private void U4CandleCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            m_u4Data.Candle = U4CandleCheckBox.Checked;
        }

        private void U4BookCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            m_u4Data.Book = U4BookCheckBox.Checked;
        }

        private void U4BellCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            m_u4Data.Bell = U4BellCheckBox.Checked;
        }

        private void U4LoveCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            m_u4Data.KeyOfLove = U4LoveCheckBox.Checked;
        }

        private void U4TruthCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            m_u4Data.KeyOfTruth = U4TruthCheckBox.Checked;
        }

        private void U4CourageCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            m_u4Data.KeyOfCourage = U4CourageCheckBox.Checked;
        }

        private void U4MovesTextBox_Validated(object sender, EventArgs e)
        {
            m_u4Data.Moves = Int32.Parse(U4MovesTextBox.Text);
        }

        private void U4LocLat1_Validated(object sender, EventArgs e)
        {
            m_u4Data.Location.Lat1 = U4LocLat1.Text[0];
        }

        private void U4LocLat2_Validated(object sender, EventArgs e)
        {
            m_u4Data.Location.Lat2 = U4LocLat2.Text[0];
        }

        private void U4LocLong1_Validated(object sender, EventArgs e)
        {
            m_u4Data.Location.Long1 = U4LocLong1.Text[0];
        }
        private void U4LocLong2_Validated(object sender, EventArgs e)
        {
            m_u4Data.Location.Long2 = U4LocLong2.Text[0];
        }

        private void U4SpellsDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            U4SpellsTextBox.Text = m_u4Data.Spells[U4SpellsDropDown.SelectedIndex].ToString();
        }

        private void U4SpellsTextBox_Validated(object sender, EventArgs e)
        {
            m_u4Data.Spells[U4SpellsDropDown.SelectedIndex] = Int32.Parse(U4SpellsTextBox.Text);
        }

        private void U4ReagentsDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            U4ReagentsTextBox.Text = m_u4Data.Reagents[U4ReagentsDropDown.SelectedIndex].ToString();
        }

        private void U4ReagentsTextBox_Validated(object sender, EventArgs e)
        {
            m_u4Data.Reagents[U4ReagentsDropDown.SelectedIndex] = Int32.Parse(U4ReagentsTextBox.Text);
        }

        private void U4PartyArmorDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            U4PartyArmorTextBox.Text = m_u4Data.Armor[U4PartyArmorDropDown.SelectedIndex].ToString();
        }

        private void U4PartyArmorTextBox_Validated(object sender, EventArgs e)
        {
            m_u4Data.Armor[U4PartyArmorDropDown.SelectedIndex] = Int32.Parse(U4PartyArmorTextBox.Text);
        }

        private void U4PartyWeaponsDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            U4PartyWeaponsTextBox.Text = m_u4Data.Weapons[U4PartyWeaponsDropDown.SelectedIndex].ToString();
        }

        private void U4PartyWeaponsTextBox_Validated(object sender, EventArgs e)
        {
            m_u4Data.Weapons[U4PartyWeaponsDropDown.SelectedIndex] = Int32.Parse(U4PartyWeaponsTextBox.Text);
        }

        private void U4FoodTextBox_Validated(object sender, EventArgs e)
        {
            m_u4Data.Food = Int32.Parse(U4FoodTextBox.Text);
        }

        private void U4GoldTextBox_Validated(object sender, EventArgs e)
        {
            m_u4Data.Gold = Int32.Parse(U4GoldTextBox.Text);
        }

        private void U4TorchesTextBox_Validated(object sender, EventArgs e)
        {
            m_u4Data.Torches = Int32.Parse(U4TorchesTextBox.Text);
        }

        private void U4GemsTextBox_Validated(object sender, EventArgs e)
        {
            m_u4Data.Gems = Int32.Parse(U4GemsTextBox.Text);
        }

        private void U4KeysTextBox_Validated(object sender, EventArgs e)
        {
            m_u4Data.Keys = Int32.Parse(U4KeysTextBox.Text);
        }

        private void U4SextantsTextBox_Validated(object sender, EventArgs e)
        {
            m_u4Data.Sextants = Int32.Parse(U4SextantsTextBox.Text);
        }

        private void U4LoadButton_Click(object sender, EventArgs e)
        {
            DialogResult result = U4OpenDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                m_u4Data = new Ultima4Data();
                if (!m_u4Data.Load(U4OpenDialog.FileName))
                {
                    MessageBox.Show("An error occured while trying to load the selected file");
                    U4SaveButton.Enabled = false;
                }
                else
                {
                    U4SaveButton.Enabled = true;
                }
                PopulateU4Data();
            }
        }

        private void U4SaveButton_Click(object sender, EventArgs e)
        {
            DialogResult result = U4SaveDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                if (!m_u4Data.Save(U4SaveDialog.FileName))
                {
                    MessageBox.Show("An error occured while trying to save the selected file");
                }
            }
        }

        private void U4GoToDropDownBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var location = m_u4GoToLocations[U4GoToDropDownBox.SelectedIndex];
            if (location.IsActive)
            {
                PopulateLocation(location.Coordinates.Lat1, location.Coordinates.Lat2, location.Coordinates.Long1, location.Coordinates.Long2);

                bool OnABoat = m_u4Data.CurrentTransportation == U4Transportation.ShipEast
                        || m_u4Data.CurrentTransportation == U4Transportation.ShipWest
                        || m_u4Data.CurrentTransportation == U4Transportation.ShipNorth
                        || m_u4Data.CurrentTransportation == U4Transportation.ShipSouth;

                if (OnABoat && !location.AtSea)
                {
                    m_u4Data.CurrentTransportation = U4Transportation.Foot;
                }
                else if (!OnABoat && location.AtSea)
                {
                    m_u4Data.CurrentTransportation = U4Transportation.ShipWest;
                }

            }
        }

        private void U4LocLat1_TextChanged(object sender, EventArgs e)
        {
            U4LocLat1_Validated(sender, e);
        }

        private void U4LocLat2_TextChanged(object sender, EventArgs e)
        {
            U4LocLat2_Validated(sender, e);
        }

        private void U4LocLong1_TextChanged(object sender, EventArgs e)
        {
            U4LocLong1_Validated(sender, e);
        }

        private void U4LocLong2_TextChanged(object sender, EventArgs e)
        {
            U4LocLong2_Validated(sender, e);
        }
    }

    class U4GoToLocation
    {
        public U4GoToLocation(string Name, U4Location Coordinates, bool AtSea, bool IsActive)
        {
            this.Name = Name;
            this.Coordinates = Coordinates;
            this.AtSea = AtSea;
            this.IsActive = IsActive;
        }

        public string Name;
        public U4Location Coordinates;
        public bool AtSea;
        public bool IsActive;
    }

}
