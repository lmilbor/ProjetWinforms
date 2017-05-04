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
            InitializeComponent();
            btnOK.Click += BtnOK_Click;
        }
        protected override void OnLoad(EventArgs e)
        {
            cbLogiciel.DataSource = TempData.ListeLogiciel;
            cbLogiciel.DisplayMember = "Nom";
            cbLogiciel.ValueMember = "CodeLogiciel";
            lblresNumVersion.Text = (TempData.ListeLogiciel.Where( l => l.Nom == cbLogiciel.SelectedText).First().ListeVersions.Count + 1).ToString();
            base.OnLoad(e);
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            version.NumeroVersion = TempData.ListeLogiciel.Where(l => l.Nom == cbLogiciel.SelectedText).First().ListeVersions.Count + 1;

            version.Millesime = ;
        }
    }
}
