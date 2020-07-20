namespace MFL_Manager
{
    partial class CapEditor
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
            this.uxCapHit = new System.Windows.Forms.NumericUpDown();
            this.lblCapData = new System.Windows.Forms.Label();
            this.uxSubmit = new System.Windows.Forms.Button();
            this.lblTeamName = new System.Windows.Forms.Label();
            this.lblDollarSign = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.uxCapHit)).BeginInit();
            this.SuspendLayout();
            // 
            // uxCapHit
            // 
            this.uxCapHit.DecimalPlaces = 2;
            this.uxCapHit.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxCapHit.Location = new System.Drawing.Point(141, 51);
            this.uxCapHit.Maximum = new decimal(new int[] {
            125,
            0,
            0,
            0});
            this.uxCapHit.Name = "uxCapHit";
            this.uxCapHit.Size = new System.Drawing.Size(127, 26);
            this.uxCapHit.TabIndex = 29;
            this.uxCapHit.Value = new decimal(new int[] {
            12500,
            0,
            0,
            131072});
            // 
            // lblCapData
            // 
            this.lblCapData.AutoSize = true;
            this.lblCapData.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCapData.Location = new System.Drawing.Point(11, 53);
            this.lblCapData.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCapData.Name = "lblCapData";
            this.lblCapData.Size = new System.Drawing.Size(72, 19);
            this.lblCapData.TabIndex = 28;
            this.lblCapData.Text = "Cap Hit";
            // 
            // uxSubmit
            // 
            this.uxSubmit.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.uxSubmit.Font = new System.Drawing.Font("Consolas", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxSubmit.Location = new System.Drawing.Point(15, 82);
            this.uxSubmit.Margin = new System.Windows.Forms.Padding(2);
            this.uxSubmit.Name = "uxSubmit";
            this.uxSubmit.Size = new System.Drawing.Size(253, 50);
            this.uxSubmit.TabIndex = 27;
            this.uxSubmit.Text = "Submit";
            this.uxSubmit.UseVisualStyleBackColor = true;
            this.uxSubmit.Click += new System.EventHandler(this.uxSubmit_Click);
            // 
            // lblTeamName
            // 
            this.lblTeamName.Font = new System.Drawing.Font("Stencil", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTeamName.Location = new System.Drawing.Point(11, 9);
            this.lblTeamName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTeamName.Name = "lblTeamName";
            this.lblTeamName.Size = new System.Drawing.Size(257, 39);
            this.lblTeamName.TabIndex = 30;
            this.lblTeamName.Text = "Salary Cap";
            this.lblTeamName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDollarSign
            // 
            this.lblDollarSign.AutoSize = true;
            this.lblDollarSign.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDollarSign.Location = new System.Drawing.Point(118, 53);
            this.lblDollarSign.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDollarSign.Name = "lblDollarSign";
            this.lblDollarSign.Size = new System.Drawing.Size(18, 19);
            this.lblDollarSign.TabIndex = 31;
            this.lblDollarSign.Text = "$";
            // 
            // CapEditor
            // 
            this.AcceptButton = this.uxSubmit;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(283, 142);
            this.Controls.Add(this.lblDollarSign);
            this.Controls.Add(this.lblTeamName);
            this.Controls.Add(this.uxCapHit);
            this.Controls.Add(this.lblCapData);
            this.Controls.Add(this.uxSubmit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "CapEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CapEditor";
            ((System.ComponentModel.ISupportInitialize)(this.uxCapHit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown uxCapHit;
        private System.Windows.Forms.Label lblCapData;
        private System.Windows.Forms.Button uxSubmit;
        private System.Windows.Forms.Label lblTeamName;
        private System.Windows.Forms.Label lblDollarSign;
    }
}