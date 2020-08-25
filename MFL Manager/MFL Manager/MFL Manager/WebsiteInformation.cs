using System;
using System.Configuration;
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
        public string PlayerUrl { get; private set; }

        public string SalaryUrl { get; private set; }

        public string LeagueUrl { get; private set; }

        public string RosterUrl { get; private set; }

        public string PlayerProfileUrl { get; private set; }
        
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
            uxLeagueURL.Text = @"https://www54.myfantasyleague.com/2020/export?TYPE=league&L=30916&APIKEY=&JSON=1";
            uxPlayerURL.Text = @"https://www54.myfantasyleague.com/2020/export?TYPE=players&L=30916&APIKEY=&DETAILS=&SINCE=&PLAYERS=&JSON=1";
            uxSalaryURL.Text = @"https://www54.myfantasyleague.com/2020/export?TYPE=salaries&L=30916&APIKEY=&JSON=1";
            uxRosterURL.Text = @"https://www54.myfantasyleague.com/2020/export?TYPE=rosters&L=30916&APIKEY=&FRANCHISE=&W=&JSON=1";
            uxPlayerProfileURL.Text = @"https://api.myfantasyleague.com/2020/export?TYPE=playerProfile";
        }
        /// <summary>
        /// Submits the URL information within the form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxSubmit_Click(object sender, EventArgs e)
        {
            PlayerUrl = uxPlayerURL.Text;
            SalaryUrl = uxSalaryURL.Text;
            LeagueUrl = uxLeagueURL.Text;
            RosterUrl = uxRosterURL.Text;
            PlayerProfileUrl = uxPlayerProfileURL.Text;
        }
    }
}
