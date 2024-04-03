using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.Office.Interop.Excel;
using app = Microsoft.Office.Interop.Excel.Application;

namespace QLCHMyPham
{
    public partial class Hoa_Don : Form
    {
        public Hoa_Don()
        {
            InitializeComponent();
        }


        private void excel(DataGridView g, string duongdan, string tenfile)
        {
            app obj = new app();
            obj.Application.Workbooks.Add(Type.Missing);
            obj.Columns.ColumnWidth = 25;
            for(int i=1; i<g.Columns.Count +1; i++)
            {
                obj.Cells[1,i] = g.Columns[i-1].HeaderText;
            }
            for(int i=0; i < g.Rows.Count; i++)
            {
                for(int j=0; j < g.Columns.Count; j++)
                {
                    if(g.Rows[i].Cells[j].Value != null)
                    {
                        obj.Cells[i+2,j+1] = g.Rows[i].Cells[j].Value.ToString();
                    }
                    
                }
            }
            obj.ActiveWorkbook.SaveCopyAs(duongdan + tenfile + ".xlsx");
            obj.ActiveWorkbook.Saved = true;
        }

        
        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("In hóa đơn thành công!!");
            excel(dgvTK, @"D:\cnpm\", "Xuất HD có mã bằng '"+cmbTK.SelectedValue.ToString() +"'");

        }

        private void button4_Click(object sender, EventArgs e)
        {
            //string tk = txtTK.Text;
            string tk = cmbTK.SelectedValue.ToString();

            string query = @"select CTHoaDon.MaHD, TenKH, TenSP, CTHoaDon.SoLuong, GiaBan as DonGia, TenNV,NgayBan, ThanhTien=GiaBan*SoLuong
            from SanPham, NhanVien, KhachHang, HoaDon,CTHoaDon 
            where SanPham.MaSP=CTHoaDon.MaSP and   HoaDon.MaKH=KhachHang.MaKH 
            and HoaDon.MaHD=CTHoaDon.MaHD and  HoaDon.MaNV = NhanVien.MaNV 
            and CTHoaDon.MaHD= '"+tk+"'";

            Ketnoi kn = new Ketnoi();
            DataSet ds = kn.laydulieu(query, "HoaDon");

            dgvTK.DataSource = ds.Tables["HoaDon"];


            int tong = 0;
            for (int i = 0; i < dgvTK.Rows.Count - 1; i++)
            {
                getDataHoaDon();
                getDataCTHoaDon();

                tong = tong + int.Parse(dgvTK.Rows[i].Cells[7].Value.ToString());

            }

            txtTongTien.Text = tong.ToString();
        }
        private void Hoa_Don_Load(object sender, EventArgs e)
        {
            getDataHoaDon();
            getDataCTHoaDon();
            getKH();
            getNV();
            getSP();

            getMahd();
           
            
        }

        private void getMahd()
        {
            //Lấy dữ liệu, hiển thị lên GridView
            string query = "select * from HoaDon";
            DataSet ds = new DataSet();
            Ketnoi cn = new Ketnoi();
            ds = cn.laydulieu(query, "HoaDon");
            cmbTK.DataSource = ds.Tables["HoaDon"];
            cmbTK.DisplayMember = "MaHDBan";
            cmbTK.ValueMember = "MaHDBan";

        }

        private void getDataHoaDon()
        {
            //Lấy dữ liệu, hiển thị lên GridView
            string query = "select * from HoaDon";
            DataSet ds = new DataSet();
            Ketnoi cn = new Ketnoi();
            ds = cn.laydulieu(query, "HoaDon");
            dgvHoaDon.DataSource = ds.Tables["HoaDon"];

        }

        private void getDataCTHoaDon()
        {
            //Lấy dữ liệu, hiển thị lên GridView
            string query = "select MaCTHD,MaHD,SanPham.MaSP,SoLuong,NgayBan, SoLuong*GiaBan as TongTien from CTHoaDon,SanPham where CTHoaDon.MaSP=SanPham.MaSP";
            DataSet ds = new DataSet();
            Ketnoi cn = new Ketnoi();
            ds = cn.laydulieu(query, "CTHoaDon");
            dgvCTHoaDon.DataSource = ds.Tables["CTHoaDon"];

        }


