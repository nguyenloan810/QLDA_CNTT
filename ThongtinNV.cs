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
    public partial class ThongtinNV : Form
    {
        public ThongtinNV()
        {
            InitializeComponent();
        }
        private void getData()
        {
            //Lấy dữ liệu, hiển thị lên GridView
            string query = "select * from NhanVien";
            DataSet ds = new DataSet();
            Ketnoi cn = new Ketnoi();
            ds = cn.laydulieu(query, "NhanVien");
            dgvNV.DataSource = ds.Tables["NhanVien"];
        }
        private void ThongtinNV_Load(object sender, EventArgs e)
        {
            getData();
           
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {
            getData();
        }

        private void btnThem_Click_1(object sender, EventArgs e)
        {
            string mnv = txtMa.Text;
            string tnv = txtTen.Text;
            string sdt = txtSDT.Text;
            string dc = txtDiaChi.Text;
            DateTime ns = txtNgaySinh.Value;
            string query = "insert into NhanVien(MaNV,TenNV,DienThoai,DiaChi,NgaySinh) values(N'" + mnv + "',N'" + tnv + "',N'" + sdt + "',N'" + dc + "','"+ ns + "' )";

            Ketnoi kn = new Ketnoi();
            bool kt = kn.ThucThi(query);
            if (kt == true)
            {
                MessageBox.Show("Thêm Thành công!!");
                getData();
                txtTen.Text = "";
                txtMa.Text = "";
                txtNgaySinh.Text = "";
                txtSDT.Text = "";
                txtDiaChi.Text = "";
                txtTim.Text = "";
            }
            else
            {
                MessageBox.Show("Thêm Thất bại!!");
            }
        }

        private void btnSua_Click_1(object sender, EventArgs e)
        {
            string mnv = txtMa.Text;
            string tnv = txtTen.Text;
            DateTime ns = txtNgaySinh.Value;
            string sdt = txtSDT.Text;
            string dc = txtDiaChi.Text;


            string query = @"update NhanVien set TenNV=N'" + tnv + "',NgaySinh=N'" + ns+ "',DiaChi=N'" + dc + "',DienThoai=N'" + sdt + "'"+
                "where MaNV=N'" + mnv + "'";

            Ketnoi kn = new Ketnoi();
            bool kt = kn.ThucThi(query);
            if (kt == true)
            {
                MessageBox.Show("Cập nhật Thành công!!");
                getData();
                txtTen.Text = "";
                txtMa.Text = "";
                txtNgaySinh.Text = "";
                txtSDT.Text = "";
                txtTim.Text = "";
            }
            else
            {
                MessageBox.Show("Cập nhật Thất bại!!");
            }
        }

        private void btnXoa_Click_1(object sender, EventArgs e)
        {
            string mnv = txtMa.Text;
            string tnv = txtTen.Text;
            string dc = txtNgaySinh.Text;
            string sdt = txtSDT.Text;

            string query = "delete from NhanVien where MaNV=N'" + mnv + "'";

            Ketnoi kn = new Ketnoi();
            bool kt = kn.ThucThi(query);
            if (kt == true)
            {
                MessageBox.Show("Xóa Thành công!!");
                txtTen.Text = "";
                txtMa.Text = "";
                txtNgaySinh.Text = "";
                txtSDT.Text = "";
                txtDiaChi.Text = "";
                txtTim.Text = "";
                getData();
            }
            else
            {
                MessageBox.Show("Xóa Thất bại!!");
            }
        }

        private void btnLamMoi_Click_1(object sender, EventArgs e)
        {

            txtTen.Text = "";
            txtMa.Text = "";
            txtNgaySinh.Text = "";
            txtSDT.Text = "";
            txtDiaChi.Text = "";
            txtTim.Text = "";
            getData();
        }

        private void btnHeThong_Click_1(object sender, EventArgs e)
        {
            HeThong frm = new HeThong();
            frm.Show();
            this.Hide();
        }

        private void dgvNV_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            if (row >= 0)
            {
                txtTen.Text = dgvNV.Rows[row].Cells["TenNV"].Value.ToString();
                txtMa.Text = dgvNV.Rows[row].Cells["MaNV"].Value.ToString();
                txtNgaySinh.Text = dgvNV.Rows[row].Cells["NgaySinh"].Value.ToString();
                txtSDT.Text = dgvNV.Rows[row].Cells["DienThoai"].Value.ToString();
                txtDiaChi.Text = dgvNV.Rows[row].Cells["DiaChi"].Value.ToString();
            }
        }

        private void btnTK_Click_1(object sender, EventArgs e)
        {
            string tk = txtTim.Text;

            string query = "select* from NhanVien  where TenNV like N'%" + tk + "%' or MaNV like N'%" + tk + "%' ";

            Ketnoi kn = new Ketnoi();
            DataSet ds = kn.laydulieu(query, "NhanVien");

            dgvNV.DataSource = ds.Tables["NhanVien"];
        }
    }
       
}
