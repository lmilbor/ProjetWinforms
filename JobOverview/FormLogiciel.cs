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
    public partial class FormLogiciel : Form
    {
        private List<Logiciel> _listeLogiciels;
        public FormLogiciel()
        {
            InitializeComponent();
            cbLogiciel.SelectionChangeCommitted += CbLogiciel_SelectionChangeCommitted;
        }

        private void CbLogiciel_SelectionChangeCommitted(object sender, EventArgs e)
        {
            dgvVersion.DataSource = _listeLogiciels.Where(l => l.Nom == cbLogiciel.SelectedText).First().
                ListeVersions;
            dgvModule.DataSource = _listeLogiciels.Where(l => l.Nom == cbLogiciel.SelectedText).First().
                ListeModules;
        }

        protected override void OnLoad(EventArgs e)
        {
            TempData.ListeLogiciel = DALLogiciel.GetListLogiciel();
            _listeLogiciels = TempData.ListeLogiciel;
            cbLogiciel.DataSource = _listeLogiciels;
            cbLogiciel.DisplayMember = "Nom";
            cbLogiciel.ValueMember = "CodeLogiciel";
            dgvVersion.DataSource = _listeLogiciels.Where(l => l.CodeLogiciel == _listeLogiciels.First().CodeLogiciel).First().ListeVersions;
            dgvModule.DataSource = _listeLogiciels.Where(l => l.CodeLogiciel == _listeLogiciels.First().CodeLogiciel).First().ListeModules;
            base.OnLoad(e);
        }
    }
}
