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
    public partial class WebsiteInformation : Form
    {
        public string PlayerURL { get; private set; }

        public string SalaryURL { get; private set; }

        public string LeagueURL { get; private set; }

        public string RosterURL { get; private set; }
        
        /// <summary>
        /// Initialize the form.
        /// </summary>
        public WebsiteInformation()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Autofills the website URL information.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxAutofill_Click(object sender, EventArgs e)
        {
            //2019 Information
            uxPlayerURL.Text = "https://www54.myfantasyleague.com/2019/export?TYPE=players&DETAILS=&SINCE=&PLAYERS=&JSON=1";
            uxSalaryURL.Text = "https://www54.myfantasyleague.com/2019/export?TYPE=salaries&L=30916&APIKEY=&JSON=1";
            uxLeagueURL.Text = "https://www54.myfantasyleague.com/2019/export?TYPE=league&L=30916&APIKEY=&JSON=1";
            uxRosterURL.Text = "https://www54.myfantasyleague.com/2019/export?TYPE=rosters&L=30916&APIKEY=&FRANCHISE=&JSON=0";
        }
        /// <summary>
        /// Submits the URL information within the form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxSubmit_Click(object sender, EventArgs e)
        {
            PlayerURL = uxPlayerURL.Text;
            SalaryURL = uxSalaryURL.Text;
            LeagueURL = uxLeagueURL.Text;
            RosterURL = uxRosterURL.Text;
        }
    }
}
