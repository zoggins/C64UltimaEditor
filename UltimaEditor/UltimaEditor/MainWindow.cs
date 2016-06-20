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

            U4SexDropDown.SelectedIndex = 0;
            U4HealthDropDown.SelectedIndex = 0;
            U4ClassDropDown.SelectedIndex = 0;
            U4WeaponDropDown.SelectedIndex = 0;
            U4ArmorDropDown.SelectedIndex = 0;
            U4VirtueDropDown.SelectedIndex = 0;
            U4RuneDropDown.SelectedIndex = 0;
            U4PartyArmorDropDown.SelectedIndex = 0;
            U4PartyWeaponsDropDown.SelectedIndex = 0;
            U4SpellsDropDown.SelectedIndex = 0;
            U4ReagentsDropDown.SelectedIndex = 0;
            U4GoToDropDownBox.SelectedIndex = 0;
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
            ValidateInteger(U4HitTextBox, 100, 800, e);

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
    }
}
