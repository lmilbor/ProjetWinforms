﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace JobOverview
{
    public partial class MDIForm : Form
    {
        // Collection des fenêtres filles
        public Dictionary<string, Form> ChildForms { get; private set; }

        public MDIForm()
        {
            InitializeComponent();
            ChildForms = new Dictionary<string, Form>();

            menuLogiciel.Click += (object sender, EventArgs e) => ShowChild("JobOverview.FormLogiciel");
            menuTacheProd.Click += (object sender, EventArgs e) => ShowChild("JobOverview.FormTacheProd");
            menuTachesAnnexes.Click += (object sender, EventArgs e) => ShowChild("JobOverview.FormSaisieTacheAnnexe");
            menuVerifTemps.Click += (object sender, EventArgs e) => ShowChild("JobOverview.FormVerifTemps");

        }

        protected override void OnLoad(EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Properties.Settings.Default.ConnectionStringJobOverview))
            {
                using (var form = new FormConnexion())
                {
                    do
                    {
                        form.ShowDialog();
                    } while (string.IsNullOrWhiteSpace(form.ChaineDeConnexion) && !(form.DialogResult.Equals(DialogResult.Cancel)));
                }
            }
            else
            {
                var mb = MessageBox.Show("Voulez-vous entrer une nouvelle chaîne de connexion ?", "Connexion", MessageBoxButtons.YesNo);
                if (mb == DialogResult.Yes)
                {
                    using (var form = new FormConnexion())
                    {
                        do
                        {
                            form.ShowDialog();
                        } while (string.IsNullOrWhiteSpace(form.ChaineDeConnexion) && !(form.DialogResult.Equals(DialogResult.Cancel)));
                    }
                }
            }
            if (!(string.IsNullOrWhiteSpace(Properties.Settings.Default.ConnectionStringJobOverview)))
            {
                TempData.ListeLogiciel = DALLogiciel.GetListLogiciel();
                TempData.ListePersonne = DALTache.GetListePersonne();
                TempData.ListeActivite = DALTache.GetListeActivite();
                TempData.ListeModule = DALTache.GetListeModule();
            }
            base.OnLoad(e);
        }

        // Affichage d'une fenêtre fille
        private void ShowChild(string name)
        {
            // Dans la collection des fenêtres filles, on recherche une fenêtre
            // dont le nom correspond à celui passé en paramètre...
            this.SuspendLayout();   // On stope le rafraîchissement du visuel
            Form form;
            if (!ChildForms.TryGetValue(name, out form))
            {
                // Si on n'en a pas trouvé, on crée une instance de cette fenêtre
                Type t = Type.GetType(name);
                form = (Form)Activator.CreateInstance(t);
                form.Name = name;

                form.MdiParent = this;
                form.FormClosed += (object sender, FormClosedEventArgs e) => RemoveChild(form);
                form.MaximizeBox = false;
                form.MinimizeBox = false;
                form.Show();

                // on ajoute la fenêtre à la collection des fenêtres filles
                // et on crée un menu associé
                AddChild(form);
                menuWindows.Visible = true;
            }

            // On maximise la taille de la fenêtre
            form.Select();
            form.WindowState = FormWindowState.Maximized;
            this.ResumeLayout(); // Rafraîchit le visuel
        }

        // Ajoute une fenêtre fille et son entrée dans le menu Fenêtres
        private void AddChild(Form f)
        {
            ChildForms.Add(f.Name, f);
            var it = menuWindows.DropDownItems.Add(f.Text);
            it.Name = f.Name;
            it.Click += (object sender, EventArgs e) => ShowChild(it.Name);
        }


        // Supprime une fenêtre fille et son entrée dans le menu Fenêtres
        private void RemoveChild(Form f)
        {
            ChildForms.Remove(f.Name);
            menuWindows.DropDownItems.RemoveByKey(f.Name);
            if (ChildForms.Count == 0) menuWindows.Visible = false;
        }
    }
}
