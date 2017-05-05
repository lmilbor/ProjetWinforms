﻿using System;
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
            cbLogiciel.DataSource = _listeLogiciel.Select(a => a.Nom).OrderBy(b => b).ToList();
            cbVersion.DataSource = _listeLogiciel.Where(a => a.Nom == (cbLogiciel.SelectedValue).ToString()).First()
               .ListeVersions.Select(b => b.NumeroVersion).OrderBy(c => c).ToList();
            cbActivite.DataSource = _listeActiviteProd.Select(a => a.Libelle).ToList();
            cbModule.DataSource = _listeModule.Select(a => a.Libellé).ToList();
            cbPersonne.DataSource = _listePersonne.Select(a => a.Nom).OrderBy(b => b).Distinct().ToList();

            base.OnLoad(e); 
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            // Initialisation des propriétées
            TacheProd = new TacheProd();
            Activite = new Activité();
            Module = new Module();
            Version = new Version();
            Logiciel = new Logiciel();
            TacheProd.IdTache = new Guid();

            // Renseignement de chaque champs des taches de production
            if(!string.IsNullOrWhiteSpace(rtbDescription.Text))
                TacheProd.Description = rtbDescription.Text;

            string tempString = mtbDureePrevue.Text.Replace(",", "");
            if (!string.IsNullOrWhiteSpace(tempString))
                TacheProd.DureePrevue = float.Parse(mtbDureePrevue.Text);
            else
                MessageBox.Show("Le champs Durée Prévue ne peut pas rester vide");

            tempString = mtbDureeRestante.Text.Replace(",", "");
            if (!string.IsNullOrWhiteSpace(tempString))
                TacheProd.DureeRestanteEstimee = float.Parse(mtbDureeRestante.Text);
            else
                MessageBox.Show("Le champs Durée Restante Estimée ne peut pas rester vide");

            if (!string.IsNullOrWhiteSpace(tbLibelle.Text))
                TacheProd.Libelle = tbLibelle.Text;
            else
                MessageBox.Show("Le champs Libellé ne peut pas rester vide");

            if (!string.IsNullOrWhiteSpace(mtbNumero.Text))
                TacheProd.Numero = int.Parse(mtbNumero.Text);
            else
                MessageBox.Show("Le champs Numéro ne peut pas rester vide");

            Pers.Nom = cbPersonne.Text;
            Activite.Libelle = cbActivite.Text;
            Activite.EstAnnexe = false;
            Module.Libellé = cbModule.Text;
            Version.NumeroVersion = float.Parse(cbVersion.Text);
            Logiciel.Nom = cbLogiciel.Text;

            base.OnClosing(e);
        }

    }
}
