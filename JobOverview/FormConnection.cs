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
    public partial class FormConnexion : Form
    {
        public string ChaineDeConnexion { get; set; }
        public FormConnexion()
        {
            InitializeComponent();
        }
        protected override void OnClosing(CancelEventArgs e)
        {
            if (DialogResult.Equals(DialogResult.OK))
            {
                if (!string.IsNullOrWhiteSpace(tbConnection.Text))
                {
                    ChaineDeConnexion = tbConnection.Text;
                    Properties.Settings.Default.ConnectionStringJobOverview = tbConnection.Text;
                    Properties.Settings.Default.Save();
                    base.OnClosing(e);
                }
                else
                {
                    MessageBox.Show("Entrez une chaine de connexion avant de continuer.");
                }
            }
            else if (DialogResult.Equals(DialogResult.Abort))
                Application.Exit();
        }

        static public void ConnectionTestUnitaire(string chaineConnexion)
        {
            Properties.Settings.Default.ConnectionStringJobOverview = chaineConnexion;
        }
    }
}
