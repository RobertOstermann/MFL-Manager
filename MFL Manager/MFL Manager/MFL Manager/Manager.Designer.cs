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
            this.uxTeam = new System.Windows.Forms.ToolStripMenuItem();
            this.uxAFC = new System.Windows.Forms.ToolStripMenuItem();
            this.uxTornados = new System.Windows.Forms.ToolStripMenuItem();
            this.uxPenguins = new System.Windows.Forms.ToolStripMenuItem();
            this.uxBombers = new System.Windows.Forms.ToolStripMenuItem();
            this.uxDactyls = new System.Windows.Forms.ToolStripMenuItem();
            this.uxODBs = new System.Windows.Forms.ToolStripMenuItem();
            this.uxNFC = new System.Windows.Forms.ToolStripMenuItem();
            this.uxStormDynasty = new System.Windows.Forms.ToolStripMenuItem();
            this.uxNikeStorm = new System.Windows.Forms.ToolStripMenuItem();
            this.uxGorillas = new System.Windows.Forms.ToolStripMenuItem();
            this.uxPower = new System.Windows.Forms.ToolStripMenuItem();
            this.uxRam = new System.Windows.Forms.ToolStripMenuItem();
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
            this.uxTeam,
            this.uxRetrieve});
            this.uxMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.uxMenuStrip.Name = "uxMenuStrip";
            this.uxMenuStrip.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.uxMenuStrip.Size = new System.Drawing.Size(1078, 24);
            this.uxMenuStrip.TabIndex = 0;
            // 
            // uxFile
            // 
            this.uxFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uxNew,
            this.uxLoad,
            this.uxSave});
            this.uxFile.Name = "uxFile";
            this.uxFile.Size = new System.Drawing.Size(37, 20);
            this.uxFile.Text = "File";
            // 
            // uxNew
            // 
            this.uxNew.Name = "uxNew";
            this.uxNew.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.uxNew.Size = new System.Drawing.Size(141, 22);
            this.uxNew.Text = "New";
            this.uxNew.Click += new System.EventHandler(this.uxNew_Click);
            // 
            // uxLoad
            // 
            this.uxLoad.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uxLocal,
            this.uxMFL});
            this.uxLoad.Name = "uxLoad";
            this.uxLoad.Size = new System.Drawing.Size(141, 22);
            this.uxLoad.Text = "Load";
            // 
            // uxLocal
            // 
            this.uxLocal.Name = "uxLocal";
            this.uxLocal.Size = new System.Drawing.Size(102, 22);
            this.uxLocal.Text = "Local";
            this.uxLocal.Click += new System.EventHandler(this.uxLocal_Click);
            // 
            // uxMFL
            // 
            this.uxMFL.Name = "uxMFL";
            this.uxMFL.Size = new System.Drawing.Size(102, 22);
            this.uxMFL.Text = "MFL";
            this.uxMFL.Click += new System.EventHandler(this.uxMFL_Click);
            // 
            // uxSave
            // 
            this.uxSave.Name = "uxSave";
            this.uxSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.uxSave.Size = new System.Drawing.Size(141, 22);
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
            this.uxEdit.Size = new System.Drawing.Size(39, 20);
            this.uxEdit.Text = "Edit";
            // 
            // uxEditPlayer
            // 
            this.uxEditPlayer.Name = "uxEditPlayer";
            this.uxEditPlayer.Size = new System.Drawing.Size(143, 22);
            this.uxEditPlayer.Text = "Edit Player";
            this.uxEditPlayer.Click += new System.EventHandler(this.uxEditPlayer_Click);
            // 
            // uxCreatePlayer
            // 
            this.uxCreatePlayer.Name = "uxCreatePlayer";
            this.uxCreatePlayer.Size = new System.Drawing.Size(143, 22);
            this.uxCreatePlayer.Text = "Create Player";
            this.uxCreatePlayer.Click += new System.EventHandler(this.uxCreatePlayer_Click);
            // 
            // uxEditCapHit
            // 
            this.uxEditCapHit.Name = "uxEditCapHit";
            this.uxEditCapHit.Size = new System.Drawing.Size(143, 22);
            this.uxEditCapHit.Text = "Cap Hit";
            this.uxEditCapHit.Click += new System.EventHandler(this.uxEditCapHit_Click);
            // 
            // uxEditCapRoom
            // 
            this.uxEditCapRoom.Name = "uxEditCapRoom";
            this.uxEditCapRoom.Size = new System.Drawing.Size(143, 22);
            this.uxEditCapRoom.Text = "Cap Room";
            this.uxEditCapRoom.Click += new System.EventHandler(this.uxEditCapRoom_Click);
            // 
            // uxView
            // 
            this.uxView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uxQuestion});
            this.uxView.Enabled = false;
            this.uxView.Name = "uxView";
            this.uxView.Size = new System.Drawing.Size(44, 20);
            this.uxView.Text = "View";
            // 
            // uxQuestion
            // 
            this.uxQuestion.Name = "uxQuestion";
            this.uxQuestion.Size = new System.Drawing.Size(79, 22);
            this.uxQuestion.Text = "?";
            // 
            // uxTeam
            // 
            this.uxTeam.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uxAFC,
            this.uxNFC});
            this.uxTeam.Enabled = false;
            this.uxTeam.Name = "uxTeam";
            this.uxTeam.Size = new System.Drawing.Size(47, 20);
            this.uxTeam.Text = "NFLTeam";
            // 
            // uxAFC
            // 
            this.uxAFC.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uxTornados,
            this.uxPenguins,
            this.uxBombers,
            this.uxDactyls,
            this.uxODBs});
            this.uxAFC.Name = "uxAFC";
            this.uxAFC.Size = new System.Drawing.Size(97, 22);
            this.uxAFC.Text = "AFC";
            // 
            // uxTornados
            // 
            this.uxTornados.Name = "uxTornados";
            this.uxTornados.Size = new System.Drawing.Size(123, 22);
            this.uxTornados.Text = "Tornados";
            this.uxTornados.Click += new System.EventHandler(this.uxTornados_Click);
            // 
            // uxPenguins
            // 
            this.uxPenguins.Name = "uxPenguins";
            this.uxPenguins.Size = new System.Drawing.Size(123, 22);
            this.uxPenguins.Text = "Penguins";
            this.uxPenguins.Click += new System.EventHandler(this.uxPenguins_Click);
            // 
            // uxBombers
            // 
            this.uxBombers.Name = "uxBombers";
            this.uxBombers.Size = new System.Drawing.Size(123, 22);
            this.uxBombers.Text = "Bombers";
            this.uxBombers.Click += new System.EventHandler(this.uxBombers_Click);
            // 
            // uxDactyls
            // 
            this.uxDactyls.Name = "uxDactyls";
            this.uxDactyls.Size = new System.Drawing.Size(123, 22);
            this.uxDactyls.Text = "Dactyls";
            this.uxDactyls.Click += new System.EventHandler(this.uxDactyls_Click);
            // 
            // uxODBs
            // 
            this.uxODBs.Name = "uxODBs";
            this.uxODBs.Size = new System.Drawing.Size(123, 22);
            this.uxODBs.Text = "ODB\'s";
            this.uxODBs.Click += new System.EventHandler(this.uxODBs_Click);
            // 
            // uxNFC
            // 
            this.uxNFC.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uxStormDynasty,
            this.uxNikeStorm,
            this.uxGorillas,
            this.uxPower,
            this.uxRam});
            this.uxNFC.Name = "uxNFC";
            this.uxNFC.Size = new System.Drawing.Size(97, 22);
            this.uxNFC.Text = "NFC";
            // 
            // uxStormDynasty
            // 
            this.uxStormDynasty.Name = "uxStormDynasty";
            this.uxStormDynasty.Size = new System.Drawing.Size(151, 22);
            this.uxStormDynasty.Text = "Storm Dynasty";
            this.uxStormDynasty.Click += new System.EventHandler(this.uxStormDynasty_Click);
            // 
            // uxNikeStorm
            // 
            this.uxNikeStorm.Name = "uxNikeStorm";
            this.uxNikeStorm.Size = new System.Drawing.Size(151, 22);
            this.uxNikeStorm.Text = "Nike Storm";
            this.uxNikeStorm.Click += new System.EventHandler(this.uxNikeStorm_Click);
            // 
            // uxGorillas
            // 
            this.uxGorillas.Name = "uxGorillas";
            this.uxGorillas.Size = new System.Drawing.Size(151, 22);
            this.uxGorillas.Text = "Gorillas";
            this.uxGorillas.Click += new System.EventHandler(this.uxGorillas_Click);
            // 
            // uxPower
            // 
            this.uxPower.Name = "uxPower";
            this.uxPower.Size = new System.Drawing.Size(151, 22);
            this.uxPower.Text = "Power";
            this.uxPower.Click += new System.EventHandler(this.uxPower_Click);
            // 
            // uxRam
            // 
            this.uxRam.Name = "uxRam";
            this.uxRam.Size = new System.Drawing.Size(151, 22);
            this.uxRam.Text = "Spoiler Jones";
            this.uxRam.Click += new System.EventHandler(this.uxRam_Click);
            // 
            // uxRetrieve
            // 
            this.uxRetrieve.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uxPlayerRankings});
            this.uxRetrieve.Enabled = false;
            this.uxRetrieve.Name = "uxRetrieve";
            this.uxRetrieve.Size = new System.Drawing.Size(61, 20);
            this.uxRetrieve.Text = "Retrieve";
            // 
            // uxPlayerRankings
            // 
            this.uxPlayerRankings.Name = "uxPlayerRankings";
            this.uxPlayerRankings.Size = new System.Drawing.Size(157, 22);
            this.uxPlayerRankings.Text = "Player Rankings";
            this.uxPlayerRankings.Click += new System.EventHandler(this.uxPlayerRankings_Click);
            // 
            // uxPlayers
            // 
            this.uxPlayers.Font = new System.Drawing.Font("Consolas", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxPlayers.FormattingEnabled = true;
            this.uxPlayers.ItemHeight = 17;
            this.uxPlayers.Location = new System.Drawing.Point(12, 85);
            this.uxPlayers.Name = "uxPlayers";
            this.uxPlayers.Size = new System.Drawing.Size(400, 378);
            this.uxPlayers.TabIndex = 1;
            this.uxPlayers.Click += new System.EventHandler(this.uxPlayers_Click);
            this.uxPlayers.DataSourceChanged += new System.EventHandler(this.uxPlayers_DataSourceChanged);
            // 
            // uxCurrentRoster
            // 
            this.uxCurrentRoster.Font = new System.Drawing.Font("Consolas", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxCurrentRoster.FormattingEnabled = true;
            this.uxCurrentRoster.ItemHeight = 17;
            this.uxCurrentRoster.Location = new System.Drawing.Point(665, 85);
            this.uxCurrentRoster.Name = "uxCurrentRoster";
            this.uxCurrentRoster.Size = new System.Drawing.Size(400, 378);
            this.uxCurrentRoster.TabIndex = 2;
            this.uxCurrentRoster.Click += new System.EventHandler(this.uxCurrentRoster_Click);
            // 
            // lblTeamName
            // 
            this.lblTeamName.Font = new System.Drawing.Font("Stencil", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTeamName.Location = new System.Drawing.Point(665, 24);
            this.lblTeamName.Name = "lblTeamName";
            this.lblTeamName.Size = new System.Drawing.Size(400, 58);
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
            this.uxFilterOptions.Location = new System.Drawing.Point(418, 85);
            this.uxFilterOptions.Name = "uxFilterOptions";
            this.uxFilterOptions.Size = new System.Drawing.Size(241, 228);
            this.uxFilterOptions.TabIndex = 4;
            this.uxFilterOptions.TabStop = false;
            this.uxFilterOptions.Text = "Filter Options:";
            // 
            // uxRosterPlayers
            // 
            this.uxRosterPlayers.AutoSize = true;
            this.uxRosterPlayers.Checked = true;
            this.uxRosterPlayers.CheckState = System.Windows.Forms.CheckState.Checked;
            this.uxRosterPlayers.Location = new System.Drawing.Point(141, 49);
            this.uxRosterPlayers.Name = "uxRosterPlayers";
            this.uxRosterPlayers.Size = new System.Drawing.Size(94, 17);
            this.uxRosterPlayers.TabIndex = 10;
            this.uxRosterPlayers.Text = "Roster Players";
            this.uxRosterPlayers.UseVisualStyleBackColor = true;
            // 
            // uxFreeAgents
            // 
            this.uxFreeAgents.AutoSize = true;
            this.uxFreeAgents.Checked = true;
            this.uxFreeAgents.CheckState = System.Windows.Forms.CheckState.Checked;
            this.uxFreeAgents.Location = new System.Drawing.Point(141, 22);
            this.uxFreeAgents.Name = "uxFreeAgents";
            this.uxFreeAgents.Size = new System.Drawing.Size(83, 17);
            this.uxFreeAgents.TabIndex = 9;
            this.uxFreeAgents.Text = "Free Agents";
            this.uxFreeAgents.UseVisualStyleBackColor = true;
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
            // uxKickers
            // 
            this.uxKickers.AutoSize = true;
            this.uxKickers.Location = new System.Drawing.Point(7, 157);
            this.uxKickers.Name = "uxKickers";
            this.uxKickers.Size = new System.Drawing.Size(60, 17);
            this.uxKickers.TabIndex = 5;
            this.uxKickers.Text = "Kickers";
            this.uxKickers.UseVisualStyleBackColor = true;
            // 
            // uxTightEnd
            // 
            this.uxTightEnd.AutoSize = true;
            this.uxTightEnd.Location = new System.Drawing.Point(7, 130);
            this.uxTightEnd.Name = "uxTightEnd";
            this.uxTightEnd.Size = new System.Drawing.Size(76, 17);
            this.uxTightEnd.TabIndex = 4;
            this.uxTightEnd.Text = "Tight Ends";
            this.uxTightEnd.UseVisualStyleBackColor = true;
            // 
            // uxReceivers
            // 
            this.uxReceivers.AutoSize = true;
            this.uxReceivers.Location = new System.Drawing.Point(7, 103);
            this.uxReceivers.Name = "uxReceivers";
            this.uxReceivers.Size = new System.Drawing.Size(101, 17);
            this.uxReceivers.TabIndex = 3;
            this.uxReceivers.Text = "Wide Receivers";
            this.uxReceivers.UseVisualStyleBackColor = true;
            // 
            // uxRunningBacks
            // 
            this.uxRunningBacks.AutoSize = true;
            this.uxRunningBacks.Location = new System.Drawing.Point(7, 76);
            this.uxRunningBacks.Name = "uxRunningBacks";
            this.uxRunningBacks.Size = new System.Drawing.Size(98, 17);
            this.uxRunningBacks.TabIndex = 2;
            this.uxRunningBacks.Text = "Running Backs";
            this.uxRunningBacks.UseVisualStyleBackColor = true;
            // 
            // uxQuarterbacks
            // 
            this.uxQuarterbacks.AutoSize = true;
            this.uxQuarterbacks.Location = new System.Drawing.Point(7, 49);
            this.uxQuarterbacks.Name = "uxQuarterbacks";
            this.uxQuarterbacks.Size = new System.Drawing.Size(89, 17);
            this.uxQuarterbacks.TabIndex = 1;
            this.uxQuarterbacks.Text = "Quarterbacks";
            this.uxQuarterbacks.UseVisualStyleBackColor = true;
            // 
            // uxAllPlayers
            // 
            this.uxAllPlayers.AutoSize = true;
            this.uxAllPlayers.Checked = true;
            this.uxAllPlayers.Location = new System.Drawing.Point(7, 22);
            this.uxAllPlayers.Name = "uxAllPlayers";
            this.uxAllPlayers.Size = new System.Drawing.Size(73, 17);
            this.uxAllPlayers.TabIndex = 0;
            this.uxAllPlayers.TabStop = true;
            this.uxAllPlayers.Text = "All Players";
            this.uxAllPlayers.UseVisualStyleBackColor = true;
            // 
            // uxFilterPlayer
            // 
            this.uxFilterPlayer.Enabled = false;
            this.uxFilterPlayer.Location = new System.Drawing.Point(119, 157);
            this.uxFilterPlayer.Name = "uxFilterPlayer";
            this.uxFilterPlayer.Size = new System.Drawing.Size(122, 48);
            this.uxFilterPlayer.TabIndex = 8;
            this.uxFilterPlayer.Text = "Filter Players";
            this.uxFilterPlayer.UseVisualStyleBackColor = true;
            this.uxFilterPlayer.Click += new System.EventHandler(this.uxFilterPlayer_Click);
            // 
            // uxRemovePlayer
            // 
            this.uxRemovePlayer.Enabled = false;
            this.uxRemovePlayer.Location = new System.Drawing.Point(418, 376);
            this.uxRemovePlayer.Name = "uxRemovePlayer";
            this.uxRemovePlayer.Size = new System.Drawing.Size(241, 41);
            this.uxRemovePlayer.TabIndex = 11;
            this.uxRemovePlayer.Text = "Remove Selected Player";
            this.uxRemovePlayer.UseVisualStyleBackColor = true;
            this.uxRemovePlayer.Click += new System.EventHandler(this.uxRemovePlayer_Click);
            // 
            // uxAddPlayer
            // 
            this.uxAddPlayer.Enabled = false;
            this.uxAddPlayer.Location = new System.Drawing.Point(418, 329);
            this.uxAddPlayer.Name = "uxAddPlayer";
            this.uxAddPlayer.Size = new System.Drawing.Size(241, 41);
            this.uxAddPlayer.TabIndex = 10;
            this.uxAddPlayer.Text = "Add Selected Player";
            this.uxAddPlayer.UseVisualStyleBackColor = true;
            this.uxAddPlayer.Click += new System.EventHandler(this.uxAddPlayer_Click);
            // 
            // uxChangePlayer
            // 
            this.uxChangePlayer.Enabled = false;
            this.uxChangePlayer.Location = new System.Drawing.Point(418, 423);
            this.uxChangePlayer.Name = "uxChangePlayer";
            this.uxChangePlayer.Size = new System.Drawing.Size(241, 41);
            this.uxChangePlayer.TabIndex = 18;
            this.uxChangePlayer.Text = "Edit Selected Player";
            this.uxChangePlayer.UseVisualStyleBackColor = true;
            this.uxChangePlayer.Click += new System.EventHandler(this.uxEditPlayer_Click);
            // 
            // lblCapHitLabel
            // 
            this.lblCapHitLabel.Font = new System.Drawing.Font("Stencil", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCapHitLabel.Location = new System.Drawing.Point(417, 497);
            this.lblCapHitLabel.Name = "lblCapHitLabel";
            this.lblCapHitLabel.Size = new System.Drawing.Size(106, 29);
            this.lblCapHitLabel.TabIndex = 19;
            this.lblCapHitLabel.Text = "Cap Hit";
            this.lblCapHitLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCapHit
            // 
            this.lblCapHit.Font = new System.Drawing.Font("Stencil", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCapHit.Location = new System.Drawing.Point(529, 497);
            this.lblCapHit.Name = "lblCapHit";
            this.lblCapHit.Size = new System.Drawing.Size(121, 29);
            this.lblCapHit.TabIndex = 20;
            this.lblCapHit.Text = "$0.00 ";
            this.lblCapHit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCapRoomLabel
            // 
            this.lblCapRoomLabel.Font = new System.Drawing.Font("Stencil", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCapRoomLabel.Location = new System.Drawing.Point(810, 497);
            this.lblCapRoomLabel.Name = "lblCapRoomLabel";
            this.lblCapRoomLabel.Size = new System.Drawing.Size(129, 29);
            this.lblCapRoomLabel.TabIndex = 21;
            this.lblCapRoomLabel.Text = "Cap Room";
            this.lblCapRoomLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCapRoom
            // 
            this.lblCapRoom.Font = new System.Drawing.Font("Stencil", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCapRoom.Location = new System.Drawing.Point(945, 497);
            this.lblCapRoom.Name = "lblCapRoom";
            this.lblCapRoom.Size = new System.Drawing.Size(121, 29);
            this.lblCapRoom.TabIndex = 22;
            this.lblCapRoom.Text = "$125.00 ";
            this.lblCapRoom.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // uxPlayerNameLabel
            // 
            this.uxPlayerNameLabel.AutoSize = true;
            this.uxPlayerNameLabel.Enabled = false;
            this.uxPlayerNameLabel.Font = new System.Drawing.Font("Stencil", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxPlayerNameLabel.Location = new System.Drawing.Point(9, 63);
            this.uxPlayerNameLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.uxPlayerNameLabel.Name = "uxPlayerNameLabel";
            this.uxPlayerNameLabel.Size = new System.Drawing.Size(52, 19);
            this.uxPlayerNameLabel.TabIndex = 23;
            this.uxPlayerNameLabel.Text = "Name";
            this.uxPlayerNameLabel.Click += new System.EventHandler(this.uxPlayerNameLabel_Click);
            // 
            // uxSalaryLabel
            // 
            this.uxSalaryLabel.AutoSize = true;
            this.uxSalaryLabel.Enabled = false;
            this.uxSalaryLabel.Font = new System.Drawing.Font("Stencil", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxSalaryLabel.Location = new System.Drawing.Point(269, 63);
            this.uxSalaryLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.uxSalaryLabel.Name = "uxSalaryLabel";
            this.uxSalaryLabel.Size = new System.Drawing.Size(68, 19);
            this.uxSalaryLabel.TabIndex = 24;
            this.uxSalaryLabel.Text = "Salary";
            this.uxSalaryLabel.Click += new System.EventHandler(this.uxSalaryLabel_Click);
            // 
            // uxRankLabel
            // 
            this.uxRankLabel.AutoSize = true;
            this.uxRankLabel.Enabled = false;
            this.uxRankLabel.Font = new System.Drawing.Font("Stencil", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxRankLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.uxRankLabel.Location = new System.Drawing.Point(213, 63);
            this.uxRankLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.uxRankLabel.Name = "uxRankLabel";
            this.uxRankLabel.Size = new System.Drawing.Size(53, 19);
            this.uxRankLabel.TabIndex = 25;
            this.uxRankLabel.Text = "Rank";
            this.uxRankLabel.Click += new System.EventHandler(this.uxRankLabel_Click);
            // 
            // uxContractYearLabel
            // 
            this.uxContractYearLabel.AutoSize = true;
            this.uxContractYearLabel.Enabled = false;
            this.uxContractYearLabel.Font = new System.Drawing.Font("Stencil", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxContractYearLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.uxContractYearLabel.Location = new System.Drawing.Point(355, 63);
            this.uxContractYearLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.uxContractYearLabel.Name = "uxContractYearLabel";
            this.uxContractYearLabel.Size = new System.Drawing.Size(49, 19);
            this.uxContractYearLabel.TabIndex = 26;
            this.uxContractYearLabel.Text = "Year";
            this.uxContractYearLabel.Click += new System.EventHandler(this.uxContractYearLabel_Click);
            // 
            // lblSalaryLabel
            // 
            this.lblSalaryLabel.Font = new System.Drawing.Font("Stencil", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSalaryLabel.Location = new System.Drawing.Point(12, 497);
            this.lblSalaryLabel.Name = "lblSalaryLabel";
            this.lblSalaryLabel.Size = new System.Drawing.Size(106, 29);
            this.lblSalaryLabel.TabIndex = 27;
            this.lblSalaryLabel.Text = "Salary";
            this.lblSalaryLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSalary
            // 
            this.lblSalary.Font = new System.Drawing.Font("Stencil", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSalary.Location = new System.Drawing.Point(123, 497);
            this.lblSalary.Name = "lblSalary";
            this.lblSalary.Size = new System.Drawing.Size(121, 29);
            this.lblSalary.TabIndex = 28;
            this.lblSalary.Text = "$0.00 ";
            this.lblSalary.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Manager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1078, 535);
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
            this.Margin = new System.Windows.Forms.Padding(2);
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
        private System.Windows.Forms.ToolStripMenuItem uxTeam;
        private System.Windows.Forms.ToolStripMenuItem uxAFC;
        private System.Windows.Forms.ToolStripMenuItem uxTornados;
        private System.Windows.Forms.ToolStripMenuItem uxPenguins;
        private System.Windows.Forms.ToolStripMenuItem uxBombers;
        private System.Windows.Forms.ToolStripMenuItem uxDactyls;
        private System.Windows.Forms.ToolStripMenuItem uxODBs;
        private System.Windows.Forms.ToolStripMenuItem uxNFC;
        private System.Windows.Forms.ToolStripMenuItem uxStormDynasty;
        private System.Windows.Forms.ToolStripMenuItem uxNikeStorm;
        private System.Windows.Forms.ToolStripMenuItem uxGorillas;
        private System.Windows.Forms.ToolStripMenuItem uxPower;
        private System.Windows.Forms.ToolStripMenuItem uxRam;
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

