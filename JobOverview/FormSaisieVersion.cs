using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JobOverview
{
    public partial class FormSaisieVersion : Form
    {
        public Version version { get; set; }
        public FormSaisieVersion()
        {
            version = new Version();
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            cbLogiciel.DataSource = TempData.ListeLogiciel;
            cbLogiciel.DisplayMember = "Nom";
            cbLogiciel.ValueMember = "CodeLogiciel";
            base.OnLoad(e);
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            try
            {
                if (DialogResult == DialogResult.OK)
                {
                    if (!string.IsNullOrWhiteSpace(cbLogiciel.Text))
                        version.CodeLogiciel = cbLogiciel.SelectedValue.ToString();
                    else
                        throw new ArgumentNullException();

                    string tempString = mtbNumVersion.Text.Replace(",", "");
                    if (!string.IsNullOrWhiteSpace(tempString))
                        version.NumeroVersion = float.Parse(mtbNumVersion.Text);
                    else
                        throw new ArgumentNullException();

                    tempString = mtbDateOuverture.Text.Replace("/", "");
                    if (!string.IsNullOrWhiteSpace(tempString))
                        version.DateOuverture = DateTime.Parse(mtbDateOuverture.Text);
                    else
                        throw new ArgumentNullException();

                    tempString = mtbDateSortie.Text.Replace("/", "");
                    if (!string.IsNullOrWhiteSpace(tempString))
                        version.DateSortiePrevue = DateTime.Parse(mtbDateSortie.Text);
                    else
                        throw new ArgumentNullException();

                    if (!string.IsNullOrWhiteSpace(mtbMillesime.Text))
                        version.Millesime = short.Parse(mtbMillesime.Text);
                    else
                        throw new ArgumentNullException(); 
                }
            }
            catch (ArgumentNullException)
            {
                MessageBox.Show("Veuillez remplir tous les champs.");
                e.Cancel = true;
            }
            base.OnClosing(e);
        }
    }
}
