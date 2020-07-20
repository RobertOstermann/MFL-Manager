namespace MFL_Manager
{
    partial class FreeAgency
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
            this.lblTeamName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblTeamName
            // 
            this.lblTeamName.Font = new System.Drawing.Font("Stencil", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTeamName.Location = new System.Drawing.Point(13, 9);
            this.lblTeamName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTeamName.Name = "lblTeamName";
            this.lblTeamName.Size = new System.Drawing.Size(533, 71);
            this.lblTeamName.TabIndex = 4;
            this.lblTeamName.Text = "MFL Team Name";
            this.lblTeamName.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // FreeAgency
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(967, 633);
            this.Controls.Add(this.lblTeamName);
            this.Name = "FreeAgency";
            this.Text = "FreeAgency";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTeamName;
    }
}