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
    public partial class HeThong : Form
    {
        public HeThong()
        {
            InitializeComponent();
        }

      
        private void btnTTNV_Click(object sender, EventArgs e)
        {
            ThongtinNV frm = new ThongtinNV(); frm.Show();
            this.Hide();
        }

        private void btnTTKH_Click(object sender, EventArgs e)
        {
            KhachHang frm = new KhachHang();
            frm.Show();
            
        }

        private void btnTTSP_Click(object sender, EventArgs e)
        {
            SanPham frm = new SanPham(); frm.Show();
           
        }

        private void btnHD_Click(object sender, EventArgs e)
        {
            Hoa_Don frm = new Hoa_Don(); 
            frm.Show();
           
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            ThongKe frm = new ThongKe(); frm.Show();
            this.Hide();
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            Application.Exit();
            //this.Hide();
            DangNhap frm = new DangNhap();
            frm.Show();
        }
       

        private void HeThong_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn đăng xuất?", "Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }

        }

        private void btnPhieuNhap_Click(object sender, EventArgs e)
        {
            PhieuNhap frm = new PhieuNhap();
            frm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GioiThieu frm = new GioiThieu();
            frm.Show();
            this.Hide();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            QLTaiKhoan frm = new QLTaiKhoan();
            frm.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
