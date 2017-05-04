namespace JobOverview
{
    partial class FormTacheProd
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cbPersonne = new System.Windows.Forms.ComboBox();
            this.cbLogiciel = new System.Windows.Forms.ComboBox();
            this.cbVersion = new System.Windows.Forms.ComboBox();
            this.btnAjout = new System.Windows.Forms.Button();
            this.dgvTacheProd = new System.Windows.Forms.DataGridView();
            this.tbDescripTache = new System.Windows.Forms.TextBox();
            this.btnEnregistrer = new System.Windows.Forms.Button();
            this.lblPersonne = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblDescrip = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTacheProd)).BeginInit();
            this.SuspendLayout();
            // 
            // cbPersonne
            // 
            this.cbPersonne.FormattingEnabled = true;
            this.cbPersonne.Location = new System.Drawing.Point(12, 29);
            this.cbPersonne.Name = "cbPersonne";
            this.cbPersonne.Size = new System.Drawing.Size(121, 21);
            this.cbPersonne.TabIndex = 0;
            // 
            // cbLogiciel
            // 
            this.cbLogiciel.FormattingEnabled = true;
            this.cbLogiciel.Location = new System.Drawing.Point(12, 81);
            this.cbLogiciel.Name = "cbLogiciel";
            this.cbLogiciel.Size = new System.Drawing.Size(121, 21);
            this.cbLogiciel.TabIndex = 1;
            // 
            // cbVersion
            // 
            this.cbVersion.FormattingEnabled = true;
            this.cbVersion.Location = new System.Drawing.Point(12, 137);
            this.cbVersion.Name = "cbVersion";
            this.cbVersion.Size = new System.Drawing.Size(121, 21);
            this.cbVersion.TabIndex = 2;
            // 
            // btnAjout
            // 
            this.btnAjout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAjout.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAjout.Location = new System.Drawing.Point(12, 207);
            this.btnAjout.Name = "btnAjout";
            this.btnAjout.Size = new System.Drawing.Size(121, 50);
            this.btnAjout.TabIndex = 3;
            this.btnAjout.Text = "Ajout Tache Production";
            this.btnAjout.UseVisualStyleBackColor = true;
            // 
            // dgvTacheProd
            // 
            this.dgvTacheProd.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTacheProd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTacheProd.Location = new System.Drawing.Point(149, 29);
            this.dgvTacheProd.Name = "dgvTacheProd";
            this.dgvTacheProd.Size = new System.Drawing.Size(406, 289);
            this.dgvTacheProd.TabIndex = 3;
            // 
            // tbDescripTache
            // 
            this.tbDescripTache.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbDescripTache.Location = new System.Drawing.Point(215, 322);
            this.tbDescripTache.Name = "tbDescripTache";
            this.tbDescripTache.Size = new System.Drawing.Size(340, 20);
            this.tbDescripTache.TabIndex = 4;
            // 
            // btnEnregistrer
            // 
            this.btnEnregistrer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEnregistrer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnregistrer.Location = new System.Drawing.Point(12, 273);
            this.btnEnregistrer.Name = "btnEnregistrer";
            this.btnEnregistrer.Size = new System.Drawing.Size(121, 45);
            this.btnEnregistrer.TabIndex = 4;
            this.btnEnregistrer.Text = "Enregistrer";
            this.btnEnregistrer.UseVisualStyleBackColor = true;
            // 
            // lblPersonne
            // 
            this.lblPersonne.AutoSize = true;
            this.lblPersonne.Location = new System.Drawing.Point(9, 13);
            this.lblPersonne.Name = "lblPersonne";
            this.lblPersonne.Size = new System.Drawing.Size(113, 13);
            this.lblPersonne.TabIndex = 5;
            this.lblPersonne.Text = "Selection de personne";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Selection de logiciel";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Selection de version";
            // 
            // lblDescrip
            // 
            this.lblDescrip.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDescrip.AutoSize = true;
            this.lblDescrip.Location = new System.Drawing.Point(149, 325);
            this.lblDescrip.Name = "lblDescrip";
            this.lblDescrip.Size = new System.Drawing.Size(60, 13);
            this.lblDescrip.TabIndex = 5;
            this.lblDescrip.Text = "Description";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(146, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Taches de production";
            // 
            // FormTacheProd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 349);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblDescrip);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblPersonne);
            this.Controls.Add(this.tbDescripTache);
            this.Controls.Add(this.dgvTacheProd);
            this.Controls.Add(this.btnEnregistrer);
            this.Controls.Add(this.btnAjout);
            this.Controls.Add(this.cbVersion);
            this.Controls.Add(this.cbLogiciel);
            this.Controls.Add(this.cbPersonne);
            this.Name = "FormTacheProd";
            this.Text = "FormTacheProd";
            ((System.ComponentModel.ISupportInitialize)(this.dgvTacheProd)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbPersonne;
        private System.Windows.Forms.ComboBox cbLogiciel;
        private System.Windows.Forms.ComboBox cbVersion;
        private System.Windows.Forms.Button btnAjout;
        private System.Windows.Forms.DataGridView dgvTacheProd;
        private System.Windows.Forms.TextBox tbDescripTache;
        private System.Windows.Forms.Button btnEnregistrer;
        private System.Windows.Forms.Label lblPersonne;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblDescrip;
        private System.Windows.Forms.Label label3;
    }
}