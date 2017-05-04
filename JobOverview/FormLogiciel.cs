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
        }
        protected override void OnLoad(EventArgs e)
        {
            _listeLogiciels = DALLogiciel.GetListLogiciel();
            cbLogiciel.DataSource = _listeLogiciels;
            cbLogiciel.DisplayMember = "Nom";
            cbLogiciel.ValueMember = "CodeLogiciel";
            dgvVersion.DataSource = _listeLogiciels.Where( l => l.CodeLogiciel == cbLogiciel.SelectedText).First().ListeVersions.ToList();
            base.OnLoad(e);
        }
    }
}
