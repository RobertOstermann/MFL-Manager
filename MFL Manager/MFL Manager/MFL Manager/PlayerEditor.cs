using System;
using System.Windows.Forms;
using MFL_Manager.Models.CustomResponeses;

namespace MFL_Manager
{
    public partial class PlayerEditor : Form
    {
        public PlayerDto Player { get; }

        /// <summary>
        /// Initailize the Component.
        /// Create player is selected.
        /// </summary>
        public PlayerEditor()
        {
            InitializeComponent();
            uxID.Enabled = true;
            Player = new PlayerDto();
        }
        /// <summary>
        /// Initialize the Component.
        /// Edit player is selected.
        /// </summary>
        /// <param name="player"></param>
        public PlayerEditor(PlayerDto player)
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
            if (uxPenguins.Checked) return 2;
            if (uxBombers.Checked) return 3;
            if (uxDactyls.Checked) return 4;
            if (uxOdbs.Checked) return 5;
            if (uxStormDynasty.Checked) return 6;
            if (uxNikeStorm.Checked) return 7;
            if (uxGorillas.Checked) return 8;
            if (uxPower.Checked) return 9;
            return uxRam.Checked ? 10 : 0;
        }

        /// <summary>
        /// Determines the position of the check boxes.
        /// </summary>
        /// <returns></returns>
        private string SubmitPosition()
        {
            if (uxQuarterbacks.Checked) return "Quarterback";
            if (uxRunningBacks.Checked) return "Running Back";
            if (uxReceivers.Checked) return "Wide Receiver";
            if (uxTightEnd.Checked) return "Tight End";
            if (uxKicker.Checked) return "Kicker";
            return uxDefense.Checked ? "Defense" : "Not Available";
        }

        /// <summary>
        /// Updates the values within the form.
        /// </summary>
        private void UpdateValues()
        {
            uxPlayerName.Text = Player.Name;
            uxID.Value = Player.Id;
            uxSalary.Value = Convert.ToDecimal(Player.Salary);
            uxContractYear.Text = Player.ContractYear;
            uxAge.Value = Player.Age;
            UpdatePosition();
            UpdateTeam();
        }

        /// <summary>
        /// Updates the position check boxes.
        /// </summary>
        private void UpdatePosition()
        {
            if (Player.Position != null)
            {
                switch (Player.Position[0])
                {
                    case 'Q':
                        uxQuarterbacks.Checked = true;
                        break;
                    case 'R':
                        uxRunningBacks.Checked = true;
                        break;
                    case 'W':
                        uxReceivers.Checked = true;
                        break;
                    case 'T':
                        uxTightEnd.Checked = true;
                        break;
                    case 'K':
                        uxKicker.Checked = true;
                        break;
                    case 'D':
                        uxDefense.Checked = true;
                        break;
                    default:
                        uxNoPosition.Checked = true;
                        break;
                }
            }
        }

        /// <summary>
        /// Updates the team check boxes.
        /// </summary>
        private void UpdateTeam()
        {
            switch (Player.MFLTeamID)
            {
                case 1:
                    uxTornados.Checked = true;
                    break;
                case 2:
                    uxPenguins.Checked = true;
                    break;
                case 3:
                    uxBombers.Checked = true;
                    break;
                case 4:
                    uxDactyls.Checked = true;
                    break;
                case 5:
                    uxOdbs.Checked = true;
                    break;
                case 6:
                    uxStormDynasty.Checked = true;
                    break;
                case 7:
                    uxNikeStorm.Checked = true;
                    break;
                case 8:
                    uxGorillas.Checked = true;
                    break;
                case 9:
                    uxPower.Checked = true;
                    break;
                case 10:
                    uxRam.Checked = true;
                    break;
                default:
                    uxNoTeam.Checked = true;
                    break;
            }
        }
    }
}
