namespace JobOverview
{
	partial class MDIForm
	{
		/// <summary>
		/// Variable nécessaire au concepteur.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Nettoyage des ressources utilisées.
		/// </summary>
		/// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Code généré par le Concepteur Windows Form

		/// <summary>
		/// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
		/// le contenu de cette méthode avec l'éditeur de code.
		/// </summary>
		private void InitializeComponent()
		{
            this.menuGeneral = new System.Windows.Forms.MenuStrip();
            this.menuLogiciel = new System.Windows.Forms.ToolStripMenuItem();
            this.menuGestionTaches = new System.Windows.Forms.ToolStripMenuItem();
            this.menuTacheProd = new System.Windows.Forms.ToolStripMenuItem();
            this.menuTachesAnnexes = new System.Windows.Forms.ToolStripMenuItem();
            this.menuVerifTemps = new System.Windows.Forms.ToolStripMenuItem();
            this.menuEchange = new System.Windows.Forms.ToolStripMenuItem();
            this.menuWindows = new System.Windows.Forms.ToolStripMenuItem();
            this.menuGeneral.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuGeneral
            // 
            this.menuGeneral.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuLogiciel,
            this.menuGestionTaches,
            this.menuVerifTemps,
            this.menuEchange,
            this.menuWindows});
            this.menuGeneral.Location = new System.Drawing.Point(0, 0);
            this.menuGeneral.Name = "menuGeneral";
            this.menuGeneral.Size = new System.Drawing.Size(787, 24);
            this.menuGeneral.TabIndex = 0;
            this.menuGeneral.Text = "menuStrip1";
            // 
            // menuLogiciel
            // 
            this.menuLogiciel.Name = "menuLogiciel";
            this.menuLogiciel.Size = new System.Drawing.Size(183, 20);
            this.menuLogiciel.Text = "Gestion des version de logiciels";
            // 
            // menuGestionTaches
            // 
            this.menuGestionTaches.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuTacheProd,
            this.menuTachesAnnexes});
            this.menuGestionTaches.Name = "menuGestionTaches";
            this.menuGestionTaches.Size = new System.Drawing.Size(112, 20);
            this.menuGestionTaches.Text = "Gestion de taches";
            // 
            // menuTacheProd
            // 
            this.menuTacheProd.Name = "menuTacheProd";
            this.menuTacheProd.Size = new System.Drawing.Size(188, 22);
            this.menuTacheProd.Text = "Taches de production";
            // 
            // menuTachesAnnexes
            // 
            this.menuTachesAnnexes.Name = "menuTachesAnnexes";
            this.menuTachesAnnexes.Size = new System.Drawing.Size(188, 22);
            this.menuTachesAnnexes.Text = "Tache annexes";
            // 
            // menuVerifTemps
            // 
            this.menuVerifTemps.Name = "menuVerifTemps";
            this.menuVerifTemps.Size = new System.Drawing.Size(187, 20);
            this.menuVerifTemps.Text = "Vérification des saisies de temps";
            // 
            // menuEchange
            // 
            this.menuEchange.Name = "menuEchange";
            this.menuEchange.Size = new System.Drawing.Size(69, 20);
            this.menuEchange.Text = "Echanges";
            // 
            // menuWindows
            // 
            this.menuWindows.Name = "menuWindows";
            this.menuWindows.Size = new System.Drawing.Size(63, 20);
            this.menuWindows.Text = "Fenêtres";
            // 
            // MDIForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(787, 514);
            this.Controls.Add(this.menuGeneral);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuGeneral;
            this.Name = "MDIForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "JobOverview";
            this.menuGeneral.ResumeLayout(false);
            this.menuGeneral.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuGeneral;
		private System.Windows.Forms.ToolStripMenuItem menuLogiciel;
		private System.Windows.Forms.ToolStripMenuItem menuWindows;
		private System.Windows.Forms.ToolStripMenuItem menuGestionTaches;
        private System.Windows.Forms.ToolStripMenuItem menuTacheProd;
        private System.Windows.Forms.ToolStripMenuItem menuTachesAnnexes;
        private System.Windows.Forms.ToolStripMenuItem menuVerifTemps;
        private System.Windows.Forms.ToolStripMenuItem menuEchange;
    }
}

