using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using MFL_Manager.Models.CustomResponeses;

namespace MFL_Manager
{
    public partial class Manager : Form
    {
        private readonly MFLController _mflController;

        public int FranchiseId;

        public ListBox SelectedListBox;

        public Manager(MFLController mflController)
        {
            InitializeComponent();
            ApiAssistant.InitializeClient();
            _mflController = mflController;
            FranchiseId = 9;
        }

        #region Button Clicks

        /// <summary>
        /// Enables all buttons. Clears the list boxes.
        /// Updates the cap information.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxNew_Click(object sender, EventArgs e)
        {
            EnableButtons();
            ClearListBoxes();
            //Update Cap Information
        }

        /// <summary>
        /// Loads player and franchise information.
        /// Enables all buttons. Clears the list boxes. Updates the cap information.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxLocal_Click(object sender, EventArgs e)
        {
            _mflController.GetLocalInformation();
            SetDivisionDropDownItems();
            EnableButtons();
            LoadListBoxes();
            SetTeam();
        }

        /// <summary>
        /// Shows a URL dialog and loads player information from the given MFL API.
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
                    Uri playerUri = new Uri(websiteInformation.PlayerUrl);
                    Uri franchiseUri = new Uri(websiteInformation.LeagueUrl);
                    Uri salaryUri = new Uri(websiteInformation.SalaryUrl);
                    Uri playerProfileUri = new Uri(websiteInformation.PlayerProfileUrl);
                    Uri rosterUri = new Uri(websiteInformation.RosterUrl);

                    _mflController.GetApiInformation(playerUri, franchiseUri, salaryUri, rosterUri, playerProfileUri);

                    SetDivisionDropDownItems();

