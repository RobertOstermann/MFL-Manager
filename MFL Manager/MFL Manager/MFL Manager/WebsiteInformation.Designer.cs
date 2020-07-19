namespace MFL_Manager
{
    partial class WebsiteInformation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WebsiteInformation));
            this.lblPlayerInformation = new System.Windows.Forms.Label();
            this.uxPlayerURL = new System.Windows.Forms.TextBox();
            this.lblSalaryInformation = new System.Windows.Forms.Label();
            this.uxSalaryURL = new System.Windows.Forms.TextBox();
            this.lblLeagueInformation = new System.Windows.Forms.Label();
            this.uxLeagueURL = new System.Windows.Forms.TextBox();
            this.uxAutofill = new System.Windows.Forms.Button();
            this.uxSubmit = new System.Windows.Forms.Button();
            this.lblRosterInformation = new System.Windows.Forms.Label();
            this.uxRosterURL = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblPlayerInformation
            // 
            this.lblPlayerInformation.AutoSize = true;
            this.lblPlayerInformation.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlayerInformation.Location = new System.Drawing.Point(13, 14);
            this.lblPlayerInformation.Name = "lblPlayerInformation";
            this.lblPlayerInformation.Size = new System.Drawing.Size(340, 23);
            this.lblPlayerInformation.TabIndex = 0;
            this.lblPlayerInformation.Text = "Player Information API Website";
            // 
            // uxPlayerURL
            // 
            this.uxPlayerURL.Location = new System.Drawing.Point(13, 39);
            this.uxPlayerURL.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.uxPlayerURL.Name = "uxPlayerURL";
            this.uxPlayerURL.Size = new System.Drawing.Size(368, 22);
            this.uxPlayerURL.TabIndex = 1;
            // 
            // lblSalaryInformation
            // 
            this.lblSalaryInformation.AutoSize = true;
            this.lblSalaryInformation.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSalaryInformation.Location = new System.Drawing.Point(12, 65);
            this.lblSalaryInformation.Name = "lblSalaryInformation";
            this.lblSalaryInformation.Size = new System.Drawing.Size(340, 23);
            this.lblSalaryInformation.TabIndex = 2;
            this.lblSalaryInformation.Text = "Salary Information API Website";
            // 
            // uxSalaryURL
            // 
            this.uxSalaryURL.Location = new System.Drawing.Point(12, 91);
            this.uxSalaryURL.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.uxSalaryURL.Name = "uxSalaryURL";
            this.uxSalaryURL.Size = new System.Drawing.Size(369, 22);
            this.uxSalaryURL.TabIndex = 3;
            // 
            // lblLeagueInformation
            // 
            this.lblLeagueInformation.AutoSize = true;
            this.lblLeagueInformation.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLeagueInformation.Location = new System.Drawing.Point(12, 116);
            this.lblLeagueInformation.Name = "lblLeagueInformation";
            this.lblLeagueInformation.Size = new System.Drawing.Size(340, 23);
            this.lblLeagueInformation.TabIndex = 4;
            this.lblLeagueInformation.Text = "League Information API Website";
            // 
            // uxLeagueURL
            // 
            this.uxLeagueURL.Location = new System.Drawing.Point(12, 142);
            this.uxLeagueURL.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.uxLeagueURL.Name = "uxLeagueURL";
            this.uxLeagueURL.Size = new System.Drawing.Size(369, 22);
            this.uxLeagueURL.TabIndex = 5;
            // 
            // uxAutofill
            // 
            this.uxAutofill.Font = new System.Drawing.Font("Consolas", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxAutofill.Location = new System.Drawing.Point(19, 232);
            this.uxAutofill.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.uxAutofill.Name = "uxAutofill";
            this.uxAutofill.Size = new System.Drawing.Size(369, 62);
            this.uxAutofill.TabIndex = 6;
            this.uxAutofill.Text = "Autofill";
            this.uxAutofill.UseVisualStyleBackColor = true;
            this.uxAutofill.Click += new System.EventHandler(this.uxAutofill_Click);
            // 
            // uxSubmit
            // 
            this.uxSubmit.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.uxSubmit.Font = new System.Drawing.Font("Consolas", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxSubmit.Location = new System.Drawing.Point(17, 298);
            this.uxSubmit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.uxSubmit.Name = "uxSubmit";
            this.uxSubmit.Size = new System.Drawing.Size(371, 62);
            this.uxSubmit.TabIndex = 7;
            this.uxSubmit.Text = "Submit";
            this.uxSubmit.UseVisualStyleBackColor = true;
            this.uxSubmit.Click += new System.EventHandler(this.uxSubmit_Click);
            // 
            // lblRosterInformation
            // 
            this.lblRosterInformation.AutoSize = true;
            this.lblRosterInformation.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRosterInformation.Location = new System.Drawing.Point(13, 166);
            this.lblRosterInformation.Name = "lblRosterInformation";
            this.lblRosterInformation.Size = new System.Drawing.Size(340, 23);
            this.lblRosterInformation.TabIndex = 8;
            this.lblRosterInformation.Text = "Roster Information API Website";
            // 
            // uxRosterURL
            // 
            this.uxRosterURL.Location = new System.Drawing.Point(12, 191);
            this.uxRosterURL.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.uxRosterURL.Name = "uxRosterURL";
            this.uxRosterURL.Size = new System.Drawing.Size(369, 22);
            this.uxRosterURL.TabIndex = 9;
            // 
            // WebsiteInformation
            // 
            this.AcceptButton = this.uxSubmit;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(397, 371);
            this.Controls.Add(this.uxRosterURL);
            this.Controls.Add(this.lblRosterInformation);
            this.Controls.Add(this.uxSubmit);
            this.Controls.Add(this.uxAutofill);
            this.Controls.Add(this.uxLeagueURL);
            this.Controls.Add(this.lblLeagueInformation);
            this.Controls.Add(this.uxSalaryURL);
            this.Controls.Add(this.lblSalaryInformation);
            this.Controls.Add(this.uxPlayerURL);
            this.Controls.Add(this.lblPlayerInformation);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "WebsiteInformation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WebsiteInformation";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPlayerInformation;
        private System.Windows.Forms.TextBox uxPlayerURL;
        private System.Windows.Forms.Label lblSalaryInformation;
        private System.Windows.Forms.TextBox uxSalaryURL;
        private System.Windows.Forms.Label lblLeagueInformation;
        private System.Windows.Forms.TextBox uxLeagueURL;
        private System.Windows.Forms.Button uxAutofill;
        private System.Windows.Forms.Button uxSubmit;
        private System.Windows.Forms.Label lblRosterInformation;
        private System.Windows.Forms.TextBox uxRosterURL;
    }
}