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
        public string Nom { get; set; }
        public FormSaisieVersion()
        {
            version = new Version();
            InitializeComponent();
            btnOK.Click += BtnOK_Click;
        }
        protected override void OnLoad(EventArgs e)
        {
            cbLogiciel.DataSource = TempData.ListeLogiciel;
            cbLogiciel.DisplayMember = "Nom";
            cbLogiciel.ValueMember = "CodeLogiciel";
            base.OnLoad(e);
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            Nom = cbLogiciel.Text;
            version.CodeLogiciel = cbLogiciel.SelectedValue.ToString();
            version.NumeroVersion = float.Parse(mtbNumVersion.Text);
            version.DateOuverture = DateTime.Parse(mtbDateOuverture.Text);
            version.DateSortiePrevue = DateTime.Parse(mtbDateSortie.Text);
            version.Millesime = short.Parse(mtbMillesime.Text);
        }
    }
}
