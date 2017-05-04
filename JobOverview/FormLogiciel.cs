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
            btnNewVersion.Click += BtnNewVersion_Click;
        }

        private void BtnNewVersion_Click(object sender, EventArgs e)
        {
            using (var form = new FormSaisieProduit())
            {
                form.ShowDialog();
                if (form.DialogResult.Equals(DialogResult.OK))
                {
                    _produitsAjoutés.Add(form.ProduitSaisi);
                    _listeProduit.Add(form.ProduitSaisi);

                }
            }
            using (var form = new FormConnexion())
            {
                form.ShowDialog();
            }
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
