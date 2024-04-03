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
    public partial class QLTaiKhoan : Form
    {
        public QLTaiKhoan()
        {
            InitializeComponent();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtCV.Text = "";
            txtMK.Text = "";
            txtTK.Text = "";

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string cv = txtCV.Text;
            string mk = txtMK.Text;
            string tk = txtTK.Text;

            string query = "insert into NguoiDung(TaiKhoan, MatKhau,ChucVu) " +
                "values(N'" + tk + "',N'" + mk + "',N'" + cv + "')";

            Ketnoi kn = new Ketnoi();
            bool kt = kn.ThucThi(query);
            if (kt == true)
            {
                MessageBox.Show("Thêm Thành công!!");
                getData();
                txtCV.Text = "";
                txtMK.Text = "";
                txtTK.Text = "";
            }
            else
            {
                MessageBox.Show("Thêm Thất bại!!");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string cv = txtCV.Text;
            string mk = txtMK.Text;
            string tk = txtTK.Text;

            string query = "update NguoiDung set MatKhau = '"+mk+"', ChucVu = '"+cv+"' where TaiKhoan ='"+tk+"'";

            Ketnoi kn = new Ketnoi();
            bool kt = kn.ThucThi(query);
            if (kt == true)
            {
                MessageBox.Show("Sửa Thành công!!");
                getData();
                txtCV.Text = "";
                txtMK.Text = "";
                txtTK.Text = "";
            }
            else
            {
                MessageBox.Show("Sửa Thất bại!!");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string cv = txtCV.Text;
            string mk = txtMK.Text;
            string tk = txtTK.Text;

            string query = "delete from NguoiDung where TaiKhoan = '"+ tk +"'";

            Ketnoi kn = new Ketnoi();
            bool kt = kn.ThucThi(query);
            if (kt == true)
            {
                MessageBox.Show("Xóa Thành công!!");
                getData();
                txtCV.Text = "";
                txtMK.Text = "";
                txtTK.Text = "";
            }
            else
            {
                MessageBox.Show("Xóa Thất bại!!");
            }
        }

        private void dgvTK_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            if (row >= 0)
            {
                txtTK.Text = dgvTK.Rows[row].Cells["TaiKhoan"].Value.ToString();
                txtCV.Text = dgvTK.Rows[row].Cells["ChucVu"].Value.ToString();
                txtMK.Text = dgvTK.Rows[row].Cells["MatKhau"].Value.ToString();
                
            }
        }
        private void getData()
        {
            //Lấy dữ liệu, hiển thị lên GridView
            string query = "select * from NguoiDung";
            DataSet ds = new DataSet();
            Ketnoi cn = new Ketnoi();
            ds = cn.laydulieu(query, "NguoiDung");
            dgvTK.DataSource = ds.Tables["NguoiDung"];
        }

        private void QLTaiKhoan_Load(object sender, EventArgs e)
        {
            getData();
        }

        private void hệThốngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HeThong f = new HeThong();
            f.Show();
            this.Hide();
        }
    }
}
