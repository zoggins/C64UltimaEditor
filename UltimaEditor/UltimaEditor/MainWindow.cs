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

            m_u4Data = new Ultima4Data();

            PopulateU4Data();

            U4GoToDropDownBox.SelectedIndex = 0;

            // TODO: Populate Goto Drop Down Box
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

        private void PopulateLocation()
        {
            U4LocLat1.Text = m_u4Data.Location.Lat1.ToString();
            U4LocLat2.Text = m_u4Data.Location.Lat2.ToString();
            U4LocLong1.Text = m_u4Data.Location.Long1.ToString();
            U4LocLong2.Text = m_u4Data.Location.Long2.ToString();

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
            PopulateLocation();

        }

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

        private void U4LocLong2_TextChanged(object sender, EventArgs e)
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
            // TODO
        }
    }
}
