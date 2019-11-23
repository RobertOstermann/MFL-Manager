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
    public partial class PlayerEditor : Form
    {
        public PlayerInfo Player { get; private set; }

        /// <summary>
        /// Initailize the Component.
        /// Create player is selected.
        /// </summary>
        public PlayerEditor()
        {
            InitializeComponent();
            uxID.Enabled = true;
            Player = new PlayerInfo();
        }
        /// <summary>
        /// Initialize the Component.
        /// Edit player is selected.
        /// </summary>
        /// <param name="player"></param>
        public PlayerEditor(PlayerInfo player)
        {
            InitializeComponent();
            Player = player;
            UpdateValues();
        }
        /// <summary>
        /// Submits the inforamtion.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxSubmit_Click(object sender, EventArgs e)
        {
            Player.Name = uxPlayerName.Text;
            Player.Id = Convert.ToInt32(uxID.Value);
            Player.Salary = Convert.ToDouble(uxSalary.Value);
            Player.ContractYear = uxContractYear.Text;
            Player.Age = Convert.ToInt32(uxAge.Value);
            Player.Position = SubmitPosition();
            Player.MFLTeamID = SubmitTeam();
        }
        /// <summary>
        /// Determines the team of the check boxes.
        /// </summary>
        /// <returns></returns>
        private int SubmitTeam()
        {
            if (uxTornados.Checked) return 1;
            else if (uxPenguins.Checked) return 2;
            else if (uxBombers.Checked) return 3;
            else if (uxDactyls.Checked) return 4;
            else if (uxOdbs.Checked) return 5;
            else if (uxStormDynasty.Checked) return 6;
            else if (uxNikeStorm.Checked) return 7;
            else if (uxGorillas.Checked) return 8;
            else if (uxPower.Checked) return 9;
            else if (uxRam.Checked) return 10;
            return 0;
        }
        /// <summary>
        /// Determines the position of the check boxes.
        /// </summary>
        /// <returns></returns>
        private char SubmitPosition()
        {
            if (uxQuarterbacks.Checked) return 'q';
            else if (uxRunningBacks.Checked) return 'r';
            else if (uxReceivers.Checked) return 'w';
            else if (uxTightEnd.Checked) return 't';
            else if (uxKicker.Checked) return 'k';
            else if (uxDefense.Checked) return 'd';
            return 'n';
        }
        /// <summary>
        /// Updates the values within the form.
        /// </summary>
        private void UpdateValues()
        {
            uxPlayerName.Text = Player.Name;
            uxID.Value = Player.Id;
            uxSalary.Value = Convert.ToDecimal(Player.Salary);
            uxContractYear.Text = Player.ContractYear.ToString();
            uxAge.Value = Player.Age;
            UpdatePosition();
            UpdateTeam();
        }
        /// <summary>
        /// Updates the position check boxes.
        /// </summary>
        private void UpdatePosition()
        {
            if (Player.Position == 'q')
            {
                uxQuarterbacks.Checked = true;
            }
            else if (Player.Position == 'r')
            {
                uxRunningBacks.Checked = true;
            }
            else if (Player.Position == 'w')
            {
                uxReceivers.Checked = true;
            }
            else if (Player.Position == 't')
            {
                uxTightEnd.Checked = true;
            }
            else if (Player.Position == 'k')
            {
                uxKicker.Checked = true;
            }
            else if (Player.Position == 'd')
            {
                uxDefense.Checked = true;
            }
            else
            {
                uxNoPosition.Checked = true;
            }
        }
        /// <summary>
        /// Updates the team check boxes.
        /// </summary>
        private void UpdateTeam()
        {
            if (Player.MFLTeamID == 1)
            {
                uxTornados.Checked = true;
            }
            else if (Player.MFLTeamID == 2)
            {
                uxPenguins.Checked = true;
            }
            else if (Player.MFLTeamID == 3)
            {
                uxBombers.Checked = true;
            }
            else if (Player.MFLTeamID == 4)
            {
                uxDactyls.Checked = true;
            }
            else if (Player.MFLTeamID == 5)
            {
                uxOdbs.Checked = true;
            }
            else if (Player.MFLTeamID == 6)
            {
                uxStormDynasty.Checked = true;
            }
            else if (Player.MFLTeamID == 7)
            {
                uxNikeStorm.Checked = true;
            }
            else if (Player.MFLTeamID == 8)
            {
                uxGorillas.Checked = true;
            }
            else if (Player.MFLTeamID == 9)
            {
                uxPower.Checked = true;
            }
            else if (Player.MFLTeamID == 10)
            {
                uxRam.Checked = true;
            }
            else
            {
                uxNoTeam.Checked = true;
            }
        }
    }
}
