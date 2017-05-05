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
        public string CahineDeConnexion { get; set; }
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
                    CahineDeConnexion = tbConnection.Text;
                    Properties.Settings.Default.ConnectionStringJobOverview = tbConnection.Text;

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
    }
}
