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
        private BindingList<Logiciel> _listeLogiciels;
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
            DALLogiciel.RemoveVersion(_SupprimerVersion);
        }

        private void BtnNewVersion_Click(object sender, EventArgs e)
        {
            using (var form = new FormSaisieVersion())
            {
                form.ShowDialog();
                if (form.DialogResult.Equals(DialogResult.OK))
                {
                    _listeLogiciels.Where(l => l.Nom == form.Nom).First().ListeVersions.Add(form.version);
                    _AjouterVersion.Add(form.version);
                }
            }
        }
        private void BtnSupVersion_Click(object sender, EventArgs e)
        {
            Version version = (Version)(dgvVersion.CurrentRow.DataBoundItem);
            if (!_AjouterVersion.Contains<Version>(version))
            //{
            //    foreach (var personne in TempData.ListePersonne)
            //    {
            //        foreach (var tache in personne.ListeTacheProd)
            //        {
            //            if (!tache.Version.Equals(version))
            //            {
                            _SupprimerVersion.Add(version);
            //            }
            //        }
            //    }
            //}
            else
                _AjouterVersion.Remove(version);

            _listeLogiciels.Where(l => l.CodeLogiciel == cbLogiciel.SelectedValue.ToString()).First().ListeVersions.Remove(version);
        }

        private void CbLogiciel_SelectionChangeCommitted(object sender, EventArgs e)
        {
            dgvVersion.DataSource = _listeLogiciels.Where(l => l.CodeLogiciel == cbLogiciel.SelectedValue.ToString()).First().
                ListeVersions;
            dgvModule.DataSource = _listeLogiciels.Where(l => l.CodeLogiciel == cbLogiciel.SelectedValue.ToString()).First().
                ListeModules;
        }

        protected override void OnLoad(EventArgs e)
        {
            _AjouterVersion = new List<Version>();
            _SupprimerVersion = new List<Version>();
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
