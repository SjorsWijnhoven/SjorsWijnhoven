namespace CursusForm {
    partial class FormStudieDashboard {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint3 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 10D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint4 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 5D);
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            button1 = new Button();
            buttonGetCursussen = new Button();
            comboBoxSortCursussen = new ComboBox();
            dataGridCursussen = new DataGridView();
            radioButtonCursussenO = new RadioButton();
            radioButtonCursussenT = new RadioButton();
            radioButtonCursussenV = new RadioButton();
            checkBoxSortCursus = new CheckBox();
            mySqlCommand1 = new MySql.Data.MySqlClient.MySqlCommand();
            mySqlCommand2 = new MySql.Data.MySqlClient.MySqlCommand();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            chartPunten = new System.Windows.Forms.DataVisualization.Charting.Chart();
            groupBoxCursussen = new GroupBox();
            labelGeavanceerd = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridCursussen).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chartPunten).BeginInit();
            groupBoxCursussen.SuspendLayout();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(0, 0);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 0;
            // 
            // buttonGetCursussen
            // 
            buttonGetCursussen.BackColor = Color.DarkOrchid;
            buttonGetCursussen.Cursor = Cursors.Hand;
            buttonGetCursussen.Font = new Font("Segoe UI", 12F, FontStyle.Bold | FontStyle.Italic);
            buttonGetCursussen.ForeColor = Color.White;
            buttonGetCursussen.Location = new Point(655, 184);
            buttonGetCursussen.Name = "buttonGetCursussen";
            buttonGetCursussen.Size = new Size(147, 42);
            buttonGetCursussen.TabIndex = 0;
            buttonGetCursussen.Text = "Geef Cursussen";
            buttonGetCursussen.UseVisualStyleBackColor = false;
            buttonGetCursussen.Click += ButtonGetCursussen_Click;
            // 
            // comboBoxSortCursussen
            // 
            comboBoxSortCursussen.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxSortCursussen.Enabled = false;
            comboBoxSortCursussen.FormattingEnabled = true;
            comboBoxSortCursussen.Items.AddRange(new object[] { "Categorie", "Naam", "Punten" });
            comboBoxSortCursussen.Location = new Point(279, 59);
            comboBoxSortCursussen.Name = "comboBoxSortCursussen";
            comboBoxSortCursussen.Size = new Size(163, 23);
            comboBoxSortCursussen.TabIndex = 2;
            // 
            // dataGridCursussen
            // 
            dataGridCursussen.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridCursussen.Location = new Point(12, 249);
            dataGridCursussen.Name = "dataGridCursussen";
            dataGridCursussen.Size = new Size(811, 287);
            dataGridCursussen.TabIndex = 3;
            // 
            // radioButtonCursussenO
            // 
            radioButtonCursussenO.AutoSize = true;
            radioButtonCursussenO.Location = new Point(23, 113);
            radioButtonCursussenO.Name = "radioButtonCursussenO";
            radioButtonCursussenO.Size = new Size(149, 19);
            radioButtonCursussenO.TabIndex = 4;
            radioButtonCursussenO.Text = "Cursussen niet behaald";
            radioButtonCursussenO.UseVisualStyleBackColor = true;
            // 
            // radioButtonCursussenT
            // 
            radioButtonCursussenT.AutoSize = true;
            radioButtonCursussenT.Checked = true;
            radioButtonCursussenT.Location = new Point(23, 63);
            radioButtonCursussenT.Name = "radioButtonCursussenT";
            radioButtonCursussenT.Size = new Size(153, 19);
            radioButtonCursussenT.TabIndex = 5;
            radioButtonCursussenT.TabStop = true;
            radioButtonCursussenT.Text = "Cursussen nog te volgen";
            radioButtonCursussenT.UseVisualStyleBackColor = true;
            // 
            // radioButtonCursussenV
            // 
            radioButtonCursussenV.AutoSize = true;
            radioButtonCursussenV.Location = new Point(23, 88);
            radioButtonCursussenV.Name = "radioButtonCursussenV";
            radioButtonCursussenV.Size = new Size(126, 19);
            radioButtonCursussenV.TabIndex = 6;
            radioButtonCursussenV.Text = "Cursussen behaald";
            radioButtonCursussenV.UseVisualStyleBackColor = true;
            // 
            // checkBoxSortCursus
            // 
            checkBoxSortCursus.AutoSize = true;
            checkBoxSortCursus.Location = new Point(191, 61);
            checkBoxSortCursus.Name = "checkBoxSortCursus";
            checkBoxSortCursus.Size = new Size(81, 19);
            checkBoxSortCursus.TabIndex = 7;
            checkBoxSortCursus.Text = "Sorteer op:";
            checkBoxSortCursus.UseVisualStyleBackColor = true;
            checkBoxSortCursus.CheckedChanged += CheckBoxSortCursussen_CheckedChanged;
            // 
            // mySqlCommand1
            // 
            mySqlCommand1.CacheAge = 0;
            mySqlCommand1.Connection = null;
            mySqlCommand1.EnableCaching = false;
            mySqlCommand1.Transaction = null;
            // 
            // mySqlCommand2
            // 
            mySqlCommand2.CacheAge = 0;
            mySqlCommand2.Connection = null;
            mySqlCommand2.EnableCaching = false;
            mySqlCommand2.Transaction = null;
            // 
            // chartPunten
            // 
            chartPunten.BackColor = SystemColors.Control;
            chartPunten.BorderlineColor = SystemColors.Control;
            chartArea2.BackColor = SystemColors.Control;
            chartArea2.Name = "chartArea";
            chartPunten.ChartAreas.Add(chartArea2);
            legend2.BackColor = SystemColors.Control;
            legend2.IsTextAutoFit = false;
            legend2.LegendStyle = System.Windows.Forms.DataVisualization.Charting.LegendStyle.Column;
            legend2.Name = "Legend";
            chartPunten.Legends.Add(legend2);
            chartPunten.Location = new Point(12, 12);
            chartPunten.Name = "chartPunten";
            series2.ChartArea = "chartArea";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series2.CustomProperties = "PieStartAngle=270";
            series2.Legend = "Legend";
            series2.Name = "Punten";
            dataPoint3.AxisLabel = "";
            dataPoint3.Color = Color.DarkOrchid;
            dataPoint3.IsValueShownAsLabel = true;
            dataPoint3.IsVisibleInLegend = true;
            dataPoint3.Label = "#VALY";
            dataPoint3.LabelToolTip = "";
            dataPoint3.LegendText = "Behaald";
            dataPoint3.LegendToolTip = "";
            dataPoint4.BorderWidth = 1;
            dataPoint4.Color = SystemColors.ControlDark;
            dataPoint4.IsValueShownAsLabel = true;
            dataPoint4.IsVisibleInLegend = true;
            dataPoint4.Label = "#VALY";
            dataPoint4.LegendText = "Te Behalen";
            series2.Points.Add(dataPoint3);
            series2.Points.Add(dataPoint4);
            chartPunten.Series.Add(series2);
            chartPunten.Size = new Size(341, 214);
            chartPunten.TabIndex = 8;
            chartPunten.Text = "Behaalde Punten";
            title2.BackColor = SystemColors.Control;
            title2.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Italic, GraphicsUnit.Point, 0);
            title2.Name = "graphTitle";
            title2.Text = "Behaalde Punten";
            chartPunten.Titles.Add(title2);
            // 
            // groupBoxCursussen
            // 
            groupBoxCursussen.Controls.Add(labelGeavanceerd);
            groupBoxCursussen.Controls.Add(radioButtonCursussenV);
            groupBoxCursussen.Controls.Add(comboBoxSortCursussen);
            groupBoxCursussen.Controls.Add(radioButtonCursussenT);
            groupBoxCursussen.Controls.Add(radioButtonCursussenO);
            groupBoxCursussen.Controls.Add(checkBoxSortCursus);
            groupBoxCursussen.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
            groupBoxCursussen.Location = new Point(361, 12);
            groupBoxCursussen.Name = "groupBoxCursussen";
            groupBoxCursussen.Size = new Size(462, 231);
            groupBoxCursussen.TabIndex = 9;
            groupBoxCursussen.TabStop = false;
            groupBoxCursussen.Text = "Cursussen Selecteren";
            // 
            // labelGeavanceerd
            // 
            labelGeavanceerd.AutoSize = true;
            labelGeavanceerd.Cursor = Cursors.Hand;
            labelGeavanceerd.Font = new Font("Segoe UI", 9F, FontStyle.Italic | FontStyle.Underline);
            labelGeavanceerd.ForeColor = SystemColors.MenuHighlight;
            labelGeavanceerd.Location = new Point(23, 199);
            labelGeavanceerd.Name = "labelGeavanceerd";
            labelGeavanceerd.Size = new Size(155, 15);
            labelGeavanceerd.TabIndex = 8;
            labelGeavanceerd.Text = "Geavanceerde Instellingen...";
            labelGeavanceerd.Click += LabelGeavanceerd_Click;
            // 
            // FormStudieDashboard
            // 
            ClientSize = new Size(835, 548);
            Controls.Add(chartPunten);
            Controls.Add(dataGridCursussen);
            Controls.Add(buttonGetCursussen);
            Controls.Add(groupBoxCursussen);
            ImeMode = ImeMode.Disable;
            Name = "FormStudieDashboard";
            Text = "Studie Dashboard";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridCursussen).EndInit();
            ((System.ComponentModel.ISupportInitialize)chartPunten).EndInit();
            groupBoxCursussen.ResumeLayout(false);
            groupBoxCursussen.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private Button buttonGetCursussen;
        private ComboBox comboBoxSortCursussen;
        private DataGridView dataGridCursussen;
        private RadioButton radioButtonCursussenO;
        private RadioButton radioButtonCursussenT;
        private RadioButton radioButtonCursussenV;
        private CheckBox checkBoxSortCursus;
        private MySql.Data.MySqlClient.MySqlCommand mySqlCommand1;
        private MySql.Data.MySqlClient.MySqlCommand mySqlCommand2;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartPunten;
        private GroupBox groupBoxCursussen;
        private Label labelGeavanceerd;
    }
}
