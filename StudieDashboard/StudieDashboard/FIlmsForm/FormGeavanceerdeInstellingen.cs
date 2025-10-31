using CursusForm;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudieDashboardForm {
    public partial class FormGeavanceerdeInstellingen : Form {

        private FormStudieDashboard studieDashboard;

        public FormGeavanceerdeInstellingen(FormStudieDashboard studieDashboard) {
            InitializeComponent();
            this.studieDashboard = studieDashboard;
        }

        private void FormGeavanceerdeInstellingen_Load(object sender, EventArgs e) {
            comboBoxSortCursussen.SelectedIndex = 0;
        }




        //INTERACTABLES
        private void ButtonBevestigen_Click(object sender, EventArgs e) {
            bool geavanceerd;

            List<string> richtingen = new();
            List<char> statussen = new();

            // Selecteer de studierichtingen
            if (checkBoxApplicatie.Checked) {
                richtingen.Add("Applicatie");
            }
            if (checkBoxWeb.Checked) {
                richtingen.Add("Web");
            }
            if (checkBoxGame.Checked) {
                richtingen.Add("Game");
            }

            // Selecteer de statussen
            if (checkBoxStatusT.Checked) {
                statussen.Add('T');
            }
            if (checkBoxStatusV.Checked) {
                statussen.Add('V');
            }
            if (checkBoxStatusO.Checked) {
                statussen.Add('O');
            }
            if (checkBoxStatusN.Checked) {
                statussen.Add('N');
            }


            
            if (richtingen.IsNullOrEmpty() && (statussen.IsNullOrEmpty())) {
                geavanceerd = false;
            } else {
                geavanceerd = true;
            }

            studieDashboard.SetGeavanceerd(geavanceerd);
            studieDashboard.SetCheckBoxSortCursussen(checkBoxSortCursus.Checked);
            studieDashboard.SetComboBoxSortCursussen(comboBoxSortCursussen.SelectedIndex);
            studieDashboard.EnableSelectionButtons(!geavanceerd);

            studieDashboard.SetCursusStatussen(statussen);
            studieDashboard.SetCursusRichtingen(richtingen);

            this.Close();
        }
        private void ButtonAnnuleren_Click(object sender, EventArgs e) {
            this.Close();
        }




        //AUTOMATIC
        private void CheckBoxSortCursus_CheckedChanged(object sender, EventArgs e) {
            if (checkBoxSortCursus.Checked) {
                comboBoxSortCursussen.Enabled = true;
            } else {
                comboBoxSortCursussen.Enabled = false;
            }
        }

    }
}
