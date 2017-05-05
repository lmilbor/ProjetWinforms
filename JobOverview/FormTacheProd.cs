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
        private BindingList<Personne> _listePersonne;
        private BindingList<Logiciel> _listeLogiciel;
        private BindingList<TacheProd> _listeNouvelleTacheProd;
        #endregion

        public FormTacheProd()
        {
            InitializeComponent();
            cbPersonne.SelectionChangeCommitted += CbPersonne_SelectionChangeCommitted;
            btnAjout.Click += BtnAjout_Click;
            btnEnregistrer.Click += (object sender, EventArgs e) => DALTache.InsertTacheProd(_listeNouvelleTacheProd);
            dgvTacheProd.CellMouseClick += (object sender, DataGridViewCellMouseEventArgs e) => tbDescripTache.Text = (_listePersonne.Where(a => a.Nom == (cbPersonne.SelectedValue).ToString()).First()
                                                                                                .ListeTacheProd.Select(b => b.Description)).FirstOrDefault();
            _listeNouvelleTacheProd = new BindingList<TacheProd>();
        }


        private void BtnAjout_Click(object sender, EventArgs e)
        {

            using (var form = new FormSaisieTacheProd())
            {
                DialogResult dr = form.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    // Association des valeurs des combos box de la fenêtre modale à la liste de tache de production
                    form.TacheProd.Version = form.Version;
                    form.TacheProd.Logiciel = form.Logiciel;
                    form.TacheProd.Module = form.Module;
                    form.TacheProd.Activite = form.Activite;
                    form.TacheProd.Login = form.Pers.Login;
                    form.TacheProd.IdTache = new Guid();

                    // Ajout de la nouvelle tache dans la liste de la personne concernée
                    _listePersonne.Where(b => b.Nom == (form.Pers.Nom).ToString()).FirstOrDefault().ListeTacheProd.Add(form.TacheProd);
                    _listeNouvelleTacheProd.Add(form.TacheProd);
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
            // Initialisation des listes
            TempData.ListePersonne = DALTache.GetListePersonne();
            _listePersonne = TempData.ListePersonne;
            _listeLogiciel = DALLogiciel.GetListLogiciel();

            // Initialisation des combo box
            //Combo Box Logiciel
            cbLogiciel.DisplayMember = "Nom";
            cbLogiciel.ValueMember = "CodeLogiciel";
            cbLogiciel.DataSource = _listeLogiciel.OrderBy(b => b.Nom).ToList();

            //Combo Box Version
            cbVersion.DataSource = _listeLogiciel.Where(a => a.CodeLogiciel == cbLogiciel.SelectedValue.ToString()).First()
            .ListeVersions.Select(b => b.NumeroVersion).OrderBy(b => b).ToList();

            //Combo Box Personne
            cbPersonne.DisplayMember = "Nom";
            cbPersonne.ValueMember = "Login";
            cbPersonne.DataSource = _listePersonne.OrderBy(b => b.Nom).Distinct().ToList();

            MiseAJourForm();

            base.OnLoad(e);
        }

        /// <summary>
        /// Mise à jour des visuels dynamiques de la form.
        /// </summary>
        public void MiseAJourForm()
        {
            // Remploi la data grid view des taches de production
            dgvTacheProd.DataSource = _listePersonne.Where(a => a.Login == cbPersonne.SelectedValue.ToString()).First().ListeTacheProd
            .Where(b => (b.Logiciel.CodeLogiciel == cbLogiciel.SelectedValue.ToString()) && (b.Version.NumeroVersion == (float)cbVersion.SelectedValue)).ToList();

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
