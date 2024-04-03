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
    public partial class SanPham : Form
    {
        public SanPham()
        {
            InitializeComponent();
        }
        private void getData()
        {
            //Lấy dữ liệu, hiển thị lên GridView
            string query = "select * from SanPham";
            DataSet ds = new DataSet();
            Ketnoi cn = new Ketnoi();
            ds = cn.laydulieu(query, "SanPham");
            dgvSP.DataSource = ds.Tables["SanPham"];
        }
        private void SanPham_Load(object sender, EventArgs e)
        {
            getData();
        }

        private void btnHeThong_Click(object sender, EventArgs e)
        {
            HeThong frm = new HeThong();
            frm.Show();
            this.Hide();
        }

        private void dgvSP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            if (row >= 0)
            {
                txtMa.Text = dgvSP.Rows[row].Cells["MaSP"].Value.ToString();
                txtTenSP.Text = dgvSP.Rows[row].Cells["TenSP"].Value.ToString();
                txtGia.Text = dgvSP.Rows[row].Cells["GiaBan"].Value.ToString();
                txtMoTa.Text = dgvSP.Rows[row].Cells["MaCL"].Value.ToString();
                txtSoluong.Text = dgvSP.Rows[row].Cells["SoLuong"].Value.ToString();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string ma = txtMa.Text;
            string ten = txtTenSP.Text;
            string mt = txtMoTa.Text;
            string gia = txtGia.Text;
            string sl = txtSoluong.Text;

            string query = "insert into SanPham(MaSP, TenSP,MaCL,GiaBan,Soluong) values(N'" + ma + "',N'" + ten + "',N'" + mt + "',N'" + gia + "',N'" + sl + "')";
            
            Ketnoi kn = new Ketnoi();
            bool kt = kn.ThucThi(query);
            if (kt == true)
            {
                MessageBox.Show("Thêm Thành công!!");
                getData();
                txtGia.Text = "";
                txtMa.Text = "";
                txtMoTa.Text = "";
                txtTenSP.Text = "";
                txtSoluong.Text="";
                txtTim.Text = "";
            }
            else
            {
                MessageBox.Show("Thêm Thất bại!!");
            }
        }
    

        private void btnSua_Click(object sender, EventArgs e)
        {
            string ma = txtMa.Text;
            string ten = txtTenSP.Text;
            string mt = txtMoTa.Text;
            string gia = txtGia.Text;
            string sl = txtSoluong.Text;

            string query = "update SanPham set TenSP=N'" + ten + "', GiaBan=N'" + gia + "',MaCL=N'" + mt + "',Soluong=N'" + sl + "' where MaSP=N'" + ma + "'";
            Ketnoi kn = new Ketnoi();
            bool kt = kn.ThucThi(query);
            if (kt == true)
            {
                MessageBox.Show("Cập nhật Thành công!!");
                getData();
                txtGia.Text = "";
                txtMa.Text = "";
                txtMoTa.Text = "";
                txtTenSP.Text = "";
                txtTim.Text = "";
            }
            else
            {
                MessageBox.Show("Cập nhật Thất bại!!");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string ma = txtMa.Text;
            string ten = txtTenSP.Text;
            string mt = txtMoTa.Text;
            string gia = txtGia.Text;
            string sl = txtSoluong.Text;


            string query = "delete from SanPham where MaSP = N'" + ma + "'";

            Ketnoi kn = new Ketnoi();
            bool kt = kn.ThucThi(query);
            if (kt == true)
            {
                MessageBox.Show("Xóa Thành công!!");
                txtGia.Text = "";
                txtMa.Text = "";
                txtMoTa.Text = "";
                txtTenSP.Text = "";
                txtSoluong.Text = "";
                txtTim.Text = "";
                getData();
            }
            else
            {
                MessageBox.Show("Xóa Thất bại!!");
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtGia.Text = "";
            txtMa.Text = "";
            txtMoTa.Text = "";
            txtTenSP.Text = "";
            txtSoluong.Text = "";
            txtTim.Text = "";
            getData();
        }

        private void btnTK_Click(object sender, EventArgs e)
        {
            string tk = txtTim.Text;

            string query = "select* from SanPham  where TenSP like N'%" + tk + "%' or MaSP like N'%" + tk + "%'" +
                "or GiaBan like N'%" + tk + "%' ";
            

            Ketnoi kn = new Ketnoi();
            DataSet ds = kn.laydulieu(query, "SanPham");

            dgvSP.DataSource = ds.Tables["SanPham"];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hoa_Don frm = new Hoa_Don();
            frm.Show();
        }

        private void cmbMaLoai_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
