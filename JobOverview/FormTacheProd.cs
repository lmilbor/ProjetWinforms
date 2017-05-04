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
    public partial class FormTacheProd : Form
    {
        private BindingList<Personne> _listePersonne;
        private BindingList<Logiciel> _listeLogiciel;
        public FormTacheProd()
        {
            InitializeComponent();
            cbPersonne.SelectionChangeCommitted += CbPersonne_SelectionChangeCommitted;
            btnAjout.Click += (object sender, EventArgs e) =>  new FormSaisieTacheProd().ShowDialog();
        }

        private void CbPersonne_SelectionChangeCommitted(object sender, EventArgs e)
        {
            dgvTacheProd.DataSource = _listePersonne.Where(a => a.Nom == (cbPersonne.SelectedValue).ToString()).First().ListeTacheProd
                .Where(b => (b.Logiciel.Nom == (cbLogiciel.SelectedValue).ToString()) && (b.Version.NumeroVersion == (float)cbVersion.SelectedValue));

            tbDescripTache.Text = (_listePersonne.Where(a => a.Nom == (cbPersonne.SelectedValue).ToString()).First()
                .ListeTacheProd.Select(b => b.Description)).FirstOrDefault();
        }

        protected override void OnLoad(EventArgs e)
        {
            _listePersonne = DALTache.GetListePersonne();
            _listeLogiciel = DALLogiciel.GetListLogiciel();
            cbLogiciel.DataSource = _listeLogiciel.Select(a => a.Nom).OrderBy(b => b).ToList();
            cbVersion.DataSource = _listeLogiciel.Where(a => a.Nom == (cbLogiciel.SelectedValue).ToString()).First()
                .ListeVersions.Select(b => b.NumeroVersion).OrderBy(c => c).ToList();
            cbPersonne.DataSource = _listePersonne.Select(a => a.Nom).OrderBy(b => b).Distinct().ToList();
            dgvTacheProd.DataSource = _listePersonne.Where(a => a.Nom == (cbPersonne.SelectedValue).ToString()).First().ListeTacheProd;
            #region Rendre invisible certaine colonne
            dgvTacheProd.Columns[1].Visible = false;
            dgvTacheProd.Columns[2].Visible = false;
            dgvTacheProd.Columns[3].Visible = false;
            dgvTacheProd.Columns[4].Visible = false;
            dgvTacheProd.Columns[5].Visible = false;
            dgvTacheProd.Columns[6].Visible = false;
            dgvTacheProd.Columns[8].Visible = false;
            dgvTacheProd.Columns[9].Visible = false;
            dgvTacheProd.Columns[10].Visible = false; 
            #endregion
            base.OnLoad(e); 
        }
    }
}
