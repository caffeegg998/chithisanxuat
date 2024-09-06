using MaterialSkin.Controls;
using ProductionDirectives.Forms.User_Controls;
using ProductionDirectives.Models;
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
        private readonly IChithisanxuatService _ichiThiSanXuat;
        public static NguoiDung _nguoiDung;
        public MainForm(Func<IChithisanxuatService, QuanLyChiThi> chiThiSanXuatFactory, IChithisanxuatService ichiThiSanXuat)
        {
            InitializeComponent();

            _chiThiSanXuatFactory = chiThiSanXuatFactory;
            _ichiThiSanXuat = ichiThiSanXuat;

            Login userControl1 = new Login();
            Dashboard dashboard = new Dashboard(ichiThiSanXuat);
            dashboard.Dock = DockStyle.Fill;
            userControl1.Dock = DockStyle.Fill;
            tabPage1.Controls.Add(dashboard);

            ChiThiSanXuat chiThiSanXuat = new ChiThiSanXuat(ichiThiSanXuat);
            chiThiSanXuat.Dock = DockStyle.Fill;

            QuanLyChiThi quanLyChiThi = _chiThiSanXuatFactory(ichiThiSanXuat);
            quanLyChiThi.Dock = DockStyle.Fill;
            quanLyChiThi.Margin = new Padding(0, 0, 0, 0);

            QuanLyNguoiDung quanLyNguoiDung = new QuanLyNguoiDung(ichiThiSanXuat);
            quanLyNguoiDung.Dock = DockStyle.Fill;

            tbLayOutQuanLyChiThi.Controls.Add(quanLyChiThi, 0, 1);
            tabPage2.Controls.Add(chiThiSanXuat);
            tabPage4.Controls.Add(quanLyNguoiDung);

            materialLabel1.Click += materialLabel1_Click;

        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void materialLabel2_Click(object sender, EventArgs e)
        {
            MaterialMessageBox.Show("Chưa có tài khoản thì liên hệ IT nó tạo cho :)", "Thông báo!");
        }

        private void materialLabel1_Click(object sender, EventArgs e)
        {
            LoginForm login = new LoginForm(_ichiThiSanXuat);
            DialogResult result = login.ShowDialog();

            if (result == DialogResult.OK)
            {
                NguoiDung nguoiDung = login._nguoiDung;
                _nguoiDung = nguoiDung;
                materialLabel1.Click -= materialLabel1_Click;
                loadUser();
            }
            else if (result == DialogResult.Cancel)
            {

                MessageBox.Show("Đăng nhập không thành công hoặc đã bị hủy.");
                // Application.Exit(); // Nếu bạn muốn đóng ứng dụng khi đăng nhập không thành công
            }

        }
        private void loadUser()
        {
            if (_nguoiDung != null)
            {
                materialLabel1.Text = _nguoiDung.First + " " + _nguoiDung.Last;
                materialLabel2.Text = _nguoiDung.Section;
            }
            
        }
    }
}
