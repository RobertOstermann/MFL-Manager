namespace MFL_Manager
{
    partial class PlayerEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlayerEditor));
            this.uxSubmit = new System.Windows.Forms.Button();
            this.lblName = new System.Windows.Forms.Label();
            this.lblSalary = new System.Windows.Forms.Label();
            this.lblID = new System.Windows.Forms.Label();
            this.lblContractYear = new System.Windows.Forms.Label();
            this.lblAge = new System.Windows.Forms.Label();
            this.uxPlayerName = new System.Windows.Forms.TextBox();
            this.uxContractYear = new System.Windows.Forms.ComboBox();
            this.uxSalary = new System.Windows.Forms.NumericUpDown();
            this.uxID = new System.Windows.Forms.NumericUpDown();
            this.uxAge = new System.Windows.Forms.NumericUpDown();
            this.uxPositionOptions = new System.Windows.Forms.GroupBox();
            this.uxDefense = new System.Windows.Forms.RadioButton();
            this.uxKicker = new System.Windows.Forms.RadioButton();
            this.uxTightEnd = new System.Windows.Forms.RadioButton();
            this.uxReceivers = new System.Windows.Forms.RadioButton();
            this.uxRunningBacks = new System.Windows.Forms.RadioButton();
            this.uxQuarterbacks = new System.Windows.Forms.RadioButton();
            this.uxNoPosition = new System.Windows.Forms.RadioButton();
            this.uxMFLTeam = new System.Windows.Forms.GroupBox();
            this.uxRam = new System.Windows.Forms.RadioButton();
            this.uxPower = new System.Windows.Forms.RadioButton();
            this.uxGorillas = new System.Windows.Forms.RadioButton();
            this.uxNikeStorm = new System.Windows.Forms.RadioButton();
            this.uxStormDynasty = new System.Windows.Forms.RadioButton();
            this.uxOdbs = new System.Windows.Forms.RadioButton();
            this.uxDactyls = new System.Windows.Forms.RadioButton();
            this.uxBombers = new System.Windows.Forms.RadioButton();
            this.uxPenguins = new System.Windows.Forms.RadioButton();
            this.uxTornados = new System.Windows.Forms.RadioButton();
            this.uxNoTeam = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.uxSalary)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uxID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uxAge)).BeginInit();
            this.uxPositionOptions.SuspendLayout();
            this.uxMFLTeam.SuspendLayout();
            this.SuspendLayout();
            // 
            // uxSubmit
            // 
            this.uxSubmit.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.uxSubmit.Font = new System.Drawing.Font("Consolas", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxSubmit.Location = new System.Drawing.Point(11, 182);
            this.uxSubmit.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.uxSubmit.Name = "uxSubmit";
            this.uxSubmit.Size = new System.Drawing.Size(255, 50);
            this.uxSubmit.TabIndex = 8;
            this.uxSubmit.Text = "Submit";
            this.uxSubmit.UseVisualStyleBackColor = true;
            this.uxSubmit.Click += new System.EventHandler(this.uxSubmit_Click);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(7, 32);
            this.lblName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(45, 19);
            this.lblName.TabIndex = 9;
            this.lblName.Text = "Name";
            // 
            // lblSalary
            // 
            this.lblSalary.AutoSize = true;
            this.lblSalary.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSalary.Location = new System.Drawing.Point(7, 92);
            this.lblSalary.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSalary.Name = "lblSalary";
            this.lblSalary.Size = new System.Drawing.Size(126, 19);
            this.lblSalary.TabIndex = 10;
            this.lblSalary.Text = "Salary      $";
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblID.Location = new System.Drawing.Point(7, 62);
            this.lblID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(27, 19);
            this.lblID.TabIndex = 11;
            this.lblID.Text = "ID";
            // 
            // lblContractYear
            // 
            this.lblContractYear.AutoSize = true;
            this.lblContractYear.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContractYear.Location = new System.Drawing.Point(7, 126);
            this.lblContractYear.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblContractYear.Name = "lblContractYear";
            this.lblContractYear.Size = new System.Drawing.Size(126, 19);
            this.lblContractYear.TabIndex = 12;
            this.lblContractYear.Text = "Contract Year";
            // 
            // lblAge
            // 
            this.lblAge.AutoSize = true;
            this.lblAge.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAge.Location = new System.Drawing.Point(9, 153);
            this.lblAge.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAge.Name = "lblAge";
            this.lblAge.Size = new System.Drawing.Size(36, 19);
            this.lblAge.TabIndex = 13;
            this.lblAge.Text = "Age";
            // 
            // uxPlayerName
            // 
            this.uxPlayerName.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxPlayerName.Location = new System.Drawing.Point(56, 29);
            this.uxPlayerName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.uxPlayerName.MaxLength = 30;
            this.uxPlayerName.Name = "uxPlayerName";
            this.uxPlayerName.Size = new System.Drawing.Size(208, 26);
            this.uxPlayerName.TabIndex = 22;
            // 
            // uxContractYear
            // 
            this.uxContractYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.uxContractYear.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxContractYear.FormattingEnabled = true;
            this.uxContractYear.Items.AddRange(new object[] {
            "2019",
            "2020",
            "2021",
            "2022"});
            this.uxContractYear.Location = new System.Drawing.Point(137, 119);
            this.uxContractYear.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.uxContractYear.MaxDropDownItems = 4;
            this.uxContractYear.Name = "uxContractYear";
            this.uxContractYear.Size = new System.Drawing.Size(127, 27);
            this.uxContractYear.TabIndex = 25;
            // 
            // uxSalary
            // 
            this.uxSalary.DecimalPlaces = 2;
            this.uxSalary.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxSalary.Location = new System.Drawing.Point(137, 90);
            this.uxSalary.Maximum = new decimal(new int[] {
            125,
            0,
            0,
            0});
            this.uxSalary.Name = "uxSalary";
            this.uxSalary.Size = new System.Drawing.Size(127, 26);
            this.uxSalary.TabIndex = 26;
            // 
            // uxID
            // 
            this.uxID.Enabled = false;
            this.uxID.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxID.Location = new System.Drawing.Point(137, 63);
            this.uxID.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.uxID.Name = "uxID";
            this.uxID.Size = new System.Drawing.Size(127, 26);
            this.uxID.TabIndex = 27;
            // 
            // uxAge
            // 
            this.uxAge.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxAge.Location = new System.Drawing.Point(137, 151);
            this.uxAge.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.uxAge.Name = "uxAge";
            this.uxAge.Size = new System.Drawing.Size(127, 26);
            this.uxAge.TabIndex = 29;
            // 
            // uxPositionOptions
            // 
            this.uxPositionOptions.Controls.Add(this.uxDefense);
            this.uxPositionOptions.Controls.Add(this.uxKicker);
            this.uxPositionOptions.Controls.Add(this.uxTightEnd);
            this.uxPositionOptions.Controls.Add(this.uxReceivers);
            this.uxPositionOptions.Controls.Add(this.uxRunningBacks);
            this.uxPositionOptions.Controls.Add(this.uxQuarterbacks);
            this.uxPositionOptions.Controls.Add(this.uxNoPosition);
            this.uxPositionOptions.Location = new System.Drawing.Point(271, 12);
            this.uxPositionOptions.Name = "uxPositionOptions";
            this.uxPositionOptions.Size = new System.Drawing.Size(162, 212);
            this.uxPositionOptions.TabIndex = 30;
            this.uxPositionOptions.TabStop = false;
            this.uxPositionOptions.Text = "Player Position";
            // 
            // uxDefense
            // 
            this.uxDefense.AutoSize = true;
            this.uxDefense.Location = new System.Drawing.Point(7, 184);
            this.uxDefense.Name = "uxDefense";
            this.uxDefense.Size = new System.Drawing.Size(65, 17);
            this.uxDefense.TabIndex = 6;
            this.uxDefense.Text = "Defense";
            this.uxDefense.UseVisualStyleBackColor = true;
            // 
            // uxKicker
            // 
            this.uxKicker.AutoSize = true;
            this.uxKicker.Location = new System.Drawing.Point(7, 157);
            this.uxKicker.Name = "uxKicker";
            this.uxKicker.Size = new System.Drawing.Size(55, 17);
            this.uxKicker.TabIndex = 5;
            this.uxKicker.Text = "Kicker";
            this.uxKicker.UseVisualStyleBackColor = true;
            // 
            // uxTightEnd
            // 
            this.uxTightEnd.AutoSize = true;
            this.uxTightEnd.Location = new System.Drawing.Point(7, 130);
            this.uxTightEnd.Name = "uxTightEnd";
            this.uxTightEnd.Size = new System.Drawing.Size(71, 17);
            this.uxTightEnd.TabIndex = 4;
            this.uxTightEnd.Text = "Tight End";
            this.uxTightEnd.UseVisualStyleBackColor = true;
            // 
            // uxReceivers
            // 
            this.uxReceivers.AutoSize = true;
            this.uxReceivers.Location = new System.Drawing.Point(7, 103);
            this.uxReceivers.Name = "uxReceivers";
            this.uxReceivers.Size = new System.Drawing.Size(96, 17);
            this.uxReceivers.TabIndex = 3;
            this.uxReceivers.Text = "Wide Receiver";
            this.uxReceivers.UseVisualStyleBackColor = true;
            // 
            // uxRunningBacks
            // 
            this.uxRunningBacks.AutoSize = true;
            this.uxRunningBacks.Location = new System.Drawing.Point(7, 76);
            this.uxRunningBacks.Name = "uxRunningBacks";
            this.uxRunningBacks.Size = new System.Drawing.Size(93, 17);
            this.uxRunningBacks.TabIndex = 2;
            this.uxRunningBacks.Text = "Running Back";
            this.uxRunningBacks.UseVisualStyleBackColor = true;
            // 
            // uxQuarterbacks
            // 
            this.uxQuarterbacks.AutoSize = true;
            this.uxQuarterbacks.Location = new System.Drawing.Point(7, 49);
            this.uxQuarterbacks.Name = "uxQuarterbacks";
            this.uxQuarterbacks.Size = new System.Drawing.Size(84, 17);
            this.uxQuarterbacks.TabIndex = 1;
            this.uxQuarterbacks.Text = "Quarterback";
            this.uxQuarterbacks.UseVisualStyleBackColor = true;
            // 
            // uxNoPosition
            // 
            this.uxNoPosition.AutoSize = true;
            this.uxNoPosition.Location = new System.Drawing.Point(7, 22);
            this.uxNoPosition.Name = "uxNoPosition";
            this.uxNoPosition.Size = new System.Drawing.Size(79, 17);
            this.uxNoPosition.TabIndex = 0;
            this.uxNoPosition.Text = "No Position";
            this.uxNoPosition.UseVisualStyleBackColor = true;
            // 
            // uxMFLTeam
            // 
            this.uxMFLTeam.Controls.Add(this.uxRam);
            this.uxMFLTeam.Controls.Add(this.uxPower);
            this.uxMFLTeam.Controls.Add(this.uxGorillas);
            this.uxMFLTeam.Controls.Add(this.uxNikeStorm);
            this.uxMFLTeam.Controls.Add(this.uxStormDynasty);
            this.uxMFLTeam.Controls.Add(this.uxOdbs);
            this.uxMFLTeam.Controls.Add(this.uxDactyls);
            this.uxMFLTeam.Controls.Add(this.uxBombers);
            this.uxMFLTeam.Controls.Add(this.uxPenguins);
            this.uxMFLTeam.Controls.Add(this.uxTornados);
            this.uxMFLTeam.Controls.Add(this.uxNoTeam);
            this.uxMFLTeam.Location = new System.Drawing.Point(439, 12);
            this.uxMFLTeam.Name = "uxMFLTeam";
            this.uxMFLTeam.Size = new System.Drawing.Size(188, 212);
            this.uxMFLTeam.TabIndex = 31;
            this.uxMFLTeam.TabStop = false;
            this.uxMFLTeam.Text = "MFL NFLTeam";
            // 
            // uxRam
            // 
            this.uxRam.AutoSize = true;
            this.uxRam.Location = new System.Drawing.Point(89, 157);
            this.uxRam.Name = "uxRam";
            this.uxRam.Size = new System.Drawing.Size(47, 17);
            this.uxRam.TabIndex = 10;
            this.uxRam.Text = "Ram";
            this.uxRam.UseVisualStyleBackColor = true;
            // 
            // uxPower
            // 
            this.uxPower.AutoSize = true;
            this.uxPower.Location = new System.Drawing.Point(89, 130);
            this.uxPower.Name = "uxPower";
            this.uxPower.Size = new System.Drawing.Size(55, 17);
            this.uxPower.TabIndex = 9;
            this.uxPower.Text = "Power";
            this.uxPower.UseVisualStyleBackColor = true;
            // 
            // uxGorillas
            // 
            this.uxGorillas.AutoSize = true;
            this.uxGorillas.Location = new System.Drawing.Point(89, 103);
            this.uxGorillas.Name = "uxGorillas";
            this.uxGorillas.Size = new System.Drawing.Size(59, 17);
            this.uxGorillas.TabIndex = 8;
            this.uxGorillas.Text = "Gorillas";
            this.uxGorillas.UseVisualStyleBackColor = true;
            // 
            // uxNikeStorm
            // 
            this.uxNikeStorm.AutoSize = true;
            this.uxNikeStorm.Location = new System.Drawing.Point(89, 76);
            this.uxNikeStorm.Name = "uxNikeStorm";
            this.uxNikeStorm.Size = new System.Drawing.Size(77, 17);
            this.uxNikeStorm.TabIndex = 7;
            this.uxNikeStorm.Text = "Nike Storm";
            this.uxNikeStorm.UseVisualStyleBackColor = true;
            // 
            // uxStormDynasty
            // 
            this.uxStormDynasty.AutoSize = true;
            this.uxStormDynasty.Location = new System.Drawing.Point(91, 49);
            this.uxStormDynasty.Name = "uxStormDynasty";
            this.uxStormDynasty.Size = new System.Drawing.Size(93, 17);
            this.uxStormDynasty.TabIndex = 6;
            this.uxStormDynasty.Text = "Storm Dynasty";
            this.uxStormDynasty.UseVisualStyleBackColor = true;
            // 
            // uxOdbs
            // 
            this.uxOdbs.AutoSize = true;
            this.uxOdbs.Location = new System.Drawing.Point(7, 157);
            this.uxOdbs.Name = "uxOdbs";
            this.uxOdbs.Size = new System.Drawing.Size(55, 17);
            this.uxOdbs.TabIndex = 5;
            this.uxOdbs.Text = "ODB\'s";
            this.uxOdbs.UseVisualStyleBackColor = true;
            // 
            // uxDactyls
            // 
            this.uxDactyls.AutoSize = true;
            this.uxDactyls.Location = new System.Drawing.Point(7, 130);
            this.uxDactyls.Name = "uxDactyls";
            this.uxDactyls.Size = new System.Drawing.Size(60, 17);
            this.uxDactyls.TabIndex = 4;
            this.uxDactyls.Text = "Dactyls";
            this.uxDactyls.UseVisualStyleBackColor = true;
            // 
            // uxBombers
            // 
            this.uxBombers.AutoSize = true;
            this.uxBombers.Location = new System.Drawing.Point(7, 103);
            this.uxBombers.Name = "uxBombers";
            this.uxBombers.Size = new System.Drawing.Size(66, 17);
            this.uxBombers.TabIndex = 3;
            this.uxBombers.Text = "Bombers";
            this.uxBombers.UseVisualStyleBackColor = true;
            // 
            // uxPenguins
            // 
            this.uxPenguins.AutoSize = true;
            this.uxPenguins.Location = new System.Drawing.Point(7, 76);
            this.uxPenguins.Name = "uxPenguins";
            this.uxPenguins.Size = new System.Drawing.Size(69, 17);
            this.uxPenguins.TabIndex = 2;
            this.uxPenguins.Text = "Penguins";
            this.uxPenguins.UseVisualStyleBackColor = true;
            // 
            // uxTornados
            // 
            this.uxTornados.AutoSize = true;
            this.uxTornados.Location = new System.Drawing.Point(7, 49);
            this.uxTornados.Name = "uxTornados";
            this.uxTornados.Size = new System.Drawing.Size(70, 17);
            this.uxTornados.TabIndex = 1;
            this.uxTornados.Text = "Tornados";
            this.uxTornados.UseVisualStyleBackColor = true;
            // 
            // uxNoTeam
            // 
            this.uxNoTeam.AutoSize = true;
            this.uxNoTeam.Location = new System.Drawing.Point(6, 26);
            this.uxNoTeam.Name = "uxNoTeam";
            this.uxNoTeam.Size = new System.Drawing.Size(77, 17);
            this.uxNoTeam.TabIndex = 0;
            this.uxNoTeam.Text = "Free Agent";
            this.uxNoTeam.UseVisualStyleBackColor = true;
            // 
            // PlayerEditor
            // 
            this.AcceptButton = this.uxSubmit;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(650, 251);
            this.Controls.Add(this.uxMFLTeam);
            this.Controls.Add(this.uxPositionOptions);
            this.Controls.Add(this.uxAge);
            this.Controls.Add(this.uxID);
            this.Controls.Add(this.uxSalary);
            this.Controls.Add(this.uxContractYear);
            this.Controls.Add(this.uxPlayerName);
            this.Controls.Add(this.lblAge);
            this.Controls.Add(this.lblContractYear);
            this.Controls.Add(this.lblID);
            this.Controls.Add(this.lblSalary);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.uxSubmit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.Name = "PlayerEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Player Editor";
            ((System.ComponentModel.ISupportInitialize)(this.uxSalary)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uxID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uxAge)).EndInit();
            this.uxPositionOptions.ResumeLayout(false);
            this.uxPositionOptions.PerformLayout();
            this.uxMFLTeam.ResumeLayout(false);
            this.uxMFLTeam.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button uxSubmit;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblSalary;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Label lblContractYear;
        private System.Windows.Forms.Label lblAge;
        private System.Windows.Forms.TextBox uxPlayerName;
        private System.Windows.Forms.ComboBox uxContractYear;
        private System.Windows.Forms.NumericUpDown uxSalary;
        private System.Windows.Forms.NumericUpDown uxID;
        private System.Windows.Forms.NumericUpDown uxAge;
        private System.Windows.Forms.GroupBox uxPositionOptions;
        private System.Windows.Forms.RadioButton uxDefense;
        private System.Windows.Forms.RadioButton uxKicker;
        private System.Windows.Forms.RadioButton uxTightEnd;
        private System.Windows.Forms.RadioButton uxReceivers;
        private System.Windows.Forms.RadioButton uxRunningBacks;
        private System.Windows.Forms.RadioButton uxQuarterbacks;
        private System.Windows.Forms.RadioButton uxNoPosition;
        private System.Windows.Forms.GroupBox uxMFLTeam;
        private System.Windows.Forms.RadioButton uxRam;
        private System.Windows.Forms.RadioButton uxPower;
        private System.Windows.Forms.RadioButton uxGorillas;
        private System.Windows.Forms.RadioButton uxNikeStorm;
        private System.Windows.Forms.RadioButton uxStormDynasty;
        private System.Windows.Forms.RadioButton uxOdbs;
        private System.Windows.Forms.RadioButton uxDactyls;
        private System.Windows.Forms.RadioButton uxBombers;
        private System.Windows.Forms.RadioButton uxPenguins;
        private System.Windows.Forms.RadioButton uxTornados;
        private System.Windows.Forms.RadioButton uxNoTeam;
    }
}