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
    public partial class ThongKe : Form
    {

        //ClassKetnoi ketnoi1 = new ClassKetnoi();
        public ThongKe()
        {
            InitializeComponent();
        }

        private void hệThốngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HeThong frm = new HeThong();
            frm.Show();
            this.Hide();
        }

        private void ThongKe_Load(object sender, EventArgs e)
        {
            //ketnoi1.ketnoi();
            Hienthi();
            
            
        }
        public void Hienthi()
        {
            string sql = @"select HoaDon.MaHD, TenKH,NgaySinh,KhachHang.SDT, TenSP, SoLuong, GiaBan as DonGia, TenNV,NgayBan, ThanhTien=GiaBan*SoLuong
                            from SanPham, NhanVien, KhachHang, HoaDon, CTHoaDon
                            where SanPham.MaSP = CTHoaDon.MaSP and
                            HoaDon.MaKH = KhachHang.MaKH and
                            HoaDon.MaHD = CTHoaDon.MaHD and
                               HoaDon.MaNV = NhanVien.MaNV; ";
           
            Ketnoi kn = new Ketnoi();
            DataSet ds = kn.laydulieu(sql, "HoaDon");
            dsdoanhthu.DataSource = ds.Tables["HoaDon"];

            int tong = 0;
            int soluongsp = 0;
            int sodon = 0;

            for (int i = 0; i < dsdoanhthu.Rows.Count - 1; i++)
            {

                tong = tong + int.Parse(dsdoanhthu.Rows[i].Cells[9].Value.ToString());
                soluongsp = soluongsp + int.Parse(dsdoanhthu.Rows[i].Cells[5].Value.ToString());
                sodon = sodon + 1;

            }

            //txtDoanhThu.Text = tong.ToString();
            labelDoanhThu.Text = tong.ToString();
            //txtSLSP.Text = soluongsp.ToString();
            labelSanPham.Text = soluongsp.ToString();
            labelDonHang.Text = sodon.ToString();
        }

       

        private void btnTongtn_Click(object sender, EventArgs e)
        {

            try
            {
                //ketnoi1.ketnoi();
                if (txtTtt.Text.Length != 0)
                {
                  
                  string query = @"select  CTHoaDon.MaHD, TenKH, TenSP, CTHoaDon.SoLuong, GiaBan as DonGia, TenNV,NgayBan, ThanhTien=GiaBan*SoLuong
                        from SanPham, NhanVien, KhachHang, HoaDon,CTHoaDon 
                        where SanPham.MaSP=CTHoaDon.MaSP and   HoaDon.MaKH=KhachHang.MaKH 
                        and HoaDon.MaHD=CTHoaDon.MaHD and  HoaDon.MaNV = NhanVien.MaNV 
                        and MONTH(NgayBan) = '" + txtTtt.Text + "' and YEAR(NgayBan) = '" + txtTtt2.Text + "'";

                    Ketnoi kn = new Ketnoi();
                    DataSet ds = kn.laydulieu(query, "HoaDon");
                    dsdoanhthu.DataSource = ds.Tables["HoaDon"];

                    int tong = 0;
                    int soluongsp=0;
                    int sodon = 0;
                    
                    for (int i = 0; i < dsdoanhthu.Rows.Count - 1; i++)
                    {
                        
                        tong = tong + int.Parse(dsdoanhthu.Rows[i].Cells[7].Value.ToString());
                        soluongsp = soluongsp + int.Parse(dsdoanhthu.Rows[i].Cells[3].Value.ToString());
                        sodon = sodon + 1;

                    }

                    //txtDoanhThu.Text = tong.ToString();
                    labelDoanhThu.Text = tong.ToString();
                    //txtSLSP.Text = soluongsp.ToString();
                    labelSanPham.Text = soluongsp.ToString();
                    labelDonHang.Text = sodon.ToString();

                }
            }
            catch
            {
                MessageBox.Show("Xem tổng doanh thu tháng thất bại!");
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Hienthi();
            txtTtt.Text = "";
            txtTtt2.Text = "";
           
        }

       private void excel(DataGridView g, string duongdan, string tenfile)
        {
            app obj = new app();
            obj.Application.Workbooks.Add(Type.Missing);
            obj.Columns.ColumnWidth = 25;
            for (int i = 1; i < g.Columns.Count + 1; i++)
            {
                obj.Cells[1, i] = g.Columns[i - 1].HeaderText;
            }
            for (int i = 0; i < g.Rows.Count; i++)
            {
                for (int j = 0; j < g.Columns.Count; j++)
                {
                    if (g.Rows[i].Cells[j].Value != null)
                    {
                        obj.Cells[i + 2, j + 1] = g.Rows[i].Cells[j].Value.ToString();
                    }

                }
            }
            obj.ActiveWorkbook.SaveCopyAs(duongdan + tenfile + ".xlsx");
            obj.ActiveWorkbook.Saved = true;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Xuất file thành công!!");
            excel(dsdoanhthu, @"D:\cnpm\", @"Doanh_thu_thang_"+txtTtt.Text+" nam "+txtTtt2.Text+"");

        }

        private void txtSLSP_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void dsdoanhthu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnHeThong_Click(object sender, EventArgs e)
        {
            HeThong frm = new HeThong();
            frm.Show();
            this.Hide();
        }
    }
}
