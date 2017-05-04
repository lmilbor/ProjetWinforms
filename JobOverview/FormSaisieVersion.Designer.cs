namespace JobOverview
{
    partial class FormSaisieVersion
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
            this.cbLogiciel = new System.Windows.Forms.ComboBox();
            this.lblLogiciel = new System.Windows.Forms.Label();
            this.lblNumVersion = new System.Windows.Forms.Label();
            this.lblresNumVersion = new System.Windows.Forms.Label();
            this.lblDateOuverture = new System.Windows.Forms.Label();
            this.lblDateSortiePrevue = new System.Windows.Forms.Label();
            this.lblMillesime = new System.Windows.Forms.Label();
            this.lblresMillesime = new System.Windows.Forms.Label();
            this.mtbDateOuverture = new System.Windows.Forms.MaskedTextBox();
            this.mtbDateSortie = new System.Windows.Forms.MaskedTextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cbLogiciel
            // 
            this.cbLogiciel.FormattingEnabled = true;
            this.cbLogiciel.Location = new System.Drawing.Point(12, 28);
            this.cbLogiciel.Name = "cbLogiciel";
            this.cbLogiciel.Size = new System.Drawing.Size(137, 21);
            this.cbLogiciel.TabIndex = 0;
            // 
            // lblLogiciel
            // 
            this.lblLogiciel.AutoSize = true;
            this.lblLogiciel.Location = new System.Drawing.Point(12, 9);
            this.lblLogiciel.Name = "lblLogiciel";
            this.lblLogiciel.Size = new System.Drawing.Size(43, 13);
            this.lblLogiciel.TabIndex = 1;
            this.lblLogiciel.Text = "Logiciel";
            // 
            // lblNumVersion
            // 
            this.lblNumVersion.AutoSize = true;
            this.lblNumVersion.Location = new System.Drawing.Point(11, 136);
            this.lblNumVersion.Name = "lblNumVersion";
            this.lblNumVersion.Size = new System.Drawing.Size(96, 13);
            this.lblNumVersion.TabIndex = 2;
            this.lblNumVersion.Text = "Numéro de version";
            // 
            // lblresNumVersion
            // 
            this.lblresNumVersion.AutoSize = true;
            this.lblresNumVersion.Location = new System.Drawing.Point(12, 158);
            this.lblresNumVersion.Name = "lblresNumVersion";
            this.lblresNumVersion.Size = new System.Drawing.Size(35, 13);
            this.lblresNumVersion.TabIndex = 3;
            this.lblresNumVersion.Text = "label3";
            // 
            // lblDateOuverture
            // 
            this.lblDateOuverture.AutoSize = true;
            this.lblDateOuverture.Location = new System.Drawing.Point(12, 52);
            this.lblDateOuverture.Name = "lblDateOuverture";
            this.lblDateOuverture.Size = new System.Drawing.Size(86, 13);
            this.lblDateOuverture.TabIndex = 4;
            this.lblDateOuverture.Text = "Date d\'ouverture";
            // 
            // lblDateSortiePrevue
            // 
            this.lblDateSortiePrevue.AutoSize = true;
            this.lblDateSortiePrevue.Location = new System.Drawing.Point(12, 91);
            this.lblDateSortiePrevue.Name = "lblDateSortiePrevue";
            this.lblDateSortiePrevue.Size = new System.Drawing.Size(140, 13);
            this.lblDateSortiePrevue.TabIndex = 5;
            this.lblDateSortiePrevue.Text = "Date de sortie prévisionnelle";
            // 
            // lblMillesime
            // 
            this.lblMillesime.AutoSize = true;
            this.lblMillesime.Location = new System.Drawing.Point(117, 136);
            this.lblMillesime.Name = "lblMillesime";
            this.lblMillesime.Size = new System.Drawing.Size(49, 13);
            this.lblMillesime.TabIndex = 6;
            this.lblMillesime.Text = "Millesime";
            // 
            // lblresMillesime
            // 
            this.lblresMillesime.AutoSize = true;
            this.lblresMillesime.Location = new System.Drawing.Point(117, 158);
            this.lblresMillesime.Name = "lblresMillesime";
            this.lblresMillesime.Size = new System.Drawing.Size(35, 13);
            this.lblresMillesime.TabIndex = 7;
            this.lblresMillesime.Text = "label1";
            // 
            // mtbDateOuverture
            // 
            this.mtbDateOuverture.Location = new System.Drawing.Point(12, 68);
            this.mtbDateOuverture.Mask = "00/00/0000";
            this.mtbDateOuverture.Name = "mtbDateOuverture";
            this.mtbDateOuverture.Size = new System.Drawing.Size(100, 20);
            this.mtbDateOuverture.TabIndex = 8;
            this.mtbDateOuverture.ValidatingType = typeof(System.DateTime);
            // 
            // mtbDateSortie
            // 
            this.mtbDateSortie.Location = new System.Drawing.Point(12, 107);
            this.mtbDateSortie.Mask = "00/00/0000";
            this.mtbDateSortie.Name = "mtbDateSortie";
            this.mtbDateSortie.Size = new System.Drawing.Size(100, 20);
            this.mtbDateSortie.TabIndex = 9;
            this.mtbDateSortie.ValidatingType = typeof(System.DateTime);
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(12, 189);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 10;
            this.btnOK.Text = "Valider";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(93, 189);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Annuler";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // FormSaisieVersion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(201, 235);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.mtbDateSortie);
            this.Controls.Add(this.mtbDateOuverture);
            this.Controls.Add(this.lblresMillesime);
            this.Controls.Add(this.lblMillesime);
            this.Controls.Add(this.lblDateSortiePrevue);
            this.Controls.Add(this.lblDateOuverture);
            this.Controls.Add(this.lblresNumVersion);
            this.Controls.Add(this.lblNumVersion);
            this.Controls.Add(this.lblLogiciel);
            this.Controls.Add(this.cbLogiciel);
            this.Name = "FormSaisieVersion";
            this.Text = "Ajouter une nouvelle version";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbLogiciel;
        private System.Windows.Forms.Label lblLogiciel;
        private System.Windows.Forms.Label lblNumVersion;
        private System.Windows.Forms.Label lblresNumVersion;
        private System.Windows.Forms.Label lblDateOuverture;
        private System.Windows.Forms.Label lblDateSortiePrevue;
        private System.Windows.Forms.Label lblMillesime;
        private System.Windows.Forms.Label lblresMillesime;
        private System.Windows.Forms.MaskedTextBox mtbDateOuverture;
        private System.Windows.Forms.MaskedTextBox mtbDateSortie;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
    }
}