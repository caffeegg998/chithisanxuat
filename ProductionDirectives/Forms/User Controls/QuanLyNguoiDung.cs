using MaterialSkin.Controls;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BCrypt.Net;
using ProductionDirectives.Utils;
using ProductionDirectives.Models;
using ProductionDirectives.Services.Interfaces;

namespace ProductionDirectives.Forms.User_Controls
{
    public partial class QuanLyNguoiDung : UserControl
    {
        IChithisanxuatService _chiThiSanXuat;
        public QuanLyNguoiDung(IChithisanxuatService ichiThiSanXuat)
        {
            InitializeComponent();
            _chiThiSanXuat = ichiThiSanXuat;
        }

        private void materialButton7_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();

            dialog.ShowDialog();

            string filePath = dialog.FileName;
            DataTable dt = docFileChiThi_Template(filePath);



            string[] columns = new string[] { "Code", "First", "Last", "Section", "Grade" };
            string[] sections = new string[] { "QA", "SMT", "PIP" };
            DataTable result = SelectAndFilterColumnsWithDataView(dt, columns, sections);

            dgvChiThi_Template.DataSource = result;
            dgvChiThi_Template.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;


        }
        public DataTable docFileChiThi_Template(string filePath)
        {
            DataTable dt = new DataTable();
            try
            {
                ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.Commercial;

                using (var package = new ExcelPackage(new FileInfo(filePath)))
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets[1];

                    // Đọc header từ dòng thứ 3
                    int columnLimit = 37;
                    int headerRow = 1;
                    int columnCount = 0;
                    foreach (var headerCell in worksheet.Cells[headerRow, 1, headerRow, columnLimit])
                    {
                        columnCount++;
                        if (dt.Columns.Contains(headerCell.Text))
                        {
                            dt.Columns.Add($"{headerCell.Text}{columnCount}", typeof(string));
                        }
                        else
                        {
                            dt.Columns.Add(headerCell.Text);
                        }
                    }

                    // Đọc data từ dòng thứ 4
                    for (int rowNum = headerRow + 1; rowNum <= 3000; rowNum++)
                    {
                        var wsRow = worksheet.Cells[rowNum, 1, rowNum, columnLimit];
                        DataRow row = dt.Rows.Add();
                        foreach (var cell in wsRow)
                        {
                            row[cell.Start.Column - 1] = cell.Text;
                        }
                    }
                }
                return dt;
            }
            catch
            {
                return null;
            }
        }

        public DataTable SelectColumns(DataTable sourceTable, params string[] columnNames)
        {
            DataTable resultTable = new DataTable();

            // Thêm các cột được chọn vào DataTable mới
            foreach (string columnName in columnNames)
            {
                if (sourceTable.Columns.Contains(columnName))
                {
                    resultTable.Columns.Add(columnName, sourceTable.Columns[columnName].DataType);
                }
            }

            // Thêm dữ liệu vào các cột được chọn
            foreach (DataRow row in sourceTable.Rows)
            {
                DataRow newRow = resultTable.NewRow();
                foreach (DataColumn column in resultTable.Columns)
                {
                    newRow[column.ColumnName] = row[column.ColumnName];
                }
                resultTable.Rows.Add(newRow);
            }

            return resultTable;
        }

        public DataTable SelectAndFilterColumnsWithDataView(DataTable sourceTable, string[] columnNames, string[] sectionValues)
        {
            // Đầu tiên, chọn các cột
            DataTable selectedTable = new DataTable();
            foreach (string columnName in columnNames)
            {
                if (sourceTable.Columns.Contains(columnName))
                {
                    selectedTable.Columns.Add(columnName, sourceTable.Columns[columnName].DataType);
                }
            }
            foreach (DataRow sourceRow in sourceTable.Rows)
            {
                DataRow newRow = selectedTable.NewRow();
                foreach (DataColumn column in selectedTable.Columns)
                {
                    newRow[column.ColumnName] = sourceRow[column.ColumnName];
                }
                selectedTable.Rows.Add(newRow);
            }

            // Tạo một DataView từ DataTable đã chọn
            DataView view = new DataView(selectedTable);

            // Áp dụng bộ lọc với LIKE
            string filter = string.Join(" OR ", sectionValues.Select(value => $"Section LIKE '%{value}%'"));
            view.RowFilter = filter;

            // Chuyển DataView thành DataTable
            return view.ToTable();
        }

        private void materialButton8_Click(object sender, EventArgs e)
        {
            List<NguoiDung> nguoiDungs = new List<NguoiDung>();
            int i = dgvChiThi_Template.Rows.Count;
            foreach (DataGridViewRow row in dgvChiThi_Template.Rows)
            {
                string code = row.Cells["Code"].Value.ToString();
                string pass = code;
                string first = row.Cells["First"].Value.ToString();
                string last = row.Cells["Last"].Value.ToString();
                string section = row.Cells["Section"].Value.ToString();
                string grade = row.Cells["Grade"].Value.ToString();

                NguoiDung nguoiDung = new NguoiDung
                {
                    Code = code,
                    Password = PasswordHasher.HashPassword(code),
                    First = first,
                    Last = last,
                    Section = section,
                    Grade = grade
                };

                nguoiDungs.Add(nguoiDung);

                
            }

            //PasswordHasher.HashPassword(code);
            _chiThiSanXuat.ImportListUser(nguoiDungs);
        }
    }

}


