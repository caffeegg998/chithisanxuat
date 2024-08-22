using MaterialSkin.Controls;
using ProductionDirectives.Forms.User_Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProductionDirectives.Forms
{
    public partial class MainForm : MaterialForm
    {
        public MainForm()
        {
            InitializeComponent();

            Login userControl1 = new Login();
            Dashboard dashboard = new Dashboard();
            dashboard.Dock = DockStyle.Fill;
            userControl1.Dock = DockStyle.Fill;
            tabPage1.Controls.Add(dashboard);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
