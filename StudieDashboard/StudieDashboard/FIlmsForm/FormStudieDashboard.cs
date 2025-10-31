using Database;
using StudieDashboardDatabase;
using StudieDashboardForm;


namespace CursusForm {
    public partial class FormStudieDashboard : Form {

        private bool geavanceerd;
        private List<string> cursusRichtingen = [];
        private List<char> cursusStatussen = [];



        public FormStudieDashboard() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            FillChart();
            comboBoxSortCursussen.SelectedIndex = 0;
            geavanceerd = false;
        }




        //INTERACTABLES
        private void ButtonGetCursussen_Click(object sender, EventArgs e) {

            List<Cursus> cursussen;
            string sortedBy = " ";

            if (!geavanceerd) {

                if (radioButtonCursussenT.Checked) {
                    cursusStatussen.Add('T');
                } else if (radioButtonCursussenO.Checked) {
                    cursusStatussen.Add('O');
                } else if (radioButtonCursussenV.Checked) {
                    cursusStatussen.Add('V');
                }

            }

            if (checkBoxSortCursus.Checked) {
                sortedBy = comboBoxSortCursussen.SelectedItem.ToString();
            }

            cursussen = DBConnectionBridge.GiveDataGridCorrectData(cursusStatussen, cursusRichtingen, checkBoxSortCursus.Checked, sortedBy, geavanceerd);
            cursusStatussen.Clear();
            cursusRichtingen.Clear();

            dataGridCursussen.DataSource = cursussen;

            FormatDataGridView();
            EnableSelectionButtons(true);
        }

        private void LabelGeavanceerd_Click(object sender, EventArgs e) {
            FormGeavanceerdeInstellingen form = new(this);
            form.Show();
        }

        public void CheckBoxSortCursussen_CheckedChanged(object sender, EventArgs e) {
            if (checkBoxSortCursus.Checked) {
                comboBoxSortCursussen.Enabled = true;
            } else {
                comboBoxSortCursussen.Enabled = false;
            }
        }




        //AUTOMATIC
        private void FillChart() {
            Dictionary<string, int> puntenData = DBConnectionBridge.GivePuntenData();
            chartPunten.Series["Punten"].Points[0].YValues[0] = puntenData["Behaalde Punten"];
            chartPunten.Series["Punten"].Points[1].YValues[0] = (puntenData["Punten Totaal"] - puntenData["Behaalde Punten"]);

        }


        private void FormatDataGridView() {
            dataGridCursussen.Columns["status"].Visible = false;

            dataGridCursussen.Columns["naam"].HeaderText = "Cursusnaam";
            dataGridCursussen.Columns["code"].HeaderText = "Cursuscode";
            dataGridCursussen.Columns["punten"].HeaderText = "Punten";
            dataGridCursussen.Columns["categorie"].HeaderText = "Categorie";

            dataGridCursussen.Columns["code"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridCursussen.Columns["punten"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridCursussen.Columns["categorie"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridCursussen.Columns["naam"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        public void EnableSelectionButtons(bool enable) {
            if(enable) {
                radioButtonCursussenO.Enabled = true;
                radioButtonCursussenT.Enabled = true;
                radioButtonCursussenV.Enabled = true;
                checkBoxSortCursus.Enabled = true;
            } else if(!enable) {
                radioButtonCursussenO.Enabled = false;
                radioButtonCursussenT.Enabled = false;
                radioButtonCursussenV.Enabled = false;
                checkBoxSortCursus.Enabled = false;
                comboBoxSortCursussen.Enabled = false;
            }
        }




        //SETTERS
        public void SetCursusRichtingen(List<string> richtingen) {
            this.cursusRichtingen = richtingen;
        }
        public void SetCursusStatussen(List<char> statussen) {
            this.cursusStatussen = statussen;
        }


        public void SetGeavanceerd(bool geavanceerd) {
            this.geavanceerd = geavanceerd;
        }
        public void SetRadioButtonCursussenT(bool isChecked) {
            radioButtonCursussenT.Checked = isChecked;
        }
        public void SetRadioButtonCursussenV(bool isChecked) {
            radioButtonCursussenV.Checked = isChecked;
        }
        public void SetRadioButtonCursussenO(bool isChecked) {
            radioButtonCursussenO.Checked = isChecked;
        }
        public void SetCheckBoxSortCursussen(bool isChecked) {
            checkBoxSortCursus.Checked = isChecked;
        }
        public void SetComboBoxSortCursussen(int index) {
            comboBoxSortCursussen.SelectedIndex = index;
        }
    }
}
