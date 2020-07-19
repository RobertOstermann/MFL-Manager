namespace MFL_Manager
{
    partial class Manager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Manager));
            this.uxMenuStrip = new System.Windows.Forms.MenuStrip();
            this.uxFile = new System.Windows.Forms.ToolStripMenuItem();
            this.uxNew = new System.Windows.Forms.ToolStripMenuItem();
            this.uxLoad = new System.Windows.Forms.ToolStripMenuItem();
            this.uxLocal = new System.Windows.Forms.ToolStripMenuItem();
            this.uxMFL = new System.Windows.Forms.ToolStripMenuItem();
            this.uxSave = new System.Windows.Forms.ToolStripMenuItem();
            this.uxEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.uxEditPlayer = new System.Windows.Forms.ToolStripMenuItem();
            this.uxCreatePlayer = new System.Windows.Forms.ToolStripMenuItem();
            this.uxEditCapHit = new System.Windows.Forms.ToolStripMenuItem();
            this.uxEditCapRoom = new System.Windows.Forms.ToolStripMenuItem();
            this.uxView = new System.Windows.Forms.ToolStripMenuItem();
            this.uxQuestion = new System.Windows.Forms.ToolStripMenuItem();
            this.uxMFLTeam = new System.Windows.Forms.ToolStripMenuItem();
            this.uxRetrieve = new System.Windows.Forms.ToolStripMenuItem();
            this.uxPlayerRankings = new System.Windows.Forms.ToolStripMenuItem();
            this.uxPlayers = new System.Windows.Forms.ListBox();
            this.uxCurrentRoster = new System.Windows.Forms.ListBox();
            this.uxOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.uxSaveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.lblTeamName = new System.Windows.Forms.Label();
            this.uxFilterOptions = new System.Windows.Forms.GroupBox();
            this.uxRosterPlayers = new System.Windows.Forms.CheckBox();
            this.uxFreeAgents = new System.Windows.Forms.CheckBox();
            this.uxDefense = new System.Windows.Forms.RadioButton();
            this.uxKickers = new System.Windows.Forms.RadioButton();
            this.uxTightEnd = new System.Windows.Forms.RadioButton();
            this.uxReceivers = new System.Windows.Forms.RadioButton();
            this.uxRunningBacks = new System.Windows.Forms.RadioButton();
            this.uxQuarterbacks = new System.Windows.Forms.RadioButton();
            this.uxAllPlayers = new System.Windows.Forms.RadioButton();
            this.uxFilterPlayer = new System.Windows.Forms.Button();
            this.uxRemovePlayer = new System.Windows.Forms.Button();
            this.uxAddPlayer = new System.Windows.Forms.Button();
            this.uxChangePlayer = new System.Windows.Forms.Button();
            this.lblCapHitLabel = new System.Windows.Forms.Label();
            this.lblCapHit = new System.Windows.Forms.Label();
            this.lblCapRoomLabel = new System.Windows.Forms.Label();
            this.lblCapRoom = new System.Windows.Forms.Label();
            this.uxPlayerNameLabel = new System.Windows.Forms.Label();
            this.uxSalaryLabel = new System.Windows.Forms.Label();
            this.uxRankLabel = new System.Windows.Forms.Label();
            this.uxContractYearLabel = new System.Windows.Forms.Label();
            this.lblSalaryLabel = new System.Windows.Forms.Label();
            this.lblSalary = new System.Windows.Forms.Label();
            this.uxMenuStrip.SuspendLayout();
            this.uxFilterOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // uxMenuStrip
            // 
            this.uxMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.uxMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uxFile,
            this.uxEdit,
            this.uxView,
            this.uxMFLTeam,
            this.uxRetrieve});
            this.uxMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.uxMenuStrip.Name = "uxMenuStrip";
            this.uxMenuStrip.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.uxMenuStrip.Size = new System.Drawing.Size(1437, 28);
            this.uxMenuStrip.TabIndex = 0;
            // 
            // uxFile
            // 
            this.uxFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uxNew,
            this.uxLoad,
            this.uxSave});
            this.uxFile.Name = "uxFile";
            this.uxFile.Size = new System.Drawing.Size(44, 24);
            this.uxFile.Text = "File";
            // 
            // uxNew
            // 
            this.uxNew.Name = "uxNew";
            this.uxNew.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.uxNew.Size = new System.Drawing.Size(167, 26);
            this.uxNew.Text = "New";
            this.uxNew.Click += new System.EventHandler(this.uxNew_Click);
            // 
            // uxLoad
            // 
            this.uxLoad.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uxLocal,
            this.uxMFL});
            this.uxLoad.Name = "uxLoad";
            this.uxLoad.Size = new System.Drawing.Size(167, 26);
            this.uxLoad.Text = "Load";
            // 
            // uxLocal
            // 
            this.uxLocal.Name = "uxLocal";
            this.uxLocal.Size = new System.Drawing.Size(119, 26);
            this.uxLocal.Text = "Local";
            this.uxLocal.Click += new System.EventHandler(this.uxLocal_Click);
            // 
            // uxMFL
            // 
            this.uxMFL.Name = "uxMFL";
            this.uxMFL.Size = new System.Drawing.Size(119, 26);
            this.uxMFL.Text = "MFL";
            this.uxMFL.Click += new System.EventHandler(this.uxMFL_Click);
            // 
            // uxSave
            // 
            this.uxSave.Name = "uxSave";
            this.uxSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.uxSave.Size = new System.Drawing.Size(167, 26);
            this.uxSave.Text = "Save";
            this.uxSave.Click += new System.EventHandler(this.uxSave_Click);
            // 
            // uxEdit
            // 
            this.uxEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uxEditPlayer,
            this.uxCreatePlayer,
            this.uxEditCapHit,
            this.uxEditCapRoom});
            this.uxEdit.Enabled = false;
            this.uxEdit.Name = "uxEdit";
            this.uxEdit.Size = new System.Drawing.Size(47, 24);
            this.uxEdit.Text = "Edit";
            // 
            // uxEditPlayer
            // 
            this.uxEditPlayer.Name = "uxEditPlayer";
            this.uxEditPlayer.Size = new System.Drawing.Size(171, 26);
            this.uxEditPlayer.Text = "Edit Player";
            this.uxEditPlayer.Click += new System.EventHandler(this.uxEditPlayer_Click);
            // 
            // uxCreatePlayer
            // 
            this.uxCreatePlayer.Name = "uxCreatePlayer";
            this.uxCreatePlayer.Size = new System.Drawing.Size(171, 26);
            this.uxCreatePlayer.Text = "Create Player";
            this.uxCreatePlayer.Click += new System.EventHandler(this.uxCreatePlayer_Click);
            // 
            // uxEditCapHit
            // 
            this.uxEditCapHit.Name = "uxEditCapHit";
            this.uxEditCapHit.Size = new System.Drawing.Size(171, 26);
            this.uxEditCapHit.Text = "Cap Hit";
            this.uxEditCapHit.Click += new System.EventHandler(this.uxEditCapHit_Click);
            // 
            // uxEditCapRoom
            // 
            this.uxEditCapRoom.Name = "uxEditCapRoom";
            this.uxEditCapRoom.Size = new System.Drawing.Size(171, 26);
            this.uxEditCapRoom.Text = "Cap Room";
            this.uxEditCapRoom.Click += new System.EventHandler(this.uxEditCapRoom_Click);
            // 
            // uxView
            // 
            this.uxView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uxQuestion});
            this.uxView.Enabled = false;
            this.uxView.Name = "uxView";
            this.uxView.Size = new System.Drawing.Size(53, 24);
            this.uxView.Text = "View";
            // 
            // uxQuestion
            // 
            this.uxQuestion.Name = "uxQuestion";
            this.uxQuestion.Size = new System.Drawing.Size(91, 26);
            this.uxQuestion.Text = "?";
            // 
            // uxMFLTeam
            // 
            this.uxMFLTeam.Enabled = false;
            this.uxMFLTeam.Name = "uxMFLTeam";
            this.uxMFLTeam.Size = new System.Drawing.Size(83, 24);
            this.uxMFLTeam.Text = "MFLTeam";
            // 
            // uxRetrieve
            // 
            this.uxRetrieve.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uxPlayerRankings});
            this.uxRetrieve.Enabled = false;
            this.uxRetrieve.Name = "uxRetrieve";
            this.uxRetrieve.Size = new System.Drawing.Size(75, 24);
            this.uxRetrieve.Text = "Retrieve";
            // 
            // uxPlayerRankings
            // 
            this.uxPlayerRankings.Name = "uxPlayerRankings";
            this.uxPlayerRankings.Size = new System.Drawing.Size(187, 26);
            this.uxPlayerRankings.Text = "Player Rankings";
            this.uxPlayerRankings.Click += new System.EventHandler(this.uxPlayerRankings_Click);
            // 
            // uxPlayers
            // 
            this.uxPlayers.Font = new System.Drawing.Font("Consolas", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxPlayers.FormattingEnabled = true;
            this.uxPlayers.ItemHeight = 22;
            this.uxPlayers.Location = new System.Drawing.Point(16, 105);
            this.uxPlayers.Margin = new System.Windows.Forms.Padding(4);
            this.uxPlayers.Name = "uxPlayers";
            this.uxPlayers.Size = new System.Drawing.Size(532, 444);
            this.uxPlayers.TabIndex = 1;
            this.uxPlayers.Click += new System.EventHandler(this.uxPlayers_Click);
            this.uxPlayers.DataSourceChanged += new System.EventHandler(this.uxPlayers_DataSourceChanged);
            // 
            // uxCurrentRoster
            // 
            this.uxCurrentRoster.Font = new System.Drawing.Font("Consolas", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxCurrentRoster.FormattingEnabled = true;
            this.uxCurrentRoster.ItemHeight = 22;
            this.uxCurrentRoster.Location = new System.Drawing.Point(887, 105);
            this.uxCurrentRoster.Margin = new System.Windows.Forms.Padding(4);
            this.uxCurrentRoster.Name = "uxCurrentRoster";
            this.uxCurrentRoster.Size = new System.Drawing.Size(532, 444);
            this.uxCurrentRoster.TabIndex = 2;
            this.uxCurrentRoster.Click += new System.EventHandler(this.uxCurrentRoster_Click);
            // 
            // lblTeamName
            // 
            this.lblTeamName.Font = new System.Drawing.Font("Stencil", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTeamName.Location = new System.Drawing.Point(887, 30);
            this.lblTeamName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTeamName.Name = "lblTeamName";
            this.lblTeamName.Size = new System.Drawing.Size(533, 71);
            this.lblTeamName.TabIndex = 3;
            this.lblTeamName.Text = "MFL NFLTeam Name";
            this.lblTeamName.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // uxFilterOptions
            // 
            this.uxFilterOptions.Controls.Add(this.uxRosterPlayers);
            this.uxFilterOptions.Controls.Add(this.uxFreeAgents);
            this.uxFilterOptions.Controls.Add(this.uxDefense);
            this.uxFilterOptions.Controls.Add(this.uxKickers);
            this.uxFilterOptions.Controls.Add(this.uxTightEnd);
            this.uxFilterOptions.Controls.Add(this.uxReceivers);
            this.uxFilterOptions.Controls.Add(this.uxRunningBacks);
            this.uxFilterOptions.Controls.Add(this.uxQuarterbacks);
            this.uxFilterOptions.Controls.Add(this.uxAllPlayers);
            this.uxFilterOptions.Controls.Add(this.uxFilterPlayer);
            this.uxFilterOptions.Enabled = false;
            this.uxFilterOptions.Location = new System.Drawing.Point(557, 105);
            this.uxFilterOptions.Margin = new System.Windows.Forms.Padding(4);
            this.uxFilterOptions.Name = "uxFilterOptions";
            this.uxFilterOptions.Padding = new System.Windows.Forms.Padding(4);
            this.uxFilterOptions.Size = new System.Drawing.Size(321, 281);
            this.uxFilterOptions.TabIndex = 4;
            this.uxFilterOptions.TabStop = false;
            this.uxFilterOptions.Text = "Filter Options:";
            // 
            // uxRosterPlayers
            // 
            this.uxRosterPlayers.AutoSize = true;
            this.uxRosterPlayers.Checked = true;
            this.uxRosterPlayers.CheckState = System.Windows.Forms.CheckState.Checked;
            this.uxRosterPlayers.Location = new System.Drawing.Point(188, 60);
            this.uxRosterPlayers.Margin = new System.Windows.Forms.Padding(4);
            this.uxRosterPlayers.Name = "uxRosterPlayers";
            this.uxRosterPlayers.Size = new System.Drawing.Size(123, 21);
            this.uxRosterPlayers.TabIndex = 10;
            this.uxRosterPlayers.Text = "Roster Players";
            this.uxRosterPlayers.UseVisualStyleBackColor = true;
            // 
            // uxFreeAgents
            // 
            this.uxFreeAgents.AutoSize = true;
            this.uxFreeAgents.Checked = true;
            this.uxFreeAgents.CheckState = System.Windows.Forms.CheckState.Checked;
            this.uxFreeAgents.Location = new System.Drawing.Point(188, 27);
            this.uxFreeAgents.Margin = new System.Windows.Forms.Padding(4);
            this.uxFreeAgents.Name = "uxFreeAgents";
            this.uxFreeAgents.Size = new System.Drawing.Size(107, 21);
            this.uxFreeAgents.TabIndex = 9;
            this.uxFreeAgents.Text = "Free Agents";
            this.uxFreeAgents.UseVisualStyleBackColor = true;
            // 
            // uxDefense
            // 
            this.uxDefense.AutoSize = true;
            this.uxDefense.Location = new System.Drawing.Point(9, 226);
            this.uxDefense.Margin = new System.Windows.Forms.Padding(4);
            this.uxDefense.Name = "uxDefense";
            this.uxDefense.Size = new System.Drawing.Size(82, 21);
            this.uxDefense.TabIndex = 6;
            this.uxDefense.Text = "Defense";
            this.uxDefense.UseVisualStyleBackColor = true;
            // 
            // uxKickers
            // 
            this.uxKickers.AutoSize = true;
            this.uxKickers.Location = new System.Drawing.Point(9, 193);
            this.uxKickers.Margin = new System.Windows.Forms.Padding(4);
            this.uxKickers.Name = "uxKickers";
            this.uxKickers.Size = new System.Drawing.Size(75, 21);
            this.uxKickers.TabIndex = 5;
            this.uxKickers.Text = "Kickers";
            this.uxKickers.UseVisualStyleBackColor = true;
            // 
            // uxTightEnd
            // 
            this.uxTightEnd.AutoSize = true;
            this.uxTightEnd.Location = new System.Drawing.Point(9, 160);
            this.uxTightEnd.Margin = new System.Windows.Forms.Padding(4);
            this.uxTightEnd.Name = "uxTightEnd";
            this.uxTightEnd.Size = new System.Drawing.Size(97, 21);
            this.uxTightEnd.TabIndex = 4;
            this.uxTightEnd.Text = "Tight Ends";
            this.uxTightEnd.UseVisualStyleBackColor = true;
            // 
            // uxReceivers
            // 
            this.uxReceivers.AutoSize = true;
            this.uxReceivers.Location = new System.Drawing.Point(9, 127);
            this.uxReceivers.Margin = new System.Windows.Forms.Padding(4);
            this.uxReceivers.Name = "uxReceivers";
            this.uxReceivers.Size = new System.Drawing.Size(128, 21);
            this.uxReceivers.TabIndex = 3;
            this.uxReceivers.Text = "Wide Receivers";
            this.uxReceivers.UseVisualStyleBackColor = true;
            // 
            // uxRunningBacks
            // 
            this.uxRunningBacks.AutoSize = true;
            this.uxRunningBacks.Location = new System.Drawing.Point(9, 94);
            this.uxRunningBacks.Margin = new System.Windows.Forms.Padding(4);
            this.uxRunningBacks.Name = "uxRunningBacks";
            this.uxRunningBacks.Size = new System.Drawing.Size(124, 21);
            this.uxRunningBacks.TabIndex = 2;
            this.uxRunningBacks.Text = "Running Backs";
            this.uxRunningBacks.UseVisualStyleBackColor = true;
            // 
            // uxQuarterbacks
            // 
            this.uxQuarterbacks.AutoSize = true;
            this.uxQuarterbacks.Location = new System.Drawing.Point(9, 60);
            this.uxQuarterbacks.Margin = new System.Windows.Forms.Padding(4);
            this.uxQuarterbacks.Name = "uxQuarterbacks";
            this.uxQuarterbacks.Size = new System.Drawing.Size(115, 21);
            this.uxQuarterbacks.TabIndex = 1;
            this.uxQuarterbacks.Text = "Quarterbacks";
            this.uxQuarterbacks.UseVisualStyleBackColor = true;
            // 
            // uxAllPlayers
            // 
            this.uxAllPlayers.AutoSize = true;
            this.uxAllPlayers.Checked = true;
            this.uxAllPlayers.Location = new System.Drawing.Point(9, 27);
            this.uxAllPlayers.Margin = new System.Windows.Forms.Padding(4);
            this.uxAllPlayers.Name = "uxAllPlayers";
            this.uxAllPlayers.Size = new System.Drawing.Size(95, 21);
            this.uxAllPlayers.TabIndex = 0;
            this.uxAllPlayers.TabStop = true;
            this.uxAllPlayers.Text = "All Players";
            this.uxAllPlayers.UseVisualStyleBackColor = true;
            // 
            // uxFilterPlayer
            // 
            this.uxFilterPlayer.Enabled = false;
            this.uxFilterPlayer.Location = new System.Drawing.Point(159, 193);
            this.uxFilterPlayer.Margin = new System.Windows.Forms.Padding(4);
            this.uxFilterPlayer.Name = "uxFilterPlayer";
            this.uxFilterPlayer.Size = new System.Drawing.Size(163, 59);
            this.uxFilterPlayer.TabIndex = 8;
            this.uxFilterPlayer.Text = "Filter Players";
            this.uxFilterPlayer.UseVisualStyleBackColor = true;
            this.uxFilterPlayer.Click += new System.EventHandler(this.uxFilterPlayer_Click);
            // 
            // uxRemovePlayer
            // 
            this.uxRemovePlayer.Enabled = false;
            this.uxRemovePlayer.Location = new System.Drawing.Point(557, 463);
            this.uxRemovePlayer.Margin = new System.Windows.Forms.Padding(4);
            this.uxRemovePlayer.Name = "uxRemovePlayer";
            this.uxRemovePlayer.Size = new System.Drawing.Size(321, 50);
            this.uxRemovePlayer.TabIndex = 11;
            this.uxRemovePlayer.Text = "Remove Selected Player";
            this.uxRemovePlayer.UseVisualStyleBackColor = true;
            this.uxRemovePlayer.Click += new System.EventHandler(this.uxRemovePlayer_Click);
            // 
            // uxAddPlayer
            // 
            this.uxAddPlayer.Enabled = false;
            this.uxAddPlayer.Location = new System.Drawing.Point(557, 405);
            this.uxAddPlayer.Margin = new System.Windows.Forms.Padding(4);
            this.uxAddPlayer.Name = "uxAddPlayer";
            this.uxAddPlayer.Size = new System.Drawing.Size(321, 50);
            this.uxAddPlayer.TabIndex = 10;
            this.uxAddPlayer.Text = "Add Selected Player";
            this.uxAddPlayer.UseVisualStyleBackColor = true;
            this.uxAddPlayer.Click += new System.EventHandler(this.uxAddPlayer_Click);
            // 
            // uxChangePlayer
            // 
            this.uxChangePlayer.Enabled = false;
            this.uxChangePlayer.Location = new System.Drawing.Point(557, 521);
            this.uxChangePlayer.Margin = new System.Windows.Forms.Padding(4);
            this.uxChangePlayer.Name = "uxChangePlayer";
            this.uxChangePlayer.Size = new System.Drawing.Size(321, 50);
            this.uxChangePlayer.TabIndex = 18;
            this.uxChangePlayer.Text = "Edit Selected Player";
            this.uxChangePlayer.UseVisualStyleBackColor = true;
            this.uxChangePlayer.Click += new System.EventHandler(this.uxEditPlayer_Click);
            // 
            // lblCapHitLabel
            // 
            this.lblCapHitLabel.Font = new System.Drawing.Font("Stencil", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCapHitLabel.Location = new System.Drawing.Point(556, 612);
            this.lblCapHitLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCapHitLabel.Name = "lblCapHitLabel";
            this.lblCapHitLabel.Size = new System.Drawing.Size(141, 36);
            this.lblCapHitLabel.TabIndex = 19;
            this.lblCapHitLabel.Text = "Cap Hit";
            this.lblCapHitLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCapHit
            // 
            this.lblCapHit.Font = new System.Drawing.Font("Stencil", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCapHit.Location = new System.Drawing.Point(705, 612);
            this.lblCapHit.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCapHit.Name = "lblCapHit";
            this.lblCapHit.Size = new System.Drawing.Size(161, 36);
            this.lblCapHit.TabIndex = 20;
            this.lblCapHit.Text = "$0.00 ";
            this.lblCapHit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCapRoomLabel
            // 
            this.lblCapRoomLabel.Font = new System.Drawing.Font("Stencil", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCapRoomLabel.Location = new System.Drawing.Point(1080, 612);
            this.lblCapRoomLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCapRoomLabel.Name = "lblCapRoomLabel";
            this.lblCapRoomLabel.Size = new System.Drawing.Size(172, 36);
            this.lblCapRoomLabel.TabIndex = 21;
            this.lblCapRoomLabel.Text = "Cap Room";
            this.lblCapRoomLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCapRoom
            // 
            this.lblCapRoom.Font = new System.Drawing.Font("Stencil", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCapRoom.Location = new System.Drawing.Point(1260, 612);
            this.lblCapRoom.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCapRoom.Name = "lblCapRoom";
            this.lblCapRoom.Size = new System.Drawing.Size(161, 36);
            this.lblCapRoom.TabIndex = 22;
            this.lblCapRoom.Text = "$125.00 ";
            this.lblCapRoom.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // uxPlayerNameLabel
            // 
            this.uxPlayerNameLabel.AutoSize = true;
            this.uxPlayerNameLabel.Enabled = false;
            this.uxPlayerNameLabel.Font = new System.Drawing.Font("Stencil", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxPlayerNameLabel.Location = new System.Drawing.Point(12, 78);
            this.uxPlayerNameLabel.Name = "uxPlayerNameLabel";
            this.uxPlayerNameLabel.Size = new System.Drawing.Size(63, 24);
            this.uxPlayerNameLabel.TabIndex = 23;
            this.uxPlayerNameLabel.Text = "Name";
            this.uxPlayerNameLabel.Click += new System.EventHandler(this.uxSortLabel_Click);
            // 
            // uxSalaryLabel
            // 
            this.uxSalaryLabel.AutoSize = true;
            this.uxSalaryLabel.Enabled = false;
            this.uxSalaryLabel.Font = new System.Drawing.Font("Stencil", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxSalaryLabel.Location = new System.Drawing.Point(359, 78);
            this.uxSalaryLabel.Name = "uxSalaryLabel";
            this.uxSalaryLabel.Size = new System.Drawing.Size(82, 24);
            this.uxSalaryLabel.TabIndex = 24;
            this.uxSalaryLabel.Text = "Salary";
            this.uxSalaryLabel.Click += new System.EventHandler(this.uxSortLabel_Click);
            // 
            // uxRankLabel
            // 
            this.uxRankLabel.AutoSize = true;
            this.uxRankLabel.Enabled = false;
            this.uxRankLabel.Font = new System.Drawing.Font("Stencil", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxRankLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.uxRankLabel.Location = new System.Drawing.Point(284, 78);
            this.uxRankLabel.Name = "uxRankLabel";
            this.uxRankLabel.Size = new System.Drawing.Size(64, 24);
            this.uxRankLabel.TabIndex = 25;
            this.uxRankLabel.Text = "Rank";
            this.uxRankLabel.Click += new System.EventHandler(this.uxSortLabel_Click);
            // 
            // uxContractYearLabel
            // 
            this.uxContractYearLabel.AutoSize = true;
            this.uxContractYearLabel.Enabled = false;
            this.uxContractYearLabel.Font = new System.Drawing.Font("Stencil", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxContractYearLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.uxContractYearLabel.Location = new System.Drawing.Point(473, 78);
            this.uxContractYearLabel.Name = "uxContractYearLabel";
            this.uxContractYearLabel.Size = new System.Drawing.Size(60, 24);
            this.uxContractYearLabel.TabIndex = 26;
            this.uxContractYearLabel.Text = "Year";
            this.uxContractYearLabel.Click += new System.EventHandler(this.uxSortLabel_Click);
            // 
            // lblSalaryLabel
            // 
            this.lblSalaryLabel.Font = new System.Drawing.Font("Stencil", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSalaryLabel.Location = new System.Drawing.Point(16, 612);
            this.lblSalaryLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSalaryLabel.Name = "lblSalaryLabel";
            this.lblSalaryLabel.Size = new System.Drawing.Size(141, 36);
            this.lblSalaryLabel.TabIndex = 27;
            this.lblSalaryLabel.Text = "Salary";
            this.lblSalaryLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSalary
            // 
            this.lblSalary.Font = new System.Drawing.Font("Stencil", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSalary.Location = new System.Drawing.Point(164, 612);
            this.lblSalary.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSalary.Name = "lblSalary";
            this.lblSalary.Size = new System.Drawing.Size(161, 36);
            this.lblSalary.TabIndex = 28;
            this.lblSalary.Text = "$0.00 ";
            this.lblSalary.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Manager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1437, 658);
            this.Controls.Add(this.lblSalary);
            this.Controls.Add(this.lblSalaryLabel);
            this.Controls.Add(this.uxContractYearLabel);
            this.Controls.Add(this.uxRankLabel);
            this.Controls.Add(this.uxSalaryLabel);
            this.Controls.Add(this.uxPlayerNameLabel);
            this.Controls.Add(this.lblCapRoom);
            this.Controls.Add(this.lblCapRoomLabel);
            this.Controls.Add(this.lblCapHit);
            this.Controls.Add(this.lblCapHitLabel);
            this.Controls.Add(this.uxChangePlayer);
            this.Controls.Add(this.uxRemovePlayer);
            this.Controls.Add(this.uxAddPlayer);
            this.Controls.Add(this.uxFilterOptions);
            this.Controls.Add(this.lblTeamName);
            this.Controls.Add(this.uxCurrentRoster);
            this.Controls.Add(this.uxPlayers);
            this.Controls.Add(this.uxMenuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.uxMenuStrip;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "Manager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MFL Manager";
            this.uxMenuStrip.ResumeLayout(false);
            this.uxMenuStrip.PerformLayout();
            this.uxFilterOptions.ResumeLayout(false);
            this.uxFilterOptions.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip uxMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem uxFile;
        private System.Windows.Forms.ToolStripMenuItem uxNew;
        private System.Windows.Forms.ToolStripMenuItem uxLoad;
        private System.Windows.Forms.ToolStripMenuItem uxLocal;
        private System.Windows.Forms.ToolStripMenuItem uxMFL;
        private System.Windows.Forms.ToolStripMenuItem uxSave;
        private System.Windows.Forms.ToolStripMenuItem uxEdit;
        private System.Windows.Forms.ToolStripMenuItem uxEditPlayer;
        private System.Windows.Forms.ToolStripMenuItem uxCreatePlayer;
        private System.Windows.Forms.ToolStripMenuItem uxEditCapHit;
        private System.Windows.Forms.ToolStripMenuItem uxEditCapRoom;
        private System.Windows.Forms.ToolStripMenuItem uxView;
        private System.Windows.Forms.ToolStripMenuItem uxMFLTeam;
        private System.Windows.Forms.ToolStripMenuItem uxRetrieve;
        private System.Windows.Forms.ToolStripMenuItem uxQuestion;
        private System.Windows.Forms.ListBox uxPlayers;
        private System.Windows.Forms.ListBox uxCurrentRoster;
        private System.Windows.Forms.OpenFileDialog uxOpenFileDialog;
        private System.Windows.Forms.SaveFileDialog uxSaveFileDialog;
        private System.Windows.Forms.Label lblTeamName;
        private System.Windows.Forms.GroupBox uxFilterOptions;
        private System.Windows.Forms.RadioButton uxDefense;
        private System.Windows.Forms.RadioButton uxKickers;
        private System.Windows.Forms.RadioButton uxTightEnd;
        private System.Windows.Forms.RadioButton uxReceivers;
        private System.Windows.Forms.RadioButton uxRunningBacks;
        private System.Windows.Forms.RadioButton uxQuarterbacks;
        private System.Windows.Forms.RadioButton uxAllPlayers;
        private System.Windows.Forms.Button uxFilterPlayer;
        private System.Windows.Forms.Button uxRemovePlayer;
        private System.Windows.Forms.Button uxAddPlayer;
        private System.Windows.Forms.Button uxChangePlayer;
        private System.Windows.Forms.Label lblCapHitLabel;
        private System.Windows.Forms.Label lblCapHit;
        private System.Windows.Forms.Label lblCapRoomLabel;
        private System.Windows.Forms.Label lblCapRoom;
        private System.Windows.Forms.Label uxPlayerNameLabel;
        private System.Windows.Forms.Label uxSalaryLabel;
        private System.Windows.Forms.Label uxRankLabel;
        private System.Windows.Forms.Label uxContractYearLabel;
        private System.Windows.Forms.Label lblSalaryLabel;
        private System.Windows.Forms.Label lblSalary;
        private System.Windows.Forms.ToolStripMenuItem uxPlayerRankings;
        private System.Windows.Forms.CheckBox uxRosterPlayers;
        private System.Windows.Forms.CheckBox uxFreeAgents;
    }
}

