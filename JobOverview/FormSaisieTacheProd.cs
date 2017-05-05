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
    public partial class FormSaisieTacheProd : Form
    {

        #region Champs privés
        private BindingList<Logiciel> _listeLogiciel;
        private BindingList<Personne> _listePersonne;
        private BindingList<Activité> _listeActiviteProd;
        private BindingList<Module> _listeModule;
        #endregion

        #region Propriétés public
        public TacheProd TacheProd { get; set; }
        public Version Version { get; set; }
        public Logiciel Logiciel { get; set; }
        public Module Module { get; set; }
        public Activité Activite { get; set; }
        public Personne Pers { get; set; } 
        #endregion


        public FormSaisieTacheProd()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            //Initialisation des listes
            _listePersonne = DALTache.GetListePersonne();
            _listeLogiciel = DALLogiciel.GetListLogiciel();
            _listeActiviteProd = new BindingList<Activité>(DALTache.GetListeActivite().Where(a => a.EstAnnexe == false).ToList());
            _listeModule = DALTache.GetListeModule();

            //Alimentation des ComboBox
            //Combo Box Logiciel
            cbLogiciel.DisplayMember = "Nom";
            cbLogiciel.ValueMember = "CodeLogiciel";
            cbLogiciel.DataSource = _listeLogiciel.OrderBy(b => b.Nom).ToList();

            //Combo Box Version
            cbVersion.DataSource = _listeLogiciel.Where(a => a.CodeLogiciel == cbLogiciel.SelectedValue.ToString()).First()
            .ListeVersions.Select(b => b.NumeroVersion).OrderBy(b => b).ToList();

            //Combo Box Activité
            cbActivite.DisplayMember = "Libelle";
            cbActivite.ValueMember = "CodeActivite";
            cbActivite.DataSource = _listeActiviteProd.OrderBy(b => b.Libelle).ToList();

            //Combo Box Module
            cbModule.DisplayMember = "Libellé";
            cbModule.ValueMember = "CodeModule";
            cbModule.DataSource = _listeModule.OrderBy(b => b.Libellé).ToList();

            //Combo Box Personne
            cbPersonne.DisplayMember = "Nom";
            cbPersonne.ValueMember = "Login";
            cbPersonne.DataSource = _listePersonne.OrderBy(b => b.Nom).Distinct().ToList();

            base.OnLoad(e); 
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if (DialogResult == DialogResult.OK)
            {

                // Initialisation des propriétées
                TacheProd = new TacheProd();
                Activite = new Activité();
                Module = new Module();
                Version = new Version();
                Logiciel = new Logiciel();
                Pers = new Personne();
                TacheProd.IdTache = new Guid();

                try
                {
                    // Renseignement de chaque champs des taches de production
                    if (!string.IsNullOrWhiteSpace(rtbDescription.Text))
                        TacheProd.Description = rtbDescription.Text;

                    string tempString = mtbDureePrevue.Text.Replace(",", "");
                    if (!string.IsNullOrWhiteSpace(tempString))
                        TacheProd.DureePrevue = float.Parse(mtbDureePrevue.Text);
                    else
                        throw new FormatException();

                    tempString = mtbDureeRestante.Text.Replace(",", "");
                    if (!string.IsNullOrWhiteSpace(tempString))
                        TacheProd.DureeRestanteEstimee = float.Parse(mtbDureeRestante.Text);
                    else
                        throw new FormatException();

                    if (!string.IsNullOrWhiteSpace(tbLibelle.Text))
                        TacheProd.Libelle = tbLibelle.Text;
                    else
                        throw new FormatException();

                    if (!string.IsNullOrWhiteSpace(mtbNumero.Text))
                        TacheProd.Numero = int.Parse(mtbNumero.Text);
                    else
                        throw new FormatException();

            Pers.Nom = cbPersonne.Text;
            Activite.Libelle = cbActivite.Text;
            Activite.Annexe = false;
            Module.Libellé = cbModule.Text;
            Version.NumeroVersion = float.Parse(cbVersion.Text);
            Logiciel.Nom = cbLogiciel.Text;

            }
            base.OnClosing(e);
        }

    }
}
