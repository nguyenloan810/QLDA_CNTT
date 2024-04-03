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
    public partial class PhieuNhap : Form
    {
        public PhieuNhap()
        {
            InitializeComponent();
        }

        private void PhieuNhap_Load(object sender, EventArgs e)
        {
            getData();
            getNCC();
            getNV();
            getSP();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            HeThong f = new HeThong();
            f.Show();
            this.Hide();
        }
        private void getData()
        {
            //Lấy dữ liệu, hiển thị lên GridView
            string query = "select * from PhieuNhap";
            DataSet ds = new DataSet();
            Ketnoi cn = new Ketnoi();
            ds = cn.laydulieu(query, "PhieuNhap");
            dgvThongtinPhieuNhap.DataSource = ds.Tables["PhieuNhap"];

        }

        private void getSP()
        {
            //Lấy dữ liệu, hiển thị lên GridView
            string query = "select * from SanPham";
            DataSet ds = new DataSet();
            Ketnoi cn = new Ketnoi();
            ds = cn.laydulieu(query, "SanPham");
            cmbSanPham.DataSource = ds.Tables["SanPham"];
            cmbSanPham.DisplayMember = "TenSP";
            cmbSanPham.ValueMember = "MaSP";

        }
        private void getNV()
        {
            //Lấy dữ liệu, hiển thị lên GridView
            string query = "select * from NhanVien";
            DataSet ds = new DataSet();
            Ketnoi cn = new Ketnoi();
            ds = cn.laydulieu(query, "NhanVien");
            cmbNV.DataSource = ds.Tables["NhanVien"];
            cmbNV.DisplayMember = "TenNV";
            cmbNV.ValueMember = "MaNV";

        }
        private void getNCC()
        {
            //Lấy dữ liệu, hiển thị lên GridView
            string query = "select * from NhaCungCap";
            DataSet ds = new DataSet();
            Ketnoi cn = new Ketnoi();
            ds = cn.laydulieu(query, "NhaCungCap");
            cmbNCC.DataSource = ds.Tables["NhaCungCap"];
            cmbNCC.DisplayMember = "TenNCC";
            cmbNCC.ValueMember = "MaNCC";

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string ma = txtMaPhieu.Text;
            string sl = txtSoLuong.Text;
            string mancc = cmbNCC.SelectedValue.ToString();
            string manv = cmbNV.SelectedValue.ToString();
            string masp = cmbSanPham.SelectedValue.ToString();
            DateTime ngay = dateTimeNgayNhap.Value;

            string query = "insert into PhieuNhap(MaPhieuNhap, NgayNhap,MaNCC,MaNV,MaSP,SoLuong) values(N'" + ma + "','" + ngay + "',N'" + mancc + "',N'" + manv + "',N'" + masp + "','" + sl + "')";

            Ketnoi kn = new Ketnoi();
            bool kt = kn.ThucThi(query);
            if (kt == true)
            {
                MessageBox.Show("Thêm phiếu nhập Thành công!!");
                getData();
                txtMaPhieu.Text = "";
                txtSoLuong.Text = "";
                txtTKnhaphang.Text = "";
            }
            else
            {
                MessageBox.Show("Thêm phiếu nhập Thất bại!!");
            }
        }

        private void btnNhapMoi_Click(object sender, EventArgs e)
        {
            txtMaPhieu.Text = "";
            txtSoLuong.Text = "";
            txtTKnhaphang.Text = "";

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string ma = txtMaPhieu.Text;
            string sl = txtSoLuong.Text;
            string mancc = cmbNCC.SelectedValue.ToString();
            string manv = cmbNV.SelectedValue.ToString();
            string masp = cmbSanPham.SelectedValue.ToString();
            DateTime ngay = dateTimeNgayNhap.Value;

            string query = "update PhieuNhap set SoLuong=N'" + sl + "'  where MaPhieuNhap=N'" + ma + "'";
            Ketnoi kn = new Ketnoi();
            bool kt = kn.ThucThi(query);
            if (kt == true)
            {
                MessageBox.Show("Cập nhật Thành công!!");
                getData();
                txtMaPhieu.Text = "";
                txtSoLuong.Text = "";
            }
            else
            {
                MessageBox.Show("Cập nhật Thất bại!!");
            }
        }

        private void btnTK_Click(object sender, EventArgs e)
        {
            string ma = txtTKnhaphang.Text;


            string query = "select* from PhieuNhap  where MaPhieuNhap like N'%" + ma + "%'";

            Ketnoi kn = new Ketnoi();
            DataSet ds = kn.laydulieu(query, "PhieuNhap");

            dgvThongtinPhieuNhap.DataSource = ds.Tables["PhieuNhap"];
        }     

        private void dgvThongtinPhieuNhap_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dgvThongtinPhieuNhap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            if (row >= 0)
            {
                txtMaPhieu.Text = dgvThongtinPhieuNhap.Rows[row].Cells["MaPhieuNhap"].Value.ToString();
                txtSoLuong.Text = dgvThongtinPhieuNhap.Rows[row].Cells["SoLuong"].Value.ToString();
                cmbSanPham.SelectedValue = dgvThongtinPhieuNhap.Rows[row].Cells["MaSP"].Value.ToString();
                cmbNV.SelectedValue = dgvThongtinPhieuNhap.Rows[row].Cells["MaNV"].Value.ToString();
                cmbNCC.SelectedValue = dgvThongtinPhieuNhap.Rows[row].Cells["MaNCC"].Value.ToString();
                dateTimeNgayNhap.Text = dgvThongtinPhieuNhap.Rows[row].Cells["NgayNhap"].Value.ToString();
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string ma = txtMaPhieu.Text;
            string sl = txtSoLuong.Text;
            string mancc = cmbNCC.SelectedValue.ToString();
            string manv = cmbNV.SelectedValue.ToString();
            string masp = cmbSanPham.SelectedValue.ToString();


            string query = "delete from PhieuNhap where MaPhieuNhap=N'" + ma + "'";

            Ketnoi kn = new Ketnoi();
            bool kt = kn.ThucThi(query);
            if (kt == true)
            {
                MessageBox.Show("Xóa Thành công!!");
                txtMaPhieu.Text = "";
                txtSoLuong.Text = "";

                getData();
            }
            else
            {
                MessageBox.Show("Xóa Thất bại!!");
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
