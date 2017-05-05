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
        private List<Version> _AjouterVersion;
        private List<Version> _SupprimerVersion;
        public FormLogiciel()
        {
            InitializeComponent();
            cbLogiciel.SelectionChangeCommitted += CbLogiciel_SelectionChangeCommitted;
            btnNewVersion.Click += BtnNewVersion_Click;
            btnSupVersion.Click += BtnSupVersion_Click;
            btnEnregister.Click += BtnEnregister_Click;
        }

        private void BtnEnregister_Click(object sender, EventArgs e)
        {
            DALLogiciel.InsertVersion(_AjouterVersion);
            _AjouterVersion.Clear();
            DALLogiciel.RemoveVersion(_SupprimerVersion);
            _SupprimerVersion.Clear();
        }

        private void BtnNewVersion_Click(object sender, EventArgs e)
        {
            using (var form = new FormSaisieVersion())
            {
                form.ShowDialog();
                if (form.DialogResult.Equals(DialogResult.OK))
                {
                    TempData.ListeLogiciel.Where(l => l.CodeLogiciel == form.version.CodeLogiciel).First().ListeVersions.Add(form.version);
                    _AjouterVersion.Add(form.version);
                }
            }
        }
        private void BtnSupVersion_Click(object sender, EventArgs e)
        {
            Version version = (Version)(dgvVersion.CurrentRow.DataBoundItem);
            if (!(TempData.ListePersonne.Select(p => p.ListeTacheProd.Select(t => t.Version).Contains<Version>(version))).First())
            // Si aucune tache ne fait référence à la version à supprimer.
            {
                if (!(_AjouterVersion.Contains<Version>(version)))
                {
                    _SupprimerVersion.Add(version);
                }
                else
                {
                    _AjouterVersion.Remove(version);
                }

                TempData.ListeLogiciel.Where(l => l.CodeLogiciel == cbLogiciel.SelectedValue.ToString()).First().ListeVersions.Remove(version);
            }
            else
                MessageBox.Show("La version que vous souhaitez supprimer a encore une ou plusieurs taches de production liés");
        }

        private void CbLogiciel_SelectionChangeCommitted(object sender, EventArgs e)
        {
            dgvVersion.DataSource = TempData.ListeLogiciel.Where(l => l.CodeLogiciel == cbLogiciel.SelectedValue.ToString()).First().
                ListeVersions;
            dgvModule.DataSource = TempData.ListeLogiciel.Where(l => l.CodeLogiciel == cbLogiciel.SelectedValue.ToString()).First().
                ListeModules;
        }

        protected override void OnLoad(EventArgs e)
        {
            _AjouterVersion = new List<Version>();
            _SupprimerVersion = new List<Version>();
            cbLogiciel.DataSource = TempData.ListeLogiciel;
            cbLogiciel.DisplayMember = "Nom";
            cbLogiciel.ValueMember = "CodeLogiciel";
            dgvVersion.DataSource = TempData.ListeLogiciel.Where(l => l.CodeLogiciel == TempData.ListeLogiciel.First().CodeLogiciel).First().ListeVersions;
            dgvModule.DataSource = TempData.ListeLogiciel.Where(l => l.CodeLogiciel == TempData.ListeLogiciel.First().CodeLogiciel).First().ListeModules;
            base.OnLoad(e);
        }
    }
}
