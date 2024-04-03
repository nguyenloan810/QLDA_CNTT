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
    public partial class KhachHang : Form
    {
        public KhachHang()
        {
            InitializeComponent();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtMa.Text = "";
            txtTen.Text = "";
            txtDC.Text = "";
            txtSDT.Text = "";
            txtTim.Text = "";
            getData();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string mkh = txtMa.Text;
            string ten = txtTen.Text;
            string dc = txtDC.Text;
            string sdt = txtSDT.Text;


            string query = "insert into KhachHang(MaKH, TenKH,DiaChi,DienThoai) values(N'" + mkh + "', N'" + ten + "',N'" + dc + "',N'" + sdt + "')";

            Ketnoi kn = new Ketnoi();
            bool kt = kn.ThucThi(query);
            if (kt == true)
            {
                MessageBox.Show("Thêm Thành công!!");
                getData();
                txtMa.Text = "";
                txtTen.Text = "";
                txtDC.Text = "";
                txtSDT.Text = "";
                txtTim.Text = "";
            }
            else
            {
                MessageBox.Show("Thêm Thất bại!!");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string mkh = txtMa.Text;
            string ten = txtTen.Text;
            string dc = txtDC.Text;
            string sdt = txtSDT.Text;


            string query = "update KhachHang set TenKH=N'" + ten + "',DienThoai=N'" + sdt + "', DiaChi=N'" + dc + "' where MaKH=N'" + mkh + "'";

            Ketnoi kn = new Ketnoi();
            bool kt = kn.ThucThi(query);
            if (kt == true)
            {
                MessageBox.Show("Sửa Thành công!!");
                getData();
                txtMa.Text = "";
                txtTen.Text = "";
                txtDC.Text = "";
                txtSDT.Text = "";
                txtTim.Text = "";
            }
            else
            {
                MessageBox.Show("Sửa Thất bại!!");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string mkh = txtMa.Text;
            string ten = txtTen.Text;
            string dc = txtDC.Text;
            string sdt = txtSDT.Text;
            string query = "delete from KhachHang where  MaKH=N'" + mkh + "'";

            Ketnoi kn = new Ketnoi();
            bool kt = kn.ThucThi(query);
            if (kt == true)
            {
                MessageBox.Show("Xóa Thành công!!");
                txtMa.Text = "";
                txtTen.Text = "";
                txtDC.Text = "";
                txtSDT.Text = "";
                txtTim.Text = "";
                getData();
            }
            else
            {
                MessageBox.Show("Xóa Thất bại!!");
            }
        }

        private void btnTK_Click(object sender, EventArgs e)
        {
            string tk = txtTim.Text;


            string query = "select* from KhachHang  where TenKH like N'%" + tk + "%' or Dienthoai like N'%" + tk + "%'" ;

            Ketnoi kn = new Ketnoi();
            DataSet ds = kn.laydulieu(query, "KhachHang");

            dgvKhach.DataSource = ds.Tables["KhachHang"];
        }
        private void getData()
        {
            //Lấy dữ liệu, hiển thị lên GridView
            string query = "select * from KhachHang";
            DataSet ds = new DataSet();
            Ketnoi cn = new Ketnoi();
            ds = cn.laydulieu(query, "KhachHang");
            dgvKhach.DataSource = ds.Tables["KhachHang"];
        }
        private void KhachHang_Load(object sender, EventArgs e)
        {
            getData();
        }

        private void btnHeThong_Click(object sender, EventArgs e)
        {
            HeThong frm = new HeThong();
            frm.Show();
            this.Hide();
        }

        private void dgvKhach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            if (row >= 0)
            {
                txtTen.Text = dgvKhach.Rows[row].Cells["TenKH"].Value.ToString();
                txtMa.Text = dgvKhach.Rows[row].Cells["MaKH"].Value.ToString();
                txtDC.Text = dgvKhach.Rows[row].Cells["DiaChi"].Value.ToString();
                txtSDT.Text = dgvKhach.Rows[row].Cells["DienThoai"].Value.ToString();
                
            }
        }

        private void dgvKhach_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnHeThong_Click_1(object sender, EventArgs e)
        {
            HeThong frm = new HeThong();
            frm.Show();
            this.Hide();
        }
    }
}
