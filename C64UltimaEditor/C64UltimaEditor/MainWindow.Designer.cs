namespace C64UltimaEditor
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                m_u1Data.Dispose();
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.MainTabControl = new System.Windows.Forms.TabControl();
            this.U1Tab = new System.Windows.Forms.TabPage();
            this.U2Tab = new System.Windows.Forms.TabPage();
            this.U3Tab = new System.Windows.Forms.TabPage();
            this.U4Tab = new System.Windows.Forms.TabPage();
            this.U4LoadButton = new System.Windows.Forms.Button();
            this.U4SaveButton = new System.Windows.Forms.Button();
            this.U4General = new System.Windows.Forms.GroupBox();
            this.U4GoToDropDownBox = new System.Windows.Forms.ComboBox();
            this.label32 = new System.Windows.Forms.Label();
            this.U4LocLong2 = new System.Windows.Forms.TextBox();
            this.U4LocLong1 = new System.Windows.Forms.TextBox();
            this.U4LocLat2 = new System.Windows.Forms.TextBox();
            this.U4MovesTextBox = new System.Windows.Forms.TextBox();
            this.U4LocLat1 = new System.Windows.Forms.TextBox();
            this.label30 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.U4PartyEquipment = new System.Windows.Forms.GroupBox();
            this.U4SextantsTextBox = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.U4GemsTextBox = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.U4GoldTextBox = new System.Windows.Forms.TextBox();
            this.label29 = new System.Windows.Forms.Label();
            this.U4KeysTextBox = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.U4TorchesTextBox = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.U4FoodTextBox = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.U4PartyWeaponsTextBox = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.U4PartyArmorTextBox = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.U4ReagentsTextBox = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.U4PartyWeaponsDropDown = new System.Windows.Forms.ComboBox();
            this.label20 = new System.Windows.Forms.Label();
            this.U4PartyArmorDropDown = new System.Windows.Forms.ComboBox();
            this.label19 = new System.Windows.Forms.Label();
            this.U4ReagentsDropDown = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.U4SpellsTextBox = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.U4SpellsDropDown = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.U4QuestItems = new System.Windows.Forms.GroupBox();
            this.U4CourageCheckBox = new System.Windows.Forms.CheckBox();
            this.U4BellCheckBox = new System.Windows.Forms.CheckBox();
            this.U4TruthCheckBox = new System.Windows.Forms.CheckBox();
            this.U4BookCheckBox = new System.Windows.Forms.CheckBox();
            this.U4CandleCheckBox = new System.Windows.Forms.CheckBox();
            this.U4WheelCheckBox = new System.Windows.Forms.CheckBox();
            this.U4HornCheckBox = new System.Windows.Forms.CheckBox();
            this.U4LoveCheckBox = new System.Windows.Forms.CheckBox();
            this.U4SkullCheckBox = new System.Windows.Forms.CheckBox();
            this.label16 = new System.Windows.Forms.Label();
            this.U4Virtues = new System.Windows.Forms.GroupBox();
            this.U4BlackCheckBox = new System.Windows.Forms.CheckBox();
            this.U4WhiteCheckBox = new System.Windows.Forms.CheckBox();
            this.U4PurpleCheckBox = new System.Windows.Forms.CheckBox();
            this.U4OrangeCheckBox = new System.Windows.Forms.CheckBox();
            this.U4GreenCheckBox = new System.Windows.Forms.CheckBox();
            this.U4RedCheckBox = new System.Windows.Forms.CheckBox();
            this.U4YellowCheckBox = new System.Windows.Forms.CheckBox();
            this.U4BlueStoneCheckBox = new System.Windows.Forms.CheckBox();
            this.label14 = new System.Windows.Forms.Label();
            this.U4VirtueTextBox = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.U4RuneCheckBox = new System.Windows.Forms.CheckBox();
            this.U4VirtueDropDown = new System.Windows.Forms.ComboBox();
            this.U4RuneDropDown = new System.Windows.Forms.ComboBox();
            this.U4PlayerStats = new System.Windows.Forms.GroupBox();
            this.U4MagicTextBox = new System.Windows.Forms.TextBox();
            this.U4IntelligenceTextBox = new System.Windows.Forms.TextBox();
            this.U4DexterityTextBox = new System.Windows.Forms.TextBox();
            this.U4StrengthTextBox = new System.Windows.Forms.TextBox();
            this.U4ExperienceTextBox = new System.Windows.Forms.TextBox();
            this.U4MaxHitTextBox = new System.Windows.Forms.TextBox();
            this.U4HitTextBox = new System.Windows.Forms.TextBox();
            this.U4ArmorDropDown = new System.Windows.Forms.ComboBox();
            this.U4WeaponDropDown = new System.Windows.Forms.ComboBox();
            this.U4HealthDropDown = new System.Windows.Forms.ComboBox();
            this.U4ClassDropDown = new System.Windows.Forms.ComboBox();
            this.U4SexDropDown = new System.Windows.Forms.ComboBox();
            this.U4NameDropDown = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.U5Tab = new System.Windows.Forms.TabPage();
            this.U4OpenDialog = new System.Windows.Forms.OpenFileDialog();
            this.U4SaveDialog = new System.Windows.Forms.SaveFileDialog();
            this.MainTabControl.SuspendLayout();
            this.U4Tab.SuspendLayout();
            this.U4General.SuspendLayout();
            this.U4PartyEquipment.SuspendLayout();
            this.U4QuestItems.SuspendLayout();
            this.U4Virtues.SuspendLayout();
            this.U4PlayerStats.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainTabControl
            // 
            this.MainTabControl.Controls.Add(this.U1Tab);
            this.MainTabControl.Controls.Add(this.U2Tab);
            this.MainTabControl.Controls.Add(this.U3Tab);
            this.MainTabControl.Controls.Add(this.U4Tab);
            this.MainTabControl.Controls.Add(this.U5Tab);
            this.MainTabControl.Location = new System.Drawing.Point(8, 8);
            this.MainTabControl.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MainTabControl.Name = "MainTabControl";
            this.MainTabControl.SelectedIndex = 0;
            this.MainTabControl.Size = new System.Drawing.Size(716, 461);
            this.MainTabControl.TabIndex = 0;
            // 
            // U1Tab
            // 
            this.U1Tab.BackColor = System.Drawing.Color.WhiteSmoke;
            this.U1Tab.Location = new System.Drawing.Point(4, 22);
            this.U1Tab.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.U1Tab.Name = "U1Tab";
            this.U1Tab.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.U1Tab.Size = new System.Drawing.Size(708, 435);
            this.U1Tab.TabIndex = 0;
            this.U1Tab.Text = "Ultima I";
            // 
            // U2Tab
            // 
            this.U2Tab.BackColor = System.Drawing.Color.WhiteSmoke;
            this.U2Tab.Location = new System.Drawing.Point(4, 22);
            this.U2Tab.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.U2Tab.Name = "U2Tab";
            this.U2Tab.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.U2Tab.Size = new System.Drawing.Size(708, 435);
            this.U2Tab.TabIndex = 1;
            this.U2Tab.Text = "Ultima II";
            // 
            // U3Tab
            // 
            this.U3Tab.BackColor = System.Drawing.Color.WhiteSmoke;
            this.U3Tab.Location = new System.Drawing.Point(4, 22);
            this.U3Tab.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.U3Tab.Name = "U3Tab";
            this.U3Tab.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.U3Tab.Size = new System.Drawing.Size(708, 435);
            this.U3Tab.TabIndex = 2;
            this.U3Tab.Text = "Ultima III";
            // 
            // U4Tab
            // 
            this.U4Tab.BackColor = System.Drawing.Color.WhiteSmoke;
            this.U4Tab.Controls.Add(this.U4LoadButton);
            this.U4Tab.Controls.Add(this.U4SaveButton);
            this.U4Tab.Controls.Add(this.U4General);
            this.U4Tab.Controls.Add(this.U4PartyEquipment);
            this.U4Tab.Controls.Add(this.U4QuestItems);
            this.U4Tab.Controls.Add(this.U4Virtues);
            this.U4Tab.Controls.Add(this.U4PlayerStats);
            this.U4Tab.Location = new System.Drawing.Point(4, 22);
            this.U4Tab.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.U4Tab.Name = "U4Tab";
            this.U4Tab.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.U4Tab.Size = new System.Drawing.Size(708, 435);
            this.U4Tab.TabIndex = 3;
            this.U4Tab.Text = "Ultima IV";
            // 
            // U4LoadButton
            // 
            this.U4LoadButton.Location = new System.Drawing.Point(534, 365);
            this.U4LoadButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.U4LoadButton.Name = "U4LoadButton";
            this.U4LoadButton.Size = new System.Drawing.Size(73, 39);
            this.U4LoadButton.TabIndex = 39;
            this.U4LoadButton.Text = "Load";
            this.U4LoadButton.UseVisualStyleBackColor = true;
            this.U4LoadButton.Click += new System.EventHandler(this.U4LoadButton_Click);
            // 
            // U4SaveButton
            // 
            this.U4SaveButton.Enabled = false;
            this.U4SaveButton.Location = new System.Drawing.Point(627, 365);
            this.U4SaveButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.U4SaveButton.Name = "U4SaveButton";
            this.U4SaveButton.Size = new System.Drawing.Size(73, 39);
            this.U4SaveButton.TabIndex = 38;
            this.U4SaveButton.Text = "Save";
            this.U4SaveButton.UseVisualStyleBackColor = true;
            this.U4SaveButton.Click += new System.EventHandler(this.U4SaveButton_Click);
            // 
            // U4General
            // 
            this.U4General.Controls.Add(this.U4GoToDropDownBox);
            this.U4General.Controls.Add(this.label32);
            this.U4General.Controls.Add(this.U4LocLong2);
            this.U4General.Controls.Add(this.U4LocLong1);
            this.U4General.Controls.Add(this.U4LocLat2);
            this.U4General.Controls.Add(this.U4MovesTextBox);
            this.U4General.Controls.Add(this.U4LocLat1);
            this.U4General.Controls.Add(this.label30);
            this.U4General.Controls.Add(this.label31);
            this.U4General.Location = new System.Drawing.Point(534, 245);
            this.U4General.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.U4General.Name = "U4General";
            this.U4General.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.U4General.Size = new System.Drawing.Size(166, 92);
            this.U4General.TabIndex = 37;
            this.U4General.TabStop = false;
            this.U4General.Text = "General";
            // 
            // U4GoToDropDownBox
            // 
            this.U4GoToDropDownBox.BackColor = System.Drawing.Color.White;
            this.U4GoToDropDownBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.U4GoToDropDownBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.U4GoToDropDownBox.FormattingEnabled = true;
            this.U4GoToDropDownBox.Items.AddRange(new object[] {
            "Not Specified"});
            this.U4GoToDropDownBox.Location = new System.Drawing.Point(55, 64);
            this.U4GoToDropDownBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.U4GoToDropDownBox.Name = "U4GoToDropDownBox";
            this.U4GoToDropDownBox.Size = new System.Drawing.Size(99, 21);
            this.U4GoToDropDownBox.TabIndex = 26;
            this.U4GoToDropDownBox.SelectedIndexChanged += new System.EventHandler(this.U4GoToDropDownBox_SelectedIndexChanged);
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(4, 64);
            this.label32.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(33, 13);
            this.label32.TabIndex = 25;
            this.label32.Text = "Go to";
            // 
            // U4LocLong2
            // 
            this.U4LocLong2.Location = new System.Drawing.Point(135, 42);
            this.U4LocLong2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.U4LocLong2.Name = "U4LocLong2";
            this.U4LocLong2.Size = new System.Drawing.Size(19, 20);
            this.U4LocLong2.TabIndex = 55;
            this.U4LocLong2.Text = "A";
            this.U4LocLong2.TextChanged += new System.EventHandler(this.U4LocLong2_TextChanged);
            this.U4LocLong2.Validating += new System.ComponentModel.CancelEventHandler(this.U4LocLong2_Validating);
            this.U4LocLong2.Validated += new System.EventHandler(this.U4LocLong2_Validated);
            // 
            // U4LocLong1
            // 
            this.U4LocLong1.Location = new System.Drawing.Point(112, 42);
            this.U4LocLong1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.U4LocLong1.Name = "U4LocLong1";
            this.U4LocLong1.Size = new System.Drawing.Size(20, 20);
            this.U4LocLong1.TabIndex = 54;
            this.U4LocLong1.Text = "A";
            this.U4LocLong1.TextChanged += new System.EventHandler(this.U4LocLong1_TextChanged);
            this.U4LocLong1.Validating += new System.ComponentModel.CancelEventHandler(this.U4LocLong1_Validating);
            this.U4LocLong1.Validated += new System.EventHandler(this.U4LocLong1_Validated);
            // 
            // U4LocLat2
            // 
            this.U4LocLat2.Location = new System.Drawing.Point(77, 42);
            this.U4LocLat2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.U4LocLat2.Name = "U4LocLat2";
            this.U4LocLat2.Size = new System.Drawing.Size(19, 20);
            this.U4LocLat2.TabIndex = 27;
            this.U4LocLat2.Text = "A";
            this.U4LocLat2.TextChanged += new System.EventHandler(this.U4LocLat2_TextChanged);
            this.U4LocLat2.Validating += new System.ComponentModel.CancelEventHandler(this.U4LocLat2_Validating);
            this.U4LocLat2.Validated += new System.EventHandler(this.U4LocLat2_Validated);
            // 
            // U4MovesTextBox
            // 
            this.U4MovesTextBox.Location = new System.Drawing.Point(61, 21);
            this.U4MovesTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.U4MovesTextBox.Name = "U4MovesTextBox";
            this.U4MovesTextBox.Size = new System.Drawing.Size(92, 20);
            this.U4MovesTextBox.TabIndex = 52;
            this.U4MovesTextBox.Text = "0";
            this.U4MovesTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.U4MovesTextBox_Validating);
            this.U4MovesTextBox.Validated += new System.EventHandler(this.U4MovesTextBox_Validated);
            // 
            // U4LocLat1
            // 
            this.U4LocLat1.Location = new System.Drawing.Point(55, 42);
            this.U4LocLat1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.U4LocLat1.Name = "U4LocLat1";
            this.U4LocLat1.Size = new System.Drawing.Size(20, 20);
            this.U4LocLat1.TabIndex = 26;
            this.U4LocLat1.Text = "A";
            this.U4LocLat1.TextChanged += new System.EventHandler(this.U4LocLat1_TextChanged);
            this.U4LocLat1.Validating += new System.ComponentModel.CancelEventHandler(this.U4LocLat1_Validating);
            this.U4LocLat1.Validated += new System.EventHandler(this.U4LocLat1_Validated);
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(4, 23);
            this.label30.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(39, 13);
            this.label30.TabIndex = 53;
            this.label30.Text = "Moves";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(4, 44);
            this.label31.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(48, 13);
            this.label31.TabIndex = 25;
            this.label31.Text = "Location";
            // 
            // U4PartyEquipment
            // 
            this.U4PartyEquipment.Controls.Add(this.U4SextantsTextBox);
            this.U4PartyEquipment.Controls.Add(this.label27);
            this.U4PartyEquipment.Controls.Add(this.U4GemsTextBox);
            this.U4PartyEquipment.Controls.Add(this.label28);
            this.U4PartyEquipment.Controls.Add(this.U4GoldTextBox);
            this.U4PartyEquipment.Controls.Add(this.label29);
            this.U4PartyEquipment.Controls.Add(this.U4KeysTextBox);
            this.U4PartyEquipment.Controls.Add(this.label26);
            this.U4PartyEquipment.Controls.Add(this.U4TorchesTextBox);
            this.U4PartyEquipment.Controls.Add(this.label25);
            this.U4PartyEquipment.Controls.Add(this.U4FoodTextBox);
            this.U4PartyEquipment.Controls.Add(this.label24);
            this.U4PartyEquipment.Controls.Add(this.U4PartyWeaponsTextBox);
            this.U4PartyEquipment.Controls.Add(this.label23);
            this.U4PartyEquipment.Controls.Add(this.U4PartyArmorTextBox);
            this.U4PartyEquipment.Controls.Add(this.label22);
            this.U4PartyEquipment.Controls.Add(this.U4ReagentsTextBox);
            this.U4PartyEquipment.Controls.Add(this.label21);
            this.U4PartyEquipment.Controls.Add(this.U4PartyWeaponsDropDown);
            this.U4PartyEquipment.Controls.Add(this.label20);
            this.U4PartyEquipment.Controls.Add(this.U4PartyArmorDropDown);
            this.U4PartyEquipment.Controls.Add(this.label19);
            this.U4PartyEquipment.Controls.Add(this.U4ReagentsDropDown);
            this.U4PartyEquipment.Controls.Add(this.label18);
            this.U4PartyEquipment.Controls.Add(this.U4SpellsTextBox);
            this.U4PartyEquipment.Controls.Add(this.label17);
            this.U4PartyEquipment.Controls.Add(this.U4SpellsDropDown);
            this.U4PartyEquipment.Controls.Add(this.label15);
            this.U4PartyEquipment.Location = new System.Drawing.Point(193, 23);
            this.U4PartyEquipment.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.U4PartyEquipment.Name = "U4PartyEquipment";
            this.U4PartyEquipment.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.U4PartyEquipment.Size = new System.Drawing.Size(328, 215);
            this.U4PartyEquipment.TabIndex = 36;
            this.U4PartyEquipment.TabStop = false;
            this.U4PartyEquipment.Text = "Party Equipment";
            // 
            // U4SextantsTextBox
            // 
            this.U4SextantsTextBox.Location = new System.Drawing.Point(281, 184);
            this.U4SextantsTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.U4SextantsTextBox.Name = "U4SextantsTextBox";
            this.U4SextantsTextBox.Size = new System.Drawing.Size(34, 20);
            this.U4SextantsTextBox.TabIndex = 50;
            this.U4SextantsTextBox.Text = "0";
            this.U4SextantsTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.U4SextantsTextBox_Validating);
            this.U4SextantsTextBox.Validated += new System.EventHandler(this.U4SextantsTextBox_Validated);
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(223, 186);
            this.label27.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(48, 13);
            this.label27.TabIndex = 51;
            this.label27.Text = "Sextants";
            // 
            // U4GemsTextBox
            // 
            this.U4GemsTextBox.Location = new System.Drawing.Point(281, 159);
            this.U4GemsTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.U4GemsTextBox.Name = "U4GemsTextBox";
            this.U4GemsTextBox.Size = new System.Drawing.Size(34, 20);
            this.U4GemsTextBox.TabIndex = 48;
            this.U4GemsTextBox.Text = "0";
            this.U4GemsTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.U4GemsTextBox_Validating);
            this.U4GemsTextBox.Validated += new System.EventHandler(this.U4GemsTextBox_Validated);
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(223, 161);
            this.label28.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(34, 13);
            this.label28.TabIndex = 49;
            this.label28.Text = "Gems";
            // 
            // U4GoldTextBox
            // 
            this.U4GoldTextBox.Location = new System.Drawing.Point(281, 134);
            this.U4GoldTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.U4GoldTextBox.Name = "U4GoldTextBox";
            this.U4GoldTextBox.Size = new System.Drawing.Size(34, 20);
            this.U4GoldTextBox.TabIndex = 46;
            this.U4GoldTextBox.Text = "0";
            this.U4GoldTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.U4GoldTextBox_Validating);
            this.U4GoldTextBox.Validated += new System.EventHandler(this.U4GoldTextBox_Validated);
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(223, 136);
            this.label29.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(29, 13);
            this.label29.TabIndex = 47;
            this.label29.Text = "Gold";
            // 
            // U4KeysTextBox
            // 
            this.U4KeysTextBox.Location = new System.Drawing.Point(71, 182);
            this.U4KeysTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.U4KeysTextBox.Name = "U4KeysTextBox";
            this.U4KeysTextBox.Size = new System.Drawing.Size(34, 20);
            this.U4KeysTextBox.TabIndex = 44;
            this.U4KeysTextBox.Text = "0";
            this.U4KeysTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.U4KeysTextBox_Validating);
            this.U4KeysTextBox.Validated += new System.EventHandler(this.U4KeysTextBox_Validated);
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(14, 184);
            this.label26.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(30, 13);
            this.label26.TabIndex = 45;
            this.label26.Text = "Keys";
            // 
            // U4TorchesTextBox
            // 
            this.U4TorchesTextBox.Location = new System.Drawing.Point(71, 157);
            this.U4TorchesTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.U4TorchesTextBox.Name = "U4TorchesTextBox";
            this.U4TorchesTextBox.Size = new System.Drawing.Size(34, 20);
            this.U4TorchesTextBox.TabIndex = 42;
            this.U4TorchesTextBox.Text = "0";
            this.U4TorchesTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.U4TorchesTextBox_Validating);
            this.U4TorchesTextBox.Validated += new System.EventHandler(this.U4TorchesTextBox_Validated);
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(14, 159);
            this.label25.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(46, 13);
            this.label25.TabIndex = 43;
            this.label25.Text = "Torches";
            // 
            // U4FoodTextBox
            // 
            this.U4FoodTextBox.Location = new System.Drawing.Point(71, 132);
            this.U4FoodTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.U4FoodTextBox.Name = "U4FoodTextBox";
            this.U4FoodTextBox.Size = new System.Drawing.Size(34, 20);
            this.U4FoodTextBox.TabIndex = 40;
            this.U4FoodTextBox.Text = "0";
            this.U4FoodTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.U4FoodTextBox_Validating);
            this.U4FoodTextBox.Validated += new System.EventHandler(this.U4FoodTextBox_Validated);
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(14, 134);
            this.label24.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(31, 13);
            this.label24.TabIndex = 41;
            this.label24.Text = "Food";
            // 
            // U4PartyWeaponsTextBox
            // 
            this.U4PartyWeaponsTextBox.Location = new System.Drawing.Point(281, 94);
            this.U4PartyWeaponsTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.U4PartyWeaponsTextBox.Name = "U4PartyWeaponsTextBox";
            this.U4PartyWeaponsTextBox.Size = new System.Drawing.Size(34, 20);
            this.U4PartyWeaponsTextBox.TabIndex = 38;
            this.U4PartyWeaponsTextBox.Text = "0";
            this.U4PartyWeaponsTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.U4PartyWeaponsTextBox_Validating);
            this.U4PartyWeaponsTextBox.Validated += new System.EventHandler(this.U4PartyWeaponsTextBox_Validated);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(223, 96);
            this.label23.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(46, 13);
            this.label23.TabIndex = 39;
            this.label23.Text = "Quantity";
            // 
            // U4PartyArmorTextBox
            // 
            this.U4PartyArmorTextBox.Location = new System.Drawing.Point(281, 72);
            this.U4PartyArmorTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.U4PartyArmorTextBox.Name = "U4PartyArmorTextBox";
            this.U4PartyArmorTextBox.Size = new System.Drawing.Size(34, 20);
            this.U4PartyArmorTextBox.TabIndex = 36;
            this.U4PartyArmorTextBox.Text = "0";
            this.U4PartyArmorTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.U4PartyArmorTextBox_Validating);
            this.U4PartyArmorTextBox.Validated += new System.EventHandler(this.U4PartyArmorTextBox_Validated);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(223, 74);
            this.label22.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(46, 13);
            this.label22.TabIndex = 37;
            this.label22.Text = "Quantity";
            // 
            // U4ReagentsTextBox
            // 
            this.U4ReagentsTextBox.Location = new System.Drawing.Point(281, 42);
            this.U4ReagentsTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.U4ReagentsTextBox.Name = "U4ReagentsTextBox";
            this.U4ReagentsTextBox.Size = new System.Drawing.Size(34, 20);
            this.U4ReagentsTextBox.TabIndex = 34;
            this.U4ReagentsTextBox.Text = "0";
            this.U4ReagentsTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.U4ReagentsTextBox_Validating);
            this.U4ReagentsTextBox.Validated += new System.EventHandler(this.U4ReagentsTextBox_Validated);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(223, 44);
            this.label21.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(46, 13);
            this.label21.TabIndex = 35;
            this.label21.Text = "Quantity";
            // 
            // U4PartyWeaponsDropDown
            // 
            this.U4PartyWeaponsDropDown.BackColor = System.Drawing.Color.White;
            this.U4PartyWeaponsDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.U4PartyWeaponsDropDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.U4PartyWeaponsDropDown.FormattingEnabled = true;
            this.U4PartyWeaponsDropDown.Items.AddRange(new object[] {
            "Hands",
            "Staff",
            "Dagger",
            "Sling",
            "Mace",
            "Axe",
            "Sword",
            "Bow",
            "Crossbow",
            "Flaming Oil",
            "Halberd",
            "Magic Axe",
            "Magic Sword",
            "Magic Bow",
            "Magic Wand",
            "Mystic Sword"});
            this.U4PartyWeaponsDropDown.Location = new System.Drawing.Point(71, 94);
            this.U4PartyWeaponsDropDown.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.U4PartyWeaponsDropDown.Name = "U4PartyWeaponsDropDown";
            this.U4PartyWeaponsDropDown.Size = new System.Drawing.Size(118, 21);
            this.U4PartyWeaponsDropDown.TabIndex = 33;
            this.U4PartyWeaponsDropDown.SelectedIndexChanged += new System.EventHandler(this.U4PartyWeaponsDropDown_SelectedIndexChanged);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(11, 96);
            this.label20.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(48, 13);
            this.label20.TabIndex = 32;
            this.label20.Text = "Weapon";
            // 
            // U4PartyArmorDropDown
            // 
            this.U4PartyArmorDropDown.BackColor = System.Drawing.Color.White;
            this.U4PartyArmorDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.U4PartyArmorDropDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.U4PartyArmorDropDown.FormattingEnabled = true;
            this.U4PartyArmorDropDown.Items.AddRange(new object[] {
            "Skin",
            "Cloth",
            "Leather",
            "Chain Mail",
            "Plate Mail",
            "Magic Chain",
            "Magic Plate",
            "Mystic Robe"});
            this.U4PartyArmorDropDown.Location = new System.Drawing.Point(71, 72);
            this.U4PartyArmorDropDown.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.U4PartyArmorDropDown.Name = "U4PartyArmorDropDown";
            this.U4PartyArmorDropDown.Size = new System.Drawing.Size(118, 21);
            this.U4PartyArmorDropDown.TabIndex = 31;
            this.U4PartyArmorDropDown.SelectedIndexChanged += new System.EventHandler(this.U4PartyArmorDropDown_SelectedIndexChanged);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(11, 74);
            this.label19.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(34, 13);
            this.label19.TabIndex = 30;
            this.label19.Text = "Armor";
            // 
            // U4ReagentsDropDown
            // 
            this.U4ReagentsDropDown.BackColor = System.Drawing.Color.White;
            this.U4ReagentsDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.U4ReagentsDropDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.U4ReagentsDropDown.FormattingEnabled = true;
            this.U4ReagentsDropDown.Items.AddRange(new object[] {
            "Sulfur Ash",
            "Ginseng",
            "Garlic",
            "Spider Silk",
            "Blood Moss",
            "Black Pearl",
            "Nightshade",
            "Mandrake"});
            this.U4ReagentsDropDown.Location = new System.Drawing.Point(71, 42);
            this.U4ReagentsDropDown.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.U4ReagentsDropDown.Name = "U4ReagentsDropDown";
            this.U4ReagentsDropDown.Size = new System.Drawing.Size(118, 21);
            this.U4ReagentsDropDown.TabIndex = 29;
            this.U4ReagentsDropDown.SelectedIndexChanged += new System.EventHandler(this.U4ReagentsDropDown_SelectedIndexChanged);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(11, 44);
            this.label18.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(53, 13);
            this.label18.TabIndex = 28;
            this.label18.Text = "Reagents";
            // 
            // U4SpellsTextBox
            // 
            this.U4SpellsTextBox.Location = new System.Drawing.Point(281, 20);
            this.U4SpellsTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.U4SpellsTextBox.Name = "U4SpellsTextBox";
            this.U4SpellsTextBox.Size = new System.Drawing.Size(34, 20);
            this.U4SpellsTextBox.TabIndex = 25;
            this.U4SpellsTextBox.Text = "0";
            this.U4SpellsTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.U4SpellsTextBox_Validating);
            this.U4SpellsTextBox.Validated += new System.EventHandler(this.U4SpellsTextBox_Validated);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(223, 22);
            this.label17.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(46, 13);
            this.label17.TabIndex = 27;
            this.label17.Text = "Quantity";
            // 
            // U4SpellsDropDown
            // 
            this.U4SpellsDropDown.BackColor = System.Drawing.Color.White;
            this.U4SpellsDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.U4SpellsDropDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.U4SpellsDropDown.FormattingEnabled = true;
            this.U4SpellsDropDown.Items.AddRange(new object[] {
            "Awaken",
            "Blink",
            "Cure",
            "Dispell",
            "Energy",
            "Fireball",
            "Gate",
            "Heal",
            "Iceball",
            "Jinx",
            "Kill",
            "Light",
            "Magic Missle",
            "Negate",
            "Open",
            "Protect",
            "Quickness",
            "Ressurect",
            "Sleep",
            "Tremor",
            "Undead",
            "View",
            "Winds",
            "X-It",
            "Y-Up",
            "Z-Down"});
            this.U4SpellsDropDown.Location = new System.Drawing.Point(71, 20);
            this.U4SpellsDropDown.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.U4SpellsDropDown.Name = "U4SpellsDropDown";
            this.U4SpellsDropDown.Size = new System.Drawing.Size(118, 21);
            this.U4SpellsDropDown.TabIndex = 26;
            this.U4SpellsDropDown.SelectedIndexChanged += new System.EventHandler(this.U4SpellsDropDown_SelectedIndexChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(11, 22);
            this.label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(35, 13);
            this.label15.TabIndex = 25;
            this.label15.Text = "Spells";
            // 
            // U4QuestItems
            // 
            this.U4QuestItems.Controls.Add(this.U4CourageCheckBox);
            this.U4QuestItems.Controls.Add(this.U4BellCheckBox);
            this.U4QuestItems.Controls.Add(this.U4TruthCheckBox);
            this.U4QuestItems.Controls.Add(this.U4BookCheckBox);
            this.U4QuestItems.Controls.Add(this.U4CandleCheckBox);
            this.U4QuestItems.Controls.Add(this.U4WheelCheckBox);
            this.U4QuestItems.Controls.Add(this.U4HornCheckBox);
            this.U4QuestItems.Controls.Add(this.U4LoveCheckBox);
            this.U4QuestItems.Controls.Add(this.U4SkullCheckBox);
            this.U4QuestItems.Controls.Add(this.label16);
            this.U4QuestItems.Location = new System.Drawing.Point(193, 245);
            this.U4QuestItems.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.U4QuestItems.Name = "U4QuestItems";
            this.U4QuestItems.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.U4QuestItems.Size = new System.Drawing.Size(329, 84);
            this.U4QuestItems.TabIndex = 35;
            this.U4QuestItems.TabStop = false;
            this.U4QuestItems.Text = "Quest Items";
            // 
            // U4CourageCheckBox
            // 
            this.U4CourageCheckBox.AutoSize = true;
            this.U4CourageCheckBox.Location = new System.Drawing.Point(223, 63);
            this.U4CourageCheckBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.U4CourageCheckBox.Name = "U4CourageCheckBox";
            this.U4CourageCheckBox.Size = new System.Drawing.Size(99, 17);
            this.U4CourageCheckBox.TabIndex = 35;
            this.U4CourageCheckBox.Text = "Key of Courage";
            this.U4CourageCheckBox.UseVisualStyleBackColor = true;
            this.U4CourageCheckBox.CheckedChanged += new System.EventHandler(this.U4CourageCheckBox_CheckedChanged);
            // 
            // U4BellCheckBox
            // 
            this.U4BellCheckBox.AutoSize = true;
            this.U4BellCheckBox.Location = new System.Drawing.Point(223, 44);
            this.U4BellCheckBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.U4BellCheckBox.Name = "U4BellCheckBox";
            this.U4BellCheckBox.Size = new System.Drawing.Size(98, 17);
            this.U4BellCheckBox.TabIndex = 34;
            this.U4BellCheckBox.Text = "Bell of Courage";
            this.U4BellCheckBox.UseVisualStyleBackColor = true;
            this.U4BellCheckBox.CheckedChanged += new System.EventHandler(this.U4BellCheckBox_CheckedChanged);
            // 
            // U4TruthCheckBox
            // 
            this.U4TruthCheckBox.AutoSize = true;
            this.U4TruthCheckBox.Location = new System.Drawing.Point(123, 64);
            this.U4TruthCheckBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.U4TruthCheckBox.Name = "U4TruthCheckBox";
            this.U4TruthCheckBox.Size = new System.Drawing.Size(84, 17);
            this.U4TruthCheckBox.TabIndex = 33;
            this.U4TruthCheckBox.Text = "Key of Truth";
            this.U4TruthCheckBox.UseVisualStyleBackColor = true;
            this.U4TruthCheckBox.CheckedChanged += new System.EventHandler(this.U4TruthCheckBox_CheckedChanged);
            // 
            // U4BookCheckBox
            // 
            this.U4BookCheckBox.AutoSize = true;
            this.U4BookCheckBox.Location = new System.Drawing.Point(123, 44);
            this.U4BookCheckBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.U4BookCheckBox.Name = "U4BookCheckBox";
            this.U4BookCheckBox.Size = new System.Drawing.Size(91, 17);
            this.U4BookCheckBox.TabIndex = 32;
            this.U4BookCheckBox.Text = "Book of Truth";
            this.U4BookCheckBox.UseVisualStyleBackColor = true;
            this.U4BookCheckBox.CheckedChanged += new System.EventHandler(this.U4BookCheckBox_CheckedChanged);
            // 
            // U4CandleCheckBox
            // 
            this.U4CandleCheckBox.AutoSize = true;
            this.U4CandleCheckBox.Location = new System.Drawing.Point(12, 44);
            this.U4CandleCheckBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.U4CandleCheckBox.Name = "U4CandleCheckBox";
            this.U4CandleCheckBox.Size = new System.Drawing.Size(98, 17);
            this.U4CandleCheckBox.TabIndex = 31;
            this.U4CandleCheckBox.Text = "Candle of Love";
            this.U4CandleCheckBox.UseVisualStyleBackColor = true;
            this.U4CandleCheckBox.CheckedChanged += new System.EventHandler(this.U4CandleCheckBox_CheckedChanged);
            // 
            // U4WheelCheckBox
            // 
            this.U4WheelCheckBox.AutoSize = true;
            this.U4WheelCheckBox.Location = new System.Drawing.Point(223, 24);
            this.U4WheelCheckBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.U4WheelCheckBox.Name = "U4WheelCheckBox";
            this.U4WheelCheckBox.Size = new System.Drawing.Size(57, 17);
            this.U4WheelCheckBox.TabIndex = 30;
            this.U4WheelCheckBox.Text = "Wheel";
            this.U4WheelCheckBox.UseVisualStyleBackColor = true;
            this.U4WheelCheckBox.CheckedChanged += new System.EventHandler(this.U4WheelCheckBox_CheckedChanged);
            // 
            // U4HornCheckBox
            // 
            this.U4HornCheckBox.AutoSize = true;
            this.U4HornCheckBox.Location = new System.Drawing.Point(123, 24);
            this.U4HornCheckBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.U4HornCheckBox.Name = "U4HornCheckBox";
            this.U4HornCheckBox.Size = new System.Drawing.Size(78, 17);
            this.U4HornCheckBox.TabIndex = 29;
            this.U4HornCheckBox.Text = "Silver Horn";
            this.U4HornCheckBox.UseVisualStyleBackColor = true;
            this.U4HornCheckBox.CheckedChanged += new System.EventHandler(this.U4HornCheckBox_CheckedChanged);
            // 
            // U4LoveCheckBox
            // 
            this.U4LoveCheckBox.AutoSize = true;
            this.U4LoveCheckBox.Location = new System.Drawing.Point(12, 64);
            this.U4LoveCheckBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.U4LoveCheckBox.Name = "U4LoveCheckBox";
            this.U4LoveCheckBox.Size = new System.Drawing.Size(83, 17);
            this.U4LoveCheckBox.TabIndex = 28;
            this.U4LoveCheckBox.Text = "Key of Love";
            this.U4LoveCheckBox.UseVisualStyleBackColor = true;
            this.U4LoveCheckBox.CheckedChanged += new System.EventHandler(this.U4LoveCheckBox_CheckedChanged);
            // 
            // U4SkullCheckBox
            // 
            this.U4SkullCheckBox.AutoSize = true;
            this.U4SkullCheckBox.Location = new System.Drawing.Point(12, 24);
            this.U4SkullCheckBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.U4SkullCheckBox.Name = "U4SkullCheckBox";
            this.U4SkullCheckBox.Size = new System.Drawing.Size(100, 17);
            this.U4SkullCheckBox.TabIndex = 27;
            this.U4SkullCheckBox.Text = "Mondain\'s Skull";
            this.U4SkullCheckBox.UseVisualStyleBackColor = true;
            this.U4SkullCheckBox.CheckedChanged += new System.EventHandler(this.U4SkullCheckBox_CheckedChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(366, 52);
            this.label16.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(27, 13);
            this.label16.TabIndex = 16;
            this.label16.Text = "% of";
            // 
            // U4Virtues
            // 
            this.U4Virtues.Controls.Add(this.U4BlackCheckBox);
            this.U4Virtues.Controls.Add(this.U4WhiteCheckBox);
            this.U4Virtues.Controls.Add(this.U4PurpleCheckBox);
            this.U4Virtues.Controls.Add(this.U4OrangeCheckBox);
            this.U4Virtues.Controls.Add(this.U4GreenCheckBox);
            this.U4Virtues.Controls.Add(this.U4RedCheckBox);
            this.U4Virtues.Controls.Add(this.U4YellowCheckBox);
            this.U4Virtues.Controls.Add(this.U4BlueStoneCheckBox);
            this.U4Virtues.Controls.Add(this.label14);
            this.U4Virtues.Controls.Add(this.U4VirtueTextBox);
            this.U4Virtues.Controls.Add(this.label13);
            this.U4Virtues.Controls.Add(this.U4RuneCheckBox);
            this.U4Virtues.Controls.Add(this.U4VirtueDropDown);
            this.U4Virtues.Controls.Add(this.U4RuneDropDown);
            this.U4Virtues.Location = new System.Drawing.Point(19, 334);
            this.U4Virtues.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.U4Virtues.Name = "U4Virtues";
            this.U4Virtues.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.U4Virtues.Size = new System.Drawing.Size(503, 85);
            this.U4Virtues.TabIndex = 1;
            this.U4Virtues.TabStop = false;
            this.U4Virtues.Text = "Virtues";
            // 
            // U4BlackCheckBox
            // 
            this.U4BlackCheckBox.AutoSize = true;
            this.U4BlackCheckBox.Location = new System.Drawing.Point(253, 44);
            this.U4BlackCheckBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.U4BlackCheckBox.Name = "U4BlackCheckBox";
            this.U4BlackCheckBox.Size = new System.Drawing.Size(53, 17);
            this.U4BlackCheckBox.TabIndex = 34;
            this.U4BlackCheckBox.Text = "Black";
            this.U4BlackCheckBox.UseVisualStyleBackColor = true;
            this.U4BlackCheckBox.CheckedChanged += new System.EventHandler(this.U4BlackCheckBox_CheckedChanged);
            // 
            // U4WhiteCheckBox
            // 
            this.U4WhiteCheckBox.AutoSize = true;
            this.U4WhiteCheckBox.Location = new System.Drawing.Point(187, 44);
            this.U4WhiteCheckBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.U4WhiteCheckBox.Name = "U4WhiteCheckBox";
            this.U4WhiteCheckBox.Size = new System.Drawing.Size(54, 17);
            this.U4WhiteCheckBox.TabIndex = 33;
            this.U4WhiteCheckBox.Text = "White";
            this.U4WhiteCheckBox.UseVisualStyleBackColor = true;
            this.U4WhiteCheckBox.CheckedChanged += new System.EventHandler(this.U4WhiteCheckBox_CheckedChanged);
            // 
            // U4PurpleCheckBox
            // 
            this.U4PurpleCheckBox.AutoSize = true;
            this.U4PurpleCheckBox.Location = new System.Drawing.Point(122, 43);
            this.U4PurpleCheckBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.U4PurpleCheckBox.Name = "U4PurpleCheckBox";
            this.U4PurpleCheckBox.Size = new System.Drawing.Size(56, 17);
            this.U4PurpleCheckBox.TabIndex = 32;
            this.U4PurpleCheckBox.Text = "Purple";
            this.U4PurpleCheckBox.UseVisualStyleBackColor = true;
            this.U4PurpleCheckBox.CheckedChanged += new System.EventHandler(this.U4PurpleCheckBox_CheckedChanged);
            // 
            // U4OrangeCheckBox
            // 
            this.U4OrangeCheckBox.AutoSize = true;
            this.U4OrangeCheckBox.Location = new System.Drawing.Point(57, 43);
            this.U4OrangeCheckBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.U4OrangeCheckBox.Name = "U4OrangeCheckBox";
            this.U4OrangeCheckBox.Size = new System.Drawing.Size(61, 17);
            this.U4OrangeCheckBox.TabIndex = 31;
            this.U4OrangeCheckBox.Text = "Orange";
            this.U4OrangeCheckBox.UseVisualStyleBackColor = true;
            this.U4OrangeCheckBox.CheckedChanged += new System.EventHandler(this.U4OrangeCheckBox_CheckedChanged);
            // 
            // U4GreenCheckBox
            // 
            this.U4GreenCheckBox.AutoSize = true;
            this.U4GreenCheckBox.Location = new System.Drawing.Point(253, 24);
            this.U4GreenCheckBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.U4GreenCheckBox.Name = "U4GreenCheckBox";
            this.U4GreenCheckBox.Size = new System.Drawing.Size(55, 17);
            this.U4GreenCheckBox.TabIndex = 30;
            this.U4GreenCheckBox.Text = "Green";
            this.U4GreenCheckBox.UseVisualStyleBackColor = true;
            this.U4GreenCheckBox.CheckedChanged += new System.EventHandler(this.U4GreenCheckBox_CheckedChanged);
            // 
            // U4RedCheckBox
            // 
            this.U4RedCheckBox.AutoSize = true;
            this.U4RedCheckBox.Location = new System.Drawing.Point(187, 24);
            this.U4RedCheckBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.U4RedCheckBox.Name = "U4RedCheckBox";
            this.U4RedCheckBox.Size = new System.Drawing.Size(46, 17);
            this.U4RedCheckBox.TabIndex = 29;
            this.U4RedCheckBox.Text = "Red";
            this.U4RedCheckBox.UseVisualStyleBackColor = true;
            this.U4RedCheckBox.CheckedChanged += new System.EventHandler(this.U4RedCheckBox_CheckedChanged);
            // 
            // U4YellowCheckBox
            // 
            this.U4YellowCheckBox.AutoSize = true;
            this.U4YellowCheckBox.Location = new System.Drawing.Point(122, 23);
            this.U4YellowCheckBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.U4YellowCheckBox.Name = "U4YellowCheckBox";
            this.U4YellowCheckBox.Size = new System.Drawing.Size(57, 17);
            this.U4YellowCheckBox.TabIndex = 28;
            this.U4YellowCheckBox.Text = "Yellow";
            this.U4YellowCheckBox.UseVisualStyleBackColor = true;
            this.U4YellowCheckBox.CheckedChanged += new System.EventHandler(this.U4YellowCheckBox_CheckedChanged);
            // 
            // U4BlueStoneCheckBox
            // 
            this.U4BlueStoneCheckBox.AutoSize = true;
            this.U4BlueStoneCheckBox.Location = new System.Drawing.Point(57, 23);
            this.U4BlueStoneCheckBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.U4BlueStoneCheckBox.Name = "U4BlueStoneCheckBox";
            this.U4BlueStoneCheckBox.Size = new System.Drawing.Size(47, 17);
            this.U4BlueStoneCheckBox.TabIndex = 27;
            this.U4BlueStoneCheckBox.Text = "Blue";
            this.U4BlueStoneCheckBox.UseVisualStyleBackColor = true;
            this.U4BlueStoneCheckBox.CheckedChanged += new System.EventHandler(this.U4BlueStoneCheckBox_CheckedChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(9, 25);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(40, 13);
            this.label14.TabIndex = 26;
            this.label14.Text = "Stones";
            // 
            // U4VirtueTextBox
            // 
            this.U4VirtueTextBox.Location = new System.Drawing.Point(329, 50);
            this.U4VirtueTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.U4VirtueTextBox.Name = "U4VirtueTextBox";
            this.U4VirtueTextBox.Size = new System.Drawing.Size(34, 20);
            this.U4VirtueTextBox.TabIndex = 25;
            this.U4VirtueTextBox.Text = "0";
            this.U4VirtueTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.U4VirtueTextBox_Validating);
            this.U4VirtueTextBox.Validated += new System.EventHandler(this.U4VirtueTextBox_Validated);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(366, 52);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(27, 13);
            this.label13.TabIndex = 16;
            this.label13.Text = "% of";
            // 
            // U4RuneCheckBox
            // 
            this.U4RuneCheckBox.AutoSize = true;
            this.U4RuneCheckBox.Location = new System.Drawing.Point(332, 25);
            this.U4RuneCheckBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.U4RuneCheckBox.Name = "U4RuneCheckBox";
            this.U4RuneCheckBox.Size = new System.Drawing.Size(64, 17);
            this.U4RuneCheckBox.TabIndex = 15;
            this.U4RuneCheckBox.Text = "Rune of";
            this.U4RuneCheckBox.UseVisualStyleBackColor = true;
            this.U4RuneCheckBox.CheckedChanged += new System.EventHandler(this.U4RuneCheckBox_CheckedChanged);
            // 
            // U4VirtueDropDown
            // 
            this.U4VirtueDropDown.BackColor = System.Drawing.Color.White;
            this.U4VirtueDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.U4VirtueDropDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.U4VirtueDropDown.FormattingEnabled = true;
            this.U4VirtueDropDown.Items.AddRange(new object[] {
            "Honesty",
            "Compassion",
            "Valor",
            "Justice",
            "Sacrifice",
            "Honor",
            "Spirituality",
            "Humility"});
            this.U4VirtueDropDown.Location = new System.Drawing.Point(397, 50);
            this.U4VirtueDropDown.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.U4VirtueDropDown.Name = "U4VirtueDropDown";
            this.U4VirtueDropDown.Size = new System.Drawing.Size(91, 21);
            this.U4VirtueDropDown.TabIndex = 14;
            this.U4VirtueDropDown.SelectedIndexChanged += new System.EventHandler(this.U4VirtueDropDown_SelectedIndexChanged);
            // 
            // U4RuneDropDown
            // 
            this.U4RuneDropDown.BackColor = System.Drawing.Color.White;
            this.U4RuneDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.U4RuneDropDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.U4RuneDropDown.FormattingEnabled = true;
            this.U4RuneDropDown.Items.AddRange(new object[] {
            "Honesty",
            "Compassion",
            "Valor",
            "Justice",
            "Sacrifice",
            "Honor",
            "Spirituality",
            "Humility"});
            this.U4RuneDropDown.Location = new System.Drawing.Point(397, 24);
            this.U4RuneDropDown.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.U4RuneDropDown.Name = "U4RuneDropDown";
            this.U4RuneDropDown.Size = new System.Drawing.Size(91, 21);
            this.U4RuneDropDown.TabIndex = 13;
            this.U4RuneDropDown.SelectedIndexChanged += new System.EventHandler(this.U4RuneDropDown_SelectedIndexChanged);
            // 
            // U4PlayerStats
            // 
            this.U4PlayerStats.Controls.Add(this.U4MagicTextBox);
            this.U4PlayerStats.Controls.Add(this.U4IntelligenceTextBox);
            this.U4PlayerStats.Controls.Add(this.U4DexterityTextBox);
            this.U4PlayerStats.Controls.Add(this.U4StrengthTextBox);
            this.U4PlayerStats.Controls.Add(this.U4ExperienceTextBox);
            this.U4PlayerStats.Controls.Add(this.U4MaxHitTextBox);
            this.U4PlayerStats.Controls.Add(this.U4HitTextBox);
            this.U4PlayerStats.Controls.Add(this.U4ArmorDropDown);
            this.U4PlayerStats.Controls.Add(this.U4WeaponDropDown);
            this.U4PlayerStats.Controls.Add(this.U4HealthDropDown);
            this.U4PlayerStats.Controls.Add(this.U4ClassDropDown);
            this.U4PlayerStats.Controls.Add(this.U4SexDropDown);
            this.U4PlayerStats.Controls.Add(this.U4NameDropDown);
            this.U4PlayerStats.Controls.Add(this.label12);
            this.U4PlayerStats.Controls.Add(this.label11);
            this.U4PlayerStats.Controls.Add(this.label10);
            this.U4PlayerStats.Controls.Add(this.label9);
            this.U4PlayerStats.Controls.Add(this.label8);
            this.U4PlayerStats.Controls.Add(this.label7);
            this.U4PlayerStats.Controls.Add(this.label6);
            this.U4PlayerStats.Controls.Add(this.label5);
            this.U4PlayerStats.Controls.Add(this.label4);
            this.U4PlayerStats.Controls.Add(this.label3);
            this.U4PlayerStats.Controls.Add(this.label2);
            this.U4PlayerStats.Controls.Add(this.label1);
            this.U4PlayerStats.Location = new System.Drawing.Point(19, 23);
            this.U4PlayerStats.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.U4PlayerStats.Name = "U4PlayerStats";
            this.U4PlayerStats.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.U4PlayerStats.Size = new System.Drawing.Size(170, 307);
            this.U4PlayerStats.TabIndex = 0;
            this.U4PlayerStats.TabStop = false;
            this.U4PlayerStats.Text = "Player Stats";
            // 
            // U4MagicTextBox
            // 
            this.U4MagicTextBox.Location = new System.Drawing.Point(85, 222);
            this.U4MagicTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.U4MagicTextBox.Name = "U4MagicTextBox";
            this.U4MagicTextBox.Size = new System.Drawing.Size(34, 20);
            this.U4MagicTextBox.TabIndex = 24;
            this.U4MagicTextBox.Text = "0";
            this.U4MagicTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.U4MagicTextBox_Validating);
            this.U4MagicTextBox.Validated += new System.EventHandler(this.U4MagicTextBox_Validated);
            // 
            // U4IntelligenceTextBox
            // 
            this.U4IntelligenceTextBox.Location = new System.Drawing.Point(85, 201);
            this.U4IntelligenceTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.U4IntelligenceTextBox.Name = "U4IntelligenceTextBox";
            this.U4IntelligenceTextBox.Size = new System.Drawing.Size(34, 20);
            this.U4IntelligenceTextBox.TabIndex = 23;
            this.U4IntelligenceTextBox.Text = "0";
            this.U4IntelligenceTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.U4IntelligenceTextBox_Validating);
            this.U4IntelligenceTextBox.Validated += new System.EventHandler(this.U4IntelligenceTextBox_Validated);
            // 
            // U4DexterityTextBox
            // 
            this.U4DexterityTextBox.Location = new System.Drawing.Point(85, 180);
            this.U4DexterityTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.U4DexterityTextBox.Name = "U4DexterityTextBox";
            this.U4DexterityTextBox.Size = new System.Drawing.Size(34, 20);
            this.U4DexterityTextBox.TabIndex = 22;
            this.U4DexterityTextBox.Text = "0";
            this.U4DexterityTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.U4DexterityTextBox_Validating);
            this.U4DexterityTextBox.Validated += new System.EventHandler(this.U4DexterityTextBox_Validated);
            // 
            // U4StrengthTextBox
            // 
            this.U4StrengthTextBox.Location = new System.Drawing.Point(85, 159);
            this.U4StrengthTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.U4StrengthTextBox.Name = "U4StrengthTextBox";
            this.U4StrengthTextBox.Size = new System.Drawing.Size(34, 20);
            this.U4StrengthTextBox.TabIndex = 21;
            this.U4StrengthTextBox.Text = "0";
            this.U4StrengthTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.U4StrengthTextBox_Validating);
            this.U4StrengthTextBox.Validated += new System.EventHandler(this.U4StrengthTextBox_Validated);
            // 
            // U4ExperienceTextBox
            // 
            this.U4ExperienceTextBox.Location = new System.Drawing.Point(85, 138);
            this.U4ExperienceTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.U4ExperienceTextBox.Name = "U4ExperienceTextBox";
            this.U4ExperienceTextBox.Size = new System.Drawing.Size(34, 20);
            this.U4ExperienceTextBox.TabIndex = 20;
            this.U4ExperienceTextBox.Text = "0";
            this.U4ExperienceTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.U4ExperienceTextBox_Validating);
            this.U4ExperienceTextBox.Validated += new System.EventHandler(this.U4ExperienceTextBox_Validated);
            // 
            // U4MaxHitTextBox
            // 
            this.U4MaxHitTextBox.Location = new System.Drawing.Point(122, 117);
            this.U4MaxHitTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.U4MaxHitTextBox.Name = "U4MaxHitTextBox";
            this.U4MaxHitTextBox.Size = new System.Drawing.Size(34, 20);
            this.U4MaxHitTextBox.TabIndex = 19;
            this.U4MaxHitTextBox.Text = "100";
            this.U4MaxHitTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.U4MaxHitTextBox_Validating);
            this.U4MaxHitTextBox.Validated += new System.EventHandler(this.U4MaxHitTextBox_Validated);
            // 
            // U4HitTextBox
            // 
            this.U4HitTextBox.Location = new System.Drawing.Point(85, 117);
            this.U4HitTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.U4HitTextBox.Name = "U4HitTextBox";
            this.U4HitTextBox.Size = new System.Drawing.Size(34, 20);
            this.U4HitTextBox.TabIndex = 18;
            this.U4HitTextBox.Text = "0";
            this.U4HitTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.U4HitTextBox_Validating);
            this.U4HitTextBox.Validated += new System.EventHandler(this.U4HitTextBox_Validated);
            // 
            // U4ArmorDropDown
            // 
            this.U4ArmorDropDown.BackColor = System.Drawing.Color.White;
            this.U4ArmorDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.U4ArmorDropDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.U4ArmorDropDown.FormattingEnabled = true;
            this.U4ArmorDropDown.Items.AddRange(new object[] {
            "Skin",
            "Cloth",
            "Leather",
            "Chain Mail",
            "Plate Mail",
            "Magic Chain",
            "Magic Plate",
            "Mystic Robe"});
            this.U4ArmorDropDown.Location = new System.Drawing.Point(65, 272);
            this.U4ArmorDropDown.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.U4ArmorDropDown.Name = "U4ArmorDropDown";
            this.U4ArmorDropDown.Size = new System.Drawing.Size(91, 21);
            this.U4ArmorDropDown.TabIndex = 17;
            this.U4ArmorDropDown.SelectedIndexChanged += new System.EventHandler(this.U4ArmorDropDown_SelectedIndexChanged);
            // 
            // U4WeaponDropDown
            // 
            this.U4WeaponDropDown.BackColor = System.Drawing.Color.White;
            this.U4WeaponDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.U4WeaponDropDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.U4WeaponDropDown.FormattingEnabled = true;
            this.U4WeaponDropDown.Items.AddRange(new object[] {
            "Hands",
            "Staff",
            "Dagger",
            "Sling",
            "Mace",
            "Axe",
            "Sword",
            "Bow",
            "Crossbow",
            "Flaming Oil",
            "Halberd",
            "Magic Axe",
            "Magic Sword",
            "Magic Bow",
            "Magic Wand",
            "Mystic Sword"});
            this.U4WeaponDropDown.Location = new System.Drawing.Point(65, 250);
            this.U4WeaponDropDown.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.U4WeaponDropDown.Name = "U4WeaponDropDown";
            this.U4WeaponDropDown.Size = new System.Drawing.Size(91, 21);
            this.U4WeaponDropDown.TabIndex = 16;
            this.U4WeaponDropDown.SelectedIndexChanged += new System.EventHandler(this.U4WeaponDropDown_SelectedIndexChanged);
            // 
            // U4HealthDropDown
            // 
            this.U4HealthDropDown.BackColor = System.Drawing.Color.White;
            this.U4HealthDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.U4HealthDropDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.U4HealthDropDown.FormattingEnabled = true;
            this.U4HealthDropDown.Items.AddRange(new object[] {
            "Good",
            "Dead",
            "Poisoned",
            "Asleep"});
            this.U4HealthDropDown.Location = new System.Drawing.Point(65, 91);
            this.U4HealthDropDown.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.U4HealthDropDown.Name = "U4HealthDropDown";
            this.U4HealthDropDown.Size = new System.Drawing.Size(91, 21);
            this.U4HealthDropDown.TabIndex = 15;
            this.U4HealthDropDown.SelectedIndexChanged += new System.EventHandler(this.U4HealthDropDown_SelectedIndexChanged);
            // 
            // U4ClassDropDown
            // 
            this.U4ClassDropDown.BackColor = System.Drawing.Color.White;
            this.U4ClassDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.U4ClassDropDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.U4ClassDropDown.FormattingEnabled = true;
            this.U4ClassDropDown.Items.AddRange(new object[] {
            "Mage",
            "Bard",
            "Fighter",
            "Druid",
            "Tinker",
            "Paladin",
            "Ranger",
            "Shepherd"});
            this.U4ClassDropDown.Location = new System.Drawing.Point(65, 69);
            this.U4ClassDropDown.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.U4ClassDropDown.Name = "U4ClassDropDown";
            this.U4ClassDropDown.Size = new System.Drawing.Size(91, 21);
            this.U4ClassDropDown.TabIndex = 14;
            this.U4ClassDropDown.SelectedIndexChanged += new System.EventHandler(this.U4ClassDropDown_SelectedIndexChanged);
            // 
            // U4SexDropDown
            // 
            this.U4SexDropDown.BackColor = System.Drawing.Color.White;
            this.U4SexDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.U4SexDropDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.U4SexDropDown.FormattingEnabled = true;
            this.U4SexDropDown.Items.AddRange(new object[] {
            "Female",
            "Male"});
            this.U4SexDropDown.Location = new System.Drawing.Point(65, 47);
            this.U4SexDropDown.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.U4SexDropDown.Name = "U4SexDropDown";
            this.U4SexDropDown.Size = new System.Drawing.Size(91, 21);
            this.U4SexDropDown.TabIndex = 13;
            this.U4SexDropDown.SelectedIndexChanged += new System.EventHandler(this.U4SexDropDown_SelectedIndexChanged);
            // 
            // U4NameDropDown
            // 
            this.U4NameDropDown.BackColor = System.Drawing.Color.White;
            this.U4NameDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.U4NameDropDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.U4NameDropDown.FormattingEnabled = true;
            this.U4NameDropDown.Location = new System.Drawing.Point(65, 25);
            this.U4NameDropDown.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.U4NameDropDown.Name = "U4NameDropDown";
            this.U4NameDropDown.Size = new System.Drawing.Size(91, 21);
            this.U4NameDropDown.TabIndex = 12;
            this.U4NameDropDown.SelectedIndexChanged += new System.EventHandler(this.U4NameDropDown_SelectedIndexChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(15, 93);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(38, 13);
            this.label12.TabIndex = 11;
            this.label12.Text = "Health";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(15, 119);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(61, 13);
            this.label11.TabIndex = 10;
            this.label11.Text = "Hit/Max Hit";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(15, 140);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(60, 13);
            this.label10.TabIndex = 9;
            this.label10.Text = "Experience";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(15, 161);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(47, 13);
            this.label9.TabIndex = 8;
            this.label9.Text = "Strength";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(15, 182);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "Dexterity";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 203);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Intelligence";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 224);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Magic";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 252);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Weapon";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 274);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Armor";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 71);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Class";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 49);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Sex";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 25);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // U5Tab
            // 
            this.U5Tab.BackColor = System.Drawing.Color.WhiteSmoke;
            this.U5Tab.Location = new System.Drawing.Point(4, 22);
            this.U5Tab.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.U5Tab.Name = "U5Tab";
            this.U5Tab.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.U5Tab.Size = new System.Drawing.Size(708, 435);
            this.U5Tab.TabIndex = 4;
            this.U5Tab.Text = "Ultima V";
            // 
            // U4OpenDialog
            // 
            this.U4OpenDialog.Filter = "C64 Disk Images|*.d64";
            // 
            // U4SaveDialog
            // 
            this.U4SaveDialog.Filter = "C64 Disk Images|*.d64";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(731, 474);
            this.Controls.Add(this.MainTabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainWindow";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.MainTabControl.ResumeLayout(false);
            this.U4Tab.ResumeLayout(false);
            this.U4General.ResumeLayout(false);
            this.U4General.PerformLayout();
            this.U4PartyEquipment.ResumeLayout(false);
            this.U4PartyEquipment.PerformLayout();
            this.U4QuestItems.ResumeLayout(false);
            this.U4QuestItems.PerformLayout();
            this.U4Virtues.ResumeLayout(false);
            this.U4Virtues.PerformLayout();
            this.U4PlayerStats.ResumeLayout(false);
            this.U4PlayerStats.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl MainTabControl;
        private System.Windows.Forms.TabPage U1Tab;
        private System.Windows.Forms.TabPage U2Tab;
        private System.Windows.Forms.TabPage U3Tab;
        private System.Windows.Forms.TabPage U4Tab;
        private System.Windows.Forms.TabPage U5Tab;
        private System.Windows.Forms.GroupBox U4PlayerStats;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox U4NameDropDown;
        private System.Windows.Forms.ComboBox U4ClassDropDown;
        private System.Windows.Forms.ComboBox U4SexDropDown;
        private System.Windows.Forms.ComboBox U4HealthDropDown;
        private System.Windows.Forms.TextBox U4MaxHitTextBox;
        private System.Windows.Forms.TextBox U4HitTextBox;
        private System.Windows.Forms.ComboBox U4ArmorDropDown;
        private System.Windows.Forms.ComboBox U4WeaponDropDown;
        private System.Windows.Forms.TextBox U4MagicTextBox;
        private System.Windows.Forms.TextBox U4IntelligenceTextBox;
        private System.Windows.Forms.TextBox U4DexterityTextBox;
        private System.Windows.Forms.TextBox U4StrengthTextBox;
        private System.Windows.Forms.TextBox U4ExperienceTextBox;
        private System.Windows.Forms.GroupBox U4Virtues;
        private System.Windows.Forms.ComboBox U4VirtueDropDown;
        private System.Windows.Forms.ComboBox U4RuneDropDown;
        private System.Windows.Forms.CheckBox U4BlackCheckBox;
        private System.Windows.Forms.CheckBox U4WhiteCheckBox;
        private System.Windows.Forms.CheckBox U4PurpleCheckBox;
        private System.Windows.Forms.CheckBox U4OrangeCheckBox;
        private System.Windows.Forms.CheckBox U4GreenCheckBox;
        private System.Windows.Forms.CheckBox U4RedCheckBox;
        private System.Windows.Forms.CheckBox U4YellowCheckBox;
        private System.Windows.Forms.CheckBox U4BlueStoneCheckBox;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox U4VirtueTextBox;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.CheckBox U4RuneCheckBox;
        private System.Windows.Forms.GroupBox U4PartyEquipment;
        private System.Windows.Forms.TextBox U4SextantsTextBox;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.TextBox U4GemsTextBox;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.TextBox U4GoldTextBox;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.TextBox U4KeysTextBox;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.TextBox U4TorchesTextBox;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox U4FoodTextBox;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox U4PartyWeaponsTextBox;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox U4PartyArmorTextBox;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox U4ReagentsTextBox;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.ComboBox U4PartyWeaponsDropDown;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.ComboBox U4PartyArmorDropDown;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.ComboBox U4ReagentsDropDown;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox U4SpellsTextBox;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.ComboBox U4SpellsDropDown;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.GroupBox U4QuestItems;
        private System.Windows.Forms.CheckBox U4CourageCheckBox;
        private System.Windows.Forms.CheckBox U4BellCheckBox;
        private System.Windows.Forms.CheckBox U4TruthCheckBox;
        private System.Windows.Forms.CheckBox U4BookCheckBox;
        private System.Windows.Forms.CheckBox U4CandleCheckBox;
        private System.Windows.Forms.CheckBox U4WheelCheckBox;
        private System.Windows.Forms.CheckBox U4HornCheckBox;
        private System.Windows.Forms.CheckBox U4LoveCheckBox;
        private System.Windows.Forms.CheckBox U4SkullCheckBox;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.GroupBox U4General;
        private System.Windows.Forms.TextBox U4LocLat2;
        private System.Windows.Forms.TextBox U4MovesTextBox;
        private System.Windows.Forms.TextBox U4LocLat1;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.ComboBox U4GoToDropDownBox;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.TextBox U4LocLong2;
        private System.Windows.Forms.TextBox U4LocLong1;
        private System.Windows.Forms.Button U4LoadButton;
        private System.Windows.Forms.Button U4SaveButton;
        private System.Windows.Forms.OpenFileDialog U4OpenDialog;
        private System.Windows.Forms.SaveFileDialog U4SaveDialog;
    }
}

