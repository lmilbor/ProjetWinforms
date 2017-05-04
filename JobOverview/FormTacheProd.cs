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
            btnAjout.Click += BtnAjout_Click;
        }

        private void BtnAjout_Click(object sender, EventArgs e)
        {
            using (var form = new FormSaisieTacheProd())
            {
                DialogResult dr = form.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    form.TacheProd.Version = form.Version;
                    form.TacheProd.Logiciel = form.Logiciel;
                    form.TacheProd.Module = form.Module;
                    form.TacheProd.Activite = form.Activite;
                    _listePersonne.Where(b => b.Nom == (form.Pers.Nom).ToString()).FirstOrDefault().ListeTacheProd.Add(form.TacheProd);
                    MiseAJourForm();
                }
            }
        }

        private void CbPersonne_SelectionChangeCommitted(object sender, EventArgs e)
        {
            MiseAJourForm();
        }

        protected override void OnLoad(EventArgs e)
        {
            Temp = DALTache.GetListePersonne();
            _listeLogiciel = DALLogiciel.GetListLogiciel();
            cbLogiciel.DataSource = _listeLogiciel.Select(a => a.Nom).OrderBy(b => b).ToList();
            cbVersion.DataSource = _listeLogiciel.Where(a => a.Nom == (cbLogiciel.SelectedValue).ToString()).First()
                .ListeVersions.Select(b => b.NumeroVersion).OrderBy(c => c).ToList();
            cbPersonne.DataSource = _listePersonne.Select(a => a.Nom).OrderBy(b => b).Distinct().ToList();
            MiseAJourForm();
            base.OnLoad(e); 
        }

        public void MiseAJourForm()
        {
            dgvTacheProd.DataSource = _listePersonne.Where(a => a.Nom == (cbPersonne.SelectedValue).ToString()).First().ListeTacheProd
            .Where(b => (b.Logiciel.Nom == (cbLogiciel.SelectedValue).ToString()) && (b.Version.NumeroVersion == (float)cbVersion.SelectedValue)).ToList();

            dgvTacheProd.Columns["DureePrevue"].Visible = false;
            dgvTacheProd.Columns["DureeRestanteEstimee"].Visible = false;
            dgvTacheProd.Columns["Version"].Visible = false;
            dgvTacheProd.Columns["Logiciel"].Visible = false;
            dgvTacheProd.Columns["Module"].Visible = false;
            dgvTacheProd.Columns["Description"].Visible = false;
            dgvTacheProd.Columns["EstAnnexe"].Visible = false;
            dgvTacheProd.Columns["Activite"].Visible = false;
            dgvTacheProd.Columns["IdTache"].Visible = false;

            tbDescripTache.Text = (_listePersonne.Where(a => a.Nom == (cbPersonne.SelectedValue).ToString()).First()
                .ListeTacheProd.Select(b => b.Description)).FirstOrDefault();

        }
    }
}
