namespace DBZ_DokkanBottle
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.heightTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.widthTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.yTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.xTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.coordinatesGroupBox = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.CSelectDifficulty = new System.Windows.Forms.ComboBox();
            this.AutoRestoreACTCheck = new System.Windows.Forms.CheckBox();
            this.button3 = new System.Windows.Forms.Button();
            this.CSelectDice = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.DSRefillLbl = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.ResetInfoGame = new System.Windows.Forms.Button();
            this.GameDoneLbl = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.NbGame = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.NbDS = new System.Windows.Forms.NumericUpDown();
            this.EventBotLogs = new System.Windows.Forms.RichTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.CkWayT = new System.Windows.Forms.CheckBox();
            this.CkWayR = new System.Windows.Forms.CheckBox();
            this.CkWayL = new System.Windows.Forms.CheckBox();
            this.CkWayD = new System.Windows.Forms.CheckBox();
            this.checkBoxTB = new System.Windows.Forms.CheckBox();
            this.button4 = new System.Windows.Forms.Button();
            this.coordinatesGroupBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NbGame)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NbDS)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(254, 26);
            this.button1.TabIndex = 0;
            this.button1.Text = "Start Botting";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(11, 24);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(132, 26);
            this.button2.TabIndex = 1;
            this.button2.Text = "Take Screenshot";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // heightTextBox
            // 
            this.heightTextBox.Location = new System.Drawing.Point(99, 58);
            this.heightTextBox.Name = "heightTextBox";
            this.heightTextBox.ReadOnly = true;
            this.heightTextBox.Size = new System.Drawing.Size(37, 20);
            this.heightTextBox.TabIndex = 23;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(78, 62);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 13);
            this.label5.TabIndex = 27;
            this.label5.Text = "Y:";
            // 
            // widthTextBox
            // 
            this.widthTextBox.Location = new System.Drawing.Point(32, 58);
            this.widthTextBox.Name = "widthTextBox";
            this.widthTextBox.ReadOnly = true;
            this.widthTextBox.Size = new System.Drawing.Size(37, 20);
            this.widthTextBox.TabIndex = 22;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 13);
            this.label4.TabIndex = 26;
            this.label4.Text = "X:";
            // 
            // yTextBox
            // 
            this.yTextBox.Location = new System.Drawing.Point(99, 21);
            this.yTextBox.Name = "yTextBox";
            this.yTextBox.ReadOnly = true;
            this.yTextBox.Size = new System.Drawing.Size(37, 20);
            this.yTextBox.TabIndex = 21;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(78, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 13);
            this.label3.TabIndex = 25;
            this.label3.Text = "Y:";
            // 
            // xTextBox
            // 
            this.xTextBox.Location = new System.Drawing.Point(32, 21);
            this.xTextBox.Name = "xTextBox";
            this.xTextBox.ReadOnly = true;
            this.xTextBox.Size = new System.Drawing.Size(37, 20);
            this.xTextBox.TabIndex = 20;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = "X:";
            // 
            // coordinatesGroupBox
            // 
            this.coordinatesGroupBox.Controls.Add(this.label2);
            this.coordinatesGroupBox.Controls.Add(this.heightTextBox);
            this.coordinatesGroupBox.Controls.Add(this.xTextBox);
            this.coordinatesGroupBox.Controls.Add(this.label5);
            this.coordinatesGroupBox.Controls.Add(this.label3);
            this.coordinatesGroupBox.Controls.Add(this.widthTextBox);
            this.coordinatesGroupBox.Controls.Add(this.yTextBox);
            this.coordinatesGroupBox.Controls.Add(this.label4);
            this.coordinatesGroupBox.Location = new System.Drawing.Point(6, 56);
            this.coordinatesGroupBox.Name = "coordinatesGroupBox";
            this.coordinatesGroupBox.Size = new System.Drawing.Size(149, 91);
            this.coordinatesGroupBox.TabIndex = 28;
            this.coordinatesGroupBox.TabStop = false;
            this.coordinatesGroupBox.Text = "Image Loc | App Loc";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.coordinatesGroupBox);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Location = new System.Drawing.Point(366, 87);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(161, 157);
            this.groupBox1.TabIndex = 29;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Screenshot Infos";
            // 
            // CSelectDifficulty
            // 
            this.CSelectDifficulty.FormattingEnabled = true;
            this.CSelectDifficulty.Items.AddRange(new object[] {
            "Normal",
            "Hard",
            "Z-Hard",
            "Super",
            "Super2"});
            this.CSelectDifficulty.Location = new System.Drawing.Point(111, 58);
            this.CSelectDifficulty.Name = "CSelectDifficulty";
            this.CSelectDifficulty.Size = new System.Drawing.Size(121, 21);
            this.CSelectDifficulty.TabIndex = 30;
            this.CSelectDifficulty.Text = "Select Difficulty";
            // 
            // AutoRestoreACTCheck
            // 
            this.AutoRestoreACTCheck.AutoSize = true;
            this.AutoRestoreACTCheck.Location = new System.Drawing.Point(250, 42);
            this.AutoRestoreACTCheck.Name = "AutoRestoreACTCheck";
            this.AutoRestoreACTCheck.Size = new System.Drawing.Size(112, 17);
            this.AutoRestoreACTCheck.TabIndex = 31;
            this.AutoRestoreACTCheck.Text = "Auto Restore ACT";
            this.AutoRestoreACTCheck.UseVisualStyleBackColor = true;
            this.AutoRestoreACTCheck.CheckedChanged += new System.EventHandler(this.AutoRestoreACTCheck_CheckedChanged);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(272, 12);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(81, 26);
            this.button3.TabIndex = 32;
            this.button3.Text = "Stop";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // CSelectDice
            // 
            this.CSelectDice.DisplayMember = "1";
            this.CSelectDice.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "Random 1-3"});
            this.CSelectDice.Location = new System.Drawing.Point(110, 98);
            this.CSelectDice.Name = "CSelectDice";
            this.CSelectDice.Size = new System.Drawing.Size(121, 21);
            this.CSelectDice.TabIndex = 33;
            this.CSelectDice.Text = "Select Dice";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.DSRefillLbl);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.ResetInfoGame);
            this.groupBox2.Controls.Add(this.GameDoneLbl);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(28, 167);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(309, 67);
            this.groupBox2.TabIndex = 34;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Bot Info";
            // 
            // DSRefillLbl
            // 
            this.DSRefillLbl.AutoSize = true;
            this.DSRefillLbl.Location = new System.Drawing.Point(272, 24);
            this.DSRefillLbl.Name = "DSRefillLbl";
            this.DSRefillLbl.Size = new System.Drawing.Size(13, 13);
            this.DSRefillLbl.TabIndex = 35;
            this.DSRefillLbl.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(169, 24);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(97, 13);
            this.label8.TabIndex = 34;
            this.label8.Text = "DS Used for Refill :";
            // 
            // ResetInfoGame
            // 
            this.ResetInfoGame.Location = new System.Drawing.Point(94, 40);
            this.ResetInfoGame.Name = "ResetInfoGame";
            this.ResetInfoGame.Size = new System.Drawing.Size(119, 20);
            this.ResetInfoGame.TabIndex = 33;
            this.ResetInfoGame.Text = "Reset";
            this.ResetInfoGame.UseVisualStyleBackColor = true;
            this.ResetInfoGame.Click += new System.EventHandler(this.ResetInfoGame_Click);
            // 
            // GameDoneLbl
            // 
            this.GameDoneLbl.AutoSize = true;
            this.GameDoneLbl.Location = new System.Drawing.Point(87, 24);
            this.GameDoneLbl.Name = "GameDoneLbl";
            this.GameDoneLbl.Size = new System.Drawing.Size(13, 13);
            this.GameDoneLbl.TabIndex = 26;
            this.GameDoneLbl.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 25;
            this.label1.Text = "Game Done : ";
            // 
            // NbGame
            // 
            this.NbGame.Location = new System.Drawing.Point(272, 117);
            this.NbGame.Name = "NbGame";
            this.NbGame.Size = new System.Drawing.Size(65, 20);
            this.NbGame.TabIndex = 35;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(260, 101);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(86, 13);
            this.label7.TabIndex = 36;
            this.label7.Text = "Amount of Game";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(269, 58);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 13);
            this.label6.TabIndex = 38;
            this.label6.Text = "Limit Refill DS";
            // 
            // NbDS
            // 
            this.NbDS.Enabled = false;
            this.NbDS.Location = new System.Drawing.Point(272, 76);
            this.NbDS.Name = "NbDS";
            this.NbDS.Size = new System.Drawing.Size(65, 20);
            this.NbDS.TabIndex = 37;
            // 
            // EventBotLogs
            // 
            this.EventBotLogs.Location = new System.Drawing.Point(28, 240);
            this.EventBotLogs.Name = "EventBotLogs";
            this.EventBotLogs.Size = new System.Drawing.Size(309, 96);
            this.EventBotLogs.TabIndex = 39;
            this.EventBotLogs.Text = "";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(145, 43);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(47, 13);
            this.label9.TabIndex = 41;
            this.label9.Text = "Difficulty";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(152, 82);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(29, 13);
            this.label10.TabIndex = 42;
            this.label10.Text = "Dice";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(152, 122);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(29, 13);
            this.label11.TabIndex = 43;
            this.label11.Text = "Way";
            // 
            // CkWayT
            // 
            this.CkWayT.AutoSize = true;
            this.CkWayT.Location = new System.Drawing.Point(125, 144);
            this.CkWayT.Name = "CkWayT";
            this.CkWayT.Size = new System.Drawing.Size(45, 17);
            this.CkWayT.TabIndex = 44;
            this.CkWayT.Text = "Top";
            this.CkWayT.UseVisualStyleBackColor = true;
            // 
            // CkWayR
            // 
            this.CkWayR.AutoSize = true;
            this.CkWayR.Checked = true;
            this.CkWayR.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CkWayR.Location = new System.Drawing.Point(68, 144);
            this.CkWayR.Name = "CkWayR";
            this.CkWayR.Size = new System.Drawing.Size(51, 17);
            this.CkWayR.TabIndex = 45;
            this.CkWayR.Text = "Right";
            this.CkWayR.UseVisualStyleBackColor = true;
            // 
            // CkWayL
            // 
            this.CkWayL.AutoSize = true;
            this.CkWayL.Location = new System.Drawing.Point(176, 144);
            this.CkWayL.Name = "CkWayL";
            this.CkWayL.Size = new System.Drawing.Size(44, 17);
            this.CkWayL.TabIndex = 46;
            this.CkWayL.Text = "Left";
            this.CkWayL.UseVisualStyleBackColor = true;
            // 
            // CkWayD
            // 
            this.CkWayD.AutoSize = true;
            this.CkWayD.Location = new System.Drawing.Point(226, 144);
            this.CkWayD.Name = "CkWayD";
            this.CkWayD.Size = new System.Drawing.Size(54, 17);
            this.CkWayD.TabIndex = 47;
            this.CkWayD.Text = "Down";
            this.CkWayD.UseVisualStyleBackColor = true;
            // 
            // checkBoxTB
            // 
            this.checkBoxTB.AutoSize = true;
            this.checkBoxTB.Location = new System.Drawing.Point(28, 60);
            this.checkBoxTB.Name = "checkBoxTB";
            this.checkBoxTB.Size = new System.Drawing.Size(40, 17);
            this.checkBoxTB.TabIndex = 48;
            this.checkBoxTB.Text = "TB";
            this.checkBoxTB.UseVisualStyleBackColor = true;
            this.checkBoxTB.CheckedChanged += new System.EventHandler(this.checkBoxTB_CheckedChanged);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(343, 316);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(19, 20);
            this.button4.TabIndex = 49;
            this.button4.Text = "?";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(365, 348);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.checkBoxTB);
            this.Controls.Add(this.CkWayD);
            this.Controls.Add(this.CkWayL);
            this.Controls.Add(this.CkWayR);
            this.Controls.Add(this.CkWayT);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.EventBotLogs);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.NbDS);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.NbGame);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.CSelectDice);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.AutoRestoreACTCheck);
            this.Controls.Add(this.CSelectDifficulty);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "Form1";
            this.Text = "DBZ Dokkan Bottle";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.coordinatesGroupBox.ResumeLayout(false);
            this.coordinatesGroupBox.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NbGame)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NbDS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox heightTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox widthTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox yTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox xTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox coordinatesGroupBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox CSelectDifficulty;
        private System.Windows.Forms.CheckBox AutoRestoreACTCheck;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ComboBox CSelectDice;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button ResetInfoGame;
        private System.Windows.Forms.Label GameDoneLbl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown NbGame;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label DSRefillLbl;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown NbDS;
        private System.Windows.Forms.RichTextBox EventBotLogs;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.CheckBox CkWayT;
        private System.Windows.Forms.CheckBox CkWayR;
        private System.Windows.Forms.CheckBox CkWayL;
        private System.Windows.Forms.CheckBox CkWayD;
        private System.Windows.Forms.CheckBox checkBoxTB;
        private System.Windows.Forms.Button button4;
    }
}

