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
        #region Champs Privés
        private List<TacheProd> _listeNouvelleTacheProd;
        #endregion

        public FormTacheProd()
        {
            InitializeComponent();
            cbPersonne.SelectionChangeCommitted += CbPersonne_SelectionChangeCommitted;
            btnAjout.Click += BtnAjout_Click;
            btnEnregistrer.Click += (object sender, EventArgs e) => DALTache.InsertTacheProd(_listeNouvelleTacheProd);
            dgvTacheProd.CellMouseClick += (object sender, DataGridViewCellMouseEventArgs e) => tbDescripTache.Text = ((TacheProd)dgvTacheProd.CurrentRow.DataBoundItem).Description;
            cbLogiciel.SelectionChangeCommitted += CbLogiciel_SelectionChangeCommitted;
            cbVersion.SelectionChangeCommitted += CbVersion_SelectionChangeCommitted;
        }

        private void CbVersion_SelectionChangeCommitted(object sender, EventArgs e)
        {
            MiseAJourForm();
        }

        private void CbLogiciel_SelectionChangeCommitted(object sender, EventArgs e)
        {
            MiseAJourForm();
        }

        private void BtnAjout_Click(object sender, EventArgs e)
        {

            using (var form = new FormSaisieTacheProd())
            {
                DialogResult dr = form.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    // Ajout de la nouvelle tache dans la liste de la personne concernée
                    _listeNouvelleTacheProd.Add(form.TacheProd);
                    TempData.ListePersonne.Where(p => p.Login == (form.TacheProd.Login).ToString()).FirstOrDefault().ListeTacheProd.Add(form.TacheProd);
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

            _listeNouvelleTacheProd = new List<TacheProd>();

            // Initialisation des combo box

            //Combo Box Personne
            cbPersonne.DisplayMember = "Nom";
            cbPersonne.ValueMember = "Login";
            cbPersonne.DataSource = TempData.ListePersonne.OrderBy(b => b.Nom).ToList();

            //Combo Box Logiciel
            cbLogiciel.DisplayMember = "Nom";
            cbLogiciel.ValueMember = "CodeLogiciel";
            cbLogiciel.DataSource = TempData.ListeLogiciel.OrderBy(b => b.Nom).ToList();

            //Combo Box Version
            cbVersion.DisplayMember = "Millesime";
            cbVersion.ValueMember = "NumeroVersion";
            cbVersion.DataSource = TempData.GetListeVersion(cbLogiciel.SelectedValue.ToString())
            .OrderBy(v => v.Millesime).ToList();

            MiseAJourForm();

            base.OnLoad(e);
        }

        /// <summary>
        /// Mise à jour des visuels dynamiques de la form.
        /// </summary>
        public void MiseAJourForm()
        {
            // Remploi la data grid view des taches de production
            dgvTacheProd.DataSource = TempData.GetListeTacheProd(cbPersonne.SelectedValue.ToString())
                                               .Where(tp => (tp.Logiciel.CodeLogiciel == cbLogiciel.SelectedValue.ToString())
                                               && (tp.Version.NumeroVersion == (float)cbVersion.SelectedValue)).ToList();
                                               
            // Rend invisible les colonnes non souhaitées
            dgvTacheProd.Columns["DureePrevue"].Visible = false;
            dgvTacheProd.Columns["DureeRestanteEstimee"].Visible = false;
            dgvTacheProd.Columns["Version"].Visible = false;
            dgvTacheProd.Columns["Logiciel"].Visible = false;
            dgvTacheProd.Columns["Module"].Visible = false;
            dgvTacheProd.Columns["Description"].Visible = false;
            dgvTacheProd.Columns["EstAnnexe"].Visible = false;
            dgvTacheProd.Columns["Activite"].Visible = false;
            dgvTacheProd.Columns["IdTache"].Visible = false;
            dgvTacheProd.Columns["Login"].Visible = false;
        }
    }
}
