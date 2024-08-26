using MaterialSkin.Controls;
using ProductionDirectives.Forms.User_Controls;
using ProductionDirectives.Repository.Interfaces;
using ProductionDirectives.Services.Interfaces;
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
        private readonly Func<IChithisanxuatService, QuanLyChiThi> _chiThiSanXuatFactory;
        public MainForm(Func<IChithisanxuatService, QuanLyChiThi> chiThiSanXuatFactory, IChithisanxuatService ichiThiSanXuat)
        {
            InitializeComponent();

            _chiThiSanXuatFactory = chiThiSanXuatFactory;

            Login userControl1 = new Login();
            Dashboard dashboard = new Dashboard();
            dashboard.Dock = DockStyle.Fill;
            userControl1.Dock = DockStyle.Fill;
            tabPage1.Controls.Add(dashboard);

            ChiThiSanXuat chiThiSanXuat = new ChiThiSanXuat();
            chiThiSanXuat.Dock = DockStyle.Fill;

            QuanLyChiThi quanLyChiThi = _chiThiSanXuatFactory(ichiThiSanXuat);
            quanLyChiThi.Dock = DockStyle.Fill;

            tabPage3.Controls.Add(quanLyChiThi);
            tabPage2.Controls.Add(chiThiSanXuat);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
