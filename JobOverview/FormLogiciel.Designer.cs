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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogiciel));
            this.cbLogiciel = new System.Windows.Forms.ComboBox();
            this.btnNewVersion = new System.Windows.Forms.Button();
            this.btnSupVersion = new System.Windows.Forms.Button();
            this.btnEnregister = new System.Windows.Forms.Button();
            this.lblLogiciel = new System.Windows.Forms.Label();
            this.dgvVersion = new System.Windows.Forms.DataGridView();
            this.lblVersion = new System.Windows.Forms.Label();
            this.lblModule = new System.Windows.Forms.Label();
            this.dgvModule = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVersion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvModule)).BeginInit();
            this.SuspendLayout();
            // 
            // cbLogiciel
            // 
            resources.ApplyResources(this.cbLogiciel, "cbLogiciel");
            this.cbLogiciel.FormattingEnabled = true;
            this.cbLogiciel.Name = "cbLogiciel";
            // 
            // btnNewVersion
            // 
            resources.ApplyResources(this.btnNewVersion, "btnNewVersion");
            this.btnNewVersion.Name = "btnNewVersion";
            this.btnNewVersion.UseVisualStyleBackColor = true;
            // 
            // btnSupVersion
            // 
            resources.ApplyResources(this.btnSupVersion, "btnSupVersion");
            this.btnSupVersion.Name = "btnSupVersion";
            this.btnSupVersion.UseVisualStyleBackColor = true;
            // 
            // btnEnregister
            // 
            resources.ApplyResources(this.btnEnregister, "btnEnregister");
            this.btnEnregister.Name = "btnEnregister";
            this.btnEnregister.UseVisualStyleBackColor = true;
            // 
            // lblLogiciel
            // 
            resources.ApplyResources(this.lblLogiciel, "lblLogiciel");
            this.lblLogiciel.Name = "lblLogiciel";
            // 
            // dgvVersion
            // 
            resources.ApplyResources(this.dgvVersion, "dgvVersion");
            this.dgvVersion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVersion.Name = "dgvVersion";
            // 
            // lblVersion
            // 
            resources.ApplyResources(this.lblVersion, "lblVersion");
            this.lblVersion.Name = "lblVersion";
            // 
            // lblModule
            // 
            resources.ApplyResources(this.lblModule, "lblModule");
            this.lblModule.Name = "lblModule";
            // 
            // dgvModule
            // 
            resources.ApplyResources(this.dgvModule, "dgvModule");
            this.dgvModule.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvModule.Name = "dgvModule";
            // 
            // FormLogiciel
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvModule);
            this.Controls.Add(this.lblModule);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.dgvVersion);
            this.Controls.Add(this.lblLogiciel);
            this.Controls.Add(this.btnEnregister);
            this.Controls.Add(this.btnSupVersion);
            this.Controls.Add(this.btnNewVersion);
            this.Controls.Add(this.cbLogiciel);
            this.Name = "FormLogiciel";
            ((System.ComponentModel.ISupportInitialize)(this.dgvVersion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvModule)).EndInit();
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
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Label lblModule;
        private System.Windows.Forms.DataGridView dgvModule;
    }
}