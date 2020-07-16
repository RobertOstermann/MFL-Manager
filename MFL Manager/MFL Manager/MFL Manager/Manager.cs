using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MFL_Manager
{
    public partial class Manager : Form
    {
        public Manager()
        {
            InitializeComponent();
            ApiAssistant.InitializeClient();
        }
        //Public should allow for access across all classes.
        public PlayerDatabase PlayerDatabase;

        public int TeamId;

        public ListBox SelectedListBox;

        /// <summary>
        /// Initializes a new player database.
        /// Enables all buttons. Clears the list boxes.
        /// Updates the cap information.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxNew_Click(object sender, EventArgs e)
        {
            PlayerDatabase = new PlayerDatabase();
            EnableButtons();
            ClearListBoxes();
            UpdateCapInformation();
        }
        /// <summary>
        /// Initializes a new player database.
        /// Shows a file dialog and loads a player list from the given file.
        /// Enables all buttons. Clears the list boxes. Updates the cap information.
        /// Shows an error message for unreadable files.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxLocal_Click(object sender, EventArgs e)
        {
            uxOpenFileDialog.FileName = null;
            if (uxOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filename = uxOpenFileDialog.FileName;
                try
                {
                    PlayerDatabase = new PlayerDatabase(filename);
                    EnableButtons();
                    LoadListBoxes();
                    UpdateCapInformation();
                }
                catch
                {
                    ClearListBoxes();
                    MessageBox.Show("Error opening " + filename);
                }
            }
        }
        /// <summary>
        /// Shows a URL dialog and loads player information from the given source.
        /// Replaces the PlayerDatabase.
        /// Enables all buttons. Clears the list boxes. Updates the cap information.
        /// Shows an error message for unreadable files.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxMFL_Click(object sender, EventArgs e)
        {
            try
            {
                WebsiteInformation websiteInformation = new WebsiteInformation();
                if (websiteInformation.ShowDialog() == DialogResult.OK)
                {
                    PlayerDatabase = new PlayerDatabase(websiteInformation.PlayerUrl, websiteInformation.SalaryUrl, websiteInformation.LeagueUrl, websiteInformation.RosterUrl);
                    EnableButtons();
                    LoadListBoxes();
                    UpdateCapInformation();
                }
            }
            catch
            {
                ClearListBoxes();
                MessageBox.Show("Invalid Website Address");
            }
        }
        /// <summary>
        /// Shows a save file dialog and saves the player list to a text file.
        /// Shows an error message if the save is not successful.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxSave_Click(object sender, EventArgs e)
        {
            if (uxSaveFileDialog.ShowDialog() == DialogResult.OK)
            {
                //Extension not working!
                uxSaveFileDialog.DefaultExt = ".txt";
                uxSaveFileDialog.AddExtension = true;

                try
                {
                    PlayerDatabase.SaveFile(uxSaveFileDialog.FileName);
                }
                catch
                {
                    MessageBox.Show("Error Saving File");
                }
            }
        }
        /// <summary>
        /// Utilizes PlayerEditor form to 
        /// edit a player's values.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxEditPlayer_Click(object sender, EventArgs e)
        {
            if (SelectedListBox != null)
            {
                PlayerInfo player = (PlayerInfo)SelectedListBox.SelectedItem;
                if (player != null)
                {
                    PlayerDatabase.RemovePlayerFromTeam(player);
                    PlayerEditor playerEditor = new PlayerEditor(player);
                    if (playerEditor.ShowDialog() == DialogResult.OK)
                    {

                        PlayerDatabase.AddPlayerToTeam(player);
                        LoadListBoxes();
                    }
                    else PlayerDatabase.AddPlayerToTeam(player);
                    UpdateCapInformation();
                }
            }
            else MessageBox.Show("Error - Invalid Player");
        }
        /// <summary>
        /// Utilizes the PlayerEditor form to 
        /// create a player.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxCreatePlayer_Click(object sender, EventArgs e)
        {
            PlayerEditor playerEditor = new PlayerEditor();
            if (playerEditor.ShowDialog() == DialogResult.OK)
            {
                PlayerDatabase.AddPlayerInformation(playerEditor.Player);
                LoadListBoxes();
            }
        }
        /// <summary>
        /// Adds the selected player to an MFL team.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxAddPlayer_Click(object sender, EventArgs e)
        {
            if (SelectedListBox != null)
            {
                PlayerInfo player = (PlayerInfo)SelectedListBox.SelectedItem;
                if (player != null)
                {
                    if (player.MFLTeamID != 0) PlayerDatabase.RemovePlayerFromTeam(player);
                    player.MFLTeamID = TeamId;
                    PlayerDatabase.AddPlayerToTeam(player);
                    LoadListBoxes();
                    UpdateCapInformation();
                }
            }
        }
        /// <summary>
        /// Removes the selected player from an MFL team.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxRemovePlayer_Click(object sender, EventArgs e)
        {
            if (SelectedListBox != null)
            {
                PlayerInfo player = (PlayerInfo)SelectedListBox.SelectedItem;
                if (player != null)
                {
                    PlayerDatabase.RemovePlayerFromTeam(player);
                    player.MFLTeamID = 0;
                    LoadListBoxes();
                    UpdateCapInformation();
                }
            }
        }
        /// <summary>
        /// Filters the players based upon user specifications.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxFilterPlayer_Click(object sender, EventArgs e)
        {
            FilterPlayers();
        }
        /// <summary>
        /// Filters the players based upon user specifications.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FilterPlayers()
        {
            if (uxRosterPlayers.Checked && uxFreeAgents.Checked)
            {
                if (uxAllPlayers.Checked) PlayerDatabase.UpdateAllPlayerList();
                else if (uxQuarterbacks.Checked) PlayerDatabase.FilterPlayerList('q');
                else if (uxRunningBacks.Checked) PlayerDatabase.FilterPlayerList('r');
                else if (uxReceivers.Checked) PlayerDatabase.FilterPlayerList('w');
                else if (uxTightEnd.Checked) PlayerDatabase.FilterPlayerList('t');
                else if (uxKickers.Checked) PlayerDatabase.FilterPlayerList('k');
                else if (uxDefense.Checked) PlayerDatabase.FilterPlayerList('d');
            }
            else if (uxRosterPlayers.Checked)
            {
                if (uxAllPlayers.Checked) PlayerDatabase.FilterPlayerList('a', true);
                else if (uxQuarterbacks.Checked) PlayerDatabase.FilterPlayerList('q', true);
                else if (uxRunningBacks.Checked) PlayerDatabase.FilterPlayerList('r', true);
                else if (uxReceivers.Checked) PlayerDatabase.FilterPlayerList('w', true);
                else if (uxTightEnd.Checked) PlayerDatabase.FilterPlayerList('t', true);
                else if (uxKickers.Checked) PlayerDatabase.FilterPlayerList('k', true);
                else if (uxDefense.Checked) PlayerDatabase.FilterPlayerList('d', true);
            }
            else if (uxFreeAgents.Checked)
            {
                if (uxAllPlayers.Checked) PlayerDatabase.FilterPlayerList('a', false);
                else if (uxQuarterbacks.Checked) PlayerDatabase.FilterPlayerList('q', false);
                else if (uxRunningBacks.Checked) PlayerDatabase.FilterPlayerList('r', false);
                else if (uxReceivers.Checked) PlayerDatabase.FilterPlayerList('w', false);
                else if (uxTightEnd.Checked) PlayerDatabase.FilterPlayerList('t', false);
                else if (uxKickers.Checked) PlayerDatabase.FilterPlayerList('k', false);
                else if (uxDefense.Checked) PlayerDatabase.FilterPlayerList('d', false);
            }
            else
            {
                PlayerDatabase.PlayerList.Clear();
            }
            PlayerDatabase.PlayerList.Sort();
            LoadPlayerListBox();
        }
        /// <summary>
        /// Sets the current team.
        /// </summary>
        /// <param name="TeamId"></param>
        private void SetCurrentTeam()
        {
            if (PlayerDatabase.Teams.TryGetValue(TeamId, out TeamInfo team))
            {
                uxCurrentRoster.DataSource = null;
                team.Players.Sort();
                uxCurrentRoster.DataSource = team.Players;
                lblTeamName.Text = team.Name;
                UpdateCapInformation();
            }
            else
            {
                lblTeamName.Text = "MFL Team Name";
            }
            ResetListBoxes();
        }
        /// <summary>
        /// Sets a new team based upon provided team id.
        /// </summary>
        /// <param name="NewTeamId"></param>
        private void SetNewTeam(int NewTeamId)
        {
            if (PlayerDatabase.Teams.TryGetValue(NewTeamId, out TeamInfo team))
            {
                TeamId = NewTeamId;
                team.Players.Sort();
                uxCurrentRoster.DataSource = null;
                uxCurrentRoster.DataSource = team.Players;
                lblTeamName.Text = team.Name;
                UpdateCapInformation();
            }
            else
            {
                lblTeamName.Text = "Error";
            }
            ResetListBoxes();
        }
        /// <summary>
        /// Updates the cap information to reflect
        /// the information stored in the player database.
        /// </summary>
        private void UpdateCapInformation()
        {
            if (PlayerDatabase.Teams.TryGetValue(TeamId, out TeamInfo team))
            {
                lblSalary.Text = String.Format("{0:C}", team.Salary);
                lblCapHit.Text = String.Format("{0:C}", team.CapHit);
                UpdateCapRoomLabel(team);
            }
            else
            {
                lblSalary.Text = String.Format("{0:C}", 0.00);
                lblCapHit.Text = String.Format("{0:C}", 0.00);
                lblCapRoom.Text = String.Format("{0:C}", PlayerDatabase.CapRoom);
            }
        }
        /// <summary>
        /// Alters the cap room label color.
        /// </summary>
        private void UpdateCapRoomLabel (TeamInfo team)
        {
            double capAvailable = PlayerDatabase.CapRoom - team.Salary - team.CapHit;
            if (capAvailable < 0)
            {
                lblCapRoom.ForeColor = Color.Red;
            }
            else
            {
                lblCapRoom.ForeColor = SystemColors.ControlText;
            }
            lblCapRoom.Text = String.Format("{0:C}", PlayerDatabase.CapRoom - team.Salary - team.CapHit);
        }
        /// <summary>
        /// Enables all buttons within the form.
        /// </summary>
        private void EnableButtons()
        {
            uxEdit.Enabled = true;
            uxTeam.Enabled = true;
            uxView.Enabled = true;
            uxRetrieve.Enabled = true;
            uxFilterOptions.Enabled = true;
            uxFilterPlayer.Enabled = true;
            uxAddPlayer.Enabled = true;
            uxRemovePlayer.Enabled = true;
            uxChangePlayer.Enabled = true;
        }
        /// <summary>
        /// Clears the list boxes within the form.
        /// </summary>
        private void ClearListBoxes()
        {
            ClearPlayerListBox();
            ClearRosterListBox();
            SetCurrentTeam();
            UpdateCapInformation();
        }
        /// <summary>
        /// Clears the players list box within the form.
        /// </summary>
        private void ClearPlayerListBox()
        {
            ResetAllLabels();
            uxPlayers.DataSource = null;
        }
        /// <summary>
        /// Clears the players list box within the form.
        /// </summary>
        private void ClearRosterListBox()
        {
            uxCurrentRoster.DataSource = null;
        }
        /// <summary>
        /// Loads the list boxes to reflect
        /// the information stored in the player database.
        /// </summary>
        private void LoadListBoxes()
        {
            ClearListBoxes();
            FilterPlayers();
            uxPlayers.DataSource = PlayerDatabase.PlayerList;
            SetCurrentTeam();
            UpdateCapInformation();
        }
        /// <summary>
        /// Loads the filtered list boxes to reflect 
        /// the information stored in the player database.
        /// </summary>
        private void LoadPlayerListBox()
        {
            ClearPlayerListBox();
            uxPlayers.DataSource = PlayerDatabase.PlayerList;
        }
        /// <summary>
        /// Loads the current roster list boxes to reflect 
        /// the information stored in the player database.
        /// </summary>
        private void LoadRosterListBox()
        {
            ClearRosterListBox();
            SetCurrentTeam();
        }

        //Sort players by chosen attribute.
        /// <summary>
        /// Sorts by player name.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxPlayerNameLabel_Click(object sender, EventArgs e)
        {
            PlayerDatabase.PlayerList.Sort((one, two) => string.Compare(one.Name, two.Name));
            ClearPlayerListBox();
            uxPlayers.DataSource = PlayerDatabase.PlayerList;  
            SetLabel(uxPlayerNameLabel);
        }
        /// <summary>
        /// Sorts by player id.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxRankLabel_Click(object sender, EventArgs e)
        {            
            PlayerDatabase.PlayerList.Sort((one, two) => one.FantasyProsRanking.CompareTo(two.FantasyProsRanking));
            ClearPlayerListBox();
            uxPlayers.DataSource = PlayerDatabase.PlayerList;
            SetLabel(uxRankLabel);
        }
        /// <summary>
        /// Sorts by player salary.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxSalaryLabel_Click(object sender, EventArgs e)
        {
            PlayerDatabase.PlayerList.Sort((one, two) => two.Salary.CompareTo(one.Salary));
            ClearPlayerListBox();
            uxPlayers.DataSource = PlayerDatabase.PlayerList;
            SetLabel(uxSalaryLabel);
        }
        /// <summary>
        /// Sorts by player contract.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxContractYearLabel_Click(object sender, EventArgs e)
        {
            PlayerDatabase.PlayerList.Sort((one, two) => string.Compare(two.ContractYear, one.ContractYear));
            ClearPlayerListBox();
            uxPlayers.DataSource = PlayerDatabase.PlayerList;
            SetLabel(uxContractYearLabel);
        }
        /// <summary>
        /// Sets a label to indicate sorting precedence.
        /// </summary>
        /// <param name="label"></param>
        private void SetLabel(Label label)
        {
            label.ForeColor = Color.DeepSkyBlue;
        }
        /// <summary>
        /// Resets all font borders and colors to original format.
        /// </summary>
        private void ResetAllLabels()
        {
            //Name
            uxPlayerNameLabel.ForeColor = SystemColors.ControlText;
            //ID
            uxRankLabel.ForeColor = SystemColors.ControlText;
            //Salary
            uxSalaryLabel.ForeColor = SystemColors.ControlText;
            //Contract Year
            uxContractYearLabel.ForeColor = SystemColors.ControlText;
        }
        /// <summary>
        /// Enables all labels.
        /// </summary>
        private void EnableLabels()
        {
            uxPlayerNameLabel.Enabled = true;
            uxRankLabel.Enabled = true;
            uxSalaryLabel.Enabled = true;
            uxContractYearLabel.Enabled = true;
        }
        /// <summary>
        /// Disables all labels.
        /// </summary>
        private void DisableLabels()
        {
            uxPlayerNameLabel.Enabled = false;
            uxRankLabel.Enabled = false;
            uxSalaryLabel.Enabled = false;
            uxContractYearLabel.Enabled = false;
        }
        /// <summary>
        /// Enables or Disable labels depending
        /// upon the DataSource of uxPlayers.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxPlayers_DataSourceChanged(object sender, EventArgs e)
        {
            if (uxPlayers.DataSource == null) DisableLabels();
            else EnableLabels();
        }

        //Set the current roster to the chosen team.
        /// <summary>
        /// Sets the TeamID to the chosen team.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxTornados_Click(object sender, EventArgs e)
        {
            SetNewTeam(1);
            //Adjust so that new teams can be added at will.
            //uxTeam.DropDownItems.Add()
        }
        /// <summary>
        /// Sets the TeamID to the chosen team.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxPenguins_Click(object sender, EventArgs e)
        {
            SetNewTeam(2);
        }
        /// <summary>
        /// Sets the TeamID to the chosen team.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxBombers_Click(object sender, EventArgs e)
        {
            SetNewTeam(3);
        }
        /// <summary>
        /// Sets the TeamID to the chosen team.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxDactyls_Click(object sender, EventArgs e)
        {
            SetNewTeam(4);
        }
        /// <summary>
        /// Sets the TeamID to the chosen team.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxODBs_Click(object sender, EventArgs e)
        {
            SetNewTeam(5);
        }
        /// <summary>
        /// Sets the TeamID to the chosen team.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxStormDynasty_Click(object sender, EventArgs e)
        {
            SetNewTeam(6); 
        }
        /// <summary>
        /// Sets the TeamID to the chosen team.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxNikeStorm_Click(object sender, EventArgs e)
        {
            SetNewTeam(7);
        }
        /// <summary>
        /// Sets the TeamID to the chosen team.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxGorillas_Click(object sender, EventArgs e)
        {
            SetNewTeam(8);
        }
        /// <summary>
        /// Sets the TeamID to the chosen team.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxPower_Click(object sender, EventArgs e)
        {
            SetNewTeam(9);
        }
        /// <summary>
        /// Sets the TeamID to the chosen team.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxRam_Click(object sender, EventArgs e)
        {
            SetNewTeam(10);
        }

        //Edit the cap information.
        /// <summary>
        /// Edits the cap hit of the current team.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxEditCapHit_Click(object sender, EventArgs e)
        {
            if (PlayerDatabase.Teams.TryGetValue(TeamId, out TeamInfo team))
            {
                CapEditor capEditor = new CapEditor(team);
                if (capEditor.ShowDialog() == DialogResult.OK)
                {
                    team.CapHit = capEditor.CapData;
                    UpdateCapInformation();
                }
            }
            else MessageBox.Show("Error - Invalid Team");
        }
        /// <summary>
        /// Edits the cap room available to all teams.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxEditCapRoom_Click(object sender, EventArgs e)
        {
            CapEditor capEditor = new CapEditor();
            if (capEditor.ShowDialog() == DialogResult.OK)
            {
                PlayerDatabase.CapRoom = capEditor.CapData;
                UpdateCapInformation();
            }
        }
        //Alters the active list box.
        /// <summary>
        /// Ensures only one list box is selected.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxPlayers_Click(object sender, EventArgs e)
        {
            uxCurrentRoster.ClearSelected();
            SelectedListBox = uxPlayers;
        }
        /// <summary>
        /// Ensures only one list box is selected.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxCurrentRoster_Click(object sender, EventArgs e)
        {
            uxPlayers.ClearSelected();
            SelectedListBox = uxCurrentRoster;
        }
        /// <summary>
        /// Ensures only one list box is selected.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ResetListBoxes()
        {
            uxPlayers.ClearSelected();
            uxCurrentRoster.ClearSelected();
        }

        //Retrieve additional information.
        private void uxPlayerRankings_Click(object sender, EventArgs e)
        {
            uxOpenFileDialog.FileName = null;
            if (uxOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filename = uxOpenFileDialog.FileName;
                try
                {
                    PlayerDatabase.ReadPlayerRankings(filename);
                    LoadListBoxes();
                }
                catch
                {
                    ClearListBoxes();
                    MessageBox.Show("Error opening " + filename);
                }
            }
        }
    }
}
