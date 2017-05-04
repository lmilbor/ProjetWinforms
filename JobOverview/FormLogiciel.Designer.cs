namespace JobOverview
{
    partial class FormLogiciel
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
            this.btnNewVersion = new System.Windows.Forms.Button();
            this.btnSupVersion = new System.Windows.Forms.Button();
            this.btnEnregister = new System.Windows.Forms.Button();
            this.lblLogiciel = new System.Windows.Forms.Label();
            this.dgvVersion = new System.Windows.Forms.DataGridView();
            this.lbModule = new System.Windows.Forms.ListBox();
            this.lblVersion = new System.Windows.Forms.Label();
            this.lblModule = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVersion)).BeginInit();
            this.SuspendLayout();
            // 
            // cbLogiciel
            // 
            this.cbLogiciel.FormattingEnabled = true;
            this.cbLogiciel.Location = new System.Drawing.Point(8, 31);
            this.cbLogiciel.Name = "cbLogiciel";
            this.cbLogiciel.Size = new System.Drawing.Size(121, 21);
            this.cbLogiciel.TabIndex = 0;
            // 
            // btnNewVersion
            // 
            this.btnNewVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewVersion.Location = new System.Drawing.Point(8, 58);
            this.btnNewVersion.Name = "btnNewVersion";
            this.btnNewVersion.Size = new System.Drawing.Size(121, 36);
            this.btnNewVersion.TabIndex = 1;
            this.btnNewVersion.Text = "Nouvelle Version";
            this.btnNewVersion.UseVisualStyleBackColor = true;
            // 
            // btnSupVersion
            // 
            this.btnSupVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSupVersion.Location = new System.Drawing.Point(8, 100);
            this.btnSupVersion.Name = "btnSupVersion";
            this.btnSupVersion.Size = new System.Drawing.Size(121, 39);
            this.btnSupVersion.TabIndex = 2;
            this.btnSupVersion.Text = "Supprimer Version";
            this.btnSupVersion.UseVisualStyleBackColor = true;
            // 
            // btnEnregister
            // 
            this.btnEnregister.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnregister.Location = new System.Drawing.Point(8, 145);
            this.btnEnregister.Name = "btnEnregister";
            this.btnEnregister.Size = new System.Drawing.Size(121, 39);
            this.btnEnregister.TabIndex = 3;
            this.btnEnregister.Text = "Enregistrer";
            this.btnEnregister.UseVisualStyleBackColor = true;
            // 
            // lblLogiciel
            // 
            this.lblLogiciel.AutoSize = true;
            this.lblLogiciel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLogiciel.Location = new System.Drawing.Point(5, 9);
            this.lblLogiciel.Name = "lblLogiciel";
            this.lblLogiciel.Size = new System.Drawing.Size(133, 17);
            this.lblLogiciel.TabIndex = 4;
            this.lblLogiciel.Text = "Selection de logiciel";
            // 
            // dgvVersion
            // 
            this.dgvVersion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvVersion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVersion.Location = new System.Drawing.Point(135, 31);
            this.dgvVersion.Name = "dgvVersion";
            this.dgvVersion.Size = new System.Drawing.Size(203, 381);
            this.dgvVersion.TabIndex = 5;
            // 
            // lbModule
            // 
            this.lbModule.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbModule.FormattingEnabled = true;
            this.lbModule.Location = new System.Drawing.Point(344, 31);
            this.lbModule.Name = "lbModule";
            this.lbModule.Size = new System.Drawing.Size(323, 381);
            this.lbModule.TabIndex = 6;
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVersion.Location = new System.Drawing.Point(147, 9);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(63, 17);
            this.lblVersion.TabIndex = 7;
            this.lblVersion.Text = "Versions";
            // 
            // lblModule
            // 
            this.lblModule.AutoSize = true;
            this.lblModule.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblModule.Location = new System.Drawing.Point(341, 9);
            this.lblModule.Name = "lblModule";
            this.lblModule.Size = new System.Drawing.Size(61, 17);
            this.lblModule.TabIndex = 8;
            this.lblModule.Text = "Modules";
            // 
            // FormLogiciel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(679, 416);
            this.Controls.Add(this.lblModule);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.lbModule);
            this.Controls.Add(this.dgvVersion);
            this.Controls.Add(this.lblLogiciel);
            this.Controls.Add(this.btnEnregister);
            this.Controls.Add(this.btnSupVersion);
            this.Controls.Add(this.btnNewVersion);
            this.Controls.Add(this.cbLogiciel);
            this.Name = "FormLogiciel";
            this.Text = "FormGestionLogiciel";
            ((System.ComponentModel.ISupportInitialize)(this.dgvVersion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbLogiciel;
        private System.Windows.Forms.Button btnNewVersion;
        private System.Windows.Forms.Button btnSupVersion;
        private System.Windows.Forms.Button btnEnregister;
        private System.Windows.Forms.Label lblLogiciel;
        private System.Windows.Forms.DataGridView dgvVersion;
        private System.Windows.Forms.ListBox lbModule;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Label lblModule;
    }
}