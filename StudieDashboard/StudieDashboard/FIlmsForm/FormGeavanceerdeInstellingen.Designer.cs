namespace StudieDashboardForm {
    partial class FormGeavanceerdeInstellingen {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            groupBoxCursussen = new GroupBox();
            groupBox1 = new GroupBox();
            checkBoxStatusN = new CheckBox();
            checkBoxStatusO = new CheckBox();
            checkBoxStatusV = new CheckBox();
            checkBoxStatusT = new CheckBox();
            comboBoxSortCursussen = new ComboBox();
            checkBoxSortCursus = new CheckBox();
            groupBoxStudierichtingen = new GroupBox();
            checkBoxApplicatie = new CheckBox();
            checkBoxGame = new CheckBox();
            checkBoxWeb = new CheckBox();
            buttonBevestigen = new Button();
            buttonAnnuleren = new Button();
            groupBoxCursussen.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBoxStudierichtingen.SuspendLayout();
            SuspendLayout();
            // 
            // groupBoxCursussen
            // 
            groupBoxCursussen.Controls.Add(groupBox1);
            groupBoxCursussen.Controls.Add(comboBoxSortCursussen);
            groupBoxCursussen.Controls.Add(checkBoxSortCursus);
            groupBoxCursussen.Controls.Add(groupBoxStudierichtingen);
            groupBoxCursussen.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
            groupBoxCursussen.Location = new Point(12, 12);
            groupBoxCursussen.Name = "groupBoxCursussen";
            groupBoxCursussen.Size = new Size(377, 260);
            groupBoxCursussen.TabIndex = 10;
            groupBoxCursussen.TabStop = false;
            groupBoxCursussen.Text = "Cursussen Selecteren";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(checkBoxStatusN);
            groupBox1.Controls.Add(checkBoxStatusO);
            groupBox1.Controls.Add(checkBoxStatusV);
            groupBox1.Controls.Add(checkBoxStatusT);
            groupBox1.Location = new Point(14, 41);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(198, 121);
            groupBox1.TabIndex = 12;
            groupBox1.TabStop = false;
            groupBox1.Text = "Cursusstatus:";
            // 
            // checkBoxStatusN
            // 
            checkBoxStatusN.AutoSize = true;
            checkBoxStatusN.Location = new Point(16, 97);
            checkBoxStatusN.Name = "checkBoxStatusN";
            checkBoxStatusN.Size = new Size(154, 19);
            checkBoxStatusN.TabIndex = 3;
            checkBoxStatusN.Text = "Cursussen niet te volgen";
            checkBoxStatusN.UseVisualStyleBackColor = true;
            // 
            // checkBoxStatusO
            // 
            checkBoxStatusO.AutoSize = true;
            checkBoxStatusO.Location = new Point(16, 72);
            checkBoxStatusO.Name = "checkBoxStatusO";
            checkBoxStatusO.Size = new Size(150, 19);
            checkBoxStatusO.TabIndex = 2;
            checkBoxStatusO.Text = "Cursussen niet behaald";
            checkBoxStatusO.UseVisualStyleBackColor = true;
            // 
            // checkBoxStatusV
            // 
            checkBoxStatusV.AutoSize = true;
            checkBoxStatusV.Location = new Point(16, 47);
            checkBoxStatusV.Name = "checkBoxStatusV";
            checkBoxStatusV.Size = new Size(127, 19);
            checkBoxStatusV.TabIndex = 1;
            checkBoxStatusV.Text = "Cursussen Behaald";
            checkBoxStatusV.UseVisualStyleBackColor = true;
            // 
            // checkBoxStatusT
            // 
            checkBoxStatusT.AutoSize = true;
            checkBoxStatusT.Location = new Point(16, 22);
            checkBoxStatusT.Name = "checkBoxStatusT";
            checkBoxStatusT.Size = new Size(154, 19);
            checkBoxStatusT.TabIndex = 0;
            checkBoxStatusT.Text = "Cursussen nog te volgen";
            checkBoxStatusT.UseVisualStyleBackColor = true;
            // 
            // comboBoxSortCursussen
            // 
            comboBoxSortCursussen.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxSortCursussen.Enabled = false;
            comboBoxSortCursussen.FormattingEnabled = true;
            comboBoxSortCursussen.Items.AddRange(new object[] { "Categorie", "Naam", "Punten" });
            comboBoxSortCursussen.Location = new Point(102, 186);
            comboBoxSortCursussen.Name = "comboBoxSortCursussen";
            comboBoxSortCursussen.Size = new Size(163, 23);
            comboBoxSortCursussen.TabIndex = 2;
            // 
            // checkBoxSortCursus
            // 
            checkBoxSortCursus.AutoSize = true;
            checkBoxSortCursus.Location = new Point(15, 186);
            checkBoxSortCursus.Name = "checkBoxSortCursus";
            checkBoxSortCursus.Size = new Size(81, 19);
            checkBoxSortCursus.TabIndex = 7;
            checkBoxSortCursus.Text = "Sorteer op:";
            checkBoxSortCursus.UseVisualStyleBackColor = true;
            checkBoxSortCursus.CheckedChanged += CheckBoxSortCursus_CheckedChanged;
            // 
            // groupBoxStudierichtingen
            // 
            groupBoxStudierichtingen.Controls.Add(checkBoxApplicatie);
            groupBoxStudierichtingen.Controls.Add(checkBoxGame);
            groupBoxStudierichtingen.Controls.Add(checkBoxWeb);
            groupBoxStudierichtingen.Location = new Point(228, 41);
            groupBoxStudierichtingen.Name = "groupBoxStudierichtingen";
            groupBoxStudierichtingen.Size = new Size(121, 100);
            groupBoxStudierichtingen.TabIndex = 11;
            groupBoxStudierichtingen.TabStop = false;
            groupBoxStudierichtingen.Text = "Studierichtingen:";
            // 
            // checkBoxApplicatie
            // 
            checkBoxApplicatie.AutoSize = true;
            checkBoxApplicatie.Location = new Point(16, 22);
            checkBoxApplicatie.Name = "checkBoxApplicatie";
            checkBoxApplicatie.Size = new Size(79, 19);
            checkBoxApplicatie.TabIndex = 8;
            checkBoxApplicatie.Text = "Applicatie";
            checkBoxApplicatie.UseVisualStyleBackColor = true;
            // 
            // checkBoxGame
            // 
            checkBoxGame.AutoSize = true;
            checkBoxGame.Location = new Point(16, 72);
            checkBoxGame.Name = "checkBoxGame";
            checkBoxGame.Size = new Size(57, 19);
            checkBoxGame.TabIndex = 10;
            checkBoxGame.Text = "Game";
            checkBoxGame.UseVisualStyleBackColor = true;
            // 
            // checkBoxWeb
            // 
            checkBoxWeb.AutoSize = true;
            checkBoxWeb.Location = new Point(16, 47);
            checkBoxWeb.Name = "checkBoxWeb";
            checkBoxWeb.Size = new Size(50, 19);
            checkBoxWeb.TabIndex = 9;
            checkBoxWeb.Text = "Web";
            checkBoxWeb.UseVisualStyleBackColor = true;
            // 
            // buttonBevestigen
            // 
            buttonBevestigen.Location = new Point(229, 278);
            buttonBevestigen.Name = "buttonBevestigen";
            buttonBevestigen.Size = new Size(75, 23);
            buttonBevestigen.TabIndex = 11;
            buttonBevestigen.Text = "OK";
            buttonBevestigen.UseVisualStyleBackColor = true;
            buttonBevestigen.Click += ButtonBevestigen_Click;
            // 
            // buttonAnnuleren
            // 
            buttonAnnuleren.Location = new Point(310, 278);
            buttonAnnuleren.Name = "buttonAnnuleren";
            buttonAnnuleren.Size = new Size(75, 23);
            buttonAnnuleren.TabIndex = 12;
            buttonAnnuleren.Text = "Annuleren";
            buttonAnnuleren.UseVisualStyleBackColor = true;
            buttonAnnuleren.Click += ButtonAnnuleren_Click;
            // 
            // FormGeavanceerdeInstellingen
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(397, 309);
            Controls.Add(buttonAnnuleren);
            Controls.Add(buttonBevestigen);
            Controls.Add(groupBoxCursussen);
            Name = "FormGeavanceerdeInstellingen";
            Text = "Geavanceerde Instellingen";
            Load += FormGeavanceerdeInstellingen_Load;
            groupBoxCursussen.ResumeLayout(false);
            groupBoxCursussen.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBoxStudierichtingen.ResumeLayout(false);
            groupBoxStudierichtingen.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBoxCursussen;
        private ComboBox comboBoxSortCursussen;
        private CheckBox checkBoxSortCursus;
        private CheckBox checkBoxGame;
        private CheckBox checkBoxWeb;
        private CheckBox checkBoxApplicatie;
        private GroupBox groupBoxStudierichtingen;
        private Button buttonBevestigen;
        private GroupBox groupBox1;
        private CheckBox checkBoxStatusN;
        private CheckBox checkBoxStatusO;
        private CheckBox checkBoxStatusV;
        private CheckBox checkBoxStatusT;
        private Button buttonAnnuleren;
    }
}