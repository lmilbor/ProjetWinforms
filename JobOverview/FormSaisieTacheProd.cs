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
        private List<Logiciel> _listeLogiciel;
        private List<Personne> _listePersonne;
        public FormSaisieTacheProd()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            //Initialisation des listes
            _listePersonne = DALTache.GetListePersonne();
            _listeLogiciel = DALLogiciel.GetListLogiciel();

            //Alimentation des ComboBox
            cbLogiciel.DataSource = _listeLogiciel.Select(a => a.Nom).OrderBy(b => b).ToList();
            cbVersion.DataSource = _listeLogiciel.Where(a => a.Nom == (cbLogiciel.SelectedValue).ToString()).First()
               .ListeVersions.Select(b => b.NumeroVersion).OrderBy(c => c).ToList();
            base.OnLoad(e); 
        }

    }
}
