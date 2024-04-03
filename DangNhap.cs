using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLCHMyPham
{
    public partial class DangNhap : Form
    {
        public DangNhap()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            
            string TaiKhoan = txtTaikhoan.Text;            
            string MatKhau = txtMatkhau.Text;            
            string select_query = $@"select Count(*) as soluong from nguoidung where TaiKhoan ='{TaiKhoan}' 
                                                   and MatKhau = '{MatKhau}' and ChucVu=N'Quản lý' ";
            Ketnoi kn = new Ketnoi();
            DataSet ds = kn.laydulieu(select_query, "nguoidung");
            //ktra sluong tra ve co =1 k
            if ((int)ds.Tables["nguoidung"].Rows[0].ItemArray[0] == 1)
            {
                MessageBox.Show("Đăng nhập thành công");
                HeThong frm = new HeThong();
                frm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Đăng nhập thất bại");
            }

        }

      

      
        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void DangNhap_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có thật sự muốn thoát chương trình?", "Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }

        }


        private void button1_Click(object sender, EventArgs e)
        {
            string TaiKhoan = txtTaikhoan.Text;

            string MatKhau = txtMatkhau.Text;

            string select_query = $@"select Count(*) as soluong from NguoiDung where TaiKhoan ='{TaiKhoan}' 
                                                    and MatKhau = '{MatKhau}' and ChucVu=N'Nhân viên' ";
            Ketnoi kn = new Ketnoi();
            DataSet ds = kn.laydulieu(select_query, "NguoiDung");
            //ktra sluong tra ve co =1 k
            if ((int)ds.Tables["NguoiDung"].Rows[0].ItemArray[0] == 1)
            {
                MessageBox.Show("Đăng nhập thành công");
                HeThongNV frm = new HeThongNV();
                frm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Đăng nhập thất bại");
            }
        }

        private void DangNhap_Load(object sender, EventArgs e)
        {

        }
    }
}