                    EnableButtons();
                    LoadListBoxes();
                }
            }
            catch (Exception ex)
            {
                ClearListBoxes();
                MessageBox.Show($@"Invalid Website Address with exception - {ex}");
            }
        }

        /// <summary>
        /// Saves the player and franchise information.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxSave_Click(object sender, EventArgs e)
        {
            _mflController.SaveInformation();
        }

        /// <summary>
        /// Selects a franchise and displays the franchise roster.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void franchise_Click(object sender, EventArgs e)
        {
            try
            {
                ToolStripItem item = (ToolStripItem) sender;
                FranchiseId = Convert.ToInt32(item.Name.Substring(2));
                SetTeam();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
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
                _mflController.SetCapInformation(capEditor.CapData);
                SetTeam();
            }
        }

        /// <summary>
        /// Edits the cap hit of the current team.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxEditCapHit_Click(object sender, EventArgs e)
        {
            FranchiseDto franchise = _mflController.GetFranchiseInformation(FranchiseId);
            if (franchise != null)
            {
                CapEditor capEditor = new CapEditor(franchise);
                if (capEditor.ShowDialog() == DialogResult.OK)
                {
                    franchise.CapHit = capEditor.CapData;
                    SetTeam();
                }
            }
            else MessageBox.Show(@"Error - Invalid NFLTeam");
        }

        /// <summary>
        /// Utilizes the PlayerEditor form to create a player.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxCreatePlayer_Click(object sender, EventArgs e)
        {
            PlayerEditor playerEditor = new PlayerEditor();
            if (playerEditor.ShowDialog() == DialogResult.OK)
            {
                _mflController.AddPlayer(playerEditor.Player);
                LoadListBoxes();
            }
        }

        /// <summary>
        /// Utilizes PlayerEditor form to edit a player's values.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxEditPlayer_Click(object sender, EventArgs e)
        {
            if (SelectedListBox != null)
            {
                PlayerDto player = (PlayerDto)SelectedListBox.SelectedItem;
                if (player != null)
                {
                    _mflController.RemovePlayerFromTeam(player);
                    PlayerEditor playerEditor = new PlayerEditor(player);
                    if (playerEditor.ShowDialog() == DialogResult.OK)
                    {

                        _mflController.AddPlayerToTeam(player);
                        LoadListBoxes();
                    }
                    else _mflController.AddPlayerToTeam(player);
                    SetTeam();
                }
            }
            else MessageBox.Show(@"Error - Invalid Player");
        }

        /// <summary>
        /// Adds the selected player to an MFL team.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxAddPlayer_Click(object sender, EventArgs e)
        {
            PlayerDto player = (PlayerDto) SelectedListBox?.SelectedItem;
            if (player != null)
            {
                if (player.MFLTeamID != 0) _mflController.RemovePlayerFromTeam(player);
                player.MFLTeamID = FranchiseId;
                _mflController.AddPlayerToTeam(player);
                LoadListBoxes();
                SetTeam();
            }
        }

        /// <summary>
        /// Removes the selected player from an MFL team.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxRemovePlayer_Click(object sender, EventArgs e)
        {
            PlayerDto player = (PlayerDto) SelectedListBox?.SelectedItem;
            if (player != null)
            {
                _mflController.RemovePlayerFromTeam(player);
                player.MFLTeamID = 0;
                LoadListBoxes();
                SetTeam();
            }
        }

        /// <summary>
        /// Retrieve Fantasy Pros player rankings.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxPlayerRankings_Click(object sender, EventArgs e)
        {
            uxOpenFileDialog.FileName = null;
            if (uxOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filename = uxOpenFileDialog.FileName;
                try
                {
                    //PlayerDatabase.ReadPlayerRankings(filename);
                    LoadListBoxes();
                }
                catch
                {
                    ClearListBoxes();
                    MessageBox.Show(@"Error opening " + filename);
                }
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Updates the cap information to reflect
        /// the information stored in the player database.
        /// </summary>
        private void SetTeam()
        {
            FranchiseDto franchise = _mflController.GetFranchiseInformation(FranchiseId);
            double capAvailable = _mflController.GetCapInformation() - franchise.Salary - franchise.CapHit;

            lblSalary.Text = $@"{franchise.Salary:C}";
            lblCapHit.Text = $@"{franchise.CapHit:C}";
            lblCapRoom.ForeColor = capAvailable < 0 ? Color.Red : SystemColors.ControlText;
            lblCapRoom.Text = $@"{_mflController.GetCapInformation() - franchise.Salary - franchise.CapHit:C}";
            lblTeamName.Text = franchise.Name;

            franchise.Players.Sort();

            uxCurrentRoster.DataSource = null;
            uxCurrentRoster.DataSource = franchise.Players;

            uxPlayers.ClearSelected();
            uxCurrentRoster.ClearSelected();
        }

        private void SetDivisionDropDownItems()
        {
            List<DivisionDto> divisionInformation = _mflController.GetDivisionInformation().ToList();
            List<FranchiseDto> franchiseInformation = _mflController.GetFranchiseInformation().ToList();

            foreach (var division in divisionInformation)
            {
                ToolStripDropDownButton item = new ToolStripDropDownButton(division.Name)
                {
                    ShowDropDownArrow = false
                };
                uxMFLTeam.DropDownItems.Add(item);
                foreach (var franchise in franchiseInformation.Where(franchise => franchise.DivisionId == division.Id))
                {
                    ToolStripItem franchiseItem = new ToolStripMenuItem(franchise.Name, null, franchise_Click)
                    {
                        Name = "ux" + franchise.Id
                    };
                    item.DropDownItems.Add(franchiseItem);
                }
            }
        }

        /// <summary>
        /// Enables all buttons within the form.
        /// </summary>
        private void EnableButtons()
        {
            uxEdit.Enabled = true;
            uxMFLTeam.Enabled = true;
            uxView.Enabled = true;
            uxRetrieve.Enabled = true;
            uxFilterOptions.Enabled = true;
            uxFilterPlayer.Enabled = true;
            uxAddPlayer.Enabled = true;
            uxRemovePlayer.Enabled = true;
            uxChangePlayer.Enabled = true;
        }

        #endregion

        #region List Box Manipulation

        /// <summary>
        /// Loads the list boxes to reflect
        /// the information stored in the player database.
        /// </summary>
        private void LoadListBoxes()
        {
            ClearListBoxes();
            FilterPlayers();
            SetTeam();
        }

        /// <summary>
        /// Clears the list boxes within the form.
        /// </summary>
        private void ClearListBoxes()
        {
            //ResetAllLabels();
            uxPlayers.DataSource = null;
            uxCurrentRoster.DataSource = null;
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

        private void FilterPlayers()
        {
            List<PlayerDto> players = _mflController.GetPlayerInformation().ToList();

            if (uxQuarterbacks.Checked)
                players = players.Where(p => p.Position[0] == 'Q').ToList();
            if (uxRunningBacks.Checked)
                players = players.Where(p => p.Position[0] == 'R').ToList();
            if (uxReceivers.Checked)
                players = players.Where(p => p.Position[0] == 'W').ToList();
            if (uxTightEnd.Checked)
                players = players.Where(p => p.Position[0] == 'T').ToList();
            if (uxKickers.Checked)
                players = players.Where(p => p.Position[0] == 'K').ToList();
            if (uxDefense.Checked)
                players = players.Where(p => p.Position[0] == 'D').ToList();

            if (!uxRosterPlayers.Checked)
                players = players.Where(p => !p.Roster).ToList();
            if (!uxFreeAgents.Checked)
                players = players.Where(p => p.Roster).ToList();

            players.Sort();

            if (uxPlayerNameLabel.ForeColor != SystemColors.ControlText)
                players.Sort((one, two) => string.CompareOrdinal(one.Name, two.Name));

            if (uxRankLabel.ForeColor != SystemColors.ControlText)
                players.Sort((one, two) => one.FantasyProsRanking.CompareTo(two.FantasyProsRanking));

            if (uxSalaryLabel.ForeColor != SystemColors.ControlText)
                players.Sort((one, two) => two.Salary.CompareTo(one.Salary));

            if(uxContractYearLabel.ForeColor != SystemColors.ControlText)
                players.Sort((one, two) => string.CompareOrdinal(two.ContractYear, one.ContractYear));

            uxPlayers.DataSource = null;
            uxPlayers.DataSource = players;
        }

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

        #endregion

        #region Sort With Labels

        /// <summary>
        /// Sets a label to indicate sorting precedence.
        /// </summary>
        /// <param name="label"></param>
        private void SetLabel(Control label)
        {
            label.ForeColor = label.ForeColor == Color.DeepSkyBlue ? SystemColors.ControlText : Color.DeepSkyBlue;
        }

        /// <summary>
        /// Resets all font borders and colors to original format.
        /// </summary>
        private void ResetAllLabels(Control label)
        {
            if (label != uxPlayerNameLabel)
                uxPlayerNameLabel.ForeColor = SystemColors.ControlText;
            if (label != uxRankLabel)
                uxRankLabel.ForeColor = SystemColors.ControlText;
            if (label != uxSalaryLabel)
                uxSalaryLabel.ForeColor = SystemColors.ControlText;
            if (label != uxContractYearLabel)
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

        /// <summary>
        /// Sorts by player name.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxSortLabel_Click(object sender, EventArgs e)
        {
            ResetAllLabels(sender as Control);
            SetLabel(sender as Control);
            FilterPlayers();
        }

        #endregion
    }
}
