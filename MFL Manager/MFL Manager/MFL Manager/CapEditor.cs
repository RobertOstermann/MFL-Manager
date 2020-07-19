using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MFL_Manager.Models.CustomResponeses;

namespace MFL_Manager
{
    public partial class CapEditor : Form
    {
        public double CapData { get; private set; }

        /// <summary>
        /// Initializes the component.
        /// </summary>
        public CapEditor()
        {
            InitializeComponent();
            lblCapData.Text = @"Cap Room";
        }
        /// <summary>
        /// Initializes the component.
        /// Sets the cap hit to the team cap hit.
        /// </summary>
        /// <param name="team"></param>
        public CapEditor(FranchiseDto franchise)
        {
            InitializeComponent();
            lblCapData.Text = @"Cap Hit";
            lblTeamName.Text = franchise.Name;
            uxCapHit.Value = Convert.ToDecimal(franchise.CapHit);
        }
        /// <summary>
        /// Submits the information.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxSubmit_Click(object sender, EventArgs e)
        {
            CapData = Convert.ToDouble(uxCapHit.Value); 
        }
    }
}
