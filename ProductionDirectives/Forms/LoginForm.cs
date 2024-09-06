using MaterialSkin.Controls;
using ProductionDirectives.Models;
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
    public partial class LoginForm : MaterialForm
    {
        private readonly IChithisanxuatService _chithisanxuatService;
        public NguoiDung _nguoiDung;
        public LoginForm(IChithisanxuatService chithisanxuatService)
        {
            InitializeComponent();
            _chithisanxuatService = chithisanxuatService;
        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            string code = materialTextBox21.Text;
            string pass = materialTextBox22.Text;
            NguoiDung nguoidung = _chithisanxuatService.GetUserBy_Code_and_Pass(code, pass);
            if(nguoidung != null)
            {
                _nguoiDung = nguoidung;
                DialogResult = DialogResult.OK;
            }
            else
            {
                _nguoiDung = null;
                DialogResult = DialogResult.Cancel;
            }
            this.Close();
        }

        private void LoginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }
    }
}
