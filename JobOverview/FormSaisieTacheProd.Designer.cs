namespace JobOverview
{
    partial class FormSaisieTacheProd
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
            this.mtbDureePrevue = new System.Windows.Forms.MaskedTextBox();
            this.lblDatePrevue = new System.Windows.Forms.Label();
            this.lblDureeRestante = new System.Windows.Forms.Label();
            this.lblNumero = new System.Windows.Forms.Label();
            this.cbLogiciel = new System.Windows.Forms.ComboBox();
            this.cbVersion = new System.Windows.Forms.ComboBox();
            this.cbModule = new System.Windows.Forms.ComboBox();
            this.lblLogiciel = new System.Windows.Forms.Label();
            this.lblVersion = new System.Windows.Forms.Label();
            this.lblModule = new System.Windows.Forms.Label();
            this.tbLibelle = new System.Windows.Forms.TextBox();
            this.lblLibelle = new System.Windows.Forms.Label();
            this.cbActivite = new System.Windows.Forms.ComboBox();
            this.lblActivite = new System.Windows.Forms.Label();
            this.rtbDescription = new System.Windows.Forms.RichTextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.btnAnnuler = new System.Windows.Forms.Button();
            this.btnValider = new System.Windows.Forms.Button();
            this.mtbNumero = new System.Windows.Forms.MaskedTextBox();
            this.cbPersonne = new System.Windows.Forms.ComboBox();
            this.lblPersonne = new System.Windows.Forms.Label();
            this.lblresDureeRestante = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // mtbDureePrevue
            // 
            this.mtbDureePrevue.Location = new System.Drawing.Point(173, 172);
            this.mtbDureePrevue.Mask = "99.9";
            this.mtbDureePrevue.Name = "mtbDureePrevue";
            this.mtbDureePrevue.Size = new System.Drawing.Size(118, 20);
            this.mtbDureePrevue.TabIndex = 0;
            // 
            // lblDatePrevue
            // 
            this.lblDatePrevue.AutoSize = true;
            this.lblDatePrevue.Location = new System.Drawing.Point(172, 157);
            this.lblDatePrevue.Name = "lblDatePrevue";
            this.lblDatePrevue.Size = new System.Drawing.Size(72, 13);
            this.lblDatePrevue.TabIndex = 1;
            this.lblDatePrevue.Text = "Durée prévue";
            // 
            // lblDureeRestante
            // 
            this.lblDureeRestante.AutoSize = true;
            this.lblDureeRestante.Location = new System.Drawing.Point(171, 203);
            this.lblDureeRestante.Name = "lblDureeRestante";
            this.lblDureeRestante.Size = new System.Drawing.Size(116, 13);
            this.lblDureeRestante.TabIndex = 1;
            this.lblDureeRestante.Text = "Durée restante estimée";
            // 
            // lblNumero
            // 
            this.lblNumero.AutoSize = true;
            this.lblNumero.Location = new System.Drawing.Point(185, 32);
            this.lblNumero.Name = "lblNumero";
            this.lblNumero.Size = new System.Drawing.Size(50, 13);
            this.lblNumero.TabIndex = 2;
            this.lblNumero.Text = "Numéro :";
            // 
            // cbLogiciel
            // 
            this.cbLogiciel.FormattingEnabled = true;
            this.cbLogiciel.Location = new System.Drawing.Point(15, 170);
            this.cbLogiciel.Name = "cbLogiciel";
            this.cbLogiciel.Size = new System.Drawing.Size(118, 21);
            this.cbLogiciel.TabIndex = 3;
            // 
            // cbVersion
            // 
            this.cbVersion.FormattingEnabled = true;
            this.cbVersion.Location = new System.Drawing.Point(15, 217);
            this.cbVersion.Name = "cbVersion";
            this.cbVersion.Size = new System.Drawing.Size(118, 21);
            this.cbVersion.TabIndex = 3;
            // 
            // cbModule
            // 
            this.cbModule.FormattingEnabled = true;
            this.cbModule.Location = new System.Drawing.Point(173, 123);
            this.cbModule.Name = "cbModule";
            this.cbModule.Size = new System.Drawing.Size(117, 21);
            this.cbModule.TabIndex = 3;
            // 
            // lblLogiciel
            // 
            this.lblLogiciel.AutoSize = true;
            this.lblLogiciel.Location = new System.Drawing.Point(13, 154);
            this.lblLogiciel.Name = "lblLogiciel";
            this.lblLogiciel.Size = new System.Drawing.Size(43, 13);
            this.lblLogiciel.TabIndex = 1;
            this.lblLogiciel.Text = "Logiciel";
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.Location = new System.Drawing.Point(14, 200);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(42, 13);
            this.lblVersion.TabIndex = 1;
            this.lblVersion.Text = "Version";
            // 
            // lblModule
            // 
            this.lblModule.AutoSize = true;
            this.lblModule.Location = new System.Drawing.Point(171, 108);
            this.lblModule.Name = "lblModule";
            this.lblModule.Size = new System.Drawing.Size(42, 13);
            this.lblModule.TabIndex = 1;
            this.lblModule.Text = "Module";
            // 
            // tbLibelle
            // 
            this.tbLibelle.Location = new System.Drawing.Point(15, 73);
            this.tbLibelle.Name = "tbLibelle";
            this.tbLibelle.Size = new System.Drawing.Size(276, 20);
            this.tbLibelle.TabIndex = 4;
            // 
            // lblLibelle
            // 
            this.lblLibelle.AutoSize = true;
            this.lblLibelle.Location = new System.Drawing.Point(12, 57);
            this.lblLibelle.Name = "lblLibelle";
            this.lblLibelle.Size = new System.Drawing.Size(37, 13);
            this.lblLibelle.TabIndex = 1;
            this.lblLibelle.Text = "Libellé";
            // 
            // cbActivite
            // 
            this.cbActivite.FormattingEnabled = true;
            this.cbActivite.Location = new System.Drawing.Point(15, 123);
            this.cbActivite.Name = "cbActivite";
            this.cbActivite.Size = new System.Drawing.Size(118, 21);
            this.cbActivite.TabIndex = 5;
            // 
            // lblActivite
            // 
            this.lblActivite.AutoSize = true;
            this.lblActivite.Location = new System.Drawing.Point(12, 107);
            this.lblActivite.Name = "lblActivite";
            this.lblActivite.Size = new System.Drawing.Size(42, 13);
            this.lblActivite.TabIndex = 1;
            this.lblActivite.Text = "Activité";
            // 
            // rtbDescription
            // 
            this.rtbDescription.Location = new System.Drawing.Point(15, 262);
            this.rtbDescription.Name = "rtbDescription";
            this.rtbDescription.Size = new System.Drawing.Size(274, 100);
            this.rtbDescription.TabIndex = 6;
            this.rtbDescription.Text = "";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(14, 247);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(60, 13);
            this.lblDescription.TabIndex = 7;
            this.lblDescription.Text = "Description";
            // 
            // btnAnnuler
            // 
            this.btnAnnuler.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAnnuler.Location = new System.Drawing.Point(166, 373);
            this.btnAnnuler.Name = "btnAnnuler";
            this.btnAnnuler.Size = new System.Drawing.Size(120, 39);
            this.btnAnnuler.TabIndex = 8;
            this.btnAnnuler.Text = "Annuler";
            this.btnAnnuler.UseVisualStyleBackColor = true;
            // 
            // btnValider
            // 
            this.btnValider.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnValider.Location = new System.Drawing.Point(17, 373);
            this.btnValider.Name = "btnValider";
            this.btnValider.Size = new System.Drawing.Size(127, 39);
            this.btnValider.TabIndex = 8;
            this.btnValider.Text = "Valider";
            this.btnValider.UseVisualStyleBackColor = true;
            // 
            // mtbNumero
            // 
            this.mtbNumero.Location = new System.Drawing.Point(243, 32);
            this.mtbNumero.Mask = "99999";
            this.mtbNumero.Name = "mtbNumero";
            this.mtbNumero.Size = new System.Drawing.Size(48, 20);
            this.mtbNumero.TabIndex = 9;
            this.mtbNumero.ValidatingType = typeof(int);
            // 
            // cbPersonne
            // 
            this.cbPersonne.FormattingEnabled = true;
            this.cbPersonne.Location = new System.Drawing.Point(15, 32);
            this.cbPersonne.Name = "cbPersonne";
            this.cbPersonne.Size = new System.Drawing.Size(118, 21);
            this.cbPersonne.TabIndex = 10;
            // 
            // lblPersonne
            // 
            this.lblPersonne.AutoSize = true;
            this.lblPersonne.Location = new System.Drawing.Point(13, 16);
            this.lblPersonne.Name = "lblPersonne";
            this.lblPersonne.Size = new System.Drawing.Size(52, 13);
            this.lblPersonne.TabIndex = 1;
            this.lblPersonne.Text = "Personne";
            // 
            // lblresDureeRestante
            // 
            this.lblresDureeRestante.AutoSize = true;
            this.lblresDureeRestante.Location = new System.Drawing.Point(172, 225);
            this.lblresDureeRestante.Name = "lblresDureeRestante";
            this.lblresDureeRestante.Size = new System.Drawing.Size(35, 13);
            this.lblresDureeRestante.TabIndex = 11;
            this.lblresDureeRestante.Text = "label1";
            // 
            // FormSaisieTacheProd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(301, 422);
            this.Controls.Add(this.lblresDureeRestante);
            this.Controls.Add(this.cbPersonne);
            this.Controls.Add(this.mtbNumero);
            this.Controls.Add(this.btnValider);
            this.Controls.Add(this.btnAnnuler);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.rtbDescription);
            this.Controls.Add(this.cbActivite);
            this.Controls.Add(this.tbLibelle);
            this.Controls.Add(this.cbModule);
            this.Controls.Add(this.cbVersion);
            this.Controls.Add(this.cbLogiciel);
            this.Controls.Add(this.lblNumero);
            this.Controls.Add(this.lblModule);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.lblLogiciel);
            this.Controls.Add(this.lblDureeRestante);
            this.Controls.Add(this.lblActivite);
            this.Controls.Add(this.lblPersonne);
            this.Controls.Add(this.lblLibelle);
            this.Controls.Add(this.lblDatePrevue);
            this.Controls.Add(this.mtbDureePrevue);
            this.Location = new System.Drawing.Point(317, 461);
            this.MaximumSize = new System.Drawing.Size(317, 461);
            this.Name = "FormSaisieTacheProd";
            this.Text = "Nouvelle tache de production";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MaskedTextBox mtbDureePrevue;
        private System.Windows.Forms.Label lblDatePrevue;
        private System.Windows.Forms.Label lblDureeRestante;
        private System.Windows.Forms.Label lblNumero;
        private System.Windows.Forms.ComboBox cbLogiciel;
        private System.Windows.Forms.ComboBox cbVersion;
        private System.Windows.Forms.ComboBox cbModule;
        private System.Windows.Forms.Label lblLogiciel;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Label lblModule;
        private System.Windows.Forms.TextBox tbLibelle;
        private System.Windows.Forms.Label lblLibelle;
        private System.Windows.Forms.ComboBox cbActivite;
        private System.Windows.Forms.Label lblActivite;
        private System.Windows.Forms.RichTextBox rtbDescription;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Button btnAnnuler;
        private System.Windows.Forms.Button btnValider;
        private System.Windows.Forms.MaskedTextBox mtbNumero;
        private System.Windows.Forms.ComboBox cbPersonne;
        private System.Windows.Forms.Label lblPersonne;
        private System.Windows.Forms.Label lblresDureeRestante;
    }
}