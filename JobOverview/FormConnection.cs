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
    public partial class FormConnexion : Form
    {
        public FormConnexion()
        {
            InitializeComponent();
        }
        protected override void OnClosing(CancelEventArgs e)
        {
            if (DialogResult.Equals(DialogResult.OK))
            {
                Properties.Settings.Default.ConnectionStringJobOverview = tbConnection.Text;
            }
            base.OnClosing(e);
        }
    }
}