        private void getKH()
        {
            //Lấy dữ liệu, hiển thị lên GridView
            string query = "select * from KhachHang";
            DataSet ds = new DataSet();
            Ketnoi cn = new Ketnoi();
            ds = cn.laydulieu(query, "KhachHang");
            cmbKhachHang.DataSource = ds.Tables["KhachHang"];
            cmbKhachHang.DisplayMember = "TenKH";
            cmbKhachHang.ValueMember = "MaKH";

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
            cmbNhanVien.DataSource = ds.Tables["NhanVien"];
            cmbNhanVien.DisplayMember = "TenNV";
            cmbNhanVien.ValueMember = "MaNV";

        }

        private void dgvHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            if (row >= 0)
            {
                txtmaHD.Text = dgvHoaDon.Rows[row].Cells["MaHD"].Value.ToString();
                cmbKhachHang.SelectedValue = dgvHoaDon.Rows[row].Cells["MaKH"].Value.ToString();
                cmbNhanVien.SelectedValue = dgvHoaDon.Rows[row].Cells["MaNV"].Value.ToString();
               
            }
        }

        private void dgvCTHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            if (row >= 0)
            {
                txtMaCTHD.Text = dgvCTHoaDon.Rows[row].Cells["MaCTHD"].Value.ToString();
                txtmaHD.Text = dgvCTHoaDon.Rows[row].Cells["MaHD"].Value.ToString();
                cmbSanPham.SelectedValue = dgvCTHoaDon.Rows[row].Cells["MaSP"].Value.ToString();
                txtSoLuong.Text = dgvCTHoaDon.Rows[row].Cells["SoLuong"].Value.ToString();
                dateTimePicker1.Text = dgvCTHoaDon.Rows[row].Cells["NgayBan"].Value.ToString();
                txtTongTien.Text = dgvCTHoaDon.Rows[row].Cells["TongTien"].Value.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string hd = txtmaHD.Text;
            string kh = cmbKhachHang.SelectedValue.ToString();
            string nv = cmbNhanVien.SelectedValue.ToString();

            string query = "insert into HoaDon(MaHD, MaKH,MaNV) values(N'" + hd + "',N'" + kh + "',N'" + nv + "')";

            Ketnoi kn = new Ketnoi();
            bool kt = kn.ThucThi(query);
            if (kt == true)
            {
                MessageBox.Show("Thêm Hóa Đơn Thành công!!");
                getDataHoaDon();
               
            }
            else
            {
                MessageBox.Show("Thêm Hóa Đơn Thất bại!!");
            }
        }

        

        private void hệThốngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HeThongNV f = new HeThongNV();
            f.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string cthd = txtMaCTHD.Text;
            string hd = txtmaHD.Text;
            string sp = cmbSanPham.SelectedValue.ToString();
            int sl = int.Parse(txtSoLuong.Text);
            DateTime ngay = dateTimePicker1.Value;
           
            string query = @"insert into CTHoaDon(MaCTHD,MaHD, MaSP,SoLuong,NgayBan) 
                        values(N'" + cthd + "',N'" + hd + "',N'" + sp + "',N'" + sl + "','" + ngay + "')";
            Ketnoi kn = new Ketnoi();
         
            
            bool kt = kn.ThucThi(query);
            if (kt == true)
            {
                MessageBox.Show("Thêm Sản phẩm Thành công!!");

                getDataCTHoaDon();

            }
            else
            {
                MessageBox.Show("Thêm Sản phẩm Thất bại!!");
            }

         
        }

        private void btnNhapMoi_Click(object sender, EventArgs e)
        {
            txtMaCTHD.Text = "";
            txtmaHD.Text = "";
            txtSoLuong.Text = "";
            //txtTK.Text = "";
            txtTongTien.Text = "";
            getDataCTHoaDon();
            getDataHoaDon();
            dgvTK.DataSource = "";
        }

        private void kháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            KhachHang f = new KhachHang();
            f.Show();
            this.Close();
        }

        private void btnHethong_Click(object sender, EventArgs e)
        {
            HeThong f = new HeThong();
            f.Show();
            this.Hide();
        }

        private void dgvCTHoaDon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
