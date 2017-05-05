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
        #region Propriétés public
        public TacheProd TacheProd { get; set; }
        #endregion


        public FormSaisieTacheProd()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {

            //Alimentation des ComboBox
            //Combo Box Logiciel
            cbLogiciel.DisplayMember = "Nom";
            cbLogiciel.ValueMember = "CodeLogiciel";
            cbLogiciel.DataSource = TempData.ListeLogiciel.OrderBy(b => b.Nom).ToList();

            //Combo Box Version
            cbVersion.DataSource = TempData.ListeLogiciel.Where(a => a.CodeLogiciel == cbLogiciel.SelectedValue.ToString()).First()
            .ListeVersions.Select(b => b.NumeroVersion).OrderBy(b => b).ToList();

            //Combo Box Activité
            cbActivite.DisplayMember = "Libelle";
            cbActivite.ValueMember = "CodeActivite";
            cbActivite.DataSource = TempData.ListeActivite.Where( a => !(a.EstAnnexe)).OrderBy(b => b.Libelle).ToList();

            //Combo Box Module
            cbModule.DisplayMember = "Libellé";
            cbModule.ValueMember = "CodeModule";
            cbModule.DataSource = TempData.ListeLogiciel.Select( l => l.ListeModules).OrderBy(m => m.Select(l => l.Libellé)).ToList();

            //Combo Box Personne
            cbPersonne.DisplayMember = "Nom";
            cbPersonne.ValueMember = "Login";
            cbPersonne.DataSource = TempData.ListePersonne.OrderBy(b => b.Nom).ToList();

            base.OnLoad(e); 
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if (DialogResult == DialogResult.OK)
            {

                // Initialisation des propriétées
                TacheProd = new TacheProd();
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

                    TacheProd.Logiciel = TempData.ListeLogiciel.Where(l => l.CodeLogiciel == cbLogiciel.SelectedValue.ToString()).First();
                    TacheProd.Module = TempData.ListeLogiciel.Where(l => l.CodeLogiciel == cbLogiciel.SelectedValue.ToString()).First().ListeModules.Where( m => m.CodeModule == cbModule.SelectedValue.ToString()).FirstOrDefault();
                    TacheProd.Version = TempData.ListeLogiciel.Where(l => l.CodeLogiciel == cbLogiciel.SelectedValue.ToString()).First().ListeVersions.Where(v => v.NumeroVersion == ((float)cbVersion.SelectedValue)).FirstOrDefault();
                    TacheProd.Login = TempData.ListePersonne.Where( p => p.Login == cbPersonne.SelectedValue.ToString()).Select( p => p.Login).FirstOrDefault();
                    TacheProd.Activite = TempData.ListeActivite.Where(a => a.CodeActivite == cbActivite.SelectedValue.ToString()).FirstOrDefault();
                }
                catch (FormatException)
                {
                    MessageBox.Show("Veuillez remplir tous les champs. Seul le champ description est falcultatif.");
                    e.Cancel = true;
                }

            }
            base.OnClosing(e);
        }

    }
}